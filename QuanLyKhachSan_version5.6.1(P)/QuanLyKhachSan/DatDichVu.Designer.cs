﻿namespace QuanLyKhachSan
{
    partial class DatDichVu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxHoten = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuyDV = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongGiaTien = new System.Windows.Forms.TextBox();
            this.lvwChooseDSDV = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.lvwDSDV = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxHoten
            // 
            this.cbxHoten.DropDownHeight = 50;
            this.cbxHoten.FormattingEnabled = true;
            this.cbxHoten.IntegralHeight = false;
            this.cbxHoten.Location = new System.Drawing.Point(175, 31);
            this.cbxHoten.Margin = new System.Windows.Forms.Padding(4);
            this.cbxHoten.Name = "cbxHoten";
            this.cbxHoten.Size = new System.Drawing.Size(288, 26);
            this.cbxHoten.TabIndex = 53;
            this.cbxHoten.SelectedIndexChanged += new System.EventHandler(this.cbxHoten_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Khách hàng:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnHuyDV);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTongGiaTien);
            this.groupBox1.Controls.Add(this.lvwChooseDSDV);
            this.groupBox1.Controls.Add(this.cbxHoten);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(581, 491);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Các dịch vụ dược đặt";
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(263, 112);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(139, 39);
            this.btnThoat.TabIndex = 57;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuyDV
            // 
            this.btnHuyDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyDV.Location = new System.Drawing.Point(76, 112);
            this.btnHuyDV.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnHuyDV.Name = "btnHuyDV";
            this.btnHuyDV.Size = new System.Drawing.Size(139, 39);
            this.btnHuyDV.TabIndex = 57;
            this.btnHuyDV.Text = "Hủy dịch vụ";
            this.btnHuyDV.UseVisualStyleBackColor = true;
            this.btnHuyDV.Click += new System.EventHandler(this.btnHuyDV_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(407, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "VND";
            // 
            // txtTongGiaTien
            // 
            this.txtTongGiaTien.Location = new System.Drawing.Point(175, 74);
            this.txtTongGiaTien.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txtTongGiaTien.Name = "txtTongGiaTien";
            this.txtTongGiaTien.ReadOnly = true;
            this.txtTongGiaTien.Size = new System.Drawing.Size(227, 24);
            this.txtTongGiaTien.TabIndex = 55;
            // 
            // lvwChooseDSDV
            // 
            this.lvwChooseDSDV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwChooseDSDV.FullRowSelect = true;
            this.lvwChooseDSDV.GridLines = true;
            this.lvwChooseDSDV.HideSelection = false;
            this.lvwChooseDSDV.Location = new System.Drawing.Point(19, 164);
            this.lvwChooseDSDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvwChooseDSDV.MultiSelect = false;
            this.lvwChooseDSDV.Name = "lvwChooseDSDV";
            this.lvwChooseDSDV.Size = new System.Drawing.Size(544, 313);
            this.lvwChooseDSDV.TabIndex = 54;
            this.lvwChooseDSDV.UseCompatibleStateImageBehavior = false;
            this.lvwChooseDSDV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã dịch vụ";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên dịch vụ";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá tiền";
            this.columnHeader3.Width = 149;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 52;
            this.label2.Text = "Tổng giá tiền:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThemDV);
            this.groupBox2.Controls.Add(this.lvwDSDV);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(602, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(578, 492);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Các dịch vụ:";
            // 
            // btnThemDV
            // 
            this.btnThemDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDV.Location = new System.Drawing.Point(208, 24);
            this.btnThemDV.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(178, 42);
            this.btnThemDV.TabIndex = 57;
            this.btnThemDV.Text = "Thêm dịch vụ";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // lvwDSDV
            // 
            this.lvwDSDV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvwDSDV.FullRowSelect = true;
            this.lvwDSDV.GridLines = true;
            this.lvwDSDV.HideSelection = false;
            this.lvwDSDV.Location = new System.Drawing.Point(16, 74);
            this.lvwDSDV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvwDSDV.Name = "lvwDSDV";
            this.lvwDSDV.Size = new System.Drawing.Size(543, 404);
            this.lvwDSDV.TabIndex = 54;
            this.lvwDSDV.UseCompatibleStateImageBehavior = false;
            this.lvwDSDV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã dịch vụ";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tên dịch vụ";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Giá tiền";
            this.columnHeader6.Width = 154;
            // 
            // DatDichVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 522);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DatDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt Dịch Vụ";
            this.Load += new System.EventHandler(this.DatDichVu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxHoten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwChooseDSDV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTongGiaTien;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuyDV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.ListView lvwDSDV;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}