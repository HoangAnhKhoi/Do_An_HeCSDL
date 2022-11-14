﻿using Spire.Doc.Documents;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace giaodien
{
    public partial class Form_ChinhSuaHD : Form
    {
        GarageDB ga;
        string user;
        string pass;
        DataBase db;
        public Form_ChinhSuaHD(string user, string pass) : this()
        {
            this.user = user;
            this.pass = pass;
            this.db = new DataBase(user, pass);
            this.ga = new GarageDB(user, pass);
        }
        bool save=false;
        private System.Data.DataTable tb_cv = new System.Data.DataTable();
        private System.Data.DataTable CV = new System.Data.DataTable();
        public Form_ChinhSuaHD()
        {
            InitializeComponent();
            DataColumn column3 = new DataColumn("MaCV");
            column3.DataType = typeof(string);
            tb_cv.Columns.Add(column3);
            DataColumn column4 = new DataColumn("TenCV");
            column4.DataType = typeof(string);
            tb_cv.Columns.Add(column4);
            DataColumn column1 = new DataColumn("MaTho");
            column1.DataType = typeof(string);
            tb_cv.Columns.Add(column1);
            DataColumn column2 = new DataColumn("TenTho");
            column2.DataType = typeof(string);
            tb_cv.Columns.Add(column2);
            tabControl1.Controls.Remove(tab_chinhsua);
        }

        private void Form_ChinhSuaHD_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM  XUAT_HDONG()";
            DataTable table_hd = db.Execute(query);
            dtgHopDong.DataSource = table_hd;
            string query1 = "EXEC XUAT_KH";
            DataTable table_kh = db.Execute(query1);
            cb_makh.DataSource = null;
            cb_makh.Items.Clear();
            cb_makh.DataSource = table_kh;
            cb_makh.DisplayMember = "KH_NguoiID";
            cb_makh.ValueMember = "KH_NguoiID";
        }
        private void ghileft(ref Spire.Doc.Document doc, string str)
        {
            Spire.Doc.Documents.Paragraph paragraph = doc.Sections[0].AddParagraph();
            Spire.Doc.Fields.TextRange text = paragraph.AppendText(str);
            text.CharacterFormat.Bold = false;
            text.CharacterFormat.FontSize = 14;
            paragraph.Format.TextAlignment = TextAlignment.Center;
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Left;
        }
        private void ghiright(ref Spire.Doc.Document doc, string str)
        {
            Spire.Doc.Documents.Paragraph paragraph = doc.Sections[0].AddParagraph();
            Spire.Doc.Fields.TextRange text = paragraph.AppendText(str);
            text.CharacterFormat.Bold = false;
            text.CharacterFormat.FontSize = 14;
            paragraph.Format.TextAlignment = TextAlignment.Auto;
            paragraph.Format.HorizontalAlignment = Spire.Doc.Documents.HorizontalAlignment.Right;
        }
        private void setup_chinhsua()
        {
            lb_sohd.Text = ga.LayMaSo("H");
            lb_kh.Text = cb_makh.Text;
            lb_soxehd.Text = txtSoxe.Text;
            lb_ngaygiaodk.Text = date_ngaygiaodukien.Text;
            string query1 = "SELECT * FROM  XUAT_NV_CHUCVU('3')";
            DataTable table_thochinh = db.Execute(query1);
            cb_thochinh.DataSource = null;
            cb_thochinh.Items.Clear();
            cb_thochinh.DataSource = table_thochinh;
            cb_thochinh.DisplayMember = "Hoten";
            cb_thochinh.ValueMember = "NV_NguoiID";
            string query2 = "SELECT * FROM  XUAT_CVIEC()";
            DataTable table_cviec = db.Execute(query2);
            cb_congviec.DataSource = null;
            cb_congviec.Items.Clear();
            cb_congviec.DataSource = table_cviec;
            cb_congviec.DisplayMember = "NoiDungCV";
            cb_congviec.ValueMember = "MaCViec";
        }
        private void btn_themhd_Click(object sender, EventArgs e)
        {
            setup_chinhsua();
            lb_ngayhopdong.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lb_sohd.Text = ga.LayMaSo("H");
            lb_gthopdong.Text = "0Đ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE THEM_HDONG @SoHD,@KH_NguoiID,@SoXe,@NgayGiaoDuKien,@result output";
            int result = them_sua_HD(cmd);
            if (result == 0)
                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                tabControl1.TabPages.Add(tab_chinhsua);
                tabControl1.TabPages.Remove(tab_hd);
            }
        }
        private void btn_xemcthd_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TIMKIEM_HDONG('" + txtSoHopDong.Text + "')";
            DataTable table_hd = db.Execute(query);
            if(table_hd.Rows.Count==0)
                MessageBox.Show("Không có hợp đồng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                lb_sohd.Text = table_hd.Rows[0][0].ToString();
                lb_ngayhopdong.Text= table_hd.Rows[0][2].ToString();
                lb_kh.Text= table_hd.Rows[0][2].ToString();
                lb_soxehd.Text= table_hd.Rows[0][3].ToString();
                lb_gthopdong.Text= table_hd.Rows[0][4].ToString();
                lb_ngaygiaodk.Text= table_hd.Rows[0][5].ToString();
            }
        }
        private void btn_themcvhd_Click(object sender, EventArgs e)
        {
            bool a = true;
            string macv = cb_congviec.SelectedValue.ToString();
            string tencv = cb_congviec.Text;
            string matho = cb_thochinh.SelectedValue.ToString();
            string tentho = cb_thochinh.Text;
            for (int i = 0; i < tb_cv.Rows.Count; i++)
            {
                if (macv == tb_cv.Rows[i][0].ToString())
                {
                    a = false;
                    break;
                }
            }
            if (a == false)
                MessageBox.Show("Công việc đã có trong hợp đồng", "Thông báo", MessageBoxButtons.OK);
            else
            {
                SqlCommand cmd = new SqlCommand();
                int result = them_ChiTietHD(macv, matho);
                if (result == 2)
                {
                    MessageBox.Show("Vật liệu của công việc không sẵn sàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 0)
                {
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DataRow row = tb_cv.NewRow();
                    row["MaCV"] = macv;
                    row["TenCV"] = tencv;
                    row["MaTho"] = matho;
                    row["TenTho"] = tentho;
                    tb_cv.Rows.Add(row);
                }
            }
            update_trigiahd();
            FillDataCV(tb_cv);
        }
        private void update_trigiahd()
        {
            string query = " SELECT * FROM TIMKIEM_HDONG('" + lb_sohd.Text + "')";
            DataTable table_hd = db.Execute(query);
            lb_gthopdong.Text = table_hd.Rows[0][4].ToString()+"Đ";
        }
        private void FillDataCV(System.Data.DataTable list)
        {
            data_cv.Rows.Clear();
            for (int i = 0; i < list.Rows.Count; i++)
            {
                int index = data_cv.Rows.Add();
                data_cv.Rows[i].Cells[1].Value = list.Rows[i][1].ToString();
                data_cv.Rows[i].Cells[0].Value = list.Rows[i][3].ToString();
            }
        }

        private void btn_xoacvhd_Click(object sender, EventArgs e)
        {
            string macv = cb_congviec.SelectedValue.ToString();
            string tencv = cb_congviec.Text;
            foreach (DataRow i in tb_cv.Rows)
            {
                if (i["MaCV"].ToString() == macv)
                {
                    i.Delete();
                    break;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText="EXECUTE XOA_CHITIET_HD @sohd,@macv";
                    SqlParameter soHDParam = new SqlParameter("@sohd", lb_sohd.Text);
                    soHDParam.SqlDbType = SqlDbType.Char;
                    soHDParam.Size = 15;
                    SqlParameter maCVParam = new SqlParameter("@macv", macv);
                    maCVParam.SqlDbType = SqlDbType.Char;
                    maCVParam.Size = 6;
                    cmd.Parameters.Add(soHDParam);
                    cmd.Parameters.Add(maCVParam);
                    db.ExecuteCMD(cmd);
                }
            }
            update_trigiahd();
            FillDataCV(tb_cv);
        }
        private int them_sua_HD(SqlCommand cmd)
        {
            SqlParameter soHDParam = new SqlParameter("@SoHD", lb_sohd.Text);
            soHDParam.SqlDbType = SqlDbType.Char;
            soHDParam.Size = 15;
            SqlParameter idKHParam = new SqlParameter("@KH_NguoiID", lb_kh.Text);
            idKHParam.SqlDbType = SqlDbType.Char;
            idKHParam.Size = 6;
            SqlParameter soxeParam = new SqlParameter("@SoXe", lb_soxehd.Text);
            soxeParam.SqlDbType = SqlDbType.Char;
            soxeParam.Size = 10;
            SqlParameter ngaygdkParam = new SqlParameter("@NgayGiaoDuKien", date_ngaygiaodukien.Text);
            ngaygdkParam.SqlDbType = SqlDbType.Date;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(soHDParam);
            cmd.Parameters.Add(idKHParam);
            cmd.Parameters.Add(soxeParam);
            cmd.Parameters.Add(ngaygdkParam);
            cmd.Parameters.Add(resultParam);
            db.ExecuteCMD(cmd);
            return (int)cmd.Parameters["@result"].Value;
        }
        private int them_ChiTietHD(string macv, string manv)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EXECUTE THEM_CHITIET_HD @SoHD,@MaCV,@MaNV,@result output";
            SqlParameter soHDParam = new SqlParameter("@SoHD", lb_sohd.Text);
            soHDParam.SqlDbType = SqlDbType.Char;
            soHDParam.Size = 15;
            SqlParameter maCVParam = new SqlParameter("@MaCV", macv);
            maCVParam.SqlDbType = SqlDbType.Char;
            maCVParam.Size = 6;
            SqlParameter maNVParam = new SqlParameter("@MaNV", manv);
            maNVParam.SqlDbType = SqlDbType.Char;
            maNVParam.Size = 6;
            SqlParameter resultParam = new SqlParameter("@result", 0);
            resultParam.SqlDbType = SqlDbType.Int;
            resultParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(soHDParam);
            cmd.Parameters.Add(maCVParam);
            cmd.Parameters.Add(maNVParam);
            cmd.Parameters.Add(resultParam);
            db.ExecuteCMD(cmd);
            return (int)cmd.Parameters["@result"].Value;
        }
        private void btn_luuhd_Click(object sender, EventArgs e)
        {
            save = true;
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            if(save == true)
            {
                tabControl1.Controls.Remove(tab_chinhsua);
                tabControl1.Controls.Add(tab_hd);
                save = false;
            }
            else
            {
                if (MessageBox.Show("Hợp đồng chưa được lưu. Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ga.delete15(ga.HD, lb_sohd.Text);
                    tabControl1.Controls.Remove(tab_chinhsua);
                    tabControl1.Controls.Add(tab_hd);
                }
            }
            tb_cv.Clear();
            data_cv.Rows.Clear();
            Form_ChinhSuaHD_Load(sender, e);
        }

        private void cb_thochinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void data_cv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                    DataGridViewRow row = new DataGridViewRow();
                    row = data_cv.Rows[e.RowIndex];
                    if (row != null)
                    {
                        cb_thochinh.Text = row.Cells[0].Value.ToString();
                        cb_congviec.Text = row.Cells[1].Value.ToString();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xoahd_Click(object sender, EventArgs e)
        {
            try
            {
                int result = ga.delete15(ga.HD, txtSoHopDong.Text);
                if (result == 0)
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                Form_ChinhSuaHD_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
