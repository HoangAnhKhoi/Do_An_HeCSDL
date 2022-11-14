using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giaodien
{
    public partial class Forgot_password : Form
    {

        DataBase db = new DataBase("sa","01677448545");
        GarageDB ga = new GarageDB("sa","01677448545");
        public Forgot_password()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Forgot_password_Load(object sender, EventArgs e)
        {
            txt_FMKhau2.Hide();
            txt_FMKhau.Hide();
            btn_accept.Hide();
        }

        private void txt_FAcc_Enter(object sender, EventArgs e)
        {
            if (txt_FAcc.Text == "Tên đăng nhập")
            {
                txt_FAcc.Text = "";
                txt_FAcc.ForeColor = Color.White;
            }
        }

        private void txt_FAcc_Leave(object sender, EventArgs e)
        {
            if (txt_FAcc.Text == "")
            {
                txt_FAcc.Text = "Tên đăng nhập";
                txt_FAcc.ForeColor = Color.Silver;
            }
        }

        private void txt_FHoTen_Enter(object sender, EventArgs e)
        {
            //if (txt_FHoTen.Text == "Họ và tên")
            //{
            //    txt_FHoTen.Text = "";
            //    txt_FHoTen.ForeColor = Color.White;
            //}
        }

        private void txt_FHoTen_Leave(object sender, EventArgs e)
        {
            //if (txt_FHoTen.Text == "")
            //{
            //    txt_FHoTen.Text = "Họ và tên";
            //    txt_FHoTen.ForeColor = Color.Silver;
            //}
        }

        private void txt_FMaQL_Enter(object sender, EventArgs e)
        {
            if (txt_FMaQL.Text == "Mã quản lý")
            {
                txt_FMaQL.Text = "";
                txt_FMaQL.ForeColor = Color.White;
            }
        }

        private void txt_FMaQL_Leave(object sender, EventArgs e)
        {
            if (txt_FMaQL.Text == "")
            {
                txt_FMaQL.Text = "Mã quản lý";
                txt_FMaQL.ForeColor = Color.Silver;
            }
        }

        private void txt_FMKhau_Enter(object sender, EventArgs e)
        {
            if (txt_FMKhau.Text == "Mật khẩu mới")
            {
                txt_FMKhau.Text = "";
                txt_FMKhau.ForeColor = Color.White;
            }
        }

        private void txt_FMKhau_Leave(object sender, EventArgs e)
        {
            if (txt_FMKhau.Text == "")
            {
                txt_FMKhau.Text = "Mật khẩu mới";
                txt_FMKhau.ForeColor = Color.Silver;
            }
        }

        private void txt_FMKhau2_Enter(object sender, EventArgs e)
        {
            if (txt_FMKhau2.Text == "Nhập lại mật khẩu")
            {
                txt_FMKhau2.Text = "";
                txt_FMKhau2.ForeColor = Color.White;
            }
        }

        private void txt_FMKhau2_Leave(object sender, EventArgs e)
        {
            if (txt_FMKhau2.Text == "")
            {
                txt_FMKhau2.Text = "Nhập lại mật khẩu";
                txt_FMKhau2.ForeColor = Color.Silver;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.ShowDialog();
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            if (String.Compare(txt_FMKhau.Text, txt_FMKhau2.Text, false) == 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE SUA_USERS @user,@pass,@chucvu,@result output";
                SqlParameter userParam = new SqlParameter("@user", txt_FAcc.Text);
                userParam.SqlDbType = SqlDbType.VarChar;
                userParam.Size = 20;
                SqlParameter passParam = new SqlParameter("@pass", txt_FMKhau.Text);
                passParam.SqlDbType = SqlDbType.VarChar;
                passParam.Size = 20;
                SqlParameter chucvuParam = new SqlParameter("@chucvu", cb_chucvusu.Text);
                chucvuParam.SqlDbType = SqlDbType.NVarChar;
                chucvuParam.Size = 30;
                SqlParameter resultParam = new SqlParameter("@result", 0);
                resultParam.SqlDbType = SqlDbType.Int;
                resultParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(userParam);
                cmd.Parameters.Add(passParam);
                cmd.Parameters.Add(chucvuParam);
                cmd.Parameters.Add(resultParam);
                db.ExecuteCMD(cmd);
                int result = (int)cmd.Parameters["@result"].Value;
                if (result == 0)
                    MessageBox.Show("Sửa tài khoản không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Sửa tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                this.Hide();
                Form1 a = new Form1();
                a.ShowDialog();
            }
            else
                MessageBox.Show("Mật khẩu không giống nhau", "Thông báo", MessageBoxButtons.OK);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_FMaQL.Text == "Mã quản lý" || txt_FAcc.Text == "Tên tài khoản")
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            else
            {
                if (txt_FMaQL.Text != "123456")
                    MessageBox.Show("Mã quản lý không đúng", "Thông báo", MessageBoxButtons.OK);
                else
                {
                    string str = "SELECT dbo.XACMINH_USERS('" + txt_FAcc.Text + "','',N'" + cb_chucvusu.Text + "')";
                    DataTable tb = db.Execute(str);
                    if (int.Parse(tb.Rows[0][0].ToString()) == 1)
                    {
                        txt_FMKhau.Show();
                        txt_FMKhau2.Show();
                        txt_FAcc.Hide();
                        cb_chucvusu.Hide();
                        txt_FMaQL.Hide();
                        btn_accept.Show();
                        btn_search.Hide();
                    }
                    else
                        MessageBox.Show("Tên đăng nhập không tồn tại", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.ShowDialog();
        }
    }
}
