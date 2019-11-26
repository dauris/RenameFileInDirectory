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
            var directory = new DirectoryInfo(@"C:\Users\Dauris Little\Downloads\Bleach Complete Series + Movies\Season 08; The Arrancar 2; The Fierce Fight");
            var files = directory.GetFiles();

            var fn = 0;
            foreach (FileInfo candidate in files)
            {
                fn++;
                File.Move(candidate.FullName, candidate.FullName.Replace(candidate.Name, $"S07E{fn}.mkv"));
            }

            Console.Read();
            var browser = new FolderBrowserDialog();
            if (browser.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine($"directory : {browser}");
            }
            Console.WriteLine($"file prefix :");

            var location = Console.ReadLine();

            Console.WriteLine($"your location : {location}");
            Console.Read();
        }
    }
}
