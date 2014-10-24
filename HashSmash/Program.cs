using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Theraot.Core;

namespace HashSmash
{
    public static class Program
    {
        const string TAB = "\t";
        const string QUOTE = "\"";

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(@"HashSmash");
                Console.WriteLine(@"Copytight by Alfonso J. Ramos - 2014");
                Console.WriteLine("");
                Console.WriteLine(@"HashSmash scans all files in the directory path,");
                Console.WriteLine(@"for each file, the MD5 is computed and wrote into the result file path.");
                Console.WriteLine(@"The computed MD5 value will be in hexadecimal form using lower caps letters.");
                Console.WriteLine(@"If no result file path is specified, results.txt in the current path is used.");
                Console.WriteLine(@"The output will have the information of each file in a separate line.");
                Console.WriteLine(@"Each line of the output file will have the following form:");
                Console.WriteLine(@"<full path of the file> tab character <computed MD5>");
                Console.WriteLine("");
                Console.WriteLine(@"Usage: HashSmash.exe <directory path> <result file path>");
                Console.WriteLine("");
                Console.WriteLine(@"Examples:");
                Console.WriteLine(@"HashSmash.exe C:\ D:\results.txt");
                Console.WriteLine(@"HashSmash.exe " + QUOTE + @"C:\Program Files" + QUOTE + @" D:\results.txt");
                Console.WriteLine(@"HashSmash.exe D:\Example");
#if DEBUG
                Console.WriteLine(@"[Press a key to exit]");
                Console.ReadKey();
#endif
            }
            else
            {
                var directoryPath = args[0];
                var resultFilePath = "results.txt";
                if (args.Length > 1 && !StringHelper.IsNullOrWhiteSpace(args[1]))
                {
                    resultFilePath = args[1];
                }
                Work(directoryPath, resultFilePath);
                Console.WriteLine(@"[Press a key to exit]");
                Console.ReadKey();
            }
        }

        private static string GetMD5(string file)
        {
            var stringBuilder = new StringBuilder();
            var md5Hasher = MD5.Create();
            using (var fileStream = File.OpenRead(file))
            {
                foreach (byte b in md5Hasher.ComputeHash(fileStream))
                {
                    stringBuilder.Append(b.ToString("x2").ToLowerInvariant());
                }
            }
            return stringBuilder.ToString();
        }

        private static void Work(string directoryPath, string resultFile)
        {
            using (var resultsFile = new StreamWriter(File.OpenWrite(resultFile)))
            {
                foreach (var file in Theraot.Core.FolderEnumeration.GetFilesRecursive(directoryPath, "*"))
                {
                    try
                    {
                        Console.Write(file);
                        var md5Result = GetMD5(file);
                        resultsFile.WriteLine(file + TAB + md5Result);
                        Console.WriteLine(TAB + md5Result);
                    }
                    catch (Exception exception)
                    {
                        Console.Error.WriteLine(TAB + @"error: {0}", exception);
                    }
                }
            }
        }
    }
}