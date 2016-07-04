using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.dataConfig;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Final.business
{
    public class xuly
    {
        public int chuyen;
        core khoitao = new core();
        public DataTable loadlop = new DataTable();
        public DataTable khoitao2 = new DataTable();

        //login
        public int login(string user, string pass)
        {
            khoitao2 = khoitao.bang(@"select * from login where taikhoan='" + user + "' and matkhau='" + pass + "'");
            if (khoitao2.Rows.Count == 1)
            {
                chuyen = Convert.ToInt32(khoitao2.Rows[0]["quyen"].ToString());
            }
            else
                MessageBox.Show("Thất Bại");
            return chuyen;
        }
        //












        //####################load###################################
        //loadbienbanthi
        public DataTable loadview()
        {
            khoitao2 = khoitao.bang(@"select TenMH,MaSP,Tensp from QLMH left join QLSP on QLMH.MA=QLSP.MA_QLMH order by TenMH asc");
            return khoitao2;
        }
        //loadMathang
        public DataTable loadmh()
        {
            khoitao2 = khoitao.bang(@"select * from QLMH");
            return khoitao2;
        }
        public DataTable loadsp()
        {
            khoitao2 = khoitao.bang(@"select MaSP,Tensp,ngaynhap,ngaysuat,soluong,donvitinh,dongia,ghichu from QLSP");
            return khoitao2;
        }
        //timkiemallinone
        public DataTable TimKiemAllInOne(string chuoi)
        {
            khoitao2 = khoitao.bang(@"" + chuoi + "");
            return khoitao2;
        }



















        //####################################checktrung#####################
        public bool checktrung(string checktrung)
        {
            khoitao2 = khoitao.bang(@"");
            if (khoitao2.Rows.Count > 0)
            {
                MessageBox.Show("Mã Giảng Viên Đã Tồn Tại");
                return false;
            }
            return true;
        }
        //kiemtratenmon
        public bool kiemtratenmon(string tenmon)
        {
            khoitao2 = khoitao.bang(@"select * from MonHoc where TenMonHoc=N'" + tenmon + "'");
            if (khoitao2.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }


        //#####################################sua############################















        #region ham edit sp
        public void suasp(string tensp,string ngaynhap,string ngaysuat,string soluong,string donvitinh,string dongia,string ghichu,string ma,string thaydoi)
        {
            try
            {
                khoitao.themsoasua(@"update QLSP set Tensp='" + tensp + "',ngaynhap=convert(datetime, '" + ngaynhap + "', 103),ngaysuat=convert(datetime, '" + ngaysuat + "', 103),soluong='" + soluong + "',donvitinh='" + donvitinh + "',dongia='" + dongia + "',ghichu='" + ghichu + "',MA_QLMH='" + ma + "' where MaSP='"+thaydoi+"'");
                MessageBox.Show(@"đã Sửa  " + khoitao.travebanghidcthuchien + " bản ghi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không hoàn hành        :" + Environment.NewLine + ex.Message.ToString(), "Lỗi Không Hoành Thành", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion



        #region Ham them SP
        public void Themsp(string MaSP, string Tensp, string ngaynhap, string ngaysuat, string soluong, string donvitinh, string dongia, string ghichu, string MA_QLMH)
        {
            try
            {
                khoitao.themsoasua(@"insert into QLSP (MaSP,Tensp,ngaynhap,ngaysuat,soluong,donvitinh,dongia,ghichu,MA_QLMH) values ('" + MaSP + "','" + Tensp + "',convert(datetime, '" + ngaynhap + "', 103),convert(datetime, '" + ngaysuat + "', 103),'" + soluong + "','" + donvitinh + "','" + dongia + "','" + ghichu + "','" + MA_QLMH + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã Đã Tồn Tại        :" + Environment.NewLine + ex.Message.ToString(), "Lỗi Không Hoành Thành", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion




        #region Ham Xoa San Pham Su Dung SP
        public void delsp(string ID)
        {
            try
            {
                khoitao.hamdelSP(@"delSP", ID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("thêm không hoàn hành        :" + Environment.NewLine + ex.Message.ToString(), "Lỗi Không Hoành Thành", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}