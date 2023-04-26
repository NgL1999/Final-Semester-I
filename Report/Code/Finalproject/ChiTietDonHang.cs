using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baicuoiki
{
    class ChiTietDonHang
    {
        private int id;
        private int soluong;
        private String tensanpham;
        private double dongia;
        private double thanhtien;
        private String masp;
        public int ID
        {
            set { this.id = value; }
            get { return this.id; }
        }
        public int Soluong
        {
            set { this.soluong = value; }
            get { return this.soluong; }
        }
        public String Tensanpham
        {
            set { this.tensanpham = value; }
            get { return this.tensanpham; }
        }
        public double Dongia
        {
            set { this.dongia = value; }
            get { return this.dongia; }
        }
        public double Thanhtien
        {
            set { this.thanhtien = value; }
            get { return this.thanhtien; }
        }
        public String Masp
        {
            set { this.masp = value; }
            get { return this.masp; }
        }
        public ChiTietDonHang() {}
        public ChiTietDonHang(int id, String tensanpham, int soluong, double dongia, double thanhtien, String masp)
        {
            this.id = id;
            this.tensanpham = tensanpham;
            this.soluong = soluong;
            this.dongia = dongia;
            this.thanhtien = thanhtien;
            this.masp = masp;
        }
    }
}

