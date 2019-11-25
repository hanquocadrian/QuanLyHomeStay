using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class CdmDatPhong
    {
        private List<CDatPhong> arrDP;

        internal List<CDatPhong> ArrDP { get => arrDP; set => arrDP = value; }

        public CdmDatPhong(List<CDatPhong> arrDP)
        {
            this.arrDP = arrDP;
        }
        public CdmDatPhong() : this(new List<CDatPhong>())
        {
        }
        public CDatPhong tim(int cmnd)
        {
            CDatPhong nv = null;
            foreach (CDatPhong item in arrDP)
            {
                if (item.Kh.CMND == cmnd)
                {
                    nv = item;
                    break;
                }
            }
            return nv;
        }
        public bool them(CDatPhong dp)
        {
            CDatPhong a = tim(dp.Kh.CMND);
            if (a == null)
            {
                arrDP.Add(dp);
                return true;
            }
            return false;
        }
        public bool xoa(int cmnd)
        {
            if (arrDP.Count > 0)
            {
                CDatPhong a = tim(cmnd);
                if (a != null)
                {
                    arrDP.Remove(a);
                    return true;
                }
            }
            return false;
        }
        public bool sua(CDatPhong dp)
        {
            if (arrDP.Count > 0)
            {
                CDatPhong a = tim(dp.Kh.CMND);
                if (a != null)
                {
                    a.Phong.Sophong = dp.Phong.Sophong;
                    a.Phong.Loaiphong = dp.Phong.Loaiphong;
                    a.Ngayden = dp.Ngayden;
                    a.Ngaydi = dp.Ngaydi;
                    return true;
                }
            }
            return false;
        }
    }
}
