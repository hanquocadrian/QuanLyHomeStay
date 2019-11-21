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
    public partial class DatPhong : Form
    {
        #region Attribute
        FormManager frmmng = new FormManager();
        private List<CDatPhong> arrDP;
        private int i = -1;

        private List<CKhachHang> arrKH;
        private List<CPhong> arrPKS;

        private string remember_tenkh;
        private int remember_cmnd;
        #endregion

        public DatPhong()
        {
            InitializeComponent();
        }

        public void OpenKH(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                arrKH = (List<CKhachHang>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("No Data KH", "Error");
            }
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

        public void ShowDataTenKH()
        {
            cbxHoten.Items.Clear();
            if(arrKH.Count>0)
            {
                foreach(CKhachHang kh in arrKH)
                {
                    cbxHoten.Items.Add(kh.Hoten+" ("+kh.CMND+")");
                }
            }
        }

        public void OpenDP(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                arrDP = (List<CDatPhong>)bf.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("No Data Đặt phòng", "Error");
            }
        }

        private void DatPhong_Load(object sender, EventArgs e)
        {
            arrDP = new List<CDatPhong>();
            OpenKH("dskh.txt");
            OpenP("dsp.txt");
            OpenDP("dsdp.txt");

            hienthi();
            ShowDataTenKH();
            cbxHoten.Select();
        }

        private void cbxHoten_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbxCMND.Items.Clear();
            //foreach (CKhachHang kh in arrKH)
            //{
            //    if (string.Compare(kh.Hoten, cbxHoten.Text) == 0)
            //        cbxCMND.Items.Add(kh.CMND);
            //}
            //cbxCMND.SelectedIndex = -1;
        }

        public void hienthi()
        {
            lvwDP.Items.Clear();
            foreach (CDatPhong dp  in arrDP)
            {
                ListViewItem li = lvwDP.Items.Add(dp.Kh.Hoten);
                li.SubItems.Add(dp.Kh.CMND.ToString());
                li.SubItems.Add(dp.Phong.Sophong.ToString());
                li.SubItems.Add(dp.Ngayden.ToShortDateString());
                li.SubItems.Add(dp.Ngaydi.ToShortDateString());
                li.SubItems.Add(dp.Phong.Loaiphong);
                li.SubItems.Add(dp.SoNgayO().ToString());
                li.SubItems.Add(dp.ThanhTien().ToString());
            }
        }

        public void hienthiDP(int j)
        {
            CDatPhong dp = (CDatPhong)arrDP[j];
            cbxHoten.Text = dp.Kh.Hoten+" ("+dp.Kh.CMND.ToString()+')';
            //cbxCMND.Text = dp.Kh.CMND.ToString();
            dtpNgayden.Value = dp.Ngayden;
            dtpNgaydi.Value = dp.Ngaydi;
            txtSoPhong.Text = dp.Phong.Sophong.ToString();
            cbxLoaiphong.Text = dp.Phong.Loaiphong;
            txtSoNgayO.Text = dp.SoNgayO().ToString();
            txtThanhTien.Text = dp.ThanhTien().ToString();
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

        public void setupBookedP(int sophong,string loaiphong)
        {
            foreach(CPhong p in arrPKS)
            {
                if (string.Compare(p.Loaiphong, loaiphong) == 0 && p.Sophong == sophong)
                    p.Trangthai = "Booked";
            }
            SaveP("dsp.txt");
        }

        public void CleanDP()
        {
            cbxHoten.Text="";
            //cbxCMND.Text = "";
            txtSoPhong.Text = "";
            txtSoNgayO.Text = "";
            cbxLoaiphong.Text = "";
            txtThanhTien.Text = "";
        }

        public void layTenKHVaCMND(string str)
        {
            string temp = str;
            int charfrom = temp.IndexOf('(', 0) + 1;
            int charto = temp.IndexOf(')', 0) - 1;
            //  h u n g _ ( 1 2 3 4 )
            //  0 1 2 3 4 5 6 7 8 9 10
            int charlenght = charto - charfrom + 1;
            remember_cmnd = int.Parse(temp.Substring(charfrom, charlenght));
            remember_tenkh = temp.Substring(0, charfrom - 3 + 1);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (radSetup.Checked == true)
            {
                if (txtSoPhong.Text == "")
                {
                    MessageBox.Show("Các TH:\n" +
                        "- NV chưa chọn Loại Phòng để có số Phòng\n" +
                        "- Loại Phòng đó đã Hết", "Error");
                    return;
                }


                layTenKHVaCMND(cbxHoten.Text);
                string hotenkh = remember_tenkh;
                int socmnd = remember_cmnd;
                if (arrDP.Count>0)
                {
                    foreach(CDatPhong dp_old in arrDP)
                    {
                        if(string.Equals(hotenkh,dp_old.Kh.Hoten)&&socmnd==dp_old.Kh.CMND)
                        {
                            MessageBox.Show("Khách Hàng đó đã đặt phòng rồi", "Error");
                            return;
                        }
                    }
                }

                int sophong = int.Parse(txtSoPhong.Text);
                string loaiphong = cbxLoaiphong.Text;

                DateTime ngayden = dtpNgayden.Value;
                DateTime ngaydi = dtpNgaydi.Value;

                CDatPhong dp = new CDatPhong();
                dp.Kh.Hoten = hotenkh;
                dp.Kh.CMND = socmnd;
                dp.Phong.Sophong = sophong;
                dp.Phong.Loaiphong = loaiphong;
                dp.Ngayden = ngayden;
                dp.Ngaydi = ngaydi;

                arrDP.Add(dp);
                txtSoNgayO.Text = dp.SoNgayO().ToString();
                txtThanhTien.Text = dp.ThanhTien().ToString();
                setupBookedP(dp.Phong.Sophong, dp.Phong.Loaiphong);

                i++;
                CleanDP();
                hienthi();
            }
        }

        private void cbxLoaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radSetup.Checked == true)
            {
                if (cbxLoaiphong.Text == "")
                {
                    MessageBox.Show("Chưa chọn Loại Phòng", "Error");
                    return;
                }
                bool checkemptyp = false;
                foreach (CPhong p in arrPKS)
                {
                    if (string.Compare(p.Loaiphong, cbxLoaiphong.Text) == 0 && string.Compare(p.Trangthai, "Empty") == 0)
                    {
                        txtSoPhong.Text = p.Sophong.ToString();
                        checkemptyp = true;
                    }
                }
                if (!checkemptyp)
                    txtSoPhong.Text = "";
            }
        }

        public void SaveKH(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrKH);
                fs.Close();
            }
            catch (Exception)
            {
                //throw;
                MessageBox.Show("Save Ko OK", "Error");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //  KH Hết đi về sau khi ở Hotel xong
            //  Tìm Phòng mà KH ở -> Empty
            //  Khách về -> Xóa Khách đó
            //  Xóa data đặt Phòng

            if (arrDP.Count <= 0)
            {
                MessageBox.Show("No Data Đặt phòng", "Error");
                return;
            }
            CDatPhong dp = arrDP[i];
            foreach (CPhong p in arrPKS)
            {
                if (p.Sophong == dp.Phong.Sophong && string.Compare(p.Loaiphong, dp.Phong.Loaiphong) == 0)
                {
                    p.Trangthai = "Empty";
                    SaveP("dsp.txt");
                    break;
                }
            }
            foreach (CKhachHang kh in arrKH)
            {
                if(kh.CMND==dp.Kh.CMND)
                {
                    arrKH.Remove(kh);
                    SaveKH("dskh.txt");
                    break;
                }
            }
            ShowDataTenKH();
            arrDP.RemoveAt(i);
            i--;
            if (i < 0 && arrDP.Count > 0) i = 0;
            if (i >= 0)
                hienthiDP(i);
            hienthi();
        }

        public void SaveDP(string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arrDP);
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
            SaveDP("dsdp.txt");
            this.Hide();
            frmmng.ShowDialog();
            this.Close();
        }

        private void lvwDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int j in lvwDP.SelectedIndices)
            {
                i = j;
                hienthiDP(i);
                break;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //  Vị trí đặt Phòng Thứ i của P cũ sẽ bị quên ik -> Empty
            // Setup như nhập, bỏ ik clearDP vs arr Add
            if (arrDP.Count > 0 && radSetup.Checked == true)
            {
                CDatPhong dp_old = arrDP[i];
                foreach (CPhong p in arrPKS)
                {
                    if (p.Sophong == dp_old.Phong.Sophong && string.Compare(p.Loaiphong, dp_old.Phong.Loaiphong) == 0)
                    {
                        p.Trangthai = "Empty";
                        SaveP("dsp.txt");
                        break;
                    }
                }
                layTenKHVaCMND(cbxHoten.Text);
                string hotenkh = remember_tenkh;
                int socmnd = remember_cmnd;

                if (txtSoPhong.Text == "")
                {
                    MessageBox.Show("Các TH:\n" +
                        "- NV chưa chọn Loại Phòng để có số Phòng\n" +
                        "- Loại Phòng đó đã Hết", "Error");
                    return;
                }
                int sophong = int.Parse(txtSoPhong.Text);
                string loaiphong = cbxLoaiphong.Text;

                DateTime ngayden = dtpNgayden.Value;
                DateTime ngaydi = dtpNgaydi.Value;

                CDatPhong dp = arrDP[i];
                dp.Kh.Hoten = hotenkh;
                dp.Kh.CMND = socmnd;
                dp.Phong.Sophong = sophong;
                dp.Phong.Loaiphong = loaiphong;
                dp.Ngayden = ngayden;
                dp.Ngaydi = ngaydi;

                txtSoNgayO.Text = dp.SoNgayO().ToString();
                txtThanhTien.Text = dp.ThanhTien().ToString();
                setupBookedP(dp.Phong.Sophong, dp.Phong.Loaiphong);

                i++;
                hienthi();
            }
        }

        private void radView_CheckedChanged(object sender, EventArgs e)
        {
            CleanDP();
        }

        private void radSetup_CheckedChanged(object sender, EventArgs e)
        {

            CleanDP();
        }
    }
}
