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
    public partial class Form_Chinh : Form
    {
        string user;
        string pass;
        public Form_Chinh()
        {
            InitializeComponent();
            custom();
        }
        public Form_Chinh(string user, string pass) :this()
        {
            this.user = user;
            this.pass = pass;
        }
        private void custom()
        {
      
            pnlHopDong.Visible = false;
        }
        private void hidesubmenu()
        {
            
            if (pnlHopDong.Visible == true)
            {
                pnlHopDong.Visible = false;
            }
        }
        private void showsubmenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                hidesubmenu();
                subMenu.Visible = true;
            }    
            else
                subMenu.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private  Form ActiveForm = null;
        private void openchildform(Form childform)
        {
            if(ActiveForm != null)
            {
                ActiveForm.Close();
            }    
            ActiveForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelchild.Controls.Add(childform);
            panelchild.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            pnlstats.Height = btnNhanVien.Height;
            pnlstats.Top = btnNhanVien.Top;
            openchildform(new Form_NhanVien(user,pass));
        }

        private void btnCongViec_Click(object sender, EventArgs e)
        {
            pnlstats.Height = btnCongViec.Height;
            pnlstats.Top = btnCongViec.Top;
            openchildform(new Form_CongViec(user, pass));
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            pnlstats.Height = btnKhachHang.Height;
            pnlstats.Top = btnKhachHang.Top;
            openchildform(new Form_KhachHang(user, pass));

        }

        private void btnHopDong_Click(object sender, EventArgs e)
        {
            pnlstats.Height = btnHopDong.Height;
            pnlstats.Top = btnHopDong.Top;
            showsubmenu(pnlHopDong);
        }

        private void btnPhieuThu_Click(object sender, EventArgs e)
        {
            pnlstats.Height = btnPhieuThu.Height;
            pnlstats.Top = btnPhieuThu.Top;
            openchildform(new Form_PhieuThu(user, pass));
        }
        private void btnDoanhSo_Click(object sender, EventArgs e)
        {
            pnlstats.Height = btnDoanhSo.Height;
            pnlstats.Top = btnDoanhSo.Top;
            openchildform(new Form_DoanhThuMotThang(user, pass));
        }

        private void Form_Chinh_Load(object sender, EventArgs e)
        {

        }
        private void btnChinhSuaHD_Click(object sender, EventArgs e)
        {
            openchildform(new Form_ChinhSuaHD(user, pass));
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            openchildform(new Form_XemHD());
        }
        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            pnlstats.Height = btnNhapKho.Height;
            pnlstats.Top = btnNhapKho.Top;
            openchildform(new Form_nhapkho(user, pass));
        }


        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.ShowDialog();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
