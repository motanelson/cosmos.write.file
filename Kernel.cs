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
            string s = "﻿\u0001main/main\u0002main\u0001main/system\u0002system\u0001main/x\u0002xxx\u0001system/main\u0002mene\u0001system/system\u0002main\u0001main/char\u0002#####\u0001";
            var fs_type = fs.GetFileSystemType(@"0:\");
            Console.WriteLine("File System Type: " + fs_type);
            var directory_list = Directory.GetFiles(@"0:\");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            File.WriteAllText(@"0:\\my.dat",s);
            s = File.ReadAllText(@"0:\\my.dat");
            Console.WriteLine(s);
            s = Console.ReadLine();

        }
    }
}
