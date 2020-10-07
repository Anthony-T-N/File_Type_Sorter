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
            main_program.create_ext_folders();
     
        }
        public void read_dir_files()
        {
            // Get the current directory.
            string[] files = Directory.GetFiles(System.AppDomain.CurrentDomain.BaseDirectory);
            List<string> file_list = new List<string>();
            List<string> extension_list = new List<string>();
            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                Console.WriteLine(filename);
                file_list.Add(filename);
                string extension = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                extension_list.Add(extension);
                Console.WriteLine(extension);
            }
        }
        public void create_ext_folders()
        {
            string pathString = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "SubFolder");
            System.IO.Directory.CreateDirectory(pathString);
            Console.WriteLine("DONE");
        }
    }
}
