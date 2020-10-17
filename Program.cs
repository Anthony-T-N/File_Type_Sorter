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
        private List<string> file_path_list = new List<string>();
        //string target_location = System.AppDomain.CurrentDomain.BaseDirectory;
        string target_location = Directory.GetCurrentDirectory() + @"\Target_Test_Folder";
        //string target_location = @"C:\Users\Anthony\source\repos\File_Type_Sorter\bin\Debug\netcoreapp3.1\Target_Test_Folder\";
        static void Main(string[] args)
        {
            Program main_program = new Program();

            Console.WriteLine("=========================================================================");
            Console.WriteLine("Welcome to the 'File Type Sorter'");
            Console.WriteLine("How to use: ");
            Console.WriteLine("1) Ensure the executable displays the directory (Target Directory) that you wish for files to be sorted.");
            Console.WriteLine("2) The program will read through all the files located in the target directory and compile a list.");
            Console.WriteLine("3) A new folder will be created containing every folder named after all the file extensions read from the previous sessesion.");
            Console.WriteLine("4) Files from the current directory will move to the newly created folder and be sorted accordingly.");
            Console.WriteLine("=========================================================================");
            bool user_input_flag = false;
            while (true)
            {
                if (user_input_flag == true)
                {
                    break;
                }
                Console.WriteLine("Target Directory: " + main_program.target_location);
                Console.WriteLine(" ");
                Console.WriteLine("Confirm to move files within the target location [Y/N]: ");
                string directory_confirmation = Console.ReadLine();
                if (directory_confirmation.ToLower() == "n")
                {
                    while (true)
                    {
                        Console.WriteLine("Please enter new target Directory: ");
                        main_program.target_location = Console.ReadLine();
                        if (main_program.target_location.EndsWith(@"\"))
                        {
                            main_program.target_location = main_program.target_location.Substring(0, main_program.target_location.Length - 1);
                            Console.WriteLine(@"[=] Removed \ from end of string");
                        }
                        if (Directory.Exists(main_program.target_location) == false)
                        {
                            Console.WriteLine("[-] Invalid directory");
                        }
                        else
                        {
                            Console.WriteLine("[+] Valid directory");
                            user_input_flag = true;
                            break;
                        }
                    }
                }
                else if (directory_confirmation.ToLower() == "y")
                {
                    user_input_flag = true;
                }
                else
                {
                    Console.WriteLine("[-] Invalid key");
                    Console.WriteLine("Please try again");
                }
            }
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Reading directory files:");
            main_program.read_dir_files();
            Console.WriteLine(" ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Creating folders based on extensions:");
            main_program.create_ext_folders();
            Console.WriteLine(" ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("Moving files to allocated folders:");
            main_program.move_files();
            Console.WriteLine(" ");
            Console.WriteLine("=========================================================================");
        }
        public void read_dir_files()
        {
            Console.WriteLine(target_location);
            string[] files = Directory.GetFiles(target_location);
            foreach (string file in files)
            {
                file_path_list.Add(file);
                string filename = Path.GetFileName(file);
                Console.WriteLine(filename);
                string extension = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                if (!extension_list.Contains(extension))
                {
                    extension_list.Add(extension);
                    Console.WriteLine("[+] " + extension);
                }
            }
        }
        public void create_ext_folders()
        {
            string current_path_string = System.IO.Path.Combine(target_location, "Sorted_Extension_Folder");
            if (!System.IO.Directory.Exists(current_path_string))
            {
                System.IO.Directory.CreateDirectory(current_path_string);
                Console.WriteLine("[+] Creating \"{0}\"", current_path_string);
            }
            else
            {
                Console.WriteLine("[-] Folder \"{0}\" already exists.", current_path_string);
                Console.WriteLine("Exiting application");
                return;
            }
            for (int i = 0; i <= extension_list.Count - 1; i++)
            {
                Console.WriteLine(System.IO.Path.Combine(current_path_string, extension_list[i]));
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(current_path_string, extension_list[i]));
            }
        }
        public void move_files()
        {
            for (int i = 0; i <= file_path_list.Count - 1; i++)
            {
                string filename = Path.GetFileName(file_path_list[i]);
                Console.WriteLine("Filename: " + filename);
                string extension = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                Console.WriteLine(target_location + @"\Sorted_Extension_Folder\" + extension + @"\" + filename);
                //File.Move(file_path_list[i], target_location + @"\Sorted_Extension_Folder\" + extension + @"\" + filename);
                //Console.WriteLine("[+] {0} \n was moved to \n {1}. \n", file_path_list[i], target_location + @"\Sorted_Extension_Folder\" + extension);
                Console.WriteLine(" ");
                Console.WriteLine(file_path_list[i]);
                Console.WriteLine("was moved to");
                Console.WriteLine(target_location + @"\Sorted_Extension_Folder\" + extension);
                Console.WriteLine(" ");
            }
        }
    }
}

