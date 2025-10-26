using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Bai2
    {   
        public static void Run()
        {
            Console.Write("Nhập vào đường dẫn thư mục: ");
            string path = Console.ReadLine();
            GetDir_and_File(path);
        }
        static void GetDir_and_File(string path)
        {
            if(!Directory.Exists(path))
            {
                Console.WriteLine("Đường dẫn không tồn tại!");
                return;
            }
            string[] listDir = Directory.GetDirectories(path);
            if (listDir.Length == 0)
            {
                Console.WriteLine("Thư mục rỗng!");
                return;
            }
            Console.WriteLine("\r\n\r\n Directory of {0}: \r\n\r\n", path);
            int countfile = 0, countdir = 0;
            long lengt = 0;
            foreach (string dir in listDir)
            {
                countdir++;
                DirectoryInfo dirInfo = new DirectoryInfo(dir);
                Console.WriteLine($"{dirInfo.CreationTime.ToString("dd/MM/yyyy hh:mm tt"),19}\t<DIR>\t\t\t{dirInfo.Name}");
            }
            string[] listfile = Directory.GetFiles(path);
            foreach (string file in listfile)
            {
                countfile++;
                FileInfo fileInfo = new FileInfo(file);
                lengt += fileInfo.Length;
                Console.WriteLine($"{fileInfo.CreationTime.ToString("dd/MM/yyyy hh:mm tt"),19}\t{fileInfo.Length.ToString("N0"),20}\t{fileInfo.Name}");
            }
            Console.WriteLine($"{countfile,15} File(s)    {lengt.ToString("N0")} bytes");
            Console.WriteLine($"{countdir,15} Dir(s)");

        }
    }
}
