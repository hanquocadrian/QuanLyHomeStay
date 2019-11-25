using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class CdmHistoryKH
    {
        private List<CHistory> arrLS;

        internal List<CHistory> ArrLS { get => arrLS; set => arrLS = value; }

        public CdmHistoryKH(List<CHistory> arrDP)
        {
            this.arrLS = arrLS;
        }
        public CdmHistoryKH() : this(new List<CHistory>())
        {
        }
        public void them(CHistory ls)
        {
            arrLS.Add(ls);
        }
    }
}
