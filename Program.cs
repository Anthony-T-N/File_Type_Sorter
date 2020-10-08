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
        private List<string> extension_list = new List<string>();
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
            foreach (string file in files)
            {
                string filename = Path.GetFileName(file);
                Console.WriteLine(filename);
                file_list.Add(filename);
                string extension = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                if (!extension_list.Contains(extension))
                {
                    extension_list.Add(extension);
                }
                Console.WriteLine(extension);
            }
        }
        public void create_ext_folders()
        {
            string current_path_string = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Sorted_Extension_Folder");
            if (!System.IO.Directory.Exists(current_path_string))
            {
                System.IO.Directory.CreateDirectory(current_path_string);
                Console.WriteLine("HELLO");
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", current_path_string);
                return;
            }
            for (int i = 0; i <= extension_list.Count - 1; i++)
            {
                System.Console.WriteLine(System.IO.Path.Combine(current_path_string, extension_list[i]));
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(current_path_string, extension_list[i]));
            }
            Console.WriteLine("DONE");
        }
    }
}
