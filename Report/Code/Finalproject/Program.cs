using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using Figgle;

namespace Finalproject
{
    class Program
    {
        static ListSP danhSachSP = new ListSP();
        static ListDH danhSachDH = new ListDH();
        static ListCT chiTietDH = new ListCT();
        static void Login()
        {
            int choose = 0;
            do
            {
                Console.WriteLine(FiggleFonts.Standard.Render("COFFEE STORE"));
                Console.WriteLine("1. User");
                Console.WriteLine("2. Admin");
                Console.WriteLine("0. Thoat");
                Console.Write("Moi chon: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            Console.Clear();
                            UserPage();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            AdminPage();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Da thoat!");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Khong co trong lua chon!");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                }
            } while (choose != 0);      
        }
        static void UserPage()
        {
            int choose = 0;
            do
            {
                Console.WriteLine(FiggleFonts.Standard.Render("Trang chu"));
                Console.WriteLine("1. San pham");
                Console.WriteLine("2. Gio hang");
                Console.WriteLine("3. Don hang");
                Console.WriteLine("0. Dang xuat");
                Console.Write("Moi chon: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            Console.Clear();
                            Product();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Cart();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Order();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Ban da dang xuat");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Khong co trong lua chon!");
                            Console.ReadKey();
                            break;
                        }
                }
                Console.Clear();
            } while (choose != 0); 
        }
        static void Product()
        {
            if (danhSachSP != null)
                danhSachSP.Xuat(0, chiTietDH);
            else
            {
                Console.WriteLine("Danh sach trong!");
                Console.ReadKey();
                Console.Clear();
            }   
        }
        static void Cart()
        {
            if (chiTietDH != null)
                chiTietDH.Xuat(danhSachDH, danhSachSP);
            else
            {
                Console.WriteLine("Gio hang trong!");
                Console.ReadKey();
                Console.Clear();
            }   
        }
        static void Order()
        {
            if (danhSachDH != null)
                danhSachDH.Xuat();
            else
            {
                Console.WriteLine("Khong co don hang!");
                Console.ReadKey();
            }
            Console.Clear();
        }
        static void AdminPage()
        {
            int choose = 0;
            do
            {
                Console.WriteLine(FiggleFonts.Standard.Render("Trang chu"));
                Console.WriteLine("1. San pham");
                Console.WriteLine("2. Don hang");
                Console.WriteLine("0. Dang xuat");
                Console.Write("Moi chon: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            Console.Clear();
                            ProductAd();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Dang bao tri");
                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Ban da dang xuat");
                            danhSachSP.Save("Products.bin");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Khong co trong lua chon!");
                            Console.ReadKey();
                            break;
                        }
                }
                Console.Clear();
            } while (choose != 0);
        }
        static void ProductAd()
        {
            int choose = 0;
            do
            {
                Console.WriteLine(FiggleFonts.Standard.Render("San pham"));
                Console.WriteLine("1. Xem san pham");
                Console.WriteLine("2. Cap nhat san pham");
                Console.WriteLine("3. Xoa san pham");
                Console.WriteLine("0. Quay lai");
                Console.Write("Moi chon: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        {
                            Console.Clear();
                            if (danhSachSP != null) danhSachSP.Xuat(1, chiTietDH);
                            else
                            {
                                Console.WriteLine("Hien tai chua co san pham!");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("===Cap nhat san pham===");
                            danhSachSP.Nhap();
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("===Xoa san pham===");
                            var msg = danhSachSP.Xoa();
                            if (msg) Console.WriteLine("Da xoa!");
                            else Console.WriteLine("Xoa san pham khong thanh cong!");
                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Da thoat!");
                            Console.ReadKey();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Khong co trong lua chon!");
                            Console.ReadKey();
                            break;
                        }
                }
                Console.Clear();
            } while (choose != 0);
        }
        static void Main(string[] args)
        {
            danhSachSP.Load("Products.bin");
            Login();
        }
    }
}
