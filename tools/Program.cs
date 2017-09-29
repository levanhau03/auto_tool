using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using Ini;
using submenu1;
using submenu2;
//using submenu3;
using submenu4;
//using submenu5;
using submenu6;

namespace tools
{
    class Program
    {
        static void Main(string[] args)
        {

            SetConsoleFont();
            Console.WindowHeight = 30;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Auto Tool beta 1.0 - coder by Mr.Hau";
            const int maxMenuItems = 7;
            int selector = 0;
            while (selector != maxMenuItems)
            {
            Console.Clear();
            DrawTitle();
            DrawMenu(maxMenuItems);
            string mainmenu = Console.ReadLine();
                int submenu;
                if (int.TryParse(mainmenu, out submenu))
                {
                    if (submenu == 1)
                    {
                        menu1 submenu1 = new menu1();
                        submenu1.creatproject();                        
                    }
                    if (submenu == 2)
                    {
                        menu2 submenu2 = new menu2();
                        submenu2.setproject();                        
                    }
                    if (submenu == 3)
                    {
                    }
                    if (submenu == 4)
                    {
                        menu4 submenu4 = new menu4();
                        submenu4.romtool();
                    }
                    if (submenu == 5)
                    { 
                    }
                    if (submenu == 6)
                    {
                        menu6 submenu6 = new menu6();
                        submenu6.setlang();
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.Write(" Chưa chọn chức năng hoặc chắc năng chưa có !");
                    Console.ReadKey();
                }

        }
        }


        private static void DrawTitle()
        {
            Console.WriteLine(" +¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯+");
            Console.WriteLine(" +\t\t\t\t\t\t\t\t+");            
            Console.WriteLine(" +\t\t  Phần mềm được viết bởi Mr.Hau  \t\t+");
            Console.WriteLine(" +\t\t\t   AUTO TOOL V1.0  \t\t\t+");
            Console.WriteLine(" +\t\t   AUTO TOOL FOR XIAOMI DEVICE  \t\t+");
            Console.WriteLine(" +\t\t\t\t\t\t\t\t+");
            Console.WriteLine("  ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ ");

        }


        private static void DrawMenu(int maxitems)
        {
            IniFile ini = new IniFile("bin\\settings.ini");
            string setlang = ini.IniReadValue("Config", "Language");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Dự án hiện tại: ");
            Console.ForegroundColor = ConsoleColor.White;
            string setproject = ini.IniReadValue("Config", "Project");
            Console.WriteLine(setproject);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Phiên bản Android: ");
            Console.ForegroundColor = ConsoleColor.White;
            string version = (setproject + "\\systen\\build.prop");
            if (File.Exists(version))
            {
                StreamReader file = new StreamReader(version);
                int counter = 0;
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("ro.build.version.release"))
                    {
                        string myString = line;

                        string[] tokens = myString.Split('=');

                        Console.WriteLine(tokens[1]);
                    }

                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Chưa có");
            }
            Console.WriteLine("");
            Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
            Console.WriteLine(" 1. Tạo dự án mới");
            Console.WriteLine(" 2. Chọn dự án");
            Console.WriteLine(" 3. Xóa dự án");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.WriteLine(" 4. Công cụ ROM");
            Console.WriteLine(" 5. Recover/Boot \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");
            Console.Write(" 6. Ngôn ngữ :");
            Console.WriteLine(setlang);
            Console.WriteLine(" 7. Thoát \n");
            Console.Write(" Chọn một chức năng : ");
        }

        private static void SetConsoleFont(string fontName = "")
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            Native.Kernel32.CONSOLE_FONT_INFOEX cfi = Native.Kernel32.GetCurrentConsoleFontEx();
            cfi.FontIndex = 0;
            cfi.FontFamily = 0;
            cfi.FaceName = (fontName != "") ? fontName : "Consolas";
            //cfi.FontWidth = (int)(Height / 2);
            cfi.FontHeight = 16;
            Native.Kernel32.SetCurrentConsoleFontEx(cfi);
        }


    }
}