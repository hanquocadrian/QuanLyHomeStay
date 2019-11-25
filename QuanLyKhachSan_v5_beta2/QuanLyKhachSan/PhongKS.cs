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
        CdmPhong xl = new CdmPhong();
        private int i = -1;

        int gpdon, gpdoi, gpcc;
        public PhongKS()
        {
            InitializeComponent();
        }

        public void hienthi()
        {
            lvwPKS.Items.Clear();
            foreach (CPhong phong in xl.ArrPKS)
            {
                ListViewItem li = lvwPKS.Items.Add(phong.Sophong.ToString());
                li.SubItems.Add(phong.Loaiphong);
                li.SubItems.Add(phong.Trangthai);
                li.SubItems.Add(phong.Gia.ToString());
            }
        }

        public void hienthiPKS(int j)
        {
            CPhong phong = xl.ArrPKS[j];
            txtSoPhong.Text = phong.Sophong.ToString();
            cbxLoaiphong.Text = phong.Loaiphong;
            cbxTrangthai.Text = phong.Trangthai;
            txtGia.Text = phong.Gia.ToString();
        }

        private CPhong TimpDon()
        {
            CPhong pdon = null;
            if (xl.ArrPKS.Count>0)
            {
                foreach (CPhong p  in xl.ArrPKS)
                {
                    if (string.Compare(p.Loaiphong,"Đơn")==0)
                    {
                        pdon = p;
                        break;
                    }
                }
            }
            return pdon;
        }

        private CPhong TimpDoi()
        {
            CPhong pdoi = null;
            if (xl.ArrPKS.Count>0)
            {
                foreach (CPhong p  in xl.ArrPKS)
                {
                    if (string.Compare(p.Loaiphong,"Đôi")==0)
                    {
                        pdoi = p;
                        break;
                    }
                }
            }
            return pdoi;
        }

        private CPhong TimpCC()
        {
            CPhong pCC = null;
            if (xl.ArrPKS.Count > 0)
            {
                foreach (CPhong p in xl.ArrPKS)
                {
                    if (string.Compare(p.Loaiphong, "Cao cấp") == 0)
                    {
                        pCC = p;
                        break;
                    }
                }
            }
            return pCC;
        }

        public void setupGiaPhong(string loaiphong,int giaphong)
        {
            if (string.Compare(loaiphong,"Đơn")==0 && giaphong!=gpdon)
                gpdon = giaphong;
            if (string.Compare(loaiphong, "Đôi") == 0 && giaphong != gpdoi)
                gpdoi = giaphong;
            if (string.Compare(loaiphong, "Cao cấp") == 0 && giaphong != gpcc)
                gpcc = giaphong;
        }

        public void syncGiaPhong(string loaiphong)
        {
            if (xl.ArrPKS.Count>0)
            {
                foreach (CPhong p  in xl.ArrPKS)
                {
                    if (string.Compare(p.Loaiphong,loaiphong)==0)
                    {
                        if (string.Compare(loaiphong, "Đơn") == 0 && gpdon!=p.Gia)
                        {
                            p.Gia = gpdon;
                        }
                        else if (string.Compare(loaiphong, "Đôi") == 0 && gpdoi != p.Gia)
                        {
                            p.Gia = gpdoi;
                        }
                        else if (string.Compare(loaiphong,"Cao cấp")==0 && gpcc != p.Gia)
                        {
                            p.Gia = gpcc;
                        }
                    }
                }
            }
        }

        private void PhongKS_Load(object sender, EventArgs e)
        {
            frmmng.Data.OpenP("dsp.txt");
            xl.ArrPKS = frmmng.Data.ArrPKS;
            if (xl.ArrPKS.Count > 0)
            {
                hienthi();
                CPhong pdon = TimpDon();
                setupGiaPhong(pdon.Loaiphong, pdon.Gia);
                CPhong pdoi = TimpDoi();
                setupGiaPhong(pdoi.Loaiphong, pdoi.Gia);
                CPhong pcc = TimpCC();
                setupGiaPhong(pcc.Loaiphong, pcc.Gia);
            }
        }

        private void cbxLoaiphong_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxLoaiphong.SelectedIndex == 0)
            {
                try
                {
                    txtGia.Text = gpdon.ToString();
                }
                catch (Exception)
                {
                    txtGia.Text = "0";
                }
            }
            else if (cbxLoaiphong.SelectedIndex == 1)
            {
                try
                {
                    txtGia.Text = gpdoi.ToString();
                }
                catch (Exception)
                {
                    txtGia.Text = "0";
                }
            }
            else
            {
                try
                {
                    txtGia.Text = gpcc.ToString();
                }
                catch (Exception)
                {
                    txtGia.Text = "0";
                }
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
            frmmng.Data.ArrPKS = xl.ArrPKS;
            frmmng.Data.SaveP("dsp.txt");
            this.Hide();
            frmmng.ShowDialog();
            this.Close();
        }

        private void PhongKS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public bool checkSoPhong(int sp)
        {
            bool kq = false;
            if (xl.ArrPKS.Count>0)
            {
                foreach (CPhong p  in xl.ArrPKS)
                {
                    if (sp==p.Sophong)
                    {
                        kq = true;
                        break;
                    }
                }
            }
            return kq;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CPhong phong = new CPhong();
            phong.Sophong = Convert.ToInt32(txtSoPhong.Text);
            phong.Loaiphong = cbxLoaiphong.Text;
            phong.Trangthai = cbxTrangthai.Text;
            phong.Gia = int.Parse(txtGia.Text) ;
            if (xl.them(phong))
            {
                i++;
                setupGiaPhong(phong.Loaiphong, phong.Gia);
                syncGiaPhong(phong.Loaiphong);
                hienthi();
            }
            else
                MessageBox.Show("Trùng Số Phòng", "Error");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (int j in lvwPKS.SelectedIndices)
            {
                if (xl.xoa(int.Parse(lvwPKS.Items[j].Text)))
                    hienthi();
                else
                    MessageBox.Show("Hết Data or Không tìm thấy Số Phòng để xóa", "Error");
                break;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CPhong phong = (CPhong)frmmng.Data.ArrPKS[i];
            phong.Sophong = Convert.ToInt32(txtSoPhong.Text);
            phong.Loaiphong = cbxLoaiphong.Text;
            phong.Trangthai = cbxTrangthai.Text;
            phong.Gia = int.Parse(txtGia.Text);


            if (xl.sua(phong))
            {
                setupGiaPhong(phong.Loaiphong, phong.Gia);
                syncGiaPhong(phong.Loaiphong);
                hienthi();
            }
            else
                MessageBox.Show("Hết Data or Sai Mã", "Error");

        }
    }
}
