using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranQuocHung_ThiMau
{
    class NhanVien
    {
        private string Msnv;
        private string HoTen;
        private double LuongCb;
        private double HeSo;

        public string Msnv1 { get => Msnv; set => Msnv = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public double LuongCb1 { get => LuongCb; set => LuongCb = value; }
        public double HeSo1 { get => HeSo; set => HeSo = value; }

        public NhanVien(string msnv, string hoTen, double luongCb, double heSo)
        {
            Msnv1 = msnv;
            HoTen1 = hoTen;
            LuongCb1 = luongCb;
            HeSo1 = heSo;
        }

        public NhanVien():this("","",0,0)
        {
        }

        public double Luong()
        {
            return LuongCb * HeSo;
        }
    }
}
