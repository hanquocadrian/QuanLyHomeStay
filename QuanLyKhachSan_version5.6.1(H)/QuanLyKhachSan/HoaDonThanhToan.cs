using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class HoaDonThanhToan : Form
    {
        #region Attributes
        FormManager frmmng = new FormManager();
        private string sTenKH;
        private int iCMND;
        #endregion
        #region Method
        public void showDataTenKH()
        {
            cbxTTKH.Items.Clear();
            if (frmmng.Data.ArrKH.Count>0)
            {
                foreach (CKhachHang kh in frmmng.Data.ArrKH)
                {
                    cbxTTKH.Items.Add(kh.Hoten + " (" + kh.CMND + ")");
                }
            }
        }
        public void layTenKHvaCMND(string c)
        {
            string temp = c;
            int charfrom = temp.IndexOf("(", 0) + 1;
            int charto = temp.IndexOf(")", charfrom) - 1;
            int charlength = charto - charfrom + 1;
            sTenKH = temp.Substring(0, charfrom - 3 + 1);
            iCMND = int.Parse(temp.Substring(charfrom, charlength));
        }
        private void hienthiDSPhong(CDatPhong dp)
        {
            lvwPhong.Items.Clear();
            if (frmmng.Data.ArrBill.Count>0)
            {
                foreach (CPhong phong in dp.Phong)
                {
                    ListViewItem li = lvwPhong.Items.Add(phong.Sophong.ToString());
                    li.SubItems.Add(phong.Loaiphong);
                    li.SubItems.Add(dp.ThanhTien(phong.Loaiphong).ToString());
                }
                txtPhongTT.Text = dp.TongThanhTien().ToString();
            }
        }
        private void hienthiDSDDV(CDatDichVu ddv)
        {
            lvwDichVu.Items.Clear();
            if (frmmng.Data.ArrBill.Count > 0)
            {
                foreach (CDichVu item in ddv.Arrdv)
                {
                    ListViewItem li = lvwDichVu.Items.Add(item.Smadv);
                    li.SubItems.Add(item.Stendv);
                    li.SubItems.Add(item.Giatien.ToString());
                }
            }
        }
        private CBill timHoaDonKH(int cmnd)
        {
            if (frmmng.Data.ArrBill.Count>0)
            {
                foreach (CBill item in frmmng.Data.ArrBill)
                {
                    if (item.Kh.CMND==cmnd)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        public int[] timDSPhongVeKhacTime(int[] vetruoc,int[] vesau, ref bool isvetruoctrue)
        {
            if (vetruoc.Length < vesau.Length)
            {
                isvetruoctrue = true;
                return vetruoc;
            }
            else
            {
                isvetruoctrue = false;
                return vesau;
            }
        }
        private void xoaHoaDonKH(CBill hoadonKH)
        {
            int i;
            int j = 0;
            int dem = 0;
            if (hoadonKH.Dp != null)
            {
                for (i = 0; i < frmmng.Data.ArrDP.Count; i++)
                {
                    if (hoadonKH.Kh.CMND == frmmng.Data.ArrDP[i].Kh.CMND)
                    {
                        while (dem <= frmmng.Data.ArrDP[i].Phong.Count - 1)
                        {
                            int sophong = frmmng.Data.ArrDP[i].Phong[j++].Sophong;
                            foreach (CPhong item in frmmng.Data.ArrPKS)
                            {
                                if (sophong == item.Sophong)
                                {
                                    item.Trangthai = "Empty";
                                    dem++;
                                }
                            }
                        }
                        frmmng.Data.ArrDP.RemoveAt(i);
                        frmmng.Data.SaveP("dsp.txt");
                        frmmng.Data.SaveDP("dsdp.txt");
                        break;
                    }
                }
            }
            if (hoadonKH.Ddv != null)
            {
                for (i = 0; i < frmmng.Data.ArrDDV.Count; i++)
                {
                    if (frmmng.Data.ArrDDV[i].Kh.CMND == hoadonKH.Kh.CMND)
                    {
                        frmmng.Data.ArrDDV.RemoveAt(i);
                        frmmng.Data.SaveDSDDV("dsddv.txt");
                        break;
                    }
                }
            }

            for (i = 0; i < frmmng.Data.ArrKH.Count; i++)
            {
                if (frmmng.Data.ArrKH[i].CMND == hoadonKH.Kh.CMND)
                {
                    frmmng.Data.ArrKH.RemoveAt(i);
                    frmmng.Data.SaveKH("dskh.txt");
                    break;
                }
            }
            for (i = 0; i < frmmng.Data.ArrBill.Count; i++)
            {
                if (frmmng.Data.ArrBill[i].Kh.CMND == hoadonKH.Kh.CMND)
                {
                    frmmng.Data.ArrBill.RemoveAt(i);
                    frmmng.Data.SaveDSBill("dsbill.txt");
                    break;
                }
            }
        }
        private void xoaHoaDonKHVeKhacTime(CBill hoadonKH)
        {
            bool isvetruoctrue = false;
            int[] vetruoc = new int[lstPVT.Items.Count];
            int[] vesau = new int[lstPVS.Items.Count];
            for (int ivt = 0; ivt < lstPVT.Items.Count; ivt++)
            {
                vetruoc[ivt] = Convert.ToInt32(lstPVT.Items.ToString());
            }
            for (int ivs = 0; ivs < lstPVS.Items.Count; ivs++)
            {
                vetruoc[ivs] = Convert.ToInt32(lstPVS.Items.ToString());
            }
            int[] dsquyetdinh = timDSPhongVeKhacTime(vetruoc, vesau,ref isvetruoctrue);

            switch (isvetruoctrue)
            {
                case true:

                    break;
                case false:
                    
                    break;
                default:
                    break;
            }
            int i;
            int j = 0;
            int dem = 0;
            if (hoadonKH.Dp != null)
            {
                for (i = 0; i < frmmng.Data.ArrDP.Count; i++)
                {
                    if (hoadonKH.Kh.CMND == frmmng.Data.ArrDP[i].Kh.CMND)
                    {
                        while (dem <= frmmng.Data.ArrDP[i].Phong.Count - 1)
                        {
                            int sophong = frmmng.Data.ArrDP[i].Phong[j++].Sophong;
                            foreach (CPhong item in frmmng.Data.ArrPKS)
                            {
                                if (sophong == item.Sophong)
                                {
                                    item.Trangthai = "Empty";
                                    dem++;
                                }
                            }
                        }
                        frmmng.Data.ArrDP.RemoveAt(i);
                        frmmng.Data.SaveP("dsp.txt");
                        frmmng.Data.SaveDP("dsdp.txt");
                        break;
                    }
                }
            }
            if (hoadonKH.Ddv != null)
            {
                for (i = 0; i < frmmng.Data.ArrDDV.Count; i++)
                {
                    if (frmmng.Data.ArrDDV[i].Kh.CMND == hoadonKH.Kh.CMND)
                    {
                        frmmng.Data.ArrDDV.RemoveAt(i);
                        frmmng.Data.SaveDSDDV("dsddv.txt");
                        break;
                    }
                }
            }

            for (i = 0; i < frmmng.Data.ArrKH.Count; i++)
            {
                if (frmmng.Data.ArrKH[i].CMND == hoadonKH.Kh.CMND)
                {
                    frmmng.Data.ArrKH.RemoveAt(i);
                    frmmng.Data.SaveKH("dskh.txt");
                    break;
                }
            }
            for (i = 0; i < frmmng.Data.ArrBill.Count; i++)
            {
                if (frmmng.Data.ArrBill[i].Kh.CMND == hoadonKH.Kh.CMND)
                {
                    frmmng.Data.ArrBill.RemoveAt(i);
                    frmmng.Data.SaveDSBill("dsbill.txt");
                    break;
                }
            }
        }
        public void clearDisplay()
        {
            cbxTTKH.Select();
            dtpNgayTT.Value = DateTime.Now;
            cbxTTKH.Text = "";
            dtpNgayDP.Value = DateTime.Now;
            dtpNgayDi.Value = DateTime.Now;
            txtPhongTT.Text = "";
            lvwDichVu.Items.Clear();
            txtDVTT.Text = "";
            txtTongTien.Text = "";
        }
        private void hienThiListBoxVeHienTai(List<CPhong> dsp)
        {
            foreach(CPhong p in dsp)
            {
                lstPVT.Items.Add(p.Sophong);
            }
        }
        #endregion

        public HoaDonThanhToan()
        {
            InitializeComponent();
            frmmng.Data.OpenP("dsp.txt");
            frmmng.Data.OpenKH("dskh.txt");
            frmmng.Data.OpenDP("dsdp.txt");
            frmmng.Data.OpenDSDDV("dsddv.txt");
            frmmng.Data.OpenDSBill("dsbill.txt");
            frmmng.Data.OpenLSKH("dslskh.txt");
            dtpNgayTT.Value = DateTime.Now;
            if (frmmng.Data.ArrBill.Count>0)
            {
                showDataTenKH();
                cbxTTKH.Text = "";
                cbxTTKH.Select();
            }
        }

        public HoaDonThanhToan(string kh)
        {
            InitializeComponent();
            frmmng.Data.OpenP("dsp.txt");
            frmmng.Data.OpenKH("dskh.txt");
            frmmng.Data.OpenDP("dsdp.txt");
            frmmng.Data.OpenDSDDV("dsddv.txt");
            frmmng.Data.OpenDSBill("dsbill.txt");
            frmmng.Data.OpenLSKH("dslskh.txt");
            dtpNgayTT.Value = DateTime.Now;
            if (frmmng.Data.ArrBill.Count > 0)
            {
                showDataTenKH();
                cbxTTKH.Text = kh;
            }
        }

        private void cbxTTKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTTKH.Text=="")
            {
                MessageBox.Show("Chưa chọn khách hàng");
                return;
            }
            layTenKHvaCMND(cbxTTKH.Text);
            CBill hoadonKH = timHoaDonKH(iCMND);
            if (hoadonKH == null) return;
            if (hoadonKH.Dp!=null)
            {
                dtpNgayDP.Value = hoadonKH.Dp.Ngayden;
                dtpNgayDi.Value = hoadonKH.Dp.Ngaydi;
                hienthiDSPhong(hoadonKH.Dp);
            }
            if (hoadonKH.Ddv != null)
            {
                hienthiDSDDV(hoadonKH.Ddv);
                txtDVTT.Text = hoadonKH.Ddv.tinhTongGiaTien().ToString();
            }
            else txtDVTT.Text = "0";
            txtTongTien.Text = hoadonKH.tinhTongThanhTien().ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if(!chkVeKhacTime.Checked)
                {
                    layTenKHvaCMND(cbxTTKH.Text);
                    CBill hoadonKH = timHoaDonKH(iCMND);
                    CHistory lskh = new CHistory();
                    lskh.Ctmbill = hoadonKH;
                    frmmng.Data.ArrLS.Add(lskh);
                    xoaHoaDonKH(hoadonKH);
                    MessageBox.Show("Thanh toán thành công.");
                    clearDisplay();
                    if (frmmng.Data.ArrBill.Count>0)
                    {
                        showDataTenKH();
                        cbxTTKH.Text = "";
                        cbxTTKH.Select();
                    }
                }
                else
                {
                    layTenKHvaCMND(cbxTTKH.Text);
                    CBill hoadonKH = timHoaDonKH(iCMND);
                    CHistory lskh = new CHistory();
                    lskh.Ctmbill = hoadonKH;
                    frmmng.Data.ArrLS.Add(lskh);
                    xoaHoaDonKHVeKhacTime(hoadonKH);
                    MessageBox.Show("Thanh toán thành công.");
                    clearDisplay();
                    if (frmmng.Data.ArrBill.Count>0)
                    {
                        showDataTenKH();
                        cbxTTKH.Text = "";
                        cbxTTKH.Select();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thanh toán không thành công.");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmmng.Data.SaveDSBill("dsbill.txt");
            frmmng.Data.SaveLSKH("dslskh.txt");
            this.Hide();
            frmmng.ShowDialog();
            this.Close();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (lstPVT.SelectedIndex >= 0)
            {
                lstPVS.Items.Add(lstPVT.SelectedItem);
                lstPVT.Items.Remove(lstPVT.SelectedItem);
            }
            else
                MessageBox.Show("Bạn Chưa chọn Phòng cần về Sau","Error");
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (lstPVS.SelectedIndex >= 0)
            {
                lstPVT.Items.Add(lstPVS.SelectedItem);
                lstPVS.Items.Remove(lstPVS.SelectedItem);
            }
            else
                MessageBox.Show("Bạn Chưa chọn Phòng cần về Trước","Error");
        }

        private void pcbD_Click(object sender, EventArgs e)
        {
            btnDown_Click(sender, e);
        }

        private void pcbU_Click(object sender, EventArgs e)
        {
            btnUp_Click(sender, e);
        }

        private void chkVeKhacTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTTKH.Text == "")
            {
                MessageBox.Show("Chưa chọn khách hàng");
                return;
            }
            if (chkVeKhacTime.Checked==true)
            {
                #region Enabled lst and btn
                lstPVT.Enabled = true;
                lstPVS.Enabled = true;
                btnUp.Enabled = true;
                pcbU.Enabled = true;
                btnDown.Enabled = true;
                pcbD.Enabled = true;
                #endregion
                
                layTenKHvaCMND(cbxTTKH.Text);
                CBill hoadonKH = timHoaDonKH(iCMND);
                if (hoadonKH.Dp != null)
                    hienThiListBoxVeHienTai(hoadonKH.Dp.Phong);
            }
            else
            {
                #region Enabled lst and btn
                lstPVT.Enabled = false;
                lstPVS.Enabled = false;
                btnUp.Enabled = false;
                pcbU.Enabled = false;
                btnDown.Enabled = false;
                pcbD.Enabled = false;
                #endregion
            }
        }

        private void HoaDonThanhToan_Load(object sender, EventArgs e)
        {
            lstPVT.Items.Clear();
            lstPVS.Items.Clear();
            chkVeKhacTime.Checked = false;
        }
    }
}
