using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranQuocHung_ThiMau
{
    class CdmPhongBan
    {
        private Hashtable dmPhongBan;

        public Hashtable DmPhongBan { get => dmPhongBan; set => dmPhongBan = value; }

        public CdmPhongBan(Hashtable dmPhongBan)
        {
            this.DmPhongBan = dmPhongBan;
        }

        public CdmPhongBan():this(new Hashtable())
        {
        }

        public PhongBan tim(string ma)
        {
            return (PhongBan)dmPhongBan[ma];
        }

        public bool them(PhongBan p)
        {
            try
            {
                PhongBan a = tim(p.MaPhong1);
                if (a == null)
                {
                    dmPhongBan.Add(p.MaPhong1, p);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool xoa(string ma)
        {
            try
            {
                PhongBan a = tim(ma);
                if (a != null)
                {
                    dmPhongBan.Remove(a.MaPhong1);
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
