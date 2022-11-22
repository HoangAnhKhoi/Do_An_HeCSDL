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
    public partial class Sign_up : Form
    {

        //DataBase db = new DataBase("sa","01677448545");
        //GarageDB gr = new GarageDB("sa", "01677448545");
        DataBase db = new DataBase("sa", "123456");
        GarageDB gr = new GarageDB("sa", "123456");
        public Sign_up()
        {
            InitializeComponent();
        }
        private void ĐNhap_txt_Enter(object sender, EventArgs e)
        {
            if (ĐNhap_txt.Text == "Tên đăng nhập")
            {
                ĐNhap_txt.Text = "";
                ĐNhap_txt.ForeColor = Color.Black;
            }
        }

        private void ĐNhap_txt_Leave(object sender, EventArgs e)
        {
            if (ĐNhap_txt.Text == "")
            {
                ĐNhap_txt.Text = "Tên đăng nhập";
                ĐNhap_txt.ForeColor = Color.Silver;
            }
        }

        private void MKhau_txt_Enter(object sender, EventArgs e)
        {
            if (MKhau_txt.Text == "Mật khẩu")
            {
                MKhau_txt.Text = "";
                MKhau_txt.UseSystemPasswordChar = true;
                MKhau_txt.ForeColor = Color.Black;
            }
        }

        private void MKhau_txt_Leave(object sender, EventArgs e)
        {
            if (MKhau_txt.Text == "")
            {
                MKhau_txt.UseSystemPasswordChar = false;
                MKhau_txt.Text = "Mật khẩu";
                MKhau_txt.ForeColor = Color.Silver;
            }
        }

        private void MaQL_txt_Enter(object sender, EventArgs e)
        {
            if (MaQL_txt.Text == "Mã quản lý")
            {
                MaQL_txt.Text = "";
                MaQL_txt.ForeColor = Color.Black;
            }
        }

        private void MaQL_txt_Leave(object sender, EventArgs e)
        {
            if (MaQL_txt.Text == "")
            {
                MaQL_txt.Text = "Mã quản lý";
                MaQL_txt.ForeColor = Color.Silver;
            }
        }

        private void Mkhau2_txt_Enter(object sender, EventArgs e)
        {
            if (Mkhau2_txt.Text == "Nhập lại mật khẩu")
            {
                Mkhau2_txt.UseSystemPasswordChar = true;
                Mkhau2_txt.Text = "";
                Mkhau2_txt.ForeColor = Color.Black;
            }
        }

        private void Mkhau2_txt_Leave(object sender, EventArgs e)
        {
            if (Mkhau2_txt.Text == "")
            {
                Mkhau2_txt.UseSystemPasswordChar = false;
                Mkhau2_txt.Text = "Nhập lại mật khẩu";
                Mkhau2_txt.ForeColor = Color.Silver;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.ShowDialog();
        }

        private void Sign_up_Load(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_chucvusu_DropDownClosed(object sender, EventArgs e)
        {
            this.cb_chucvusu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void SingUp_btn_Click_1(object sender, EventArgs e)
        {
            if (ĐNhap_txt.Text == "Tên đăng nhập" || MKhau_txt.Text == "Mật khẩu" || MaQL_txt.Text == "Mã quản lý")
            {
                MessageBox.Show("Hãy nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (MaQL_txt.Text != "123456")
                    MessageBox.Show("Mã quản lý không đúng", "Thông báo", MessageBoxButtons.OK);
                else
                {
                    string str = "SELECT dbo.XACMINH_USERS('" + ĐNhap_txt.Text + "','" + MKhau_txt.Text + "',N'" + cb_chucvusu.Text + "')   ";
                    DataTable tb = db.Execute(str);
                    if (int.Parse(tb.Rows[0][0].ToString()) == 0 || int.Parse(tb.Rows[0][0].ToString()) == 1)
                        MessageBox.Show("Tên đăng nhập này đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                    else
                    {
                        if (String.Compare(Mkhau2_txt.Text.ToString(), MKhau_txt.Text.ToString(), false) == 0)
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandText = "EXECUTE THEM_USER @user,@pass,@chucvu,@manv,@result output";
                            SqlParameter userParam = new SqlParameter("@user", ĐNhap_txt.Text);
                            userParam.SqlDbType = SqlDbType.VarChar;
                            userParam.Size = 20;
                            SqlParameter passParam = new SqlParameter("@pass", MKhau_txt.Text);
                            passParam.SqlDbType = SqlDbType.VarChar;
                            passParam.Size = 20;
                            SqlParameter chucvuParam = new SqlParameter("@chucvu", cb_chucvusu.Text);
                            chucvuParam.SqlDbType = SqlDbType.NVarChar;
                            chucvuParam.Size = 30;
                            SqlParameter manvParam = new SqlParameter("@manv", cb_chucvusu.Text);
                            manvParam.SqlDbType = SqlDbType.Char;
                            manvParam.Size = 6;
                            SqlParameter resultParam = new SqlParameter("@result", 0);
                            resultParam.SqlDbType = SqlDbType.Int;
                            resultParam.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(userParam);
                            cmd.Parameters.Add(passParam);
                            cmd.Parameters.Add(chucvuParam);
                            cmd.Parameters.Add(manvParam);
                            cmd.Parameters.Add(resultParam);
                            db.ExecuteCMD(cmd);
                            int result = (int)cmd.Parameters["@result"].Value;
                            if (result == 0)
                                MessageBox.Show("Tạo tài khoản không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                            this.Hide();
                            Form1 a = new Form1();
                            a.ShowDialog();
                        }
                        else
                            MessageBox.Show("Mật khẩu không giống nhau", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void txt_manv_Leave(object sender, EventArgs e)
        {
            if (txt_manv.Text == "")
            {
                txt_manv.UseSystemPasswordChar = false;
                txt_manv.Text = "Mã số nhân viên";
                txt_manv.ForeColor = Color.Silver;
            }
        }

        private void txt_manv_Enter(object sender, EventArgs e)
        {
            if (txt_manv.Text == "Mã số nhân viên")
            {
                txt_manv.UseSystemPasswordChar = true;
                txt_manv.Text = "";
                txt_manv.ForeColor = Color.Black;
            }
        }
    }
}
