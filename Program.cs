using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{

    class Program
    {
        class FileManager
        {
            public DirectoryInfo SomeDirectory { get; private set; }
            public string PathDirectory { get; private set; }
            public FileManager()
            {
                PathDirectory = Environment.CurrentDirectory;
                SomeDirectory = new DirectoryInfo(PathDirectory);
            }

            public void ChangeDirectory()
            {     
                Console.Write(PathDirectory + @"\");
               
                string next = Console.ReadLine();

                PathDirectory = Path.Combine(PathDirectory, next);
                SomeDirectory = new DirectoryInfo(PathDirectory);
            }
            public void CreateDirectory()
            {                
                string name;               
               
                Console.WriteLine("Enter name for directory: ");
                name = Console.ReadLine();
                PathDirectory += "\\" + name;
                if (!new DirectoryInfo(PathDirectory).Exists)
                {                    
                    Directory.CreateDirectory(PathDirectory);
                    Console.WriteLine("Directory has been created");                    
                }
                else
                {                    
                    Console.WriteLine("Directory already exist.");                    
                }
            }
            public void DeleteDirectory()
            {
                int action;
                string path;

                Console.WriteLine("1. Delete current directory");
                Console.WriteLine("2. Another directory");

                action = int.Parse(Console.ReadLine());

                if (action == 1)
                    path = PathDirectory;
                else
                {
                    Console.Write("Enter path to directory you want to delete: ");
                    path = Console.ReadLine();
                }

                if (!new DirectoryInfo(path).Exists)
                {                  
                    Console.WriteLine("Such directory does not exist!");                   
                }
                else
                {
                    Directory.Delete(path, true);
                }
            }

            public void ShowDirectoriesAndFiles()
            {
                Console.WriteLine("--------Directories--------");
                if (SomeDirectory.GetDirectories().Length == 0)
                    Console.WriteLine("This catalog does not exist directories!\n");

                foreach (var d in SomeDirectory.GetDirectories())
                {
                    Console.WriteLine($"Directory: {d.Name}  time:  {d.CreationTime} atr: {d.Attributes}");
                }

                Console.WriteLine();

                Console.WriteLine("--------Files--------");
                if (SomeDirectory.GetFiles().Length == 0)
                    Console.WriteLine("This directory does not exist files!\n");

                foreach (var file in SomeDirectory.GetFiles())
                {
                    Console.WriteLine($"File: {file.Name}  time:  {file.CreationTime} atr: {file.Attributes}");
                }
            }

            public void ShowOnlyDirectories()
            {
                Console.WriteLine("--------Directories--------");
                if(SomeDirectory.GetDirectories().Length==0)
                    Console.WriteLine("This catalog does not exist directories!\n");

                foreach (var d in SomeDirectory.GetDirectories())
                {
                    Console.WriteLine($"Directory: {d.Name}  time:  {d.CreationTime} atr: {d.Attributes}");
                }
                Console.WriteLine();                
            }


            public void DeleteFile()
            {                
                string name;
                
                Console.Write("Enter name of file:");
                name = Console.ReadLine();

                PathDirectory += "\\" + name;

                if (!new FileInfo(PathDirectory).Exists)
                {                   
                    Console.WriteLine("Such file does not exist!");
                   
                }
                else
                {
                    File.Delete(PathDirectory);
                }
            }
            public void ShowFileInfo()
            {
               
                string name;
                
                Console.Write("Enter name of file: ");
                name = Console.ReadLine();

                PathDirectory += "\\" + name;

                if (!new FileInfo(PathDirectory).Exists)
                {                  
                    Console.WriteLine("Such file does not exist!");                   
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(PathDirectory);
                    Console.WriteLine("FileName   : {0}", fileInfo.Name);
                    Console.WriteLine("Ext        : {0}", fileInfo.Extension);
                    Console.WriteLine("Path       : {0}", fileInfo.FullName);
                    Console.WriteLine("Dir        : {0}", fileInfo.Directory);
                    Console.WriteLine("Size(MB)   : {0}", ((fileInfo.Length) / 1024f) / 1024f);
                    Console.WriteLine("Last Access: {0}", fileInfo.LastAccessTime);                             
                }
            }
            public void MoveFile()
            {
                string pathFileExist, pathFileMove;

                Console.Write("Enter path to file: ");
                pathFileExist = Console.ReadLine();

                Console.Write("Enter new path for file: ");
                pathFileMove = Console.ReadLine();

                if (!new FileInfo(pathFileExist).Exists)
                {                  
                    Console.WriteLine("Such file does not exist!");                   
                }
                else
                    File.Move(pathFileExist, pathFileMove);
            }    
            

        }

        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            int action, action2, action3;       

            do
            {
                Console.Clear();

                Console.WriteLine($"You are here: {fileManager.PathDirectory}\n");

                Console.WriteLine("1. Work with directories");
                Console.WriteLine("2. Work with files");
                Console.WriteLine("3. Change directory");
                Console.WriteLine("4. Exit\n");
                Console.Write("Enter action:");

                action = int.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine($"You are here: {fileManager.PathDirectory}\n");

                            Console.WriteLine("1. Create directory");
                            Console.WriteLine("2. Delete with files");
                            Console.WriteLine("3. Show directories and files");
                            Console.WriteLine("4. Show only directories");
                            Console.WriteLine("5. Back to main menu");

                            Console.Write("Enter action:");

                            action2 = int.Parse(Console.ReadLine());
                            switch (action2)
                            {
                                case 1:
                                    fileManager.CreateDirectory();
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    fileManager.DeleteDirectory();
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    fileManager.ShowDirectoriesAndFiles();
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    fileManager.ShowOnlyDirectories();
                                    Console.ReadKey();

                                    break;
                                case 5:
                                    break;
                            }
                            
                        } while (action2 != 5);
                        break;


                    case 2:
                        do
                        {
                            Console.Clear();

                            Console.WriteLine($"You are here: {fileManager.PathDirectory}\n");

                            Console.WriteLine("1. Delete file");
                            Console.WriteLine("2. Move file");                            
                            Console.WriteLine("3. File Info");
                            Console.WriteLine("4. Back to main menu");

                            Console.Write("Enter action:");

                            action3 = int.Parse(Console.ReadLine());
                            switch (action3)
                            {
                                case 1:
                                    fileManager.DeleteFile();
                                    break;
                                case 2:
                                    fileManager.MoveFile();
                                    break;                                
                                case 3:
                                    fileManager.ShowFileInfo();
                                    break;
                                case 4:
                                    break;
                            }
                           
                        } while (action3 != 4);
                        break;

                    case 3:
                        fileManager.ChangeDirectory();
                        break;
                    case 4:                       
                        break;
                    
                }
            } while (action != 4);
        }

    }
}
