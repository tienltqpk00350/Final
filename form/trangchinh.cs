using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final.form
{
    public partial class trangchinh : Form
    {
        public trangchinh()
        {
            InitializeComponent();
        }
        public static Final.business.xuly khoitao = new business.xuly();

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            view userControl = new view();
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(userControl);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            mathang userControl = new mathang();
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(userControl);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            sanpham userControl = new sanpham();
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(userControl);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            banhang userControl = new banhang();
            userControl.Dock = DockStyle.Fill;
            panel2.Controls.Add(userControl);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
