using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileNameChanger_Console
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var currentDirectory = @"C:\\Users\\Dauris Little\\";
            Console.WriteLine("Current Directory Location : C:\\Users\\Dauris Little");
            ListFilesWithinDirectory(currentDirectory);

            Console.WriteLine("Name change has been successful \n You may now leave the application ");
            Console.ReadKey();
        }

        private static void ChangeFilesNames(string findDirectory, FileInfo[] files)
        {
            //create a preview of the file names
            var fn = 0;
            foreach (var file in files)
            {
                fn++;
                Console.WriteLine($"Current File Name -- {file.Name} changed New File Name -- S07E{fn}");
            }

            var nameChangeStatus = Console.ReadLine();

            if (nameChangeStatus== "Yes")
            {
                fn = 0;
                foreach (var candidate in files)
                {
                    fn++;
                    File.Move(candidate.FullName, candidate.FullName.Replace(candidate.Name, $"S07E{fn}.mkv"));
                }
            }
            else
            {
                Console.WriteLine("Name change has been cancel");
            }
            
        }

        private static void ListFilesWithinDirectory(string findDirectory)
        {
            var userSelectedDirectory = Console.ReadLine();
            var newDirectory = $"{findDirectory}{userSelectedDirectory}\\";
            if (!string.IsNullOrEmpty(userSelectedDirectory))
            {
                var reviewDirectory = new DirectoryInfo($@"{newDirectory}");
                var directories = reviewDirectory.GetDirectories();
                var files = reviewDirectory.GetFiles();
                
                //this will list out the current level directories 
                Console.WriteLine("Current Directories");
                foreach (var directory in directories)
                {
                    
                    Console.WriteLine(directory.Name);
                }
                
                //this will list out the current level of files
                Console.WriteLine("Current Files");
                foreach (var file in files)
                {
                    Console.WriteLine($"{file.Name}");
                }

                //this recycle then
                ListFilesWithinDirectory(newDirectory);

            }
            else
            {
                var reviewDirectory = new DirectoryInfo($@"{newDirectory}");
                var files = reviewDirectory.GetFiles();

                Console.WriteLine("----------Current Files up for renaming----------");
                foreach (var file in files)
                {
                    Console.WriteLine($"{file.Name}");
                }
                Console.WriteLine("----------\n Do you wish to proceed");
                var renameFiles = Console.ReadLine();

                ChangeFilesNames(renameFiles, files);
            }
        }
    }
}
