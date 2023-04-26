using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTablePrettyPrinter;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using Baicuoiki;

namespace Finalproject
{
    class ListSP
    {
        Dictionary<String, SanPham> listsp;
        public ListSP()
        {
            this.listsp = new Dictionary<String, SanPham>();
        }
        public void Nhap()
        {
            SanPham sp = new SanPham();
            sp.Nhap();
            char c = ' ';
            if (sp != null)
            {
                if (this.listsp.ContainsKey(sp.ID))
                {
                    Console.WriteLine("Ma san pham da ton tai!");
                    Console.WriteLine("Ban co muon cap nhat ?");
                    Console.Write("\nNhap 'y' de xac nhan, bat ky de huy: ");
                    c = Convert.ToChar(Console.ReadLine().ToLower());
                    if (c == 'y')
                    {
                        listsp.Add(sp.ID, sp);
                        Console.WriteLine("Da cap nhat!");
                    }
                    else Console.WriteLine("Da huy!");
                }
                else
                {
                    Console.Write("\nNhap 'y' de xac nhan, bat ky de huy: ");
                    c = Convert.ToChar(Console.ReadLine().ToLower());
                    if (c == 'y')
                    {
                        listsp.Add(sp.ID, sp);
                        Console.WriteLine("Da them!");
                    }
                    else Console.WriteLine("Da huy!");
                }  
            }
            else Console.WriteLine("Du lieu trong!");
        }
        public void Xuat(int c, ListCT items)
        {
            int trangHienTai = 0;
            int kichThuocTrang = 10;
            int tongSoTrang = (int)Math.Ceiling((double)listsp.Count()/kichThuocTrang);
            
            while (true)
            {
                int viTriDau = trangHienTai * kichThuocTrang;
                int viTriCuoi = Math.Min(viTriDau + kichThuocTrang, listsp.Count()) - 1;
                
                DataTable table = new DataTable("Danh sach san pham");
                table.Columns.Add("ID", typeof(String));
                table.Columns.Add("Ten san pham", typeof(String));
                table.Columns.Add("Don gia", typeof(double));
                table.Columns.Add("So luong", typeof(int));
                table.Columns.Add("Mo ta", typeof(String));
                table.Columns.Add("Nha cung cap", typeof(String));
                table.Columns.Add("Loai san pham", typeof(String));
                for (int i = viTriDau; i <= viTriCuoi; i++)
                {
                    var sp = listsp.ElementAt(i);
                    table.Rows.Add(sp.Value.ID, sp.Value.Ten, sp.Value.Dongia, sp.Value.Soluong, sp.Value.Mota, sp.Value.Nhacungcap, sp.Value.Loai); 
                }
                Console.WriteLine(table.ToPrettyPrintedString());
                
                Console.WriteLine($"{trangHienTai + 1} / {tongSoTrang}");
                Console.WriteLine("\nNhan <- de quay lai, -> de chuyen tiep, x de quay lai\n");
                var key = ConsoleKey.A;
                if (c == 0)
                {
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("1. Them san pham vao gio hang");
                    Console.Write("Moi chon: ");

                    key = Console.ReadKey().Key;
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
                                Themvaogio(items);
                                Console.ReadKey();
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
                }
                else
                {
                    key = Console.ReadKey().Key;
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
                }
                Console.Clear();
                if (key == ConsoleKey.X)
                    break;
            }
        }
        public SanPham Tim()
        {
            Console.Write("\nNhap ma san pham: ");
            String masp = Console.ReadLine();
            SanPham sp = new SanPham();
            if (listsp.TryGetValue(masp, out sp))
                return sp;
            else
                return null;
        }
        public bool Capnhat(int i, ChiTietDonHang x)
        {
            if (i == 0)
            {
                if (listsp[x.Masp].Soluong < x.Soluong) return false;
                else return true;
            }
           else
            {
                listsp[x.Masp].Soluong -= x.Soluong;
                return true;
            }
        }
        public bool Xoa()
        {
            Console.Write("\nNhap ma san pham: ");
            String masp = Console.ReadLine();
            Console.Write("\nNhap 'y' de xac nhan, bat ky de huy: ");
            char c = Convert.ToChar(Console.ReadLine().ToLower());
            if (c == 'y')
                return listsp.Remove(masp);
            else return false;
        }
        public void Themvaogio(ListCT items)
        {
            var sp = Tim();
            if (sp != null)
            {
                Console.WriteLine($"San pham: {sp.Ten}");
                Console.WriteLine($"Don gia: {sp.Dongia}");
                Console.Write("Nhap so luong: ");
                var soluong = int.Parse(Console.ReadLine());
                Console.Write("Nhap 'y' de xac nhan, ky tu bat ky de huy: ");
                char c = char.Parse(Console.ReadLine().ToLower());
                if (c == 'y')
                {
                    items.Nhap(sp.Ten, soluong, sp.Dongia, sp.ID);
                    Console.WriteLine("Da them vao gio hang!");
                }
                else
                {
                    Console.WriteLine("Da huy!");
                    
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay san pham");
                
            }
        }
        public void Save(string fileName)
        { 
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this.listsp);
            }
        }
        public void Load(string fileName)
        {
            try
            {
                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    this.listsp = (Dictionary<String, SanPham>)formatter.Deserialize(stream);
                }
            }
            catch { }
        }
    }
}
