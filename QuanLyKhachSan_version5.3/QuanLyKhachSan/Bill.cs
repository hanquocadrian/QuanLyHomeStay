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
    public partial class Bill : Form
    {
        #region Attributes
        FormManager frmmng = new FormManager();
        //private int i = -1;
        private string sTenKH;
        private int iCMND;
        #endregion
        #region Method
        public void ShowDataTenKH()
        {
            cbxKH.Items.Clear();
            if (frmmng.Data.ArrKH.Count > 0)
            {
                foreach (CKhachHang kh in frmmng.Data.ArrKH)
                {
                    cbxKH.Items.Add(kh.Hoten + " (" + kh.CMND + ")");
                }
            }
        }
        public void clearDisplay()
        {
            cbxKH.Select();
            dtpNgayThanhToan.Value = DateTime.Now;
            cbxKH.Text = "";
            radPhongDon.Checked = false;
            radPhongDoi.Checked = false;
            radPhongDB.Checked = false;
            dtpNgayDat.Value = DateTime.Now;
            dtpNgayDi.Value = DateTime.Now;
            txtTongTienPhong.Text = "";
            lvwChooseDV.Items.Clear();
            txtTongTienDV.Text = "";
            txtTongTienHD.Text = "";
        }
        public void disableSomething()
        {
            dtpNgayThanhToan.Enabled = false;
            radPhongDon.Enabled = false;
            radPhongDoi.Enabled = false;
            radPhongDB.Enabled = false;
            dtpNgayDat.Enabled = false;
            dtpNgayDi.Enabled = false;
            txtTongTienPhong.ReadOnly = true;
            txtTongTienDV.ReadOnly = true;
            txtTongTienHD.ReadOnly = true;
        }
        public void layTenKHvaCMND(string c)
        {
            string temp = c;
            int charfrom = temp.IndexOf('(', 0) + 1;
            int charto = temp.IndexOf(')', 0) - 1;
            int charlength = charto - charfrom + 1;
            sTenKH = temp.Substring(0, charfrom - 3 + 1);
            iCMND = int.Parse(temp.Substring(charfrom, charlength));
        }
        private CBill timBillOfKH(int scmnd)
        {
            if(frmmng.Data.ArrBill.Count>0)
            {
                foreach (CBill item in frmmng.Data.ArrBill)
                {
                    if (item.Kh.CMND == scmnd)
                        return item;
                }
            }
            return null;
        }
        private void hienthiChooseDSDV(CDatDichVu ddv)
        {
            lvwChooseDV.Items.Clear();
            if(frmmng.Data.ArrBill.Count>0)
            {
                foreach (CDichVu item in ddv.Arrdv)
                {
                    ListViewItem li = lvwChooseDV.Items.Add(item.Smadv);
                    li.SubItems.Add(item.Stendv);
                    li.SubItems.Add(item.Giatien.ToString());
                }
            }
        }
        #endregion
        public Bill(string kh)
        {
            InitializeComponent();

            frmmng.Data.OpenKH("dskh.txt");
            frmmng.Data.OpenDP("dsdp.txt");
            frmmng.Data.OpenDSDDV("dsddv.txt");
            frmmng.Data.OpenDSBill("dsbill.txt");

            dtpNgayThanhToan.Value = DateTime.Now;
            disableSomething();
            if (frmmng.Data.ArrKH.Count > 0)
            {
                ShowDataTenKH();
                cbxKH.Text = kh;
            }
        }
        public Bill()
        {
            InitializeComponent();

            frmmng.Data.OpenKH("dskh.txt");
            frmmng.Data.OpenDP("dsdp.txt");
            frmmng.Data.OpenDSDDV("dsddv.txt");
            frmmng.Data.OpenDSBill("dsbill.txt");

            dtpNgayThanhToan.Value = DateTime.Now;
            disableSomething();
            if(frmmng.Data.ArrKH.Count>0)
            {
                ShowDataTenKH();
                cbxKH.Text = "";
                cbxKH.Select();
            }
        }

        private void cbxKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpNgayThanhToan.Value = DateTime.Now;
            if (cbxKH.Text == "")
            {
                MessageBox.Show("Chưa chọn KH", "Error");
                return;
            }
            layTenKHvaCMND(cbxKH.Text);
            CBill customerbill = timBillOfKH(iCMND);
           
            if (customerbill.Dp != null)
            {
                if (customerbill.Dp.Phong.Loaiphong == "Đơn") radPhongDon.Checked = true;
                else if (customerbill.Dp.Phong.Loaiphong == "Đôi") radPhongDoi.Checked = true;
                else radPhongDB.Checked = true;
                dtpNgayDat.Value = customerbill.Dp.Ngayden;
                dtpNgayDi.Value = customerbill.Dp.Ngaydi;
                txtTongTienPhong.Text = customerbill.Dp.ThanhTien().ToString();
            }
            else
                txtTongTienPhong.Text = "0";

            if(customerbill.Ddv != null)
            {
                hienthiChooseDSDV(customerbill.Ddv);
                txtTongTienDV.Text = customerbill.Ddv.tinhTongGiaTien().ToString();
            }
            else
                txtTongTienDV.Text = "0";

            txtTongTienHD.Text = customerbill.tinhTongThanhTien().ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmmng.Data.SaveDSBill("dsbill.txt");
            this.Hide();
            frmmng.ShowDialog();
            this.Close();
        }

        private void deletBillOfCustomer(CBill ctmbill)
        {
            int i;
            for (i = 0; i < frmmng.Data.ArrDP.Count; i++)
            {
                if(frmmng.Data.ArrDP[i].Kh.CMND==ctmbill.Kh.CMND)
                {
                    int sophong = frmmng.Data.ArrDP[i].Phong.Sophong;
                    foreach (CPhong item in frmmng.Data.ArrPKS)
                    {
                        if (sophong == item.Sophong)
                        {
                            item.Trangthai = "Empty";
                            break;
                        }
                    }
                    frmmng.Data.ArrDP.RemoveAt(i);
                    frmmng.Data.SaveDP("dsdp.txt");
                    break;
                }
            }
            for(i=0;i<frmmng.Data.ArrDDV.Count;i++)
            {
                if(frmmng.Data.ArrDDV[i].Kh.CMND==ctmbill.Kh.CMND)
                {
                    frmmng.Data.ArrDDV.RemoveAt(i);
                    frmmng.Data.SaveDSDDV("dsddv.txt");
                    break;
                }
            }
            for(i=0;i<frmmng.Data.ArrKH.Count;i++)
            {
                if(ctmbill.Kh.CMND==frmmng.Data.ArrKH[i].CMND)
                {
                    frmmng.Data.ArrKH.RemoveAt(i);
                    frmmng.Data.SaveKH("dskh.txt");
                    break;
                }
            }

            for (i = 0; i < frmmng.Data.ArrBill.Count; i++)
            {
                if (ctmbill.Kh.CMND == frmmng.Data.ArrBill[i].Kh.CMND)
                {
                    frmmng.Data.ArrBill.RemoveAt(i);
                    frmmng.Data.SaveDSBill("dsbill.txt");
                    break;
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                layTenKHvaCMND(cbxKH.Text);
                CBill customerbill = timBillOfKH(iCMND);

                CHistory lskh = new CHistory();
                lskh.Ctmbill = customerbill;

                frmmng.Data.ArrLS.Add(lskh);
                frmmng.Data.SaveLSKH("dslskh.txt");
                deletBillOfCustomer(customerbill);
                MessageBox.Show("Đã Checkout thành công.");
                clearDisplay();
                if (frmmng.Data.ArrKH.Count > 0)
                {
                    ShowDataTenKH();
                    cbxKH.Text = "";
                    cbxKH.Select();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không Checkout thành công.");
                throw;
            }

        }
    }
}
