using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Bai4
    {
        public static void Run()
        {
            CPhanSo a = new CPhanSo();
            CPhanSo b = new CPhanSo();
            CPhanSo result = new CPhanSo();
            CDayPhanSo dayPhanSo;
            int choice;
            do
            {
                Console.WriteLine("\n======MENU BAI 4======");
                Console.WriteLine("1. Tính toán hai phân số");
                Console.WriteLine("2. Làm việc với dãy các phân số");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng:");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Phân số 1: ");
                        a.Nhap();
                        Console.WriteLine("Phân số 2: ");
                        b.Nhap();
                        Console.Write("Hai phân số vừa nhập là: ");
                        a.Xuat();
                        Console.Write(" và ");
                        b.Xuat();
                        result = new CPhanSo(a + b);
                        Console.Write("\nTổng của 2 phân số là: ");
                        result.Xuat();
                        result = new CPhanSo(a - b);
                        Console.Write("\nHiệu của 2 phân số là: ");
                        result.Xuat();
                        result = new CPhanSo(a * b);
                        Console.Write("\nTích của 2 phân số là: ");
                        result.Xuat();
                        result = new CPhanSo(a / b);
                        Console.Write("\nThương của 2 phân số là: ");
                        result.Xuat();
                        break;
                    case 2:
                        int n = ReadPositiveInt("Nhập số lượng phân số trong dãy: ");
                        dayPhanSo = new CDayPhanSo(n);
                        dayPhanSo.Nhap();
                        Console.Write("Dãy phân số vừa nhập là: ");
                        dayPhanSo.Xuat();
                        Console.Write("\nPhân số lớn nhất trong dãy là: ");
                        dayPhanSo.PhanSoMax().Xuat();
                        dayPhanSo.SapXepTangDan();
                        Console.Write("\nDãy phân số sau khi sắp xếp tăng dần là: ");
                        dayPhanSo.SapXepTangDan();
                        dayPhanSo.Xuat();
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ");
                        break;
                }

            } while (choice != 0);

        }
        public class CPhanSo
        {
            private int tuso;
            private int mauso;
            public CPhanSo(int tuso = 0, int mauso = 1)
            {
                int uc = UCLN(tuso, mauso);
                if (mauso < 0)
                {
                    this.tuso = -tuso / uc;
                    this.mauso = -mauso / uc;
                }
                else
                {
                    this.tuso = tuso / uc;
                    this.mauso = mauso / uc;
                }
            }
            public CPhanSo(CPhanSo other)
            {
                this.tuso = other.tuso;
                this.mauso = other.mauso;
            }
            public void Nhap()
            {
                tuso = Read("Nhập tử số: ");
                mauso = Read("Nhập mẫu số: ");
            }
            public void Xuat()
            {
                if (mauso == 1) Console.Write(tuso);
                else if (tuso == 0) Console.Write(0);
                else Console.Write($"{tuso}/{mauso}");
            }
            public int Tuso
            {
                get { return tuso; }
            }
            public int Mauso
            {
                get { return mauso; }
            }
            public static CPhanSo operator +(CPhanSo a, CPhanSo b)
            {
                return new CPhanSo(a.tuso * b.mauso + b.tuso * a.mauso, a.mauso * b.mauso);
            }
            public static CPhanSo operator -(CPhanSo a, CPhanSo b)
            {
                return new CPhanSo(a.tuso * b.mauso - b.tuso * a.mauso, a.mauso * b.mauso);
            }
            public static CPhanSo operator *(CPhanSo a, CPhanSo b)
            {
                return new CPhanSo(a.tuso * b.tuso, a.mauso * b.mauso);
            }
            public static CPhanSo operator /(CPhanSo a, CPhanSo b)
            {
                return new CPhanSo(a.tuso * b.mauso, a.mauso * b.tuso);
            }

        }
        class CDayPhanSo
        {
            private CPhanSo[] arr;
            private int size;
            public CDayPhanSo(int size)
            {
                this.size = size;
                arr = new CPhanSo[size];
            }
            public void Nhap()
            {
                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine($"Nhập phân số thứ {i + 1}: ");
                    arr[i] = new CPhanSo();
                    arr[i].Nhap();
                }
            }
            public CPhanSo PhanSoMax()
            {
                CPhanSo max = arr[0];
                for (int i = 1; i < size; i++)
                {
                    if (arr[i].Tuso * max.Mauso > max.Tuso * arr[i].Mauso)
                    {
                        max = arr[i];
                    }
                }
                return max;
            }
            public void Xuat()
            {
                for (int i = 0; i < size; i++)
                {
                    arr[i].Xuat();
                    Console.Write(" ");
                }
            }
            public void SapXepTangDan()
            {
                Array.Sort(arr, (a, b) => (a.Tuso * b.Mauso).CompareTo(b.Tuso * a.Mauso));
            }
        }
        static int ReadPositiveInt(string message)
        {
            int n;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }
        static int Read(string message)
        {
            int n;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out n) || (message== "Nhập mẫu số: "&& n==0));
            return n;
        }
        static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }

}
