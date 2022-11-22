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
    public partial class Form_XemHD : Form
    {
        GarageDB ga;
        string user;
        string pass;
        DataBase db;
        public Form_XemHD(string user, string pass) : this()
        {
            this.user = user;
            this.pass = pass;
            this.db = new DataBase(user, pass);
            this.ga = new GarageDB(user, pass);
        }
        public Form_XemHD()
        {
            InitializeComponent();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            try
            {
                string query1 = "SELECT * FROM XUAT_HOPDONG_BACKUP('" + txt_mahd.Text + "')";
                DataTable hd = db.Execute(query1);
                if(hd.Rows.Count==1)
                {
                    lb_sohd.Text = hd.Rows[0][0].ToString();
                    lb_ngayhopdong.Text= hd.Rows[0][1].ToString();
                    lb_kh.Text= hd.Rows[0][2].ToString();
                    lb_soxehd.Text= hd.Rows[0][3].ToString();
                    lb_gthopdong.Text= hd.Rows[0][4].ToString();
                    lb_ngaygiaodk.Text= hd.Rows[0][5].ToString();
                    lb_ngaynghiemthu.Text= hd.Rows[0][6].ToString();
                    string query2 = "SELECT * FROM CONGVIEC_HD('" + txt_mahd.Text + "')";
                    data_chitietHD.DataSource = db.Execute(query2);
                }    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_mahd_Leave(object sender, EventArgs e)
        {
            if (txt_mahd.Text == "")
            {
                txt_mahd.Text = "Nhập mã hợp đồng";
                txt_mahd.ForeColor = Color.Gray;
            }
        }

        private void txt_mahd_Enter(object sender, EventArgs e)
        {
            if (txt_mahd.Text == "Nhập mã hợp đồng")
            {
                txt_mahd.Text = "";
                txt_mahd.ForeColor = Color.Gray;
            }
        }

        private void lb_gthopdong_TextChanged(object sender, EventArgs e)
        {
            lb_gthopdong.Text = string.Format("{0:0,0}", decimal.Parse(lb_gthopdong.Text));
        }
    }
}
