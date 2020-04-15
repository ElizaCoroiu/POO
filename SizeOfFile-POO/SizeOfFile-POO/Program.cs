using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SizeOfFile_POO
{
    class Program
    {
        static void Main(string[] args)
        {
            double size = 0;

            foreach (string path in args)
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    size = GetSizeOfFile(path);
                    Console.WriteLine($"Size of file is = {size}");
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    size = GetSizeOfDirectory(path);

                    Console.WriteLine($"Size of directory is = {size}");
                }
                else 
                {
                    Console.WriteLine("{0} is not a valid file or directory", path); 
                }
            }

            Console.ReadKey();
        }

        public static double GetSizeOfDirectory(string targetDirectory)
        {
            // Get the size of the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            double size = 0;

            // Console.WriteLine($"Found {fileEntries.Length} files in directory {targetDirectory}");

            foreach (string fileName in fileEntries)
            {
                size += GetSizeOfFile(fileName);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);

            // Console.WriteLine($"Found {subdirectoryEntries.Length} sub-directories in directory {targetDirectory}");

            foreach (string subdirectory in subdirectoryEntries)
            {
                size += GetSizeOfDirectory(subdirectory);
            }

            return size;
        }

        public static double GetSizeOfFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            return fileInfo.Length;
        }
    }
}
