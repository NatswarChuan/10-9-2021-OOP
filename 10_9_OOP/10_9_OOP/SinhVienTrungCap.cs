using System;
using System.Collections.Generic;
using System.Text;

namespace _10_9_OOP
{
    class SinhVienTrungCap : SinhVien
    {
        //Fields
        private double hocPhi;
        private static int count = 0;

        //Properties
        public double HocPhi { get => hocPhi; set => hocPhi = value; }
        public static int Count { get => count; }

        //Contructors
        public SinhVienTrungCap() : base() { }

        public SinhVienTrungCap(string maSV, string hoTen, string lop, string khoa, DateTime ngaySinh, double hocPhi) : base(maSV, hoTen, lop, khoa, ngaySinh)
        {
            this.HocPhi = hocPhi;
            count++;
        }

        ~SinhVienTrungCap()
        {
            count--;
        }

        //Methods
        public override double tinhHocPhi()
        {
            double hocPhi = this.hocPhi + SinhVien.BaoHiemYTe + SinhVien.PhuThu;

            return hocPhi;
        }

        public override string toString()
        {
            string str = $"{base.toString()}\nHoc phi hoc ky: {this.HocPhi}";

            return str;
        }
    }
}
