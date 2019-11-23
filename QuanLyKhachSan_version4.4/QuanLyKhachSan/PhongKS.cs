using System;
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

namespace QuanLyKhachSan
{
    public partial class PhongKS : Form
    {
        FormManager frmmng = new FormManager();
        private int i = -1;
        public PhongKS()
        {
            InitializeComponent();
        }

        public void hienthi()
        {
            lvwPKS.Items.Clear();
            foreach (CPhong phong in frmmng.Data.ArrPKS)
            {
                ListViewItem li = lvwPKS.Items.Add(phong.Sophong.ToString());
                li.SubItems.Add(phong.Loaiphong);
                li.SubItems.Add(phong.Trangthai);
                li.SubItems.Add(phong.Gia);
            }
        }

        public void hienthiPKS(int j)
        {
            CPhong phong = frmmng.Data.ArrPKS[j];
            txtSoPhong.Text = phong.Sophong.ToString();
            cbxLoaiphong.Text = phong.Loaiphong;
            cbxTrangthai.Text = phong.Trangthai;
            txtGia.Text = phong.Gia;
        }



        private void PhongKS_Load(object sender, EventArgs e)
        {
            frmmng.Data = new CData();
            frmmng.Data.OpenP("dsp.txt");
            if (frmmng.Data.ArrPKS.Count > 0)
                hienthi();
        }

        private void cbxLoaiphong_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxLoaiphong.SelectedIndex == 0)
            {
                txtGia.Text = "100.000 VND/ngày";
            }
            else if (cbxLoaiphong.SelectedIndex == 1)
            {
                txtGia.Text = "300.000 VND/ngày";
            }
            else
            {
                txtGia.Text = "600.000 VND/ngày";
            }
        }

        private void lvwPKS_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int j in lvwPKS.SelectedIndices)
            {
                i = j;
                hienthiPKS(j);
                break;
            }
        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmmng.Data.SaveP("dsp.txt");
            this.Hide();
            frmmng.ShowDialog();
            this.Close();
        }

        private void PhongKS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CPhong phong = new CPhong();
            phong.Sophong = Convert.ToInt32(txtSoPhong.Text);
            phong.Loaiphong = cbxLoaiphong.Text;
            phong.Trangthai = cbxTrangthai.Text;
            phong.Gia = txtGia.Text;
            frmmng.Data.ArrPKS.Add(phong);
            i++;
            hienthi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (frmmng.Data.ArrPKS.Count > 0)
            {
                frmmng.Data.ArrPKS.RemoveAt(i);
                i--;
                if (i < 0 && frmmng.Data.ArrPKS.Count > 0)
                {
                    i = 0;
                }
                if (i >= 0)
                {
                    hienthiPKS(i);
                }
                hienthi();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CPhong phong = (CPhong)frmmng.Data.ArrPKS[i];
            phong.Sophong = Convert.ToInt32(txtSoPhong.Text);
            phong.Loaiphong = cbxLoaiphong.Text;
            phong.Trangthai = cbxTrangthai.Text;
            phong.Gia = txtGia.Text;
            hienthi();
        }
    }
}
