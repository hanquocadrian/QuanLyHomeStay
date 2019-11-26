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
        CdmDatPhong xldp = new CdmDatPhong();
        CdmPhong xlp = new CdmPhong();
        CdmKhachHang xlkh = new CdmKhachHang();
        CdmHistoryKH xllskh = new CdmHistoryKH();
        private int i = -1;

        private string sTenKH;
        private int sCMND;
        #endregion

        public DatPhong()
        {
            InitializeComponent();
        }

        private void DatPhong_Load(object sender, EventArgs e)
        {
            frmmng.Data.OpenKH("dskh.txt");
            xlkh.ArrKH = frmmng.Data.ArrKH;
            frmmng.Data.OpenP("dsp.txt");
            xlp.ArrPKS = frmmng.Data.ArrPKS;
            frmmng.Data.OpenDP("dsdp.txt");
            xldp.ArrDP = frmmng.Data.ArrDP;
            frmmng.Data.OpenLSKH("dslskh.txt");
            xllskh.ArrLS = frmmng.Data.ArrLS;

            hienthi();
            ShowDataTenKH();
            cbxHoten.Select();
        }

        public void hienthi()
        {
            lvwDP.Items.Clear();
            foreach (CDatPhong dp  in xldp.ArrDP)
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
            CDatPhong dp = (CDatPhong)xldp.ArrDP[j];
            cbxHoten.Text = dp.Kh.Hoten + " (" + dp.Kh.CMND.ToString() + ")";
            dtpNgayden.Value = dp.Ngayden;
            dtpNgaydi.Value = dp.Ngaydi;
            txtSoPhong.Text = dp.Phong.Sophong.ToString();
            cbxLoaiphong.Text = dp.Phong.Loaiphong;
            txtSoNgayO.Text = dp.SoNgayO().ToString();
            txtThanhTien.Text = dp.ThanhTien().ToString();
        }

        public void setupBookedP(int sophong,string loaiphong)
        {
            foreach(CPhong p in xlp.ArrPKS)
            {
                if (string.Compare(p.Loaiphong, loaiphong) == 0 && p.Sophong == sophong)
                    p.Trangthai = "Booked";
            }
            frmmng.Data.ArrPKS= xlp.ArrPKS;
            frmmng.Data.SaveP("dsp.txt");
        }
        public void ShowDataTenKH()
        {
            cbxHoten.Items.Clear();
            if (xlkh.ArrKH.Count > 0)
            {
                foreach (CKhachHang kh in xlkh.ArrKH)
                {
                    cbxHoten.Items.Add(kh.Hoten + " (" + kh.CMND + ")");
                }
            }
        }

        public void layTenKHvaCMND(string c)
        {
            string temp = c;
            int charfrom = temp.IndexOf('(', 0) + 1;
            int charto = temp.IndexOf(')', 0) - 1;
            int charlength = charto - charfrom + 1;
            sTenKH = temp.Substring(0, charfrom - 3 + 1);
            sCMND = int.Parse(temp.Substring(charfrom, charlength));
        }
        public void CleanDP()
        {
            cbxHoten.Text="";
            txtSoPhong.Text = "";
            txtSoNgayO.Text = "";
            cbxLoaiphong.Text = "";
            txtThanhTien.Text = "";
        }

        public int timGiaPhong(string loai)
        {
            foreach(CPhong p in xlp.ArrPKS)
            {
                if (string.Equals(p.Loaiphong, loai))
                    return p.Gia;
            }
            return -1;
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
                layTenKHvaCMND(cbxHoten.Text);
                string hotenkh = sTenKH;
                int socmnd = sCMND;
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

                dp.Phong.Gia = timGiaPhong(dp.Phong.Loaiphong);

                if (xldp.them(dp))
                {
                    txtSoNgayO.Text = dp.SoNgayO().ToString();
                    txtThanhTien.Text = dp.ThanhTien().ToString();
                    setupBookedP(dp.Phong.Sophong, dp.Phong.Loaiphong);

                    i++;
                    CleanDP();
                    hienthi();
                }
                else
                    MessageBox.Show("Khách Hàng đã đặt rồi", "Error");
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
                foreach (CPhong p in xlp.ArrPKS)
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

        private CKhachHang timInfoKH(string hoten, int cmnd)
        {
            CKhachHang timkh = null;
            foreach (CKhachHang kh  in xlkh.ArrKH)
            {
                if (string.Compare(kh.Hoten,hoten)==0 && cmnd==kh.CMND)
                {
                    timkh = kh;
                    break;
                }
            }
            return timkh;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xldp.ArrDP.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Error");
                return;
            }
            CHistory ls = new CHistory();
            ls.Dp.Kh.Hoten = xldp.ArrDP[i].Kh.Hoten;
            ls.Dp.Kh.CMND = xldp.ArrDP[i].Kh.CMND;
            ls.Dp.Ngayden = xldp.ArrDP[i].Ngayden;
            ls.Dp.Ngaydi = xldp.ArrDP[i].Ngaydi;
            ls.Dp.Phong.Sophong = xldp.ArrDP[i].Phong.Sophong;
            ls.Dp.Phong.Loaiphong = xldp.ArrDP[i].Phong.Loaiphong;
            ls.Dp.Phong.Gia = xldp.ArrDP[i].Phong.Gia;
            CKhachHang timkh = timInfoKH(ls.Dp.Kh.Hoten, ls.Dp.Kh.CMND);
            if (timkh == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng trong danh sách khách hàng");
                return;
            }
            ls.Kh.Hoten = ls.Dp.Kh.Hoten;
            ls.Kh.CMND = ls.Dp.Kh.CMND;
            ls.Kh.Gioitinh = timkh.Gioitinh;
            ls.Kh.Tuoi = timkh.Tuoi;
            ls.Kh.Quoctich = timkh.Quoctich;
            ls.Kh.Sdt = timkh.Sdt;
            xllskh.them(ls);

            CDatPhong dp = xldp.ArrDP[i];
            foreach (CPhong p in xlp.ArrPKS)
            {
                if (p.Sophong == dp.Phong.Sophong && string.Compare(p.Loaiphong, dp.Phong.Loaiphong) == 0)
                {
                    p.Trangthai = "Empty";
                    frmmng.Data.ArrPKS = xlp.ArrPKS;
                    frmmng.Data.SaveP("dsp.txt");
                    break;
                }
            }
            foreach (CKhachHang kh in xlkh.ArrKH)
            {
                if(kh.CMND==dp.Kh.CMND)
                {
                    if (xlkh.xoa(kh.CMND))
                    {
                        frmmng.Data.ArrKH = xlkh.ArrKH;
                        frmmng.Data.SaveKH("dskh.txt");
                        break;
                    }
                }
            }
            ShowDataTenKH();
            foreach (int j in lvwDP.SelectedIndices)
            {
                if (xldp.xoa(int.Parse(lvwDP.Items[j].SubItems[1].Text)))
                {
                    i--;
                    if (i < 0 && xldp.ArrDP.Count > 0) i = 0;
                    if (i >= 0)
                        hienthiDP(i);
                    hienthi();
                }
                else
                    MessageBox.Show("Hết Data or Không tìm thấy Mã để xóa", "Error");
                break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmmng.Data.ArrLS = xllskh.ArrLS;
            frmmng.Data.SaveLSKH("dslskh.txt");
            frmmng.Data.ArrDP = xldp.ArrDP;
            frmmng.Data.SaveDP("dsdp.txt");
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
            //  Vị trí đặt Phòng Thứ i của P cũ sẽ bị mất đi -> Empty
            // Setup như nhập, bỏ ik clearDP vs arr Add
            if (xldp.ArrDP.Count > 0 && radSetup.Checked == true)
            {
                CDatPhong dp_old = xldp.ArrDP[i];
                foreach (CPhong p in xlp.ArrPKS)
                {
                    if (p.Sophong == dp_old.Phong.Sophong && string.Compare(p.Loaiphong, dp_old.Phong.Loaiphong) == 0)
                    {
                        p.Trangthai = "Empty";
                        frmmng.Data.ArrPKS = xlp.ArrPKS;
                        frmmng.Data.SaveP("dsp.txt");
                        break;
                    }
                }
                layTenKHvaCMND(cbxHoten.Text);
                string hotenkh = sTenKH;
                int socmnd = sCMND;

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

                CDatPhong dp = new CDatPhong();
                dp.Kh.Hoten = hotenkh;
                dp.Kh.CMND = socmnd;
                dp.Phong.Sophong = sophong;
                dp.Phong.Loaiphong = loaiphong;
                dp.Ngayden = ngayden;
                dp.Ngaydi = ngaydi;

                dp.Phong.Gia = timGiaPhong(dp.Phong.Loaiphong);

                if (xldp.sua(dp))
                {
                    txtSoNgayO.Text = dp.SoNgayO().ToString();
                    txtThanhTien.Text = dp.ThanhTien().ToString();
                    setupBookedP(dp.Phong.Sophong, dp.Phong.Loaiphong);
                    hienthi();
                }
                else
                    MessageBox.Show("Hết Data or Sai Mã", "Error");
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
