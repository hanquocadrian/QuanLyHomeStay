﻿using System;
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
    public partial class NhanVien : Form
    {
        FormManager frmmng = new FormManager();
        private int i = -1;
        public NhanVien()
        {
            InitializeComponent();
        }
        public void hienthi()
        {
            lvwNV.Items.Clear();
            foreach (CNhanVien nv in frmmng.Data.ArrNV)
            {
                ListViewItem li = lvwNV.Items.Add(nv.MaNV);
                li.SubItems.Add(nv.HoTen);
                if (nv.GioiTinh == true)
                {
                    li.SubItems.Add("Nam");
                }
                else li.SubItems.Add("Nu");
                li.SubItems.Add(nv.NgaySinh.ToShortDateString());
                li.SubItems.Add(nv.Sdt.ToString());
                li.SubItems.Add(nv.QueQuan);
                li.SubItems.Add(nv.ChucVu);
                li.SubItems.Add(nv.Luong);
            }
        }

        public void hienthiNV(int j)
        {
            CNhanVien nv = (CNhanVien)frmmng.Data.ArrNV[j];
            txtMaNV.Text = nv.MaNV;
            txtTenNV.Text = nv.HoTen;
            chkGioiTinh.Checked = nv.GioiTinh;
            dtpNgaySinh.Value = nv.NgaySinh;
            txtSDT.Text = nv.Sdt.ToString();
            txtQueQuan.Text = nv.QueQuan;
            cbxChucVu.Text = nv.ChucVu;
            txtLuongcb.Text = nv.Luong;
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            frmmng.Data.OpenNV("dsnv.txt");
            if (frmmng.Data.ArrNV.Count > 0)
                hienthi();
        }

        private void cbxChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxChucVu.SelectedIndex == 0)
            {
                txtLuongcb.Text = "40.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 1)
            {
                txtLuongcb.Text = "20.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 2)
            {
                txtLuongcb.Text = "20.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 3)
            {
                txtLuongcb.Text = "20.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 4)
            {
                txtLuongcb.Text = "10.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 5)
            {
                txtLuongcb.Text = "7.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 6)
            {
                txtLuongcb.Text = "7.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 7)
            {
                txtLuongcb.Text = "8.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 8)
            {
                txtLuongcb.Text = "5.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 9)
            {
                txtLuongcb.Text = "5.000.000 VND";
            }
            else if (cbxChucVu.SelectedIndex == 10)
            {
                txtLuongcb.Text = "6.000.000 VND";
            }
        }

        private void NhanVien_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void lvwNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (int j in lvwNV.SelectedIndices)
            {
                i = j;
                hienthiNV(j);
                break;
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            CNhanVien nv = (CNhanVien)frmmng.Data.ArrNV[i];
            nv.MaNV = txtMaNV.Text;
            nv.HoTen = txtTenNV.Text;
            nv.GioiTinh = chkGioiTinh.Checked;
            nv.NgaySinh = dtpNgaySinh.Value;
            nv.Sdt = Convert.ToInt32(txtSDT.Text);
            nv.QueQuan = txtQueQuan.Text;
            nv.ChucVu = cbxChucVu.Text;
            nv.Luong = txtLuongcb.Text;
            hienthi();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            CNhanVien nv = new CNhanVien();
            nv.MaNV = txtMaNV.Text;
            nv.HoTen = txtTenNV.Text;
            nv.GioiTinh = chkGioiTinh.Checked;
            nv.NgaySinh = dtpNgaySinh.Value;
            nv.Sdt = Convert.ToInt32(txtSDT.Text);
            nv.QueQuan = txtQueQuan.Text;
            nv.ChucVu = cbxChucVu.Text;
            nv.Luong = txtLuongcb.Text;
            frmmng.Data.ArrNV.Add(nv);
            i++;
            hienthi();
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            frmmng.Data.ArrNV.RemoveAt(i);
            i--;
            if (i < 0 && frmmng.Data.ArrNV.Count > 0)
            {
                i = 0;
            }
            if (i >= 0)
            {
                hienthiNV(i);
            }
            hienthi();
        }

        private void chkGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGioiTinh.Checked == true)
            {
                chkGioiTinh.Text = "Nam";
            }
            else chkGioiTinh.Text = "Nu";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmmng.Data.SaveNV("dsnv.txt");
            this.Hide();
            frmmng.ShowDialog();
            this.Close();
        }
    }
}