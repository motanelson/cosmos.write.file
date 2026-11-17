using Cosmos.HAL.BlockDevice.Registers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Text;
using Sys = Cosmos.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Cosmoseditor
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;
        protected override void BeforeRun()
        {
            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        }

        protected override void Run()
        {
            string[] s = { "" };
            while (true) 
            {
                var fs_type = fs.GetFileSystemType(@"0:\");
                Console.WriteLine("File System Type: " + fs_type);
                var directory_list = Directory.GetFiles(@"0:\");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();

                foreach (var file in directory_list)
                {
                    Console.WriteLine(file);
                }
                var available_space = fs.GetAvailableFreeSpace(@"0:\");
                Console.WriteLine("Available Free Space: " + available_space);
                coneditor.Main(s);


            }
        }
    }
    class ceditor
    {
        private static String source = " ";
        public static void saves(String names, String a)
        {
            File.WriteAllText(names, a);


        }
        public static void appends(String a)
        {
            source = source + a;


        }
        public static String gets()
        {
            String a = "";
            a = Console.ReadLine();
            return a;


        }
        public static void editorloop(String names)
        {
            source = "";
            while (true)
            {
                String a = "";
                a = gets();
                appends(a + "\r\n");
                if (a == "") break;
            }
            saves(names, source);

        }
    }


    class coneditor
    {

        public static void Main(String[] args)
        {
            String s = "";

            Console.WriteLine("give a file name to create ? empty line to save and exit ? ");
            s = @"0:\\" + Console.ReadLine();
            ceditor.editorloop(s);
        }



    }



}
