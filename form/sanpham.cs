using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Final.form
{

    public partial class sanpham : UserControl
    {
        string chuoi = @"select TenMH,MaSP,Tensp,ngaynhap,ngaysuat,soluong,donvitinh,dongia,ghichu from QLMH left join QLSP on QLMH.MA=QLSP.MA_QLMH";
        string where = @" where ";
        string nhapsuat;
        string gitrixapxep;
        string caulenh;
        public sanpham()
        {
            InitializeComponent();
            loaddatagridview();
            loadcompobox();
        }
        void loadcompobox()
        {
            comboBox2.DataSource = trangchinh.khoitao.loadsp();
            comboBox2.DisplayMember = "Tensp";
            comboBox1.DataSource = trangchinh.khoitao.loadmh();
            comboBox1.DisplayMember = "TenMH";
            comboBox3.DataSource = trangchinh.khoitao.loadmh();
            comboBox3.DisplayMember = "TenMH";
        }
        void loaddatagridview()
        {
            dataGridView1.DataSource=trangchinh.khoitao.loadsp();
        }

        string tuychinhtimkiem()
        {
            chuoi = @"select MaSP,Tensp,ngaynhap,ngaysuat,soluong,donvitinh,dongia,ghichu from QLMH right join QLSP on QLMH.MA=QLSP.MA_QLMH";
            where = @" where ";
            if (checkBox2.Checked == true)
            {
                chuoi += where;
                chuoi += @"TenMH='" + comboBox1.Text.Trim() + "'";
                where = " AND ";
            }
            if (checkBox1.Checked == true)
            {
                chuoi += where;
                chuoi += @"Tensp='" + comboBox2.Text.Trim() + "'";
                where = " AND ";
            }
            if (checkBox3.Checked == true)
            {
                hamnhapsuat();
                if(nhapsuat!=null)
                {
                    chuoi += where;
                    chuoi += @"" + nhapsuat + " BETWEEN convert(datetime, '" + dateTimePicker1.Text.Trim() + "', 103) and convert(datetime, '" + dateTimePicker2.Text.Trim() + "', 103)";
                }   
            }
            return chuoi;
        }


        string hamnhapsuat() 
        {
            if (dateTimePicker1.Value <= dateTimePicker2.Value)
            {
                if (radioButton1.Checked == true)
                {
                    nhapsuat = " ngaynhap ";
                }
                else
                    nhapsuat = " ngaysuat ";

            }
            else
            {
                MessageBox.Show("từ<đến | Tick was uncheck");
                checkBox3.Checked = false;
            }
            return nhapsuat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tuychinhtimkiem();
            dataGridView1.DataSource = trangchinh.khoitao.TimKiemAllInOne(chuoi);
            
        }
        //hamthucthi
        void thucthithemsoasua(string truyenvao) { 
            if(truyenvao=="them")
            {
                Final.form.trangchinh.khoitao.Themsp(hamlayma(), textBox1.Text.Trim(), dateTimePicker3.Text.Trim(), dateTimePicker4.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), textBox7.Text.Trim(), xapseptheloai());
                loaddatagridview();
                comboBox2.DataSource = trangchinh.khoitao.loadsp();
                comboBox2.DisplayMember = "Tensp";
            }
            if (truyenvao == "soa")
            {
                Final.form.trangchinh.khoitao.delsp(label12.Text.Trim());
                loaddatagridview();
                comboBox2.DataSource = trangchinh.khoitao.loadsp();
                comboBox2.DisplayMember = "Tensp";
            }
            if (truyenvao == "sua")
            {
                Final.form.trangchinh.khoitao.suasp(textBox1.Text.Trim(), dateTimePicker3.Text.Trim(), dateTimePicker4.Text.Trim(), textBox4.Text.Trim(), textBox5.Text.Trim(), textBox6.Text.Trim(), textBox7.Text.Trim(), xapseptheloai(), label12.Text.Trim());
                comboBox2.DataSource = trangchinh.khoitao.loadsp();
                comboBox2.DisplayMember = "Tensp";
                loaddatagridview();
            }
            
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            textBox1.Text = dataGridView1["Column2", index].Value.ToString();
            string abc = dateTimePicker3.Text = dataGridView1["Column3", index].Value.ToString();
            dateTimePicker4.Text = dataGridView1["Column4", index].Value.ToString();
            textBox4.Text = dataGridView1["Column5", index].Value.ToString();
            textBox5.Text = dataGridView1["Column6", index].Value.ToString();
            textBox6.Text = dataGridView1["Column7", index].Value.ToString();
            textBox7.Text = dataGridView1["Column8", index].Value.ToString();
            label12.Text = dataGridView1["Column1", index].Value.ToString();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            dieukhien(2);
            textBox1.Text = "";
            dateTimePicker3.Text = "";
            dateTimePicker4.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            caulenh = "them";
        }
        void dieukhien(int type)
        {
            toolStripButton1.Visible = type == 1 ? true : false;
            toolStripButton2.Visible = type == 1 ? true : false;
            toolStripButton3.Visible = type == 1 ? true : false;

            panel6.Visible = type == 2 ? true : false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dieukhien(1);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dieukhien(2);
            caulenh = "sua";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            dieukhien(2);
            caulenh = "soa";
        }

        //ham xap xep the loai
        string xapseptheloai()
        {
            string input=comboBox3.Text.Trim();
            DataTable chua = Final.form.trangchinh.khoitao.loadmh();
            for (int i = 0; i < chua.Rows.Count;i++ )
            {
                if (chua.Rows[i]["TenMH"].ToString()==input)
                {
                    gitrixapxep = chua.Rows[i]["MA"].ToString().Trim();
                    break;
                }
            }
            return gitrixapxep;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dieukhien(1);
            thucthithemsoasua(caulenh);
        }




        string hamlayma()
        {
            string nextID;
            DataTable chua = Final.form.trangchinh.khoitao.loadsp();
            double[] arrCode = new double[chua.Rows.Count];
            int code;
            if (chua.Rows.Count==0)
            {
                nextID = convertToUnSign3().Remove(1) + 1;
            }else
            {
                for (int i = 0; i < chua.Rows.Count; i++)
                {
                    code = int.Parse(chua.Rows[i]["MaSP"].ToString().Remove(0, 1));
                    arrCode[i] = code;
                }
                code = Convert.ToInt32(arrCode.Max() + 1);
                nextID =  convertToUnSign3().Remove(1) + code;
            }
            return nextID;
        }


        string convertToUnSign3()
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = comboBox3.Text.Trim().Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

    }
}
