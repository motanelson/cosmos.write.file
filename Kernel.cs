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
            string s = "; --- Hello World & Math in JASM ---\r\n.class public HelloWorld\r\n.super java/lang/Object\r\n\r\n.method public static main : ()V\r\n   .limit stack 4\r\n   .limit locals 2\r\n\r\n   getstatic java/lang/System/out Ljava/io/PrintStream;\r\n   ldc \"Hello from Java Virtual Machine!\"\r\n   invokevirtual java/io/PrintStream/println(Ljava/lang/String;)V\r\n\r\n   ; Compute (15 * 3) + 7\r\n   bipush 15\r\n   iconst_3\r\n   imul\r\n   bipush 7\r\n   iadd\r\n   istore_1\r\n\r\n   getstatic java/lang/System/out Ljava/io/PrintStream;\r\n   ldc \"Calculation Result (15 * 3 + 7):\"\r\n   invokevirtual java/io/PrintStream/println(Ljava/lang/String;)V\r\n\r\n   getstatic java/lang/System/out Ljava/io/PrintStream;\r\n   iload_1\r\n   invokevirtual java/io/PrintStream/println(I)V\r\n\r\n   return\r\n.end method";
            var fs_type = fs.GetFileSystemType(@"0:\");
            Console.WriteLine("File System Type: " + fs_type);
            var directory_list = Directory.GetFiles(@"0:\");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            File.WriteAllText(@"0:\\my.asm",s);
            s = File.ReadAllText(@"0:\\my.asm");
            Console.WriteLine(s);
            s = Console.ReadLine();

        }
    }
}
