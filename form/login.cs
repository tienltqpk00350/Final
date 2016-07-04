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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if(Final.form.trangchinh.khoitao.login(textBox1.Text.Trim(), textBox2.Text.Trim())==1)
                {
                    Final.form.trangchinh khoitao = new trangchinh();
                    khoitao.Show();
                    this.Hide();
                }
            }else MessageBox.Show("Thông Tin thiếu sót");
        }
    }
}
