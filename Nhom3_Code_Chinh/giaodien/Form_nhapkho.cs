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
                cb_mavl.DisplayMember = "MaVL";
                cb_mavl.ValueMember = "TenVL";
                string query3 = "SELECT * FROM  XUAT_NV()";
                DataTable table_cb_manv = db.Execute(query3);
                cb_manv.DataSource = null;
                cb_manv.Items.Clear();
                cb_manv.DataSource = table_cb_manv;
                cb_manv.DisplayMember = "NV_NguoiID";
                cb_manv.ValueMember = "NV_NguoiID";
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
            SqlParameter diaChiParam = new SqlParameter("@dienthoai", txt_dchincc.Text);
            diaChiParam.SqlDbType = SqlDbType.NVarChar;
            diaChiParam.Size = 30;
            SqlParameter sdtParam = new SqlParameter("@diachi", txt_sdtncc.Text);
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
                if (result == 0 && txt_mancc.Text=="")
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
            SqlParameter maNKhoParam = new SqlParameter("@nguoiid", ga.LayMaSo("N"));
            maNKhoParam.SqlDbType = SqlDbType.Char;
            maNKhoParam.Size = 15;
            SqlParameter maVLParam = new SqlParameter("@hoten", cb_mavl.SelectedValue.ToString());
            maVLParam.SqlDbType = SqlDbType.Char;
            maVLParam.Size = 6;
            SqlParameter maNCCParam = new SqlParameter("@diachi", cb_mancc.SelectedValue.ToString());
            maNCCParam.SqlDbType = SqlDbType.Char;
            maNCCParam.Size = 6;
            SqlParameter soluongParam = new SqlParameter("@dienthoai", txt_soluong.Text);
            soluongParam.SqlDbType = SqlDbType.Int;
            SqlParameter giaTriParam = new SqlParameter("@ngaysinh", txt_giatri);
            giaTriParam.SqlDbType = SqlDbType.Int;
            SqlParameter maNVParam = new SqlParameter("@cccd", cb_mavl.SelectedValue.ToString());
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
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
            Form_nhankho_Load(sender, e);
        }

        private void btn_xoaNKho_Click(object sender, EventArgs e)
        {
        }
    }
}
