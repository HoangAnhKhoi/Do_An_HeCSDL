namespace giaodien
{
    partial class Form_XemHD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_mahd = new Guna.UI.WinForms.GunaTextBox();
            this.data_chitietHD = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_timkiem = new Guna.UI.WinForms.GunaButton();
            this.lb_gthopdong = new System.Windows.Forms.Label();
            this.lb_kh = new System.Windows.Forms.Label();
            this.lb_ngaygiaodk = new System.Windows.Forms.Label();
            this.lb_soxehd = new System.Windows.Forms.Label();
            this.lb_ngayhopdong = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lb_sohd = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_ngaynghiemthu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.data_chitietHD)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_mahd
            // 
            this.txt_mahd.BaseColor = System.Drawing.Color.White;
            this.txt_mahd.BorderColor = System.Drawing.Color.DimGray;
            this.txt_mahd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_mahd.FocusedBaseColor = System.Drawing.Color.White;
            this.txt_mahd.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txt_mahd.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_mahd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_mahd.ForeColor = System.Drawing.Color.Black;
            this.txt_mahd.Location = new System.Drawing.Point(16, 25);
            this.txt_mahd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_mahd.Name = "txt_mahd";
            this.txt_mahd.PasswordChar = '\0';
            this.txt_mahd.SelectedText = "";
            this.txt_mahd.Size = new System.Drawing.Size(813, 37);
            this.txt_mahd.TabIndex = 0;
            this.txt_mahd.Text = "Nhập mã hợp đồng";
            this.txt_mahd.Enter += new System.EventHandler(this.txt_mahd_Enter);
            this.txt_mahd.Leave += new System.EventHandler(this.txt_mahd_Leave);
            // 
            // data_chitietHD
            // 
            this.data_chitietHD.AllowUserToAddRows = false;
            this.data_chitietHD.AllowUserToResizeRows = false;
            this.data_chitietHD.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_chitietHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data_chitietHD.ColumnHeadersHeight = 40;
            this.data_chitietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.data_chitietHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.data_chitietHD.Location = new System.Drawing.Point(424, 73);
            this.data_chitietHD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.data_chitietHD.Name = "data_chitietHD";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.data_chitietHD.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.data_chitietHD.RowHeadersVisible = false;
            this.data_chitietHD.RowHeadersWidth = 51;
            this.data_chitietHD.Size = new System.Drawing.Size(616, 506);
            this.data_chitietHD.TabIndex = 19;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TenCV";
            this.dataGridViewTextBoxColumn3.HeaderText = "Công việc";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TriGiaCV";
            this.dataGridViewTextBoxColumn4.HeaderText = "Trị giá công việc";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TenTho";
            this.dataGridViewTextBoxColumn5.HeaderText = "Tên thợ";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.AnimationHoverSpeed = 0.07F;
            this.btn_timkiem.AnimationSpeed = 0.03F;
            this.btn_timkiem.BackColor = System.Drawing.Color.Transparent;
            this.btn_timkiem.BaseColor = System.Drawing.Color.Transparent;
            this.btn_timkiem.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_timkiem.BorderSize = 2;
            this.btn_timkiem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_timkiem.FocusedColor = System.Drawing.Color.Empty;
            this.btn_timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.ForeColor = System.Drawing.Color.LightGray;
            this.btn_timkiem.Image = null;
            this.btn_timkiem.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_timkiem.Location = new System.Drawing.Point(837, 15);
            this.btn_timkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btn_timkiem.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_timkiem.OnHoverForeColor = System.Drawing.Color.White;
            this.btn_timkiem.OnHoverImage = null;
            this.btn_timkiem.OnPressedColor = System.Drawing.Color.Black;
            this.btn_timkiem.Radius = 20;
            this.btn_timkiem.Size = new System.Drawing.Size(189, 50);
            this.btn_timkiem.TabIndex = 21;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // lb_gthopdong
            // 
            this.lb_gthopdong.AutoSize = true;
            this.lb_gthopdong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_gthopdong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_gthopdong.Location = new System.Drawing.Point(187, 492);
            this.lb_gthopdong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_gthopdong.Name = "lb_gthopdong";
            this.lb_gthopdong.Size = new System.Drawing.Size(73, 24);
            this.lb_gthopdong.TabIndex = 89;
            this.lb_gthopdong.Text = "10000Đ";
            this.lb_gthopdong.TextChanged += new System.EventHandler(this.lb_gthopdong_TextChanged);
            // 
            // lb_kh
            // 
            this.lb_kh.AutoSize = true;
            this.lb_kh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_kh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_kh.Location = new System.Drawing.Point(187, 175);
            this.lb_kh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_kh.Name = "lb_kh";
            this.lb_kh.Size = new System.Drawing.Size(66, 24);
            this.lb_kh.TabIndex = 88;
            this.lb_kh.Text = "KH001";
            // 
            // lb_ngaygiaodk
            // 
            this.lb_ngaygiaodk.AutoSize = true;
            this.lb_ngaygiaodk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ngaygiaodk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_ngaygiaodk.Location = new System.Drawing.Point(187, 374);
            this.lb_ngaygiaodk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ngaygiaodk.Name = "lb_ngaygiaodk";
            this.lb_ngaygiaodk.Size = new System.Drawing.Size(100, 24);
            this.lb_ngaygiaodk.TabIndex = 87;
            this.lb_ngaygiaodk.Text = "21/11/2002";
            // 
            // lb_soxehd
            // 
            this.lb_soxehd.AutoSize = true;
            this.lb_soxehd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_soxehd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_soxehd.Location = new System.Drawing.Point(187, 306);
            this.lb_soxehd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_soxehd.Name = "lb_soxehd";
            this.lb_soxehd.Size = new System.Drawing.Size(109, 24);
            this.lb_soxehd.TabIndex = 86;
            this.lb_soxehd.Text = "78D1-67894";
            // 
            // lb_ngayhopdong
            // 
            this.lb_ngayhopdong.AutoSize = true;
            this.lb_ngayhopdong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ngayhopdong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_ngayhopdong.Location = new System.Drawing.Point(187, 242);
            this.lb_ngayhopdong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ngayhopdong.Name = "lb_ngayhopdong";
            this.lb_ngayhopdong.Size = new System.Drawing.Size(80, 24);
            this.lb_ngayhopdong.TabIndex = 85;
            this.lb_ngayhopdong.Text = "2/1/2002";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(20, 492);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(155, 24);
            this.label15.TabIndex = 84;
            this.label15.Text = "Trị giá hợp đồng:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(20, 175);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 24);
            this.label14.TabIndex = 83;
            this.label14.Text = "Mã khách hàng:";
            // 
            // lb_sohd
            // 
            this.lb_sohd.AutoSize = true;
            this.lb_sohd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sohd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_sohd.Location = new System.Drawing.Point(187, 111);
            this.lb_sohd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_sohd.Name = "lb_sohd";
            this.lb_sohd.Size = new System.Drawing.Size(67, 24);
            this.lb_sohd.TabIndex = 82;
            this.lb_sohd.Text = "HD001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(19, 374);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 24);
            this.label5.TabIndex = 81;
            this.label5.Text = "Ngày giao dự kiến:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(21, 308);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 80;
            this.label3.Text = "Số xe:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(20, 242);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 79;
            this.label1.Text = "Ngày hợp đồng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(11, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 78;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(20, 111);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 24);
            this.label12.TabIndex = 77;
            this.label12.Text = "Số hợp đồng:";
            // 
            // lb_ngaynghiemthu
            // 
            this.lb_ngaynghiemthu.AutoSize = true;
            this.lb_ngaynghiemthu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ngaynghiemthu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lb_ngaynghiemthu.Location = new System.Drawing.Point(187, 436);
            this.lb_ngaynghiemthu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_ngaynghiemthu.Name = "lb_ngaynghiemthu";
            this.lb_ngaynghiemthu.Size = new System.Drawing.Size(100, 24);
            this.lb_ngaynghiemthu.TabIndex = 91;
            this.lb_ngaynghiemthu.Text = "21/11/2002";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(20, 436);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 24);
            this.label6.TabIndex = 90;
            this.label6.Text = "Ngày nghiệm thu:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label17.Location = new System.Drawing.Point(20, 137);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(203, 17);
            this.label17.TabIndex = 92;
            this.label17.Text = "⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(21, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 17);
            this.label2.TabIndex = 93;
            this.label2.Text = "⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(20, 267);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 17);
            this.label7.TabIndex = 94;
            this.label7.Text = "⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(24, 331);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 17);
            this.label8.TabIndex = 95;
            this.label8.Text = "⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(24, 399);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 17);
            this.label9.TabIndex = 96;
            this.label9.Text = "⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(24, 460);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(203, 17);
            this.label10.TabIndex = 97;
            this.label10.Text = "⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(21, 521);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(203, 17);
            this.label11.TabIndex = 98;
            this.label11.Text = "⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺⎺";
            // 
            // Form_XemHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1056, 593);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lb_ngaynghiemthu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_gthopdong);
            this.Controls.Add(this.lb_kh);
            this.Controls.Add(this.lb_ngaygiaodk);
            this.Controls.Add(this.lb_soxehd);
            this.Controls.Add(this.lb_ngayhopdong);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lb_sohd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_timkiem);
            this.Controls.Add(this.data_chitietHD);
            this.Controls.Add(this.txt_mahd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_XemHD";
            this.Text = "Form_XemHD";
            ((System.ComponentModel.ISupportInitialize)(this.data_chitietHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaTextBox txt_mahd;
        private System.Windows.Forms.DataGridView data_chitietHD;
        private Guna.UI.WinForms.GunaButton btn_timkiem;
        private System.Windows.Forms.Label lb_gthopdong;
        private System.Windows.Forms.Label lb_kh;
        private System.Windows.Forms.Label lb_ngaygiaodk;
        private System.Windows.Forms.Label lb_soxehd;
        private System.Windows.Forms.Label lb_ngayhopdong;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lb_sohd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lb_ngaynghiemthu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}