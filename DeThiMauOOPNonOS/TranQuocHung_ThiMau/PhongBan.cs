using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranQuocHung_ThiMau
{
    class PhongBan
    {
        private string MaPhong;
        private string TenPhong;
        private Hashtable dmNhanVien;

        public string MaPhong1 { get => MaPhong; set => MaPhong = value; }
        public string TenPhong1 { get => TenPhong; set => TenPhong = value; }
        public Hashtable DmNhanVien { get => dmNhanVien; set => dmNhanVien = value; }

        public PhongBan(string maPhong, string tenPhong, Hashtable dmNhanVien)
        {
            MaPhong1 = maPhong;
            TenPhong1 = tenPhong;
            this.DmNhanVien = dmNhanVien;
        }

        public PhongBan():this("","",new Hashtable())
        {
        }

        public NhanVien tim(string ma)
        {
            return (NhanVien)dmNhanVien[ma];
        }
        public bool themNhanVien(NhanVien nv)
        {
            try
            {
                NhanVien a = tim(nv.Msnv1);
                if (a == null)
                {
                    dmNhanVien.Add(nv.Msnv1, nv);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoaNhanVien(string ma)
        {
            try
            {
                NhanVien a = tim(ma);
                if (a != null)
                {
                    dmNhanVien.Remove(a.Msnv1);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
