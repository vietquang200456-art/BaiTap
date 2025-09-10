using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BaiTapVeNha
{

    public class HocSinh
    {
        public int ID { get; set; }
        public string ten { get; set; }
        public int tuoi { get; set; }

        public HocSinh(int ID, string ten, int tuoi)
        {
            this.ID = ID;
            this.ten = ten;
            this.tuoi = tuoi;
        }
        public HocSinh() { }

        public void nhap()
        {
            Console.WriteLine("Nhap vao ID:");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nhap vao ten:");
            ten = Console.ReadLine();
            Console.WriteLine("Nhap vao tuoi:");
            tuoi = Convert.ToInt32(Console.ReadLine());
        }
        public void hienthi()
        {
            Console.WriteLine("ID: {0} , Ten: {1} , Tuoi: {2}", ID, ten, tuoi);
        }
    }
    class DSHS
    {
        List<HocSinh> dshs = new List<HocSinh>()
        {
            new HocSinh(1,"Nguyen Viet Quang" , 21),
            new HocSinh(2," Ly Thi Thu Ha" ,22),
            new HocSinh (3," Nguyen Huu Canh" ,20),
            new HocSinh(1, "Bui Truong An", 16),
            new HocSinh(2, "Nguyen Van Binh", 18),
            new HocSinh(3, "Nguyen Hoang Anh", 14),
            new HocSinh(4, "Luong Cuong", 20),
            new HocSinh(5, "Tran Quoc Anh", 15)
        };
        
        // Cau a.
        public void hienthids()
        {
                       foreach(var hs in dshs)
            {
                hs.hienthi();
            }
        }
        // Cau b.
        public void HStuoiten15()
        {
            var hs15 = from hs in dshs
                       where hs.tuoi >= 15 && hs.tuoi <= 18
                       select hs;
            Console.WriteLine("Danh sach hoc sinh co tuoi tu 15 den 18 la:");
            foreach (var hs in hs15)
            {
                hs.hienthi();
            }

        }
        // Cau c.
        public void HstenA()
        {
            var HsA = from hs in dshs
                      let tenrieng = hs.ten.Trim().Split(' ').Last()
                      where tenrieng.StartsWith("A",StringComparison.OrdinalIgnoreCase)
                      select hs;
            Console.WriteLine("Danh sach hoc sinh co ten bat dau bang chu A la:");
            foreach (var hs in HsA)
            {
                hs.hienthi();
            }
        }
        // Cau d.
        public void Tongtuoi()
        {
            var tongtuoi = dshs.Sum(hs => hs.tuoi);
            Console.WriteLine("Tong tuoi cua hoc sinh la :" + tongtuoi);
        }
        // Cau e.
        public void HSlontuoinhat()
        {
            int Maxtuoi = dshs.Max(hs => hs.tuoi);
            var HSmax = from hs in dshs
                        where hs.tuoi == Maxtuoi
                        select hs;
            Console.WriteLine("Hoc sinh co tuoi lon nhat la:");
            foreach (var hs in HSmax)
            {
                hs.hienthi();
            }
        }
        // Cau f.
        public void Sapxeptheotuoi()
        {
            var sapxep = from hs in dshs
                         orderby hs.tuoi ascending
                         select hs;
            Console.WriteLine("Danh sach hoc sinh sap xep theo tuoi tang dan la:");
            foreach (var hs in sapxep)
            {
                hs.hienthi();
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DSHS dshs = new DSHS();
            dshs.hienthids();
            dshs.HStuoiten15();
            dshs.HstenA();
            dshs.Tongtuoi();
            dshs.HSlontuoinhat();
            dshs.Sapxeptheotuoi();
            Console.ReadLine();
        }
    }
}
