using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ArcConfigViewer
{
    public static class TreeBuilder
    {
        private static char[] ReadChars(string filename, int count)
        {
            if (!File.Exists(filename)) return null;

            using (var stream = File.OpenRead(filename))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                var buffer = new char[count];
                var n = reader.ReadBlock(buffer, 0, count);

                var result = new char[n];

                Array.Copy(buffer, result, n);

                return result;
            }
        }

        private static bool IsBashScript(string fileName)
        {
            const string searchTerm = @"#!/bin/sh";
            var length = searchTerm.Length;

            var actual = new string(ReadChars(fileName, length));

            if (!string.IsNullOrEmpty(actual))
                return actual == searchTerm;

            //default
            return false;
        }

        public static void BuildTree(DirectoryInfo directoryInfo, TreeNodeCollection addInMe)
        {
            var curNode = addInMe.Add(directoryInfo.Name, directoryInfo.Name, 1, 1); //folder image

            foreach (var file in directoryInfo.GetFiles())
            {
                var name = file.Name;
                var ext = Path.GetExtension(name).ToLower();

                switch (ext)
                {
                    case @".glbcfg":
                    case @".config":
                    case @".conf":
                    case @".dft":
                    case @".ini":
                    case @".settings":
                    case @".fix":
                        curNode.Nodes.Add(file.FullName, name, 2, 2); //config image
                        break;

                    case @".xml":
                    case @".json":
                    case @".csv":
                    case @".yml":
                    case @".yaml":
                    case @".md":
                        curNode.Nodes.Add(file.FullName, name, 4, 4); //metadata image
                        break;

                    case @".snk":
                    case @".pfx":
                    case @".pem":
                        curNode.Nodes.Add(file.FullName, name, 5, 5); //keyfile image
                        break;

                    case @".sqlite":
                    case @".db":
                        curNode.Nodes.Add(file.FullName, name, 3, 3); //database image
                        break;

                    case @".srl":
                    case @".crt":
                        curNode.Nodes.Add(file.FullName, name, 6, 6); //certificate image
                        break;

                    case @".deb":
                    case @".pkg":
                    case @".so":
                        curNode.Nodes.Add(file.FullName, name, 7, 7); //executable image
                        break;

                    case @".sh":
                        curNode.Nodes.Add(file.FullName, name, 8, 8); //script image
                        break;

                    default:
                        if (IsBashScript(file.FullName))
                            curNode.Nodes.Add(file.FullName, name, 8, 8); //script image
                        else
                            curNode.Nodes.Add(file.FullName, name, 0, 0); //file image
                        break;
                }
            }
            foreach (var dir in directoryInfo.GetDirectories())
            {
                BuildTree(dir, curNode.Nodes);
            }
        }
    }
}