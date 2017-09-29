using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace submenu1
{
    public class menu1
    {

        public void creatproject()
        {
            Console.Clear();
            Console.Write("Nhập tên dự án :"); // Prompt
            string path = Console.ReadLine();
            if (Regex.IsMatch(path, "[^A-Za-z_ŠšČčŽžĆćĐđ]"))
            {
                Console.WriteLine("Chứa ký tự không hợp lệ!");
            }
            else
            {
                if (!string.IsNullOrEmpty(path))
                    Directory.CreateDirectory("hau-" + path);
                else
                {
                    Console.WriteLine("Chứa ký tự không hợp lệ!");
                }
                //Console.Write("Đã tạo :");
            }
            //Console.ReadKey();
        }
    }
}