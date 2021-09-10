using System;
using System.Collections.Generic;
using System.Text;

namespace _10_9_OOP
{
    abstract class SinhVien : ISinhVien
    {
        //Fields
        private string maSV;
        private string hoTen;
        private string lop;
        private string khoa;
        private DateTime ngaySinh;
        private static double baoHiemYTe = 500000;
        private static double phuThu = 5000;

        //Properties
        public string MaSV { get => maSV; set => maSV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public static double BaoHiemYTe { get => baoHiemYTe; }
        public static double PhuThu { get => phuThu; }

        //Contructors
        public SinhVien() { }

        public SinhVien(string maSV, string hoTen, string lop, string khoa, DateTime ngaySinh)
        {
            this.MaSV = maSV;
            this.HoTen = hoTen;
            this.Lop = lop;
            this.Khoa = khoa;
            this.NgaySinh = ngaySinh;
        }

        //Methods
        public abstract double tinhHocPhi();
        public virtual string toString()
        {
            string str = $"Ho ten: {this.HoTen}\nMSSV: {this.MaSV}\nLop: {this.Lop}\nNgay sinh: {this.NgaySinh.Day}/{this.NgaySinh.Month}/{this.NgaySinh.Year}";

            return str;
        }
    }
}
