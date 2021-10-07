using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace TxtDif
{
    class Program
    {
        static void Main(string[] args)
        {
            // put directory name here where files to be comapred are placed
            String directoryStr = @"C:\Users\username\Desktop\compare_directory"; 
            // Read file1 and file2 content from the specified directory
            String[] linesFile1 = File.ReadAllLines(Path.Combine(directoryStr, "file1.ext"));
            String[] linesFile2 = File.ReadAllLines(Path.Combine(directoryStr, "file2.ext"));

            // put any string based conditions to select only required lines for comparision // can comment if not required
            linesFile1 = linesFile1.Where(x => x.Contains("ConditionalString1") && x.Contains("ConditionalString2")).ToArray();
            linesFile2 = linesFile2.Where(x => x.Contains("ConditionalString1") && x.Contains("ConditionalString2")).ToArray();

            // sort the file content to compare effectively and efficiently and log result in more readable manner // 
            // can comment if files are very large // performance issue occured
            // write the result log in text files
            File.WriteAllLines(Path.Combine(directoryStr, "ResultFile1.txt"), linesFile1.OrderBy(x => x));
            File.WriteAllLines(Path.Combine(directoryStr, "ResultFile2.txt"), linesFile2.OrderBy(x => x));

            // comparision and result logging in text files
            IEnumerable<String> onlyFIle1Lines = linesFile1.Except(linesFile2);
            File.WriteAllLines(Path.Combine(directoryStr, "ResultOnlyFile1.txt"), onlyFIle1Lines);
            IEnumerable<String> onlyFile2Lines = linesFile2.Except(linesFile1);
            File.WriteAllLines(Path.Combine(directoryStr, "ResultOnlyFile2.txt"), onlyFile2Lines);
        }
    }
}
