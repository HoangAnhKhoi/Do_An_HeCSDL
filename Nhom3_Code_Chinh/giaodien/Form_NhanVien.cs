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
    public partial class Form_NhanVien : Form
    {
        GarageDB ga;
        string user;
        string pass;
        DataBase db;
        bool fix = true;
        public Form_NhanVien()
        {
            InitializeComponent();
        }
        public Form_NhanVien(string user, string pass) :this()
        {
            this.user = user;
            this.pass = pass;
            this.db = new DataBase(user, pass);
            this.ga = new GarageDB(user,pass);
        }
        private void Form_NhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                string query1 = "EXEC XUAT_CHUCVU";
                DataTable table_chuVu = db.Execute(query1);
                cb_chucvu.DataSource = null;
                cb_chucvu.Items.Clear();
                cb_chucvu.DataSource = table_chuVu;
                cb_chucvu.DisplayMember = "TenCV";
                cb_chucvu.ValueMember = "MaCV";
                Form1 formDangNhap = new Form1();
                string query = "EXEC XUAT_NV";
                DataTable table_nv = db.Execute(query);
                data_nv.DataSource = table_nv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillDataIntoGrid(DataTable list)
        {
            data_nv.Rows.Clear();
            for (int i = 0; i < list.Rows.Count; i++)
            {
                int index = data_nv.Rows.Add();
                data_nv.Rows[i].Cells[0].Value = list.Rows[i][0].ToString();
                data_nv.Rows[i].Cells[1].Value = list.Rows[i][1].ToString();
                data_nv.Rows[i].Cells[2].Value = list.Rows[i][2].ToString();
                data_nv.Rows[i].Cells[3].Value = list.Rows[i][3].ToString();
                data_nv.Rows[i].Cells[4].Value = list.Rows[i][4].ToString();
            }
        }

        private void txt_luong_Leave(object sender, EventArgs e)
        {
        }
        private int them_sua_NV(SqlCommand cmd)
        {
            int gTinh = 0;
            if (rdn_nu.Checked == false)
                gTinh = 1;
            SqlParameter maNVParam = new SqlParameter("@nguoiid", txt_manv.Text);
            maNVParam.SqlDbType = SqlDbType.Char;
            maNVParam.Size = 6;
            SqlParameter hoTenParam = new SqlParameter("@hoten", txt_tennv.Text);
            hoTenParam.SqlDbType = SqlDbType.NVarChar;
            hoTenParam.Size = 30;
            SqlParameter diaChiParam = new SqlParameter("@diachi", txt_dchinv.Text);
            diaChiParam.SqlDbType = SqlDbType.NVarChar;
            diaChiParam.Size = 30;
            SqlParameter sdtParam = new SqlParameter("@dienthoai", txt_sdtnv.Text);
            sdtParam.SqlDbType = SqlDbType.Char;
            sdtParam.Size = 11;
            string ngaySinh = date_ngaysinh.Value.ToString();
            SqlParameter ngaySinhParam = new SqlParameter("@ngaysinh", ngaySinh);
            ngaySinhParam.SqlDbType = SqlDbType.Date;
            SqlParameter cccdParam = new SqlParameter("@cccd", txt_cccdnv.Text);
            cccdParam.SqlDbType = SqlDbType.Char;
            cccdParam.Size = 11;
            SqlParameter gTinhParam = new SqlParameter("@gioitinnh", gTinh);
            gTinhParam.SqlDbType = SqlDbType.Bit;
            SqlParameter maChucVuParam = new SqlParameter("@macv", cb_chucvu.SelectedValue.ToString());
            maChucVuParam.SqlDbType = SqlDbType.Char;
            maChucVuParam.Size = 6;
            SqlParameter luongParam = new SqlParameter("@luong", txt_luong.Text);
            luongParam.SqlDbType = SqlDbType.Decimal;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(luongParam);
            cmd.Parameters.Add(maChucVuParam);
            cmd.Parameters.Add(maNVParam);
            cmd.Parameters.Add(hoTenParam);
            cmd.Parameters.Add(diaChiParam);
            cmd.Parameters.Add(sdtParam);
            cmd.Parameters.Add(ngaySinhParam);
            cmd.Parameters.Add(cccdParam);
            cmd.Parameters.Add(gTinhParam);
            cmd.Parameters.Add(resultParam);
            db.ExecuteCMD(cmd);
            return (int)cmd.Parameters["@result"].Value;
        }
        private void btn_themnv_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE THEM_NV @nguoiid,@hoten,@diachi,@dienthoai,@ngaysinh,@cccd,@gioitinnh,@macv,@luong,@result output";
                int result = them_sua_NV(cmd);
                if (result == 0)
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                Form_NhanVien_Load(sender, e);
            }
            catch(Exception a)
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_suanv_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE SUA_NV @nguoiid,@hoten,@diachi,@dienthoai,@ngaysinh,@cccd,@gioitinnh,@macv,@luong,@result output";
                int result = them_sua_NV(cmd);
                if (result == 0)
                    MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_NhanVien_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoanv_Click_1(object sender, EventArgs e)
        {
            try
            {
                int result = ga.delete(ga.NHANVIEN, txt_manv.Text);
                if (result == 0)
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_NhanVien_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_manv_TextChanged(object sender, EventArgs e)
        {
            if (fix == true)
            {
                if (txt_manv.Text != "" && fix != true)
                {
                    string query = "SELECT * FROM TIM_MS_NV('" + txt_manv.Text + "')";
                    data_nv.DataSource = db.Execute(query);
                }
                else
                    Form_NhanVien_Load(sender, e);
            }
        }

        private void txt_tennv_TextChanged(object sender, EventArgs e)
        {
            if (fix == true)
            {
                if (txt_tennv.Text != "" && fix != true)
                {
                    string query = "SELECT * FROM TIM_TEN_NV(N'" + txt_tennv.Text + "')";
                    data_nv.DataSource = db.Execute(query);
                }
                else
                    Form_NhanVien_Load(sender, e);
            }
        }

        private void data_nv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (data_nv.Rows.Count != 1)
                {
                    fix = false;
                    DataGridViewRow row = new DataGridViewRow();
                    row = data_nv.Rows[e.RowIndex];
                    if (row != data_nv.Rows[data_nv.Rows.Count - 1] && row != null)
                    {
                        txt_dchinv.Text = row.Cells[2].Value.ToString();
                        txt_sdtnv.Text = row.Cells[3].Value.ToString();
                        string[] arrListStr = row.Cells[4].Value.ToString().Split('/');
                        arrListStr[2] = arrListStr[2].Substring(0, 4);
                        date_ngaysinh.Value = new DateTime(int.Parse(arrListStr[2]), int.Parse(arrListStr[1]), int.Parse(arrListStr[0]));
                        txt_cccdnv.Text = row.Cells[5].Value.ToString();
                        if (row.Cells[6].Value.ToString() == "False")
                            rdn_nu.Checked = true;
                        else
                            rbn_nam.Checked = true;
                        cb_chucvu.Text = row.Cells[7].Value.ToString();
                        txt_luong.Text = row.Cells[8].Value.ToString();
                        txt_manv.Text = row.Cells[0].Value.ToString();
                        txt_tennv.Text = row.Cells[1].Value.ToString();
                    }
                    fix = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_luong_TextChanged(object sender, EventArgs e)
        {
            txt_luong.Text = string.Format("{0:0,0}", decimal.Parse(txt_luong.Text));
            txt_luong.SelectionStart = txt_luong.Text.Length;
        }

        private void txt_luong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void cb_chucvu_TextChanged(object sender, EventArgs e)
        {
            if (fix == true)
            {
                if (cb_chucvu.Text != "")
                {
                    string query = "SELECT * FROM XUAT_NV_CHUCVU('" + cb_chucvu.SelectedValue.ToString() + "')";
                    data_nv.DataSource = db.Execute(query);
                }
                else
                    Form_NhanVien_Load(sender, e);
            }
        }
    }
}
