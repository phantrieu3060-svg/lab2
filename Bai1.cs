using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Bai1
    {   
        public static void Run()
        {
            int month = Nhap("Nhập vào tháng (1->12): ");
            int year = Nhap("Nhập vào năm (1->9999): ");
            int days = DayOfMonth(month, year);
            int start = DayOfWeek(month, year);
            Print(start, days);
        }
        static int Nhap(string message)
        {
            int n;
            if (message == "Nhập vào tháng (1->12): ")
                do
                {
                    Console.Write(message);
                } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > 12);
            else
                do
                {
                    Console.Write(message);
                } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n >= 10000);
            return n;
        }
        // Kiểm tra năm nhuận 
        static bool IsLeapYear(int y)
        {
            return (y % 4 == 0 && y % 100 != 0) || y % 400 == 0;
        }
        // Kiểm tra tính hợp lệ của ngày tháng năm 
        static int DayOfMonth(int m, int y)
        {

            switch (m)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    if (!IsLeapYear(y)) return 28;
                    return 29;
            }

        }
        // Xác định thứ dựa trên thuật toán Sakamoto 
        static int DayOfWeek(int m, int y)
        {
            int d = 1;
            int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
            if (m < 3) y--;
            int r = (y + y / 4 - y / 100 + y / 400 + t[m - 1] + d) % 7;
            return r;
        }
        static void Print(int start, int day)
        {
            Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");
            for (int i = 0; i < start; i++)
                Console.Write("\t");
            for (int i = 1; i <= day; i++)
            {
                Console.Write($"{i}\t");
                if ((i + start) % 7 == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
