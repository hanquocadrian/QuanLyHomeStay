using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace TranQuocHung_ThiMau
{
    public partial class PhongBanForm : Form
    {
        #region Attributes
        private CdmPhongBan xl = new CdmPhongBan();
        public static Hashtable dspb;

        internal CdmPhongBan Xl { get => xl; set => xl = value; }
        #endregion
        #region Method
        public void hienThi()
        {
            lvwPB.Items.Clear();
            foreach (DictionaryEntry item in Xl.DmPhongBan)
            {
                PhongBan p = (PhongBan)item.Value;
                ListViewItem li = lvwPB.Items.Add(p.MaPhong1);
                li.SubItems.Add(p.TenPhong1);
            }
        }
        public void hienThiPB(string ma)
        {
            PhongBan a = Xl.tim(ma);
            txtMP.Text = a.MaPhong1;
            txtTP.Text = a.TenPhong1;
        }
        #endregion
        public PhongBanForm()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhongBan p = new PhongBan();
            p.MaPhong1 = txtMP.Text;
            p.TenPhong1 = txtTP.Text;

            if (Xl.them(p))
            {
                hienThi();
                dspb = Xl.DmPhongBan;
            }
            else
                MessageBox.Show("Trùng mã phòng", "Error");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (int item in lvwPB.SelectedIndices)
            {
                if (Xl.xoa(lvwPB.Items[item].Text))
                {
                    hienThi();
                    dspb = Xl.DmPhongBan;
                }
                break;
            }
        }

        private void lvwPB_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int item in lvwPB.SelectedIndices)
            {
                hienThiPB(lvwPB.Items[item].Text);
                break;
            }
        }
    }
}
