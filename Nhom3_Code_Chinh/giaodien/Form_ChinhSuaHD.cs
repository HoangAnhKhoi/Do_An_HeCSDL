using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using Spire.Doc.Formatting;
using Document = Spire.Doc.Document;

namespace giaodien
{
    public partial class Form_ChinhSuaHD : Form
    {
        private System.Data.DataTable tb_cv = new System.Data.DataTable();
        private System.Data.DataTable CV = new System.Data.DataTable();
        public Form_ChinhSuaHD()
        {
            InitializeComponent();
        }

        private void Form_ChinhSuaHD_Load(object sender, EventArgs e)
        {

        }
        private void FillComBoKH(System.Data.DataTable list)
        {

        }
        private void FillComBoCV(System.Data.DataTable list)
        {
        }
        private void FillComBoTHO(System.Data.DataTable list)
        {
        }
        private void gunaButton1_Click(object sender, EventArgs e)
        {

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
        private void txt_sohd_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_soxe_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cb_makh_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void date_ngaygiaohd_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void date_ngayhd_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {

        }

        private void btn_themcv_Click(object sender, EventArgs e)
        {

        }
        private void FillDataCV(System.Data.DataTable list)
        {

        }

        private void btn_xoacv_Click(object sender, EventArgs e)
        {

        }

        private void data_cvhopdong_Click(object sender, EventArgs e)
        {
        }

        private void data_cvhopdong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_sohd_Leave(object sender, EventArgs e)
        {
       
        }

        private void txt_sohd_Enter(object sender, EventArgs e)
        {
            
        }

        private void cb_makh_Leave(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
