using Spire.Doc.Documents;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace giaodien
{
    public partial class Form_ChinhSuaHD : Form
    {
        DataBase db = new DataBase();
        GarageDB ga = new GarageDB();
        bool save;
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
            string query1 = "SELECT * FROM  XUAT_KH()";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btn_themhd_Click(object sender, EventArgs e)
        {
            lb_sohd.Text = ga.LayMaSo("H");
            lb_kh.Text = cb_makh.Text;
            lb_ngayhopdong.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lb_soxehd.Text = txtSoxe.Text;
            lb_ngaygiaodk.Text = date_ngaygiaodukien.Text;
            lb_gthopdong.Text = "0Đ";
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
            Form_ChinhSuaHD_Load(sender, e);
        }
        private void btn_xemcthd_Click(object sender, EventArgs e)
        {

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
            FillDataCV(tb_cv);
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
                }
            }
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
            
        }
    }
}
