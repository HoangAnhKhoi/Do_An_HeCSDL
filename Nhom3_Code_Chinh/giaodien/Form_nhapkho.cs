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
    public partial class Form_nhapkho : Form
    {
        DataBase db = new DataBase();
        GarageDB ga = new GarageDB();
        public Form_nhapkho()
        {
            InitializeComponent();
        }
        private void Form_nhankho_Load(object sender, System.EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM  XUAT_NCC()";
                DataTable table_ncc = db.Execute(query);
                data_ncc.DataSource = table_ncc;
                string query1 = "SELECT * FROM  XUAT_NCC()";
                DataTable table_cb_ncchuVu = db.Execute(query1);
                cb_mancc.DataSource = null;
                cb_mancc.Items.Clear();
                cb_mancc.DataSource = table_cb_ncchuVu;
                cb_mancc.DisplayMember = "TenNhaCC";
                cb_mancc.ValueMember = "MaNhaCC";
                string query2 = "SELECT * FROM  XUAT_VL()";
                DataTable table_cb_vl = db.Execute(query2);
                cb_mavl.DataSource = null;
                cb_mavl.Items.Clear();
                cb_mavl.DataSource = table_cb_vl;
                cb_mavl.DisplayMember = "TenVL";
                cb_mavl.ValueMember = "MaVL";
                string query3 = "SELECT * FROM  XUAT_NV()";
                DataTable table_cb_manv = db.Execute(query3);
                cb_manv.DataSource = null;
                cb_manv.Items.Clear();
                cb_manv.DataSource = table_cb_manv;
                cb_manv.DisplayMember = "NV_NguoiID";
                cb_manv.ValueMember = "NV_NguoiID";
                string query4 = "SELECT * FROM  XUAT_VL()";
                DataTable table_vl = db.Execute(query4);
                data_vl.DataSource = table_vl;
                string query5 = "SELECT * FROM  XUAT_NHAPKHO()";
                DataTable table_NKho = db.Execute(query5);
                data_NKho.DataSource = table_NKho;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {

        }
        private int them_sua_NCC(SqlCommand cmd)
        {
            SqlParameter maNCCParam = new SqlParameter("@manhacc", txt_mancc.Text);
            maNCCParam.SqlDbType = SqlDbType.NChar;
            maNCCParam.Size = 6;
            SqlParameter tennccParam = new SqlParameter("@tennhacc", txt_tenncc.Text);
            tennccParam.SqlDbType = SqlDbType.NVarChar;
            tennccParam.Size = 30;
            SqlParameter diaChiParam = new SqlParameter("@diachi", txt_dchincc.Text);
            diaChiParam.SqlDbType = SqlDbType.NVarChar;
            diaChiParam.Size = 30;
            SqlParameter sdtParam = new SqlParameter("@dienthoai", txt_sdtncc.Text);
            sdtParam.SqlDbType = SqlDbType.Char;
            sdtParam.Size = 11;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(maNCCParam);
            cmd.Parameters.Add(tennccParam);
            cmd.Parameters.Add(diaChiParam);
            cmd.Parameters.Add(sdtParam);
            cmd.Parameters.Add(resultParam);
            db.ExecuteCMD(cmd);
            return (int)cmd.Parameters["@result"].Value;
        }
        private void btn_themncc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE THEM_NCC @manhacc,@tennhacc,@dienthoai,@diachi,@result output";
                int result = them_sua_NCC(cmd);
                if (result == 0)
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                Form_nhankho_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_suancc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE SUA_NCC @manhacc,@tennhacc,@dienthoai,@diachi,@result output";
                int result = them_sua_NCC(cmd);
                if (result == 0)
                    MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_nhankho_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoancc_Click(object sender, EventArgs e)
        {
            try
            {
                int result = ga.delete(ga.NCC, txt_mancc.Text);
                if (result == 0)
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_nhankho_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int them_sua_NKho(SqlCommand cmd)
        {
            lb_maNKho.Text = ga.LayMaSo("N");
            SqlParameter maNKhoParam = new SqlParameter("@MaNKho", lb_maNKho.Text);
            maNKhoParam.SqlDbType = SqlDbType.Char;
            maNKhoParam.Size = 15;
            SqlParameter maVLParam = new SqlParameter("@MaVL", cb_mavl.SelectedValue.ToString());
            maVLParam.SqlDbType = SqlDbType.Char;
            maVLParam.Size = 6;
            SqlParameter maNCCParam = new SqlParameter("@MaNhaCC", cb_mancc.SelectedValue.ToString());
            maNCCParam.SqlDbType = SqlDbType.Char;
            maNCCParam.Size = 6;
            SqlParameter soluongParam = new SqlParameter("@SoLuong", txt_soluong.Text);
            soluongParam.SqlDbType = SqlDbType.Int;
            SqlParameter giaTriParam = new SqlParameter("@GiaTri", txt_giatri.Text);
            giaTriParam.SqlDbType = SqlDbType.Decimal;
            SqlParameter maNVParam = new SqlParameter("@MaNV", cb_manv.SelectedValue.ToString());
            maNVParam.SqlDbType = SqlDbType.Char;
            maNVParam.Size = 6;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(maNKhoParam);
            cmd.Parameters.Add(maVLParam);
            cmd.Parameters.Add(maNCCParam);
            cmd.Parameters.Add(soluongParam);
            cmd.Parameters.Add(giaTriParam);
            cmd.Parameters.Add(maNVParam);
            cmd.Parameters.Add(resultParam);
            db.ExecuteCMD(cmd);
            return (int)cmd.Parameters["@result"].Value;
        }
        private void btn_themNKho_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE THEM_NHAPKHO @MaNKho,@MaVL,@MaNhaCC,@SoLuong,@GiaTri,@MaNV,@result output";
            int result = them_sua_NKho(cmd);
            if (result == 0)
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            }
            Form_nhankho_Load(sender, e);
        }

        private void btn_xoaNKho_Click(object sender, EventArgs e)
        {
            try
            {
                int result = ga.delete15(ga.NHAPKHO, lb_maNKho.Text);
                if (result == 0)
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_nhankho_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int them_sua_VL(SqlCommand cmd)
        {
            SqlParameter maVLParam = new SqlParameter("@mavl", txt_mavl.Text);
            maVLParam.SqlDbType = SqlDbType.Char;
            maVLParam.Size = 6;
            SqlParameter tenVLParam = new SqlParameter("@tenvl", txt_tenvl.Text);
            tenVLParam.SqlDbType = SqlDbType.NVarChar;
            tenVLParam.Size = 20;
            SqlParameter soluongParam = new SqlParameter("@soluong", txt_soluongvl.Text);
            soluongParam.SqlDbType = SqlDbType.Int;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(maVLParam);
            cmd.Parameters.Add(tenVLParam);
            cmd.Parameters.Add(soluongParam);
            cmd.Parameters.Add(resultParam);
            db.ExecuteCMD(cmd);
            return (int)cmd.Parameters["@result"].Value;
        }
        private void btn_themvl_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE THEM_VL @mavl,@tenvl,@soluong,@result output";
                int result = them_sua_VL(cmd);
                if (result == 0)
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                Form_nhankho_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_suavl_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EXECUTE SUA_VL @mavl,@tenvl,@soluong,@result output";
                int result = them_sua_VL(cmd);
                if (result == 0)
                    MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_nhankho_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_xoavl_Click(object sender, EventArgs e)
        {
            try
            {
                int result = ga.delete(ga.VL, txt_mavl.Text);
                if (result == 0 && txt_mancc.Text == "")
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_nhankho_Load(sender, e);
            }
            catch (Exception a)
            {
                MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void data_vl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = data_vl.Rows[e.RowIndex];
                if (row != null)
                {
                    txt_mavl.Text = row.Cells[0].Value.ToString();
                    txt_tenvl.Text = row.Cells[1].Value.ToString();
                    txt_soluongvl.Text = row.Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void data_ncc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = data_ncc.Rows[e.RowIndex];
                if (row != null)
                {
                    txt_mancc.Text = row.Cells[0].Value.ToString();
                    txt_tenncc.Text = row.Cells[1].Value.ToString();
                    txt_sdtncc.Text = row.Cells[2].Value.ToString();
                    txt_dchincc.Text = row.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void data_NKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = data_NKho.Rows[e.RowIndex];
                if (row != null)
                {
                    lb_maNKho.Text = row.Cells[0].Value.ToString();
                    cb_mavl.Text = row.Cells[1].Value.ToString();
                    cb_mancc.Text = row.Cells[2].Value.ToString();
                    txt_soluong.Text = row.Cells[3].Value.ToString();
                    txt_giatri.Text= row.Cells[4].Value.ToString();
                    cb_manv.Text= row.Cells[6].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_suaNKho_Click(object sender, EventArgs e)
        {

        }
    }
}
