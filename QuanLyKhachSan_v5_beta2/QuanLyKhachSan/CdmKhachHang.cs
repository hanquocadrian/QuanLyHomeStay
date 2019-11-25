using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class CdmKhachHang
    {
        private List<CKhachHang> arrKH;

        internal List<CKhachHang> ArrKH { get => arrKH; set => arrKH = value; }

        public CdmKhachHang(List<CKhachHang> arrKH)
        {
            this.arrKH = arrKH;
        }
        public CdmKhachHang() : this(new List<CKhachHang>())
        {
        }
        public CKhachHang tim(int cmnd)
        {
            CKhachHang nv = null;
            foreach (CKhachHang item in arrKH)
            {
                if (item.CMND == cmnd)
                {
                    nv = item;
                    break;
                }
            }
            return nv;
        }
        public bool them(CKhachHang kh)
        {
            CKhachHang a = tim(kh.CMND);
            if (a == null)
            {
                arrKH.Add(kh);
                return true;
            }
            return false;
        }
        public bool xoa(int cmnd)
        {
            if (arrKH.Count > 0)
            {
                CKhachHang a = tim(cmnd);
                if (a != null)
                {
                    arrKH.Remove(a);
                    return true;
                }
            }
            return false;
        }
        public bool sua(CKhachHang kh)
        {
            if (arrKH.Count > 0)
            {
                CKhachHang a = tim(kh.CMND);
                if (a != null)
                {
                    a.Gioitinh = kh.Gioitinh;
                    a.Hoten = kh.Hoten;
                    a.Quoctich = kh.Quoctich;
                    a.Sdt = kh.Sdt;
                    a.Tuoi = kh.Tuoi;
                    return true;
                }
            }
            return false;
        }
    }
}
