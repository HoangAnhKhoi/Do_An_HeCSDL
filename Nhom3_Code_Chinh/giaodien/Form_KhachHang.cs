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
    public partial class Form_KhachHang : Form
    {
        GarageDB ga;
        string user;
        string pass;
        DataBase db;
        bool fix = true;
        public Form_KhachHang()
        {
            InitializeComponent();
        }
        public Form_KhachHang(string user, string pass) : this()
        {
            this.user = user;
            this.pass = pass;
            this.db = new DataBase(user, pass);
            ga = new GarageDB(user,pass);
        }

        private void gunaGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_KhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "EXEC XUAT_KH";
                DataTable table_kh = db.Execute(query);
                data_kh.DataSource = table_kh;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillDataIntoGrid(DataTable list)
        {
            /*data_KHang.Rows.Clear();
            for (int i = 0; i < list.Rows.Count; i++)
            {
                int index = data_KHang.Rows.Add();
                data_KHang.Rows[i].Cells[0].Value = list.Rows[i][0].ToString();
                data_KHang.Rows[i].Cells[1].Value = list.Rows[i][1].ToString();
                data_KHang.Rows[i].Cells[2].Value = list.Rows[i][2].ToString();
                data_KHang.Rows[i].Cells[3].Value = list.Rows[i][3].ToString();
            }*/
        }
        private int them_sua_KH(SqlCommand cmd)
        {
            int gTinh = 0;
            if (rbn_nukh.Checked == false)
                gTinh = 1;
            SqlParameter maNVParam = new SqlParameter("@nguoiid", txt_makh.Text);
            maNVParam.SqlDbType = SqlDbType.Char;
            maNVParam.Size = 6;
            SqlParameter hoTenParam = new SqlParameter("@hoten", txt_tenkh.Text);
            hoTenParam.SqlDbType = SqlDbType.NVarChar;
            hoTenParam.Size = 30;
            SqlParameter diaChiParam = new SqlParameter("@diachi", txt_diachikh.Text);
            diaChiParam.SqlDbType = SqlDbType.NVarChar;
            diaChiParam.Size = 30;
            SqlParameter sdtParam = new SqlParameter("@dienthoai", txt_sdtkh.Text);
            sdtParam.SqlDbType = SqlDbType.Char;
            sdtParam.Size = 11;
            string ngaySinh = date_ngaysinhkh.Value.ToString();
            SqlParameter ngaySinhParam = new SqlParameter("@ngaysinh", ngaySinh);
            ngaySinhParam.SqlDbType = SqlDbType.Date;
            SqlParameter cccdParam = new SqlParameter("@cccd", txt_CCCDkh.Text);
            cccdParam.SqlDbType = SqlDbType.Char;
            cccdParam.Size = 11;
            SqlParameter gTinhParam = new SqlParameter("@gioitinnh", gTinh);
            gTinhParam.SqlDbType = SqlDbType.Bit;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(maNVParam);
            cmd.Parameters.Add(hoTenParam);
            cmd.Parameters.Add(diaChiParam);
            cmd.Parameters.Add(sdtParam);
            cmd.Parameters.Add(ngaySinhParam);
            cmd.Parameters.Add(cccdParam);
            cmd.Parameters.Add(gTinhParam);
            cmd.Parameters.Add(resultParam);
            db.ExecuteCMD(cmd);
            return  (int)cmd.Parameters["@result"].Value;
        }
        private void btn_themKH_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE THEM_KH @nguoiid,@hoten,@diachi,@dienthoai,@ngaysinh,@cccd,@gioitinnh,@result output";
                int result = them_sua_KH(cmd);
                if (result == 0)
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                Form_KhachHang_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_suaKH_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE SUA_KH @nguoiid,@hoten,@diachi,@dienthoai,@ngaysinh,@cccd,@gioitinnh,@result output";
                int result = them_sua_KH(cmd);
                if (result == 0)
                    MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_KhachHang_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void btn_xoaKH_Click(object sender, EventArgs e)
        {
            try
            {
                int result = ga.delete(ga.KH, txt_makh.Text);
                if (result == 0)
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_KhachHang_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_sdt_Leave(object sender, EventArgs e)
        {
        }

        private void data_kh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fix = false;
                DataGridViewRow row = new DataGridViewRow();
                row = data_kh.Rows[e.RowIndex];
                if (row != null)
                {
                    txt_makh.Text = row.Cells[0].Value.ToString();
                    txt_tenkh.Text = row.Cells[1].Value.ToString();
                    txt_diachikh.Text = row.Cells[2].Value.ToString();
                    txt_sdtkh.Text = row.Cells[3].Value.ToString();
                    string[] arrListStr = row.Cells[4].Value.ToString().Split('/');
                    arrListStr[2] = arrListStr[2].Substring(0, 4);
                    date_ngaysinhkh.Value = new DateTime(int.Parse(arrListStr[2]), int.Parse(arrListStr[1]), int.Parse(arrListStr[0]));
                    txt_CCCDkh.Text = row.Cells[5].Value.ToString();
                    if (row.Cells[6].Value.ToString() == "False")
                        rbn_nukh.Checked = true;
                    else
                        rbn_namkh.Checked = true;
                }
                fix = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_makh_TextChanged(object sender, EventArgs e)
        {

            if (fix == true)
            {
                if (txt_makh.Text != "")
                {
                    string query = "SELECT * FROM TIM_MS_KH('" + txt_makh.Text + "')";
                    data_kh.DataSource = db.Execute(query);
                }
                else
                    Form_KhachHang_Load(sender, e);
            }
        }

        private void txt_tenkh_TextChanged(object sender, EventArgs e)
        {
            if (fix == true)
            {
                if (txt_tenkh.Text != "")
                {
                    string query = "SELECT * FROM TIM_TEN_KH(N'" + txt_tenkh.Text + "')";
                    data_kh.DataSource = db.Execute(query);
                }
                else
                    Form_KhachHang_Load(sender, e);
            }
        }
    }
}
