using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giaodien
{
    public partial class Form_DoanhThuMotThang : Form
    {
        GarageDB gr;
        GarageDB ga;
        string user;
        string pass;
        DataBase db;
        public Form_DoanhThuMotThang()
        {
            InitializeComponent();
        }
        public Form_DoanhThuMotThang(string user, string pass) : this()
        {
            this.user = user;
            this.pass = pass;
            this.db = new DataBase(user, pass);
            this.gr = new GarageDB(user, pass);
            this.ga = new GarageDB(user, pass);
        }

        private void btn_tinhDthu_Click(object sender, EventArgs e)
        {
            try
            {
                string BD = date_from.Value.ToString("yyyy-MM-dd");
                string KT = date_to.Value.ToString("yyyy-MM-dd");
                string query1 = "SELECT * FROM XUAT_DOANHTHU('" + BD + "','" + KT + "')";
                DataTable tb1 = db.Execute(query1);
                string query2 = "DECLARE @result int EXEC @result= DOANHTHU '" + BD + "','" + KT + "' SELECT @result";
                DataTable tb2 = db.Execute(query2);
                txt_tongtien.Text = tb2.Rows[0][0].ToString();
                data_DoanhThu.DataSource = tb1;
                string query3 = "SELECT * FROM XUAT_NHAPKHO_BACKUP('" + BD + "','" + KT + "')";
                data_NKho.DataSource = db.Execute(query3);
                string query4 = "DECLARE @result int EXEC @result= TONGTIEN_NHAPKHO '" + BD + "','" + KT + "' SELECT @result";
                DataTable tb3 = db.Execute(query4);
                txt_tienNKho.Text = tb3.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form_DoanhThuMotThang_Load(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string BD = date_from.Value.ToString("yyyy-MM-dd");
                string KT = date_to.Value.ToString("yyyy-MM-dd");
                string query1 = "EXEC XOA_DOANHTHU '" + BD + "','" + KT + "'";
                db.ExecuteNonQuery(query1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xuatDL_Click(object sender, EventArgs e)
        {

        }
    }
}
