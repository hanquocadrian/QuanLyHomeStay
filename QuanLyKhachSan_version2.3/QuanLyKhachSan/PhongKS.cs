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
        private List<CPhong> arrPKS;
        private int i = -1;

        int gpdon, gpdoi, gpdb;
        public PhongKS()
        {
            InitializeComponent();
        }

        public void hienthi()
        {
            lvwPKS.Items.Clear();
            foreach (CPhong phong in arrPKS)
            {
                ListViewItem li = lvwPKS.Items.Add(phong.Sophong.ToString());
                li.SubItems.Add(phong.Loaiphong);
                li.SubItems.Add(phong.Trangthai);
                li.SubItems.Add(phong.Gia.ToString());
            }
        }

        public void hienthiPKS(int j)
        {
            CPhong phong = arrPKS[j];
            txtSoPhong.Text = phong.Sophong.ToString();
            cbxLoaiphong.Text = phong.Loaiphong;
            cbxTrangthai.Text = phong.Trangthai;
            txtGia.Text = phong.Gia.ToString();
        }

        public void OpenP(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                arrPKS = (List<CPhong>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("No Data PKS", "Error");
            }
        }

        private CPhong timPDon()
        {
            CPhong pdon = null; 
            if(arrPKS.Count>0)
            {
                foreach(CPhong p in arrPKS)
                {
                    if (string.Compare(p.Loaiphong, "Đơn") == 0)
                    {
                        pdon = p;
                        break;
                    }
                }
            }
            return pdon;
        }
        private CPhong timPDoi()
        {
            CPhong pdoi = null;
            if (arrPKS.Count > 0)
            {
                foreach (CPhong p in arrPKS)
                {
                    if (string.Compare(p.Loaiphong, "Đôi") == 0)
                    {
                        pdoi = p;
                        break;
                    }
                }
            }
            return pdoi;
        }
        private CPhong timPDB()
        {
            CPhong pdb = null;
            if (arrPKS.Count > 0)
            {
                foreach (CPhong p in arrPKS)
                {
                    if (string.Compare(p.Loaiphong, "Đơn") == 0)
                    {
                        pdb = p;
                        break;
                    }
                }
            }
            return pdb;
        }
        private void PhongKS_Load(object sender, EventArgs e)
        {
            arrPKS = new List<CPhong>();
            OpenP("dsp.txt");
            if (arrPKS.Count > 0)
            {
                hienthi();
                CPhong pdon = timPDon();
                setupGiaPhong(pdon.Loaiphong, pdon.Gia);
                CPhong pdoi = timPDoi();
                setupGiaPhong(pdoi.Loaiphong, pdoi.Gia);
                CPhong pdb = timPDB();
                setupGiaPhong(pdb.Loaiphong, pdb.Gia);
            }

        }

        private void cbxLoaiphong_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxLoaiphong.SelectedIndex == 0)
            {
                //txtGia.Text = "100.000 VND/ngày";
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
                //txtGia.Text = "300.000 VND/ngày";
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
                //txtGia.Text = "600.000 VND/ngày";
                try
                {
                    txtGia.Text = gpdb.ToString();
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

        public void SaveP(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrPKS);
                fs.Close();
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("Save Ko OK", "Error");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            SaveP("dsp.txt");
            this.Hide();
            frmmng.ShowDialog();
            this.Close();
        }

        private void PhongKS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void setupGiaPhong(string loaiphong,int giaphong)
        {
            if (string.Compare(loaiphong, "Đơn") == 0 && giaphong != gpdon)
                gpdon = giaphong;
            else if (string.Compare(loaiphong, "Đôi") == 0 && giaphong != gpdoi)
                gpdoi = giaphong;
            else if (string.Compare(loaiphong, "Cao cấp") == 0 && giaphong != gpdoi)
                gpdb = giaphong;
        }

        public void syncGiaPhong(string loaiphong)
        {
            if (arrPKS.Count > 0)
            {
                foreach (CPhong p in arrPKS)
                {
                    if(string.Compare(loaiphong, p.Loaiphong) == 0)
                    {
                        if (string.Compare(loaiphong, "Đơn") == 0 && gpdon != p.Gia)
                            p.Gia = gpdon;
                        else if (string.Compare(loaiphong, "Đôi") == 0 && gpdoi != p.Gia)
                            p.Gia = gpdoi;
                        else if (string.Compare(loaiphong, "Cao cấp") == 0 && gpdoi != p.Gia)
                            p.Gia = gpdb;
                    }
                }
            }
        }

        public bool checkSameSoPhong(int sp)
        {
            bool kq = false;
            if (arrPKS.Count > 0)
            { 
                foreach(CPhong p in arrPKS)
                {
                    if(sp==p.Sophong)
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
            if (checkSameSoPhong(Convert.ToInt32(txtSoPhong.Text)))
                return;
            phong.Sophong = Convert.ToInt32(txtSoPhong.Text);
            phong.Loaiphong = cbxLoaiphong.Text;
            phong.Trangthai = cbxTrangthai.Text;
            phong.Gia = int.Parse(txtGia.Text);
            arrPKS.Add(phong);
            i++;

            setupGiaPhong(phong.Loaiphong, phong.Gia);
            syncGiaPhong(phong.Loaiphong);
            hienthi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (arrPKS.Count > 0)
            {
                arrPKS.RemoveAt(i);
                i--;
                if (i < 0 && arrPKS.Count > 0)
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
            CPhong phong = (CPhong)arrPKS[i];
            phong.Sophong = Convert.ToInt32(txtSoPhong.Text);
            phong.Loaiphong = cbxLoaiphong.Text;
            phong.Trangthai = cbxTrangthai.Text;
            phong.Gia = int.Parse(txtGia.Text);

            setupGiaPhong(phong.Loaiphong, phong.Gia);
            syncGiaPhong(phong.Loaiphong);
            hienthi();
        }
    }
}
