using Baicuoiki;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablePrettyPrinter;

namespace Finalproject
{
    class ListCT
    {
        List<ChiTietDonHang> listct;
        public ListCT()
        {
            this.listct = new List<ChiTietDonHang>();
        }
        public void Nhap(String tensanpham, int soluong, double dongia, String masp)
        {
            var thanhtien = soluong * dongia;
            ChiTietDonHang sp = new ChiTietDonHang(listct.Count() + 1, tensanpham, soluong, dongia, thanhtien, masp);
            listct.Add(sp);
        }
        public void Xuat(ListDH dsDH, ListSP dsSP)
        {
            int trangHienTai = 0;
            int kichThuocTrang = 10;
            int tongSoTrang = (int)Math.Ceiling((double)listct.Count() / kichThuocTrang);

            while (true)
            {
                int viTriDau = trangHienTai * kichThuocTrang;
                int viTriCuoi = Math.Min(viTriDau + kichThuocTrang, listct.Count()) - 1;
                
                DataTable table = new DataTable("Danh sach san pham");
                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Ten san pham", typeof(String));
                table.Columns.Add("Don gia", typeof(double));
                table.Columns.Add("So luong", typeof(int));
                table.Columns.Add("Thanh tien", typeof(double));
                table.Columns.Add("MA", typeof(String));
                for (int i = viTriDau; i <= viTriCuoi; i++)
                {
                    var sp = listct.ElementAt(i);
                    table.Rows.Add(sp.ID, sp.Tensanpham, sp.Dongia, sp.Soluong, sp.Thanhtien, sp.Masp);
                }
                Console.WriteLine(table.ToPrettyPrintedString());
                
                Console.WriteLine($"{trangHienTai + 1} / {tongSoTrang}");
                Console.WriteLine("\nNhan <- de quay lai, -> de chuyen tiep, x de quay lai\n");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("1. Dat hang");
                Console.WriteLine("2. Xoa san pham khoi gio hang");
                Console.Write("Moi chon: ");
                var key = Console.ReadKey().Key;
                char c = ' ';
                
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
                            Console.WriteLine("\n========================================");
                            Console.WriteLine("Tong tien = {0}", listct.Sum(x => x.Thanhtien));
                            Console.Write("Nhap 'y' de xac nhan dat hang, ky tu bat ky de huy: ");
                            c = char.Parse(Console.ReadLine().ToLower());
                            if (c == 'y')
                            { 
                                int check = 0;
                                foreach (var sp in listct)
                                    if (dsSP.Capnhat(0, sp) == false)
                                    {
                                        check = 1;
                                        break;
                                    }
                                if (check == 1)
                                {
                                    Console.WriteLine("Khong du hang!");
                                    break;
                                }
                                else
                                {
                                    foreach (var sp in listct)
                                        dsSP.Capnhat(1, sp);
                                    dsDH.Nhap(listct, listct.Sum(x => x.Thanhtien));
                                    Console.WriteLine("Dat hang thanh cong!");
                                    listct.Clear();
                                } 
                                Console.ReadKey(); 
                            }
                            else
                                Console.WriteLine("Da huy!");
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Write("Chon 1 - {0} de xoa: ", listct.Count());
                            int s = Convert.ToInt32(Console.ReadLine());
                            if (s < 1 && s > listct.Count())
                                Console.WriteLine("Nam ngoai danh sach!");
                            else
                            {
                                Console.Write("Nhap 'y' de xac nhan xoa, ky tu bat ky de huy: ");
                                c = char.Parse(Console.ReadLine().ToLower());
                                if (c == 'y')
                                {
                                    listct.RemoveAt(s - 1);
                                    Console.WriteLine("Da xoa!");
                                }
                                else
                                    Console.WriteLine("Da huy!");
                            }
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
        //public double Tongtien()
        //{
        //    return listct.Sum(x => x.Thanhtien);
        //}
        //public int Soluong()
        //{
        //    return listct.Count();
        //}
        //public void Xoa(int i)
        //{
        //   listct.RemoveAt(i - 1);
        //}
        //public void Clear()
        //{
        //    listct.Clear();
        //}
        //public List<ChiTietDonHang> Listct()
        //{
        //    return listct;
        //}
    }
}
