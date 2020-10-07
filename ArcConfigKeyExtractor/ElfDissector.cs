using AlphaOmega.Debug;
using ArcConfigViewer;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArcConfigKeyExtractor
{
    public class ElfDissector
    {
        public string ElfFilePath { get; }

        public ElfDissector(string fileName)
        {
            ElfFilePath = fileName;
        }

        public void ExtractStrings()
        {
            try
            {
                using (var file = new ElfFile(StreamLoader.FromFile(ElfFilePath)))
                {
                    if (file.Header.IsValid)
                    {
                        var strings = new List<string>();

                        foreach (var strSec in file.GetStringSections())
                            foreach (var str in strSec)
                                if (str != null)
                                {
                                    var n = str.Name;
                                    var idx = str.Index;
                                    var e = $"STRING ENTRY: {idx} :: {n}";
                                    strings.Add(e);
                                }
                        File.WriteAllLines(@"strings.log", strings);
                    }
                }
            }
            catch (Exception ex)
            {
                UiMessages.Error(ex.ToString());
            }
        }
    }
}