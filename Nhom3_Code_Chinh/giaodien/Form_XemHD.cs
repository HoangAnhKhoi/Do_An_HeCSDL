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
        public Form_XemHD()
        {
            InitializeComponent();
        }

        private void txt_mahd_Enter(object sender, EventArgs e)
        {
            if(txt_mahd.Text=="Nhập mã hợp đồng")
            {
                txt_mahd.Text = "";
                txt_mahd.ForeColor = Color.Silver;
            }    
        }

        private void txt_mahd_Leave(object sender, EventArgs e)
        {
            if (txt_mahd.Text == "")
            {
                txt_mahd.Text = "Nhập mã hợp đồng";
                txt_mahd.ForeColor = Color.Silver;
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
        }
        private void FillDataIntoGrid(DataTable list)
        {
            data_chitietHD.Rows.Clear();
            for (int i = 0; i < list.Rows.Count; i++)
            {
                int index = data_chitietHD.Rows.Add();
                data_chitietHD.Rows[i].Cells[0].Value = list.Rows[i][0].ToString();
                data_chitietHD.Rows[i].Cells[1].Value = list.Rows[i][1].ToString();
                data_chitietHD.Rows[i].Cells[2].Value = list.Rows[i][2].ToString();
                data_chitietHD.Rows[i].Cells[3].Value = list.Rows[i][3].ToString();
                data_chitietHD.Rows[i].Cells[4].Value = list.Rows[i][4].ToString();
            }
        }

        private void Form_XemHD_Load(object sender, EventArgs e)
        {

        }
    }
}
