using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Bai5
    {
      
        public static void Run()
        {
            Console.WriteLine("Nhập số lượng bất động sản: ");
            int n = ReadPositiveInt();
            cQuanLy quanly = new cQuanLy(n);
            quanly.Nhap();
            int choice;
            do
            {
              Console.WriteLine("\n======MENU BAI 5======");
                Console.WriteLine("1. Hiển thị danh sách bất động sản");
                Console.WriteLine("2. Tìm kiếm bất động sản theo địa điểm, giá bán và diện tích");
                Console.WriteLine("3. Tính tổng tiền từng loại bất động sản");
                Console.WriteLine("4. Hiển thị khu đất có diện tích > 100m2 hoặc nhà phố có diện tích > 60m2 và năm xây dựng >= 2019");
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
                        quanly.Xuat();
                        break;
                    case 2:
                        Console.Write("Nhập địa điểm cần tìm: ");
                        string diadiem = Console.ReadLine();
                        Console.Write("Nhập giá bán tối đa: ");
                        long giaban = ReadPositiveLong();
                        Console.Write("Nhập diện tích tối thiểu: ");
                        double dientich = ReadPositiveDouble();
                        quanly.TimKiem(diadiem, giaban, dientich);
                        break;
                    case 3:
                        Console.WriteLine($"Tổng tiền khu đất: {quanly.TongTienKhuDat():N0}");
                        Console.WriteLine($"Tổng tiền nhà phố: {quanly.TongTienNhaPho():N0}");
                        Console.WriteLine($"Tổng tiền chung cư: {quanly.TongTienChungCu():N0}");
                        break;
                    case 4:
                        quanly.XuatKD_NP();
                        break;
                    case 0:
                        Console.WriteLine("Thoát chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }    while (choice != 0);
        }
        // Lớp Khu Đất
        public class cKhuDat
        {
            protected string diadiem;
            protected long giaban;
            protected double dientich;
            protected int maloai; // 1: Khu đất, 2: Nhà phố, 3: Chung cư
            public cKhuDat(string diadiem = "", long giaban = 0, double dientich = 0)
            {
                this.diadiem = diadiem;
                this.giaban = giaban;
                this.dientich = dientich;
                this.maloai = 1;
            }
            public virtual void Nhap()
            {
                Console.Write("Nhập địa điểm: ");
                diadiem = Console.ReadLine();
                Console.Write("Nhập giá bán: ");
                giaban = ReadPositiveLong();
                Console.Write("Nhập diện tích: ");
                dientich = ReadPositiveDouble();
            }
            public virtual void Xuat()
            {
               Console.Write($" {diadiem,20} {giaban,15:N0} {dientich,12}");
            }
            public virtual string GetDiaDiem()
            {
                return diadiem;
            }
            public virtual double GetDienTich()
            {
                return dientich;
            }
            public virtual long GetGiaBan()
            {
                return giaban;
            }
            public virtual int GetMaLoai()
            {
                return maloai;
            }
            public virtual int GetNamXD()
            {
                return 0;
            }
        }
        // Lớp Nhà Phố ke thừa từ Khu Đất
        public class cNhaPho : cKhuDat
        {
            private int namxd;
            private int sotang;
            public cNhaPho(string diadiem = "", long giaban = 0, double dientich = 0, int namxd = 0, int sotang = 0) : base(diadiem, giaban, dientich)
            {
                this.namxd = namxd;
                this.sotang = sotang;
                this.maloai = 2;
            }
            public override void Nhap()
            {
                base.Nhap();
                Console.Write("Nhập năm xây dựng: ");
                namxd = ReadPositiveInt();
                Console.Write("Nhập số tầng: ");
                sotang = ReadPositiveInt();
            }
            public override void Xuat()
            {
                base.Xuat();
                Console.Write($" {namxd,7} {sotang,5}");
            }
            public override int GetNamXD()
            {
                return namxd;
            }
        }
        // Lớp Chung Cư ke thừa từ Khu Đất
        public class cChungCu : cKhuDat
        {
            private int tang;
            public cChungCu(string diadiem = "", long giaban = 0, double dientich = 0, int tang = 0) : base(diadiem, giaban, dientich)
            {
                this.tang = tang;
                this.maloai = 3;

            }
            public override void Nhap()
            {
                base.Nhap();
                Console.Write("Nhập tầng: ");
                tang = ReadPositiveInt();
            }
            public override void Xuat()
            {
                base.Xuat();
                Console.Write($" {"",7} {tang,5}");
            }
        }
        // Lớp Quản Lý
        public class cQuanLy
        {
            private cKhuDat[] ds;
            private int soluong;
            public cQuanLy(int soluong)
            {
                this.soluong = soluong;
                ds = new cKhuDat[soluong];
            }
            public void Nhap()
            {
                for (int i = 0; i < soluong; i++)
                {
                    Console.WriteLine($"\nNhập thông tin khu đất thứ {i + 1}:");
                    Console.Write("Chọn loại khu đất (1. Khu đất,2. Nhà phố, 3. Chung cư): ");
                    if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > 3)
                    {
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại.");
                        i--;
                        continue;
                    }
                    if (choice == 1)
                    {
                        ds[i] = new cKhuDat();
                    }
                    else if (choice == 2)
                    {
                        ds[i] = new cNhaPho();
                    }
                    else if(choice == 3)
                    {
                        ds[i] = new cChungCu();
                    }
                    ds[i].Nhap();
                }
            }
            public void Xuat()
            {
                Console.WriteLine("\nDanh sách bất động sản:");
                Console.WriteLine($"{"Loại", 10} {"Địa điểm", 20} {"Giá bán",15} {"Diện tích",12} {"Năm XD",7}{"Tầng",5}");
                for (int i = 0; i < soluong; i++)
                {
                    switch(ds[i].GetMaLoai())
                    {
                        case 1:
                            Console.Write($"{"Khu đất",10}");
                            break;
                        case 2:
                            Console.Write($"{"Nhà phố",10}");
                            break;
                        case 3:
                            Console.Write($"{"Chung cư",10}");
                            break;
                    }
                    ds[i].Xuat();
                    Console.WriteLine();
                }
            }
            public void TimKiem(string diadiem, long giaban, double dientich)
            {

                bool found = false;
                Console.WriteLine($"{"Loại",10} {"Địa điểm",20} {"Giá bán",15} {"Diện tích",12} {"Năm XD",7}{"Tầng",5}");
                for (int i = 0; i < soluong; i++)
                {
                    if (ds[i].GetMaLoai() == 1) continue;
                    if (ds[i].GetDiaDiem().Equals(diadiem, StringComparison.OrdinalIgnoreCase) && giaban >= ds[i].GetGiaBan() && dientich <= ds[i].GetDienTich())
                    {

                        switch (ds[i].GetMaLoai())
                        {
                            case 1:
                                Console.Write($"{"Khu đất",10}");
                                break;
                            case 2:
                                Console.Write($"{"Nhà phố",10}");
                                break;
                            case 3:
                                Console.Write($"{"Chung cư",10}");
                                break;
                        }
                        ds[i].Xuat();
                        Console.WriteLine();
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Không tìm bất động sản nào phù hợp.");
                }
            }
            public long TongTienKhuDat()
            {
                long tongtien = 0;
                for (int i = 0; i < soluong; i++)
                {
                    if (ds[i].GetMaLoai() == 1)
                    {
                        tongtien += ds[i].GetGiaBan();
                    }
                }
                return tongtien;
            }
            public long TongTienNhaPho()
            {
                long tongtien = 0;
                for (int i = 0; i < soluong; i++)
                {
                    if (ds[i].GetMaLoai() == 2)
                    {
                        tongtien += ds[i].GetGiaBan();
                    }
                }
                return tongtien;
            }
            public long TongTienChungCu()
            {
                long tongtien = 0;
                for (int i = 0; i < soluong; i++)
                {
                    if (ds[i].GetMaLoai() == 3)
                    {
                        tongtien += ds[i].GetGiaBan();
                    }
                }
                return tongtien;
            }
            public void XuatKD_NP()
            {
                Console.WriteLine($"{"Loại",10} {"Địa điểm",20} {"Giá bán",15} {"Diện tích",12} {"Năm XD",7}{"Tầng",5}");
                for (int i = 0; i < soluong; i++)
                {
                    if (ds[i].GetMaLoai() == 1 && ds[i].GetDienTich() > 100)
                    {
                        Console.Write($"{"Khu đất",10}");
                        ds[i].Xuat();
                        Console.WriteLine();
                    }
                    else if (ds[i].GetMaLoai() == 2 && ds[i].GetDienTich() > 60 && ds[i].GetNamXD() >= 2019)
                    {
                        Console.Write($"{"Nhà phố",10}");
                        ds[i].Xuat();
                        Console.WriteLine();
                    }
                }
            }
        }
        static public int ReadPositiveInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("Giá trị vừa nhập không hợp lệ vui lòng nhập lại: ");
            }
            return  value;
        }
        static public double ReadPositiveDouble()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("Giá trị vừa nhập không hợp lệ vui lòng nhập lại: ");
            }
            return value;
        }
        static public long ReadPositiveLong()
        {
            long value;
            while (!long.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("Giá trị vừa nhập không hợp lệ vui lòng nhập lại: ");
            }
            return value;
        }

    }
}
