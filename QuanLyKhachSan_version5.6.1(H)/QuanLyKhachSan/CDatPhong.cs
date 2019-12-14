﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    [Serializable]
    class CDatPhong 
    {
        private CKhachHang kh;
        private List<CPhong> phong;
        private DateTime m_Ngayden;
        private DateTime m_Ngaydi;

        public DateTime Ngayden { get => m_Ngayden; set => m_Ngayden = value; }
        public DateTime Ngaydi { get => m_Ngaydi; set => m_Ngaydi = value; }
        internal CKhachHang Kh { get => kh; set => kh = value; }
        internal List<CPhong> Phong { get => phong; set => phong = value; }

        public CDatPhong() : this(new CKhachHang(),new List<CPhong>(), DateTime.Now, DateTime.Now)
        {
        }

        public CDatPhong(CKhachHang kh, List<CPhong> phong, DateTime m_Ngayden, DateTime m_Ngaydi)
        {
            this.kh = kh;
            this.phong = phong;
            this.m_Ngayden = m_Ngayden;
            this.m_Ngaydi = m_Ngaydi;
        }

        public int SoNgayO()
        {
            TimeSpan s = m_Ngaydi - m_Ngayden;
            int kq = s.Days + 1;
            return kq;
        }
        public float ThanhTien(string loai)
        {
            float s = 0;
            foreach (CPhong p in phong)
            {
                if (string.Equals(p.Loaiphong, loai))
                {
                    s = Convert.ToSingle(p.Gia) * SoNgayO();
                    break;
                }
            }
            return s;
        }
        public float TongThanhTien()
        {
            // ik theo đoàn -> cùng ngày ở
            float s = 0;
            foreach (CPhong p in phong)
            {
                s += Convert.ToSingle(p.Gia) * SoNgayO();
            }
            return s;
        }
    }
}
