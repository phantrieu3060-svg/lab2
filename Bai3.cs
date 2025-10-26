using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Bai3
    {
        public static void Run()
        {
            int n = Input("Nhập số dòng của ma trận: ");
            int m = Input("Nhập số cột của ma trận: ");
            Console.WriteLine("Nhập các phần tử của ma trận: ");
            int[,] matrix = InputMatrix(n, m);
            int choice;
            do
            {
                Console.WriteLine("\n======MENU BAI 3======");
                Console.WriteLine("1. In ma trận");
                Console.WriteLine("2. In các phần tử là số nguyên tố trong ma trận");
                Console.WriteLine("3. Tìm kiếm phần tử trong ma trận");
                Console.WriteLine("4. Tìm dòng chứa nhiều số nguyên tố nhất");
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
                        PrintMatix(matrix);
                        break;
                    case 2:
                        PrintIfPrime(matrix);
                        break;
                    case 3:
                        int value = Input("Nhập phần tử cần tìm kiếm trong ma trận: ");
                        KeyValuePair<int, int> idx = FindValue(matrix, value);
                        if (idx.Key != -1 && idx.Value != -1)
                            Console.WriteLine($"Phần tử {value} tìm thấy tại vị trí dòng {idx.Key }, cột {idx.Value }");
                        else
                            Console.WriteLine($"Phần tử {value} không tồn tại trong ma trận.");
                        break;
                    case 4:
                        int row = RowMostPrime(matrix);
                        if (row != -1)
                            Console.WriteLine("Dòng chứa nhiều số nguyên tố nhất là dòng: " +row );
                        else
                            Console.WriteLine("Không có dòng nào chứa số nguyên tố.");
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
        // Nhập số nguyên dương
        static int Input(string message)
        {
            int n;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }
        // Đọc số nguyên 
        static int ReadIntegers()
        {
            int n;
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("Giá trị nhập vào không hợp lệ. Vui lòng nhập lại một số nguyên.");
            }
            return n;
        }
        // Nhập ma trận
        static int[,] InputMatrix(int n, int m)
        {
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = ReadIntegers();
            return a;
        }
      
        //In ma trận
        static void PrintMatix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
        }
        // Kiểm tra số nguyên tố
        static bool IsPrime(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0) return false;
            return true;
        }
        // Tìm kiếm phần tử
        static KeyValuePair<int, int> FindValue(int[,] matrix, int n)
        {
            KeyValuePair<int, int>? idx = null;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (matrix[i, j] == n)
                    {
                        idx = new KeyValuePair<int, int>(i, j);
                    }

            return idx ?? new KeyValuePair<int, int>(-1, -1);
        }
        // In phần tử là số nguyên tố
        static void PrintIfPrime(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (IsPrime(matrix[i, j])) Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
        // Tìm dòng chứa nhiều số nguyên tố nhất
        static int RowMostPrime(int[,] matrix)
        {
            int row = -1;
            int max = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (IsPrime(matrix[i, j])) count++;
                if (count != 0 && (row == -1 || count > max))
                {
                    max = count;
                    row = i;
                }
            }
            return row;

        }
    }
}
