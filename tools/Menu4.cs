using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Ini;

namespace submenu4
{
    public class menu4
    {
        public void romtool()
        {
            IniFile ini = new IniFile("bin\\settings.ini");
            Console.Clear();
            string setproject = ini.IniReadValue("Config", "Project");
            string FileSystem = setproject + "\\system.img";
            if (File.Exists(FileSystem))
            {
                string answer;

                Console.Write(" Tìm thấy 'system.img' bạn muốn giải nén ? (y/n): ");
                answer = Console.ReadLine();
                if (answer.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                    string path1 = AppDomain.CurrentDomain.BaseDirectory + setproject + "\\";
                    string path3 = (path1 + "system.img " + path1 + "\\systen");
                    Console.WriteLine(" Đang giải nén .img");
                    RunApp("bin\\ImgExtractor.exe", path3);
                }
                else if (answer.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine(" Bạn đã không tiếp tục");
                }
            }
            else
            {

                string[] files = Directory.GetFiles(setproject, "*.zip");
                int i = 0;
                Dictionary<int, string> items = new Dictionary<int, string>();
                if (files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        items.Add(i, fileName);
                        i++;
                        Console.WriteLine(" " + i + ". " + fileName);
                    }
                    Console.WriteLine("");
                    Console.Write(" Chọn ROM : ");
                    string num_line = Console.ReadLine();
                    int num_folder;
                    if (int.TryParse(num_line, out num_folder))
                    {
                        foreach (KeyValuePair<int, string> de in items)
                        {
                            if (num_folder == de.Key + 1)
                            {
                                Console.WriteLine(" Đã chọn :" + de.Value);
                                Console.WriteLine(" Đang giải nén ZIP");
                                string path = (AppDomain.CurrentDomain.BaseDirectory + setproject + "\\" + de.Value);
                                string path1 = AppDomain.CurrentDomain.BaseDirectory + setproject + "\\";
                                string path2 = (path1 + "system.transfer.list " + path1 + "system.new.dat " + path1 + "system.img");
                                string path3 = (path1 + "system.img " + path1 + "\\systen");
                                RunApp("bin\\7za.exe", "x " + path + " -o" + path1 + " -y");
                                if (File.Exists(FileSystem))
                                {
                                    Console.WriteLine(" Đang giải nén .img");
                                    RunApp("bin\\ImgExtractor.exe", path3);
                                }
                                else
                                {
                                    RunApp1("bin\\sdat2img.exe", path2);
                                    Console.WriteLine(" Đang giải nén .img");
                                    RunApp("bin\\ImgExtractor.exe", path3);
                                }
                            }
                        }
                    }
                }
            }
            Console.Clear();
            Console.WriteLine(" Hãy chọn chức năng \n");
            Console.WriteLine(" 1. Deodex ROM");
            Console.WriteLine(" 2. Change perm type");
            Console.WriteLine(" 3. Debloat Menu");
            Console.WriteLine(" 4. Build Menu");
            try
            {
                int menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Đã chọn 1");
                        break;
                    case 2:
                        Console.WriteLine("Đã chọn 2");
                        break;
                    case 3:
                        Console.WriteLine("Đã chọn 3");
                        break;
                    case 4:
                        Console.WriteLine("Đã chọn 4");
                        break;
                    default:
                        Console.WriteLine("Chức năng chưa có");
                        break;
                }
            }
            catch
            {
                Console.WriteLine(" Vui lòng chọn chức năng");
            }
            Console.ReadKey();

        }
        private static void RunApp(string FileName, string Arguments)
        {
            ProcessStartInfo p = new ProcessStartInfo();
            //p.WindowStyle = ProcessWindowStyle.Normal;
            p.CreateNoWindow = true;
            p.UseShellExecute = false;
            p.FileName = FileName;
            p.Arguments = Arguments;
            Process x = Process.Start(p);
            x.WaitForExit();

        }
        private static void RunApp1(string FileName, string Arguments)
        {
            Process p = new Process();
            p.StartInfo.FileName = FileName;
            p.StartInfo.Arguments = Arguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
        }
        private static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (outLine.Data != null)
                Console.WriteLine(" " + outLine.Data.ToString());
        }


    }

}