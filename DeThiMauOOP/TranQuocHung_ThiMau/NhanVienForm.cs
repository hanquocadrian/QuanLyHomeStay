using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranQuocHung_ThiMau
{
    public partial class NhanVienForm : Form
    {
        #region Attributes
        private PhongBan xlnv = new PhongBan();
        PhongBanForm frmpb = new PhongBanForm();
        public Hashtable dspb;
        #endregion
        #region Method
        private void hienThi(PhongBan p)
        {
            lvwNV.Items.Clear();
            foreach (DictionaryEntry item in p.DmNhanVien)
            {
                NhanVien nv = (NhanVien)item.Value;
                ListViewItem li = lvwNV.Items.Add(nv.Msnv1);
                li.SubItems.Add(nv.HoTen1);
                li.SubItems.Add(nv.LuongCb1.ToString());
                li.SubItems.Add(nv.HeSo1.ToString());
                li.SubItems.Add(nv.Luong().ToString());
            }
        }
        private void hienThi(NhanVien a)
        {
            txtHoTen.Text = a.HoTen1;
            txtMSNV.Text = a.Msnv1;
            txtLCB.Text = a.LuongCb1.ToString();
            txtHS.Text = a.HeSo1.ToString();
        }
        public string timMaPB(string ten)
        {
            string mapb = "";
            foreach (DictionaryEntry item in frmpb.Xl.DmPhongBan)
            {
                PhongBan pb = (PhongBan)item.Value;
                if(string.Equals(pb.TenPhong1,ten))
                {
                    mapb = pb.MaPhong1;
                    break;
                }
            }
            return mapb;
        }
        #endregion
        public NhanVienForm()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.Msnv1 = txtMSNV.Text;
            nv.HoTen1 = txtHoTen.Text;
            nv.HeSo1 = Convert.ToDouble(txtHS.Text);
            nv.LuongCb1 = Convert.ToDouble(txtLCB.Text);

            if (string.Compare(cboTP.SelectedItem.ToString(), "") == 0) return;
            
            string mapb = timMaPB(cboTP.SelectedItem.ToString());
            PhongBan a = frmpb.Xl.tim(mapb);
            if(a!=null)
            {
                if (a.themNhanVien(nv))
                {
                    hienThi(a);
                    frmpb.SavePB("dspb.txt");
                }
                else
                    MessageBox.Show("Trùng mã NV", "Error");
            }
            else
                    MessageBox.Show("Chưa tìm thấy Phòng", "Error");
                
        }

        private void cboTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            txtMSNV.Text = "";
            txtLCB.Text = "";
            txtHS.Text = "";
            PhongBan p = null;
            foreach (DictionaryEntry item in frmpb.Xl.DmPhongBan)
            {
                PhongBan ip = (PhongBan)item.Value;
                if(string.Equals(ip.TenPhong1,cboTP.SelectedItem.ToString()))
                {
                    p = ip;
                }
            }
            if (p != null)
                hienThi(p);
        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            frmpb.OpenPB("dspb.txt");
            if (frmpb.Xl.DmPhongBan.Count > 0)
            {
                cboTP.Items.Clear();
                foreach (DictionaryEntry item in frmpb.Xl.DmPhongBan)
                {
                    PhongBan pb = (PhongBan)item.Value;
                    cboTP.Items.Add(pb.TenPhong1);
                }
            }
            else
                MessageBox.Show("Chưa tìm thấy Phòng", "Error");
        }

        private void NhanVienForm_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mapb = timMaPB(cboTP.SelectedItem.ToString());
            string manv = "";
            foreach(int j in lvwNV.SelectedIndices)
            {
                manv = lvwNV.Items[j].Text;
                break;
            }
            PhongBan p = frmpb.Xl.tim(mapb);
            if(p!=null)
            {
                if (p.xoaNhanVien(manv))
                {
                    hienThi(p);
                    frmpb.SavePB("dspb.txt");
                }
                else
                    MessageBox.Show("Chưa tìm thấy NV đó", "Error");
            }
            else
                MessageBox.Show("Chưa tìm thấy Phòng", "Error");
        }

        private void lvwNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int j in lvwNV.SelectedIndices)
            {
                string mapb = timMaPB(cboTP.SelectedItem.ToString());
                string manv = "";
                manv = lvwNV.Items[j].Text;
                PhongBan p = frmpb.Xl.tim(mapb);
                if (p != null)
                {
                    NhanVien nv = p.tim(manv);
                    if (nv != null)
                    {
                        hienThi(nv);
                    }
                    else
                        MessageBox.Show("Chưa tìm thấy NV đó", "Error");
                }
                else
                    MessageBox.Show("Chưa tìm thấy Phòng", "Error");
                break;
            }
        }
    }
}
