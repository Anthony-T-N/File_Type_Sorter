using System;
using System.IO;
using System.Collections.Generic;

/* Approach
 * 1) Select specific folder  
 * 2) Read through and extract all extensions of files of the folder and add to a list.
 * 3) Create new folders based on said extensions.
 * 4) Move files to allocated folders based on extensions.
 */

namespace File_Type_Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Program main_program = new Program();
            main_program.read_dir_files();
     
        }
        public void read_dir_files()
        {
            // Get the current directory.
            string[] files = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory);
            List<string> file_list = new List<string>();
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
                file_list.Add(file);
                string extension = file.Substring(file.LastIndexOf("."), file.Length - 1);
                Console.WriteLine(extension);
            }
        }
    }
}
