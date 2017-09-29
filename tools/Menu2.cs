using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using Ini;

namespace submenu2
{
    public class menu2
    {

        public void setproject()
        {
            IniFile ini = new IniFile("bin\\settings.ini");
            Console.Clear();
            int i = 0;
            ArrayList Name_folders = new ArrayList();
            Dictionary<int, string> items = new Dictionary<int, string>();

            foreach (string s in Directory.GetDirectories(AppDomain.CurrentDomain.BaseDirectory))
            {
                string fName = s.Remove(0, AppDomain.CurrentDomain.BaseDirectory.Length);
                if (fName.StartsWith("hau-"))
                {
                    Name_folders.Insert(i, fName);
                    items.Add(i, fName);
                    i++;
                    Console.WriteLine(i + ". " + s.Remove(0, AppDomain.CurrentDomain.BaseDirectory.Length));
                    Console.WriteLine("");
                    Console.Write("Chọn dự án :");
                }

            }
            string num_line = Console.ReadLine();
            int num_folder;
            if (int.TryParse(num_line, out num_folder))
            {
                foreach (KeyValuePair<int, string> de in items)
                {
                    if (num_folder == de.Key + 1)
                    {
                        Console.WriteLine("Đã chọn :" + de.Value);
                        ini.IniWriteValue("Config", "Project", de.Value);

                    }
                }

            }
            Console.ReadKey();
        }
    }
}