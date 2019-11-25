using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class CdmPhong
    {
        private List<CPhong> arrPKS;

        internal List<CPhong> ArrPKS { get => arrPKS; set => arrPKS = value; }

        public CdmPhong(List<CPhong> arrPKS)
        {
            this.arrPKS = arrPKS;
        }
        public CdmPhong() : this(new List<CPhong>())
        {
        }
        public CPhong tim(int so)
        {
            CPhong nv = null;
            foreach (CPhong item in arrPKS)
            {
                if (item.Sophong == so)
                {
                    nv = item;
                    break;
                }
            }
            return nv;
        }
        public bool them(CPhong p)
        {
            CPhong a = tim(p.Sophong);
            if (a == null)
            {
                arrPKS.Add(p);
                return true;
            }
            return false;
        }
        public bool xoa(int so)
        {
            if (arrPKS.Count > 0)
            {
                CPhong a = tim(so);
                if (a != null)
                {
                    arrPKS.Remove(a);
                    return true;
                }
            }
            return false;
        }
        public bool sua(CPhong p)
        {
            if (arrPKS.Count > 0)
            {
                CPhong a = tim(p.Sophong);
                if (a != null)
                {
                    a.Gia = p.Gia;
                    a.Loaiphong = p.Loaiphong;
                    a.Trangthai = p.Trangthai;
                    return true;
                }
            }
            return false;
        }
    }
}
