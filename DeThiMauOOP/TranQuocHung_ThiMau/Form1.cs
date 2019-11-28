using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TranQuocHung_ThiMau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void phongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhongBanForm frmpb = new PhongBanForm();
            frmpb.MdiParent = this;
            frmpb.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVienForm frmnv = new NhanVienForm();
            frmnv.MdiParent = this;
            frmnv.Show();
        }
    }
}
