using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class CdmNhanVien
    {
        private List<CNhanVien> arrNV;

        internal List<CNhanVien> ArrNV { get => arrNV; set => arrNV = value; }

        public CdmNhanVien(List<CNhanVien> arrNV)
        {
            this.arrNV = arrNV;
        }
        public CdmNhanVien() : this(new List<CNhanVien>())
        {
        }
        public CNhanVien tim(string ma)
        {
            CNhanVien nv = null;
            foreach (CNhanVien item in arrNV)
            {
                if(string.Equals(item.MaNV,ma))
                {
                    nv = item;
                    break;
                }
            }
            return nv;
        }
        public bool them(CNhanVien nv)
        {
            CNhanVien a = tim(nv.MaNV);
            if(a==null)
            {
                arrNV.Add(nv);
                return true;
            }
            return false;
        }
        public bool xoa(string ma)
        {
            if(arrNV.Count>0)
            {
                CNhanVien a = tim(ma);
                if(a!=null)
                {
                    arrNV.Remove(a);
                    return true;
                }
            }
            return false;
        }
        public bool sua(CNhanVien nv)
        {
            if(arrNV.Count>0)
            {
                CNhanVien a = tim(nv.MaNV);
                if(a!=null)
                {
                    a.HoTen = nv.HoTen;
                    a.ChucVu = nv.ChucVu;
                    a.GioiTinh = nv.GioiTinh;
                    a.Luong = nv.Luong;
                    a.NgaySinh = nv.NgaySinh;
                    a.QueQuan = nv.QueQuan;
                    a.Sdt = nv.Sdt;
                    return true;
                }
            }
            return false;
        }
    }
}
