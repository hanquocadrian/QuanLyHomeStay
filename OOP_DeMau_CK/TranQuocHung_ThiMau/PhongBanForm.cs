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
        public void OpenPB(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Xl.DmPhongBan = (Hashtable)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                fs.Close();
                //throw;
            }
        }
        public void SavePB(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Xl.DmPhongBan);
                fs.Close();
            }
            catch (Exception)
            {
                fs.Close();
                throw;
            }
        }
        #endregion
        public PhongBanForm()
        {
            InitializeComponent();
            OpenPB("dspb.txt");
            if (Xl.DmPhongBan.Count > 0)
                hienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            PhongBan p = new PhongBan();
            p.MaPhong1 = txtMP.Text;
            p.TenPhong1 = txtTP.Text;

            if (Xl.them(p))
            {
                hienThi();
                SavePB("dspb.txt");
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
                    SavePB("dspb.txt");
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
