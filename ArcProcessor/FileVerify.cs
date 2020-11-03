using System;
using System.IO;
using System.Text;

namespace ArcProcessor
{
    public static class FileVerify
    {
        /// <summary>
        /// Reads the ASCII bytes from index 0 to count of the specified fileName.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static char[] ReadChars(string fileName, int count)
        {
            if (!File.Exists(fileName)) return null;

            using (var stream = File.OpenRead(fileName))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                var buffer = new char[count];
                var n = reader.ReadBlock(buffer, 0, count);

                var result = new char[n];

                Array.Copy(buffer, result, n);

                return result;
            }
        }

        /// <summary>
        /// Checks for an SQLite ASCII header in the specified file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsSqlLiteDatabase(string fileName)
        {
            const string searchTerm = @"SQLite format 3";

            return SearchFile(fileName, searchTerm);
        }

        /// <summary>
        /// Checks for a bash generic ASCII header in the specified file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool IsBashScript(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            const string searchTerm = @"#!/bin/sh";

            return ext == @".sh" || SearchFile(fileName, searchTerm);
        }

        /// <summary>
        /// Searches the START of the file for the matching search term; starts at index 0 and reads to searchTerm.Length.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public static bool SearchFile(string fileName, string searchTerm)
        {
            try
            {
                var searchLength = searchTerm.Length;

                var actual = new string(ReadChars(fileName, searchLength));

                if (!string.IsNullOrEmpty(actual))
                    return actual == searchTerm;
            }
            catch
            {
                //nothing
            }

            //default
            return false;
        }
    }
}