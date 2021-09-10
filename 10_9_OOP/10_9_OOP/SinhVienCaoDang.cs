using System;
using System.Collections.Generic;
using System.Text;

namespace _10_9_OOP
{
    class SinhVienCaoDang : SinhVien
    {
        //Fields
        private int soTinChiLyThuyet;
        private int soTinChiThucHanh;
        private static double donGiaLyThuyet = 180000;
        private static double donGiaThucHanh = 230000;
        private static int count = 0;

        //Properties
        public int SoTinChiLyThuyet { get => soTinChiLyThuyet; set => soTinChiLyThuyet = value; }
        public int SoTinChiThucHanh { get => soTinChiThucHanh; set => soTinChiThucHanh = value; }
        public static double DonGiaLyThuyet { get => donGiaLyThuyet; }
        public static double DonGiaThucHanh { get => donGiaThucHanh; }
        public static int Count { get => count; }

        //Contructors
        public SinhVienCaoDang() : base() { }

        public SinhVienCaoDang(string maSV, string hoTen, string lop, string khoa, DateTime ngaySinh, int soTinChiLyThuyet, int soTinChiThucHanh) : base(maSV, hoTen, lop, khoa, ngaySinh)
        {
            this.SoTinChiLyThuyet = soTinChiLyThuyet;
            this.SoTinChiThucHanh = soTinChiThucHanh;
            count++;
        }

        ~SinhVienCaoDang()
        {
            count--;
        }

        //Methods
        public override double tinhHocPhi()
        {
            double hocPhi = (this.SoTinChiLyThuyet * SinhVienCaoDang.DonGiaLyThuyet) + (this.SoTinChiThucHanh * SinhVienCaoDang.DonGiaThucHanh) + SinhVien.BaoHiemYTe + SinhVien.PhuThu;

            return hocPhi;
        }

        public override string toString()
        {
            string str = $"{base.toString()}\nSo tin chi thuc hanh: {this.SoTinChiThucHanh}\nSo tin chi ly thuyet: {this.SoTinChiLyThuyet}";

            return str;
        }
    }
}
