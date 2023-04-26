using Baicuoiki;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablePrettyPrinter;
using System.Data;

namespace Finalproject
{
    class ListDH
    {
        Dictionary<String, DonHang> listdh;
        public ListDH()
        {
            listdh = new Dictionary<String, DonHang>();
        }
        public void Nhap(List<ChiTietDonHang> list, double tongtien)
        {
            var ma = "DH";
            var madh = Convert.ToString(ma + (listdh.Count() + 1));
            var dh = new DonHang(madh, DateTime.Today, list, tongtien);
            listdh.Add(dh.ID, dh);
        }
        public void Xuat()
        {
            int trangHienTai = 0;
            int kichThuocTrang = 10;
            int tongSoTrang = (int)Math.Ceiling((double)listdh.Count / kichThuocTrang);

            while (true)
            {
                int viTriDau = trangHienTai * kichThuocTrang;
                int viTriCuoi = Math.Min(viTriDau + kichThuocTrang, listdh.Count) - 1;
                
                DataTable table = new DataTable("Danh sach don hang");
                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Tong tien", typeof(double));
                table.Columns.Add("Ngay dat hang", typeof(DateTime));
                for (int i = viTriDau; i <= viTriCuoi; i++)
                {
                    var dh = listdh.ElementAt(i);
                    table.Rows.Add(dh.Value.ID, dh.Value.Tongtien(), dh.Value.Ngaydathang);
                }
                Console.WriteLine(table.ToPrettyPrintedString());
                
                Console.WriteLine($"{trangHienTai + 1} / {tongSoTrang}");
                Console.WriteLine("\nNhan <- de quay lai, -> de chuyen tiep, x de thoat");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("1. Xem chi tiet don hang");
                Console.Write("Moi chon: ");
                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            trangHienTai = Math.Max(trangHienTai - 1, 0);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            trangHienTai = Math.Min(trangHienTai + 1, tongSoTrang - 1);
                            break;
                        }
                    case ConsoleKey.D1:
                        {
                            var x = Tim();
                            if (x != null) x.Xuat();
                            else Console.WriteLine("\nDon hang khong ton tai!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.X:
                        {
                            Console.WriteLine("\nDa thoat!");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nKhong co trong lua chon!");
                            Console.ReadKey();
                            break;
                        }
                }
                Console.Clear();
                if (key == ConsoleKey.X)
                    break;
            }
        }
        public DonHang Tim()
        {
            Console.Write("\nNhap ma don hang: ");
            String madh = Console.ReadLine();
            var dh = new DonHang();
            if (listdh.TryGetValue(madh, out dh))
                return dh;
            else
                return null;
        }
        //public bool Xoa()
        //{
        //    Console.Write("Nhap ma san pham: ");
        //    String madh = Console.ReadLine();
        //    return listdh.Remove(madh);
        //}
    }
}
