using Baicuoiki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablePrettyPrinter;
using System.Data;

namespace ConsoleApp1
{
    class DonHang
    {
        private String id;
        private DateTime ngaydat;
        private List<ChiTietDonHang> chitiet;
        private double tongtien;
        public List<ChiTietDonHang> Chitiet
        {
            set { this.chitiet = value; }
            get { return this.chitiet; }
        }
        public DateTime Ngaydathang
        {
            set { this.ngaydat = value; }
            get { return this.ngaydat; }
        }
        public String ID
        {
            set { this.id = value; }
            get { return this.id; }
        }
        public double Tongtien()
        {
            return this.tongtien;
        }
        public void Xuat()
        {
            DataTable table = new DataTable("Chi tiet don hang");
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("San pham", typeof(String)); 
            table.Columns.Add("So luong", typeof(int));
            table.Columns.Add("Don gia", typeof(double));
            table.Columns.Add("Thanh tien", typeof(double));
            foreach (var sp in this.chitiet)
                table.Rows.Add(sp.ID, sp.Tensanpham, sp.Soluong, sp.Dongia, sp.Thanhtien);
            Console.WriteLine(table.ToPrettyPrintedString());
        }
        public DonHang() {}
        public DonHang(String id, DateTime ngaydat, List<ChiTietDonHang> chitiet, double tongtien)
        {
            this.id = id;
            this.ngaydat = ngaydat;
            this.chitiet = chitiet.ToList();
            this.tongtien = tongtien;
        }
    }
}