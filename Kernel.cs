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

namespace Cosmosfiles
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
            string s = "﻿loads=load\r\nmain=menus\r\n[system]\r\ninit=loads\r\nmem=48k";
            var fs_type = fs.GetFileSystemType(@"0:\");
            Console.WriteLine("File System Type: " + fs_type);
            var directory_list = Directory.GetFiles(@"0:\");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            File.WriteAllText(@"0:\\my.ini",s);
            s = File.ReadAllText(@"0:\\my.ini");
            Console.WriteLine(s);
            s = Console.ReadLine();

        }
    }
}
