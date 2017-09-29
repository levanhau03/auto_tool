using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Ini;

namespace submenu6
{
    public class menu6
    {

        public void setlang()
        {
            Console.Clear();
            
            string setlang = AppDomain.CurrentDomain.BaseDirectory + "\\bin";
            string[] files = Directory.GetFiles(setlang, "*.lng");
            int i = 0;
            Dictionary<int, string> items = new Dictionary<int, string>();
            if (files.Length > 0)
            {
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    items.Add(i, fileName);
                    i++;
                    //Console.WriteLine(" " + i + ". " + fileName);
                    IniFile ini = new IniFile("bin\\" + fileName);
                    string defaultlang = ini.IniReadValue("Language", "Defaultlang");
                    Console.WriteLine(" " + i + ". " + defaultlang);
                }
                Console.WriteLine("");
                Console.Write(" Chọn ngôn ngữ : ");
                string num_line = Console.ReadLine();
                int num_folder;
                if (int.TryParse(num_line, out num_folder))
                {
                    foreach (KeyValuePair<int, string> de in items)
                    {
                        if (num_folder == de.Key + 1)
                        {
                            Console.WriteLine(" Đã chọn :" + de.Value);

                        }
                    }
                }
            }

            //Console.WriteLine(" Hãy chọn \"ngôn ngữ\" \n");
            //Console.WriteLine(" 1. English");
            //Console.WriteLine(" 2. Tiếng việt");
            //try
            //{
            //    int menu = int.Parse(Console.ReadLine());
            //    switch (menu)
            //    {
            //        case 1:
            //            Console.WriteLine("Selected \"English\" \n");
            //            ini.IniWriteValue("Config", "Language", "en");
            //            break;
            //        case 2:
            //            Console.WriteLine("Đã chọn \"Tiếng việt\" \n");
            //            ini.IniWriteValue("Config", "Language", "vn");
            //            break;
            //        default:
            //            Console.WriteLine("Chức năng chưa có");
            //            break;
            //    }

            //}
            //catch
            //{
            //    Console.WriteLine("Vui lòng chọn chức năng");
            //}
            Console.ReadKey();
        }
    }
}