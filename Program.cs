using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n======MENU======");
                Console.WriteLine("1. Bài 1: In lịch tháng");
                Console.WriteLine("2. Bài 2: Liệt kê thư mục và tập tin");
                Console.WriteLine("3. Bài 3: Ma trận ");
                Console.WriteLine("4. Bài 4: Phân số");
                Console.WriteLine("5. Bài 5: Quản lý bất động sản");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Bai1.Run();
                        break;
                    case 2:
                        Bai2.Run();
                        break;
                    case 3:
                        Bai3.Run();
                        break;
                    case 4:
                        Bai4.Run();
                        break;
                    case 5:
                        Bai5.Run();
                        break;
                    case 0:
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            } while (choice != 0);
        }
    }
}
