using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _10_9_OOP
{
    class TienIchSinhVien
    {
        private List<ISinhVien> sinhViens;

        public TienIchSinhVien()
        {
            sinhViens = new List<ISinhVien>();
        }

        /// <summary>
        /// Nhap danh sach sinh vien
        /// </summary>
        /// <returns></returns>
        public void nhapListSinhVien()
        {

            char key = '\0';

            do
            {
                Console.WriteLine("1. Sinh Vien Trung Cap"
                                    + "\n2. Sinh Vien Cao Dang"
                                    + "\nESC. Ngung Nhap");
                do
                {
                    key = Console.ReadKey(true).KeyChar;
                } while (!key.Equals((char)ConsoleKey.Escape) && !key.Equals((char)ConsoleKey.NumPad1) && !key.Equals((char)ConsoleKey.D1) && !key.Equals((char)ConsoleKey.NumPad2) && !key.Equals((char)ConsoleKey.D2));

                if (key.Equals((char)ConsoleKey.NumPad1) || key.Equals((char)ConsoleKey.D1))
                {
                    this.sinhViens.Add(nhapSinhVienTrungCap());
                }
                else if (key.Equals((char)ConsoleKey.NumPad2) || key.Equals((char)ConsoleKey.D2))
                {
                    this.sinhViens.Add(nhapSinhVienCaoDang());
                }

            } while (!key.Equals((char)ConsoleKey.Escape));

        }

        /// <summary>
        /// Nhap sinh vien cao dang
        /// </summary>
        /// <returns></returns>
        private ISinhVien nhapSinhVienCaoDang()
        {
            string maSV;
            string hoTen;
            string lop;
            string khoa;
            int ngaySinh;
            int thangSinh;
            int namSinh;
            int soTinChiLyThuyet;
            int soTinChiThucHanh;

            Console.Write("Nhap ho ten: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhap MSSV: ");
            maSV = Console.ReadLine();
            Console.Write("Nhap lop: ");
            lop = Console.ReadLine();
            Console.Write("Nhap khoa: ");
            khoa = Console.ReadLine();

            do
            {
                Console.Write("Nhap ngay sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out ngaySinh));
            do
            {
                Console.Write("Nhap thang sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out thangSinh));
            do
            {
                Console.Write("Nhap nam sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out namSinh));
            do
            {
                Console.Write("Nhap so tin chi ly thuyet: ");
            } while (!int.TryParse(Console.ReadLine(), out soTinChiLyThuyet));
            do
            {
                Console.Write("Nhap so tin chi thuc hanh: ");
            } while (!int.TryParse(Console.ReadLine(), out soTinChiThucHanh));

            return new SinhVienCaoDang(maSV, hoTen, lop, khoa, new DateTime(namSinh, thangSinh, ngaySinh), soTinChiLyThuyet, soTinChiThucHanh);
        }

        /// <summary>
        /// Nhap sinh vien trung cap
        /// </summary>
        /// <returns></returns>
        private ISinhVien nhapSinhVienTrungCap()
        {
            string maSV;
            string hoTen;
            string lop;
            string khoa;
            int ngaySinh;
            int thangSinh;
            int namSinh;
            double hocPhi;

            Console.Write("Nhap ho ten: ");
            hoTen = Console.ReadLine();
            Console.Write("Nhap MSSV: ");
            maSV = Console.ReadLine();
            Console.Write("Nhap lop: ");
            lop = Console.ReadLine();
            Console.Write("Nhap khoa: ");
            khoa = Console.ReadLine();

            do
            {
                Console.Write("Nhap ngay sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out ngaySinh));
            do
            {
                Console.Write("Nhap thang sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out thangSinh));
            do
            {
                Console.Write("Nhap nam sinh: ");
            } while (!int.TryParse(Console.ReadLine(), out namSinh));
            do
            {
                Console.Write("Nhap hoc phi hoc ky: ");
            } while (!double.TryParse(Console.ReadLine(), out hocPhi));

            return new SinhVienTrungCap(maSV, hoTen, lop, khoa, new DateTime(namSinh, thangSinh, ngaySinh), hocPhi);
        }

        /// <summary>
        /// Hien thi thong tin tat ca sinh vien ra man hinh
        /// </summary>
        public void hienThiListSinhVien()
        {
            foreach (ISinhVien sinhVien in this.sinhViens)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine(sinhVien.toString());
            }
        }

        /// <summary>
        /// hien thi so luong sinh vien cua moi loai sinh vien
        /// </summary>
        public void hienThiSoLuongCacSinhVien()
        {
            Console.WriteLine($"Co {SinhVienCaoDang.Count} sinh vien cao dang.");
            Console.WriteLine($"Co {SinhVienTrungCap.Count} sinh vien trung cap.");

            int count_CaoDang = 0;
            int count_TrungCap = 0;
            foreach (ISinhVien sinhVien in this.sinhViens)
            {
                if (sinhVien is SinhVienCaoDang)
                {
                    count_CaoDang++;
                }
                else if (sinhVien is SinhVienTrungCap)
                {
                    count_TrungCap++;
                }
            }

            Console.WriteLine($"Co {count_CaoDang} sinh vien cao dang trong mang.");
            Console.WriteLine($"Co {count_TrungCap} sinh vien trung cap trong mang.");
        }

        /// <summary>
        /// tim kiem
        /// </summary>
        /// <returns></returns>
        public void find()
        {

            string key = "";
            string[] strs = new string[0];
            Console.Write("Nhap tu can tim: ");
            key = Console.ReadLine();

            foreach (SinhVien sv in this.sinhViens)
            {
                if (sv.HoTen.Equals(key) || sv.MaSV.Equals(key))
                {
                    Array.Resize(ref strs, strs.Length + 1);
                    strs[strs.Length - 1] = sv.toString();
                }
            }

            if (strs.Length > 0)
            {
                //hien thi ra man hinh
                foreach (var item in strs)
                {
                    Console.WriteLine(item);
                }

                //luu vao file
                WriteFile("find.txt", strs);
            }
            else
            {
                Console.WriteLine("Khong tim thay");
            }
        }

        /// <summary>
        /// ghi file
        /// </summary>
        /// <param name="link"></param>
        /// <param name="arrString"></param>
        private void WriteFile(string link, string[] arrString)
        {
            StreamWriter streamWriter;
            if (File.Exists(link))
            {
                File.SetAttributes(link, FileAttributes.Normal);
                streamWriter = new StreamWriter(link);
            }
            else
            {
                streamWriter = new StreamWriter(link);
                File.SetAttributes(link, FileAttributes.Normal);
            }
            for (int i = 0; i < arrString.Length - 1; i++)
            {
                streamWriter.WriteLine(arrString[i]);
            }
            streamWriter.Write(arrString[arrString.Length - 1]);
            streamWriter.Close();
            File.SetAttributes(link, FileAttributes.ReadOnly);
        }
    }
}
