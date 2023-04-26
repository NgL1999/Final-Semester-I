using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablePrettyPrinter;

namespace Finalproject
{
    [Serializable]
    class SanPham
    {
        private String id;
        private String ten;
        private double dongia;
        private int soluong;
        private String mota;
        private String nhacungcap;
        private String loaisanpham;
        public String ID
        {
            set { this.id = value; }
            get { return this.id; }
        }
        public String Ten
        {
            set { this.ten = value; }
            get { return this.ten; }
        }
        public double Dongia
        {
            set { this.dongia = value; }
            get { return this.dongia; }
        }
        public int Soluong
        {
            set { this.soluong = value; }
            get { return this.soluong; }
        }
        public String Mota
        {
            set { this.mota = value; }
            get { return this.mota; }
        }
        public String Nhacungcap
        {
            set { this.nhacungcap = value; }
            get { return this.nhacungcap; }
        }
        public String Loai
        {
            set { this.loaisanpham = value; }
            get { return this.loaisanpham; }
        }
        public void Xuat()
        {
            DataTable table = new DataTable("Danh sach san pham");
            table.Columns.Add("ID", typeof(String));
            table.Columns.Add("Ten san pham", typeof(String));
            table.Columns.Add("Don gia", typeof(double));
            table.Columns.Add("So luong", typeof(int));
            table.Columns.Add("Mo ta", typeof(String));
            table.Columns.Add("Nha cung cap", typeof(String));
            table.Columns.Add("Loai san pham", typeof(String));
            table.Rows.Add(this.id, this.ten, this.dongia, this.soluong, this.mota, this.nhacungcap, this.loaisanpham);
            Console.WriteLine(table.ToPrettyPrintedString());
        }
        public void Nhap()
        {
            Console.Write("Ma san pham: ");
            this.id = Console.ReadLine();
            Console.Write("Ten san pham: ");
            this.ten = Console.ReadLine();
            Console.Write("Don gia: ");
            this.dongia = double.Parse(Console.ReadLine());
            Console.Write("So luong: ");
            this.soluong = int.Parse(Console.ReadLine());
            Console.Write("Mo ta: ");
            this.mota = Console.ReadLine();
            Console.Write("Nha cung cap: ");
            this.nhacungcap = Console.ReadLine();
            Console.Write("Loai san pham: ");
            this.loaisanpham = Console.ReadLine();
        }
        public SanPham() { }
        public SanPham(String id, String ten, double dongia, int soluong, String mota, String nhacungcap, String loaisanpham)
        {
            this.id = id;
            this.ten = ten;
            this.dongia = dongia;
            this.soluong = soluong;
            this.mota = mota;
            this.nhacungcap = nhacungcap;
            this.loaisanpham = loaisanpham;
        }
    }
}
