using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    [Serializable]
    class CBill
    {
        private CKhachHang m_kh;
        private CDatPhong m_dp;
        private CDatDichVu m_ddv;
        private DateTime m_ngaythanhtoan;
        private bool m_isdathanhtoantrue;

        public CBill(CKhachHang kh, CDatPhong dp, CDatDichVu ddv, DateTime ngaythanhtoan)
        {
            m_kh = kh;
            m_dp = dp;
            m_ddv = ddv;
            m_ngaythanhtoan = ngaythanhtoan;
            m_isdathanhtoantrue = false;
        }

        public CBill(): this(new CKhachHang(),new CDatPhong(),new CDatDichVu(),DateTime.Now)
        {
        }

        public DateTime Ngaythanhtoan { get => m_ngaythanhtoan; set => m_ngaythanhtoan = value; }
        internal CKhachHang Kh { get => m_kh; set => m_kh = value; }
        internal CDatPhong Dp { get => m_dp; set => m_dp = value; }
        internal CDatDichVu Ddv { get => m_ddv; set => m_ddv = value; }
        public bool Isdathanhtoantrue { get => m_isdathanhtoantrue; set => m_isdathanhtoantrue = value; }

        public float tinhTongThanhTien()
        {
            if (!m_isdathanhtoantrue)
            {
                if (m_dp == null && m_ddv == null) return 0;
                else if (m_dp == null) return m_ddv.tinhTongGiaTien();
                else if (m_ddv == null) return m_dp.TongThanhTien();
                return m_dp.TongThanhTien() + m_ddv.tinhTongGiaTien();
            }
            else
            {
                if (m_ddv == null) return 0;
                else return m_ddv.tinhTongGiaTien();
            }
        }
    }
}
