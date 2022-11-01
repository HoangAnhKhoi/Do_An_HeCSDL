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
        private System.Data.DataTable tb_cv = new System.Data.DataTable();
        private System.Data.DataTable CV = new System.Data.DataTable();
        public Form_ChinhSuaHD()
        {
            InitializeComponent();
        }

        private void Form_ChinhSuaHD_Load(object sender, EventArgs e)
        {
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
            string query = "SELECT * FROM  XUAT_HDONG()";
            DataTable table_hd = db.Execute(query);
            dtgHopDong.DataSource = table_hd;
            tabControl1.Controls.Remove(tab_chinhsua);
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
            tabControl1.Controls.Remove(tab_hd);
            tabControl1.Controls.Add(tab_chinhsua);
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
                DataRow row = tb_cv.NewRow();
                row["MaCV"] = macv;
                row["TenCV"] = tencv;
                row["MaTho"] = matho;
                row["TenTho"] = tentho;
                tb_cv.Rows.Add(row);
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
        private void btn_luuhd_Click(object sender, EventArgs e)
        {

        }
    }
}
