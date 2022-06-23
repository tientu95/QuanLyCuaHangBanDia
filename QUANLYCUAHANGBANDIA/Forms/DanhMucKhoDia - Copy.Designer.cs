
namespace Quan_ly_cua_hang_ban_dia.Forms
{
    partial class frm_DMKhodia
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
            this.dg_Khodia = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OPEN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Anh = new System.Windows.Forms.TextBox();
            this.txt_Ghichu = new System.Windows.Forms.TextBox();
            this.txt_Madia = new System.Windows.Forms.TextBox();
            this.cbo_Maloai = new System.Windows.Forms.ComboBox();
            this.cbo_MaNSX = new System.Windows.Forms.ComboBox();
            this.txt_Tendia = new System.Windows.Forms.TextBox();
            this.txt_Dongiaban = new System.Windows.Forms.TextBox();
            this.txt_Dongianhap = new System.Windows.Forms.TextBox();
            this.txt_Soluong = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_Dong = new System.Windows.Forms.Button();
            this.btn_Hienthi = new System.Windows.Forms.Button();
            this.btn_Timkiem = new System.Windows.Forms.Button();
            this.btn_Boqua = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.pxbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Khodia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxbox)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Khodia
            // 
            this.dg_Khodia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Khodia.Location = new System.Drawing.Point(2, 345);
            this.dg_Khodia.Name = "dg_Khodia";
            this.dg_Khodia.RowHeadersWidth = 51;
            this.dg_Khodia.RowTemplate.Height = 24;
            this.dg_Khodia.Size = new System.Drawing.Size(1116, 270);
            this.dg_Khodia.TabIndex = 27;
            this.dg_Khodia.Click += new System.EventHandler(this.dg_Khodia_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Mã đĩa";
            // 
            // btn_OPEN
            // 
            this.btn_OPEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OPEN.Location = new System.Drawing.Point(324, 148);
            this.btn_OPEN.Name = "btn_OPEN";
            this.btn_OPEN.Size = new System.Drawing.Size(113, 40);
            this.btn_OPEN.TabIndex = 8;
            this.btn_OPEN.Text = "Open Image";
            this.btn_OPEN.UseVisualStyleBackColor = true;
            this.btn_OPEN.Click += new System.EventHandler(this.btn_OPEN_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tên đĩa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "Thể loại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 34;
            this.label4.Text = "Nơi sản xuất";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "Số lượng ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Đơn giá nhập";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Đơn giá bán";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(261, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 16);
            this.label8.TabIndex = 44;
            this.label8.Text = "Ảnh";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(261, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 16);
            this.label9.TabIndex = 45;
            this.label9.Text = "Ghi chú";
            // 
            // txt_Anh
            // 
            this.txt_Anh.Location = new System.Drawing.Point(324, 112);
            this.txt_Anh.Name = "txt_Anh";
            this.txt_Anh.Size = new System.Drawing.Size(172, 20);
            this.txt_Anh.TabIndex = 7;
            // 
            // txt_Ghichu
            // 
            this.txt_Ghichu.Location = new System.Drawing.Point(324, 213);
            this.txt_Ghichu.Multiline = true;
            this.txt_Ghichu.Name = "txt_Ghichu";
            this.txt_Ghichu.Size = new System.Drawing.Size(362, 113);
            this.txt_Ghichu.TabIndex = 9;
            // 
            // txt_Madia
            // 
            this.txt_Madia.Location = new System.Drawing.Point(106, 28);
            this.txt_Madia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Madia.Name = "txt_Madia";
            this.txt_Madia.Size = new System.Drawing.Size(140, 20);
            this.txt_Madia.TabIndex = 0;
            // 
            // cbo_Maloai
            // 
            this.cbo_Maloai.FormattingEnabled = true;
            this.cbo_Maloai.Location = new System.Drawing.Point(106, 122);
            this.cbo_Maloai.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_Maloai.Name = "cbo_Maloai";
            this.cbo_Maloai.Size = new System.Drawing.Size(140, 21);
            this.cbo_Maloai.TabIndex = 2;
            // 
            // cbo_MaNSX
            // 
            this.cbo_MaNSX.FormattingEnabled = true;
            this.cbo_MaNSX.Location = new System.Drawing.Point(106, 169);
            this.cbo_MaNSX.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_MaNSX.Name = "cbo_MaNSX";
            this.cbo_MaNSX.Size = new System.Drawing.Size(140, 21);
            this.cbo_MaNSX.TabIndex = 3;
            // 
            // txt_Tendia
            // 
            this.txt_Tendia.Location = new System.Drawing.Point(106, 75);
            this.txt_Tendia.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Tendia.Name = "txt_Tendia";
            this.txt_Tendia.Size = new System.Drawing.Size(140, 20);
            this.txt_Tendia.TabIndex = 1;
            // 
            // txt_Dongiaban
            // 
            this.txt_Dongiaban.Location = new System.Drawing.Point(106, 310);
            this.txt_Dongiaban.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Dongiaban.Name = "txt_Dongiaban";
            this.txt_Dongiaban.Size = new System.Drawing.Size(140, 20);
            this.txt_Dongiaban.TabIndex = 6;
            // 
            // txt_Dongianhap
            // 
            this.txt_Dongianhap.Location = new System.Drawing.Point(106, 263);
            this.txt_Dongianhap.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Dongianhap.Name = "txt_Dongianhap";
            this.txt_Dongianhap.Size = new System.Drawing.Size(140, 20);
            this.txt_Dongianhap.TabIndex = 5;
            this.txt_Dongianhap.TextChanged += new System.EventHandler(this.txt_Dongianhap_TextChanged);
            this.txt_Dongianhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Dongianhap_KeyPress);
            // 
            // txt_Soluong
            // 
            this.txt_Soluong.Location = new System.Drawing.Point(106, 216);
            this.txt_Soluong.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Soluong.Name = "txt_Soluong";
            this.txt_Soluong.Size = new System.Drawing.Size(140, 20);
            this.txt_Soluong.TabIndex = 4;
            this.txt_Soluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Soluong_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(320, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(208, 25);
            this.label10.TabIndex = 46;
            this.label10.Text = "Danh Mục Kho Đĩa";
            // 
            // btn_Dong
            // 
            this.btn_Dong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Thoat;
            this.btn_Dong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dong.Location = new System.Drawing.Point(984, 620);
            this.btn_Dong.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(102, 38);
            this.btn_Dong.TabIndex = 17;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Dong.UseVisualStyleBackColor = true;
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // btn_Hienthi
            // 
            this.btn_Hienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Hienthi.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Hien_thi;
            this.btn_Hienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Hienthi.Location = new System.Drawing.Point(839, 620);
            this.btn_Hienthi.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Hienthi.Name = "btn_Hienthi";
            this.btn_Hienthi.Size = new System.Drawing.Size(124, 38);
            this.btn_Hienthi.TabIndex = 16;
            this.btn_Hienthi.Text = "Hiển thị DS";
            this.btn_Hienthi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Hienthi.UseVisualStyleBackColor = true;
            this.btn_Hienthi.Click += new System.EventHandler(this.btn_Hienthi_Click);
            // 
            // btn_Timkiem
            // 
            this.btn_Timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Timkiem.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Tim__2_;
            this.btn_Timkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Timkiem.Location = new System.Drawing.Point(704, 620);
            this.btn_Timkiem.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Timkiem.Name = "btn_Timkiem";
            this.btn_Timkiem.Size = new System.Drawing.Size(114, 38);
            this.btn_Timkiem.TabIndex = 15;
            this.btn_Timkiem.Text = "Tìm kiếm";
            this.btn_Timkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Timkiem.UseVisualStyleBackColor = true;
            this.btn_Timkiem.Click += new System.EventHandler(this.btn_Timkiem_Click);
            // 
            // btn_Boqua
            // 
            this.btn_Boqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Boqua.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.next;
            this.btn_Boqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Boqua.Location = new System.Drawing.Point(569, 620);
            this.btn_Boqua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Boqua.Name = "btn_Boqua";
            this.btn_Boqua.Size = new System.Drawing.Size(114, 38);
            this.btn_Boqua.TabIndex = 14;
            this.btn_Boqua.Text = "Bỏ qua";
            this.btn_Boqua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Boqua.UseVisualStyleBackColor = true;
            this.btn_Boqua.Click += new System.EventHandler(this.btn_Boqua_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Luu.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Luu1;
            this.btn_Luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Luu.Location = new System.Drawing.Point(299, 620);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(114, 38);
            this.btn_Luu.TabIndex = 12;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Xoa4;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(434, 620);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(114, 38);
            this.btn_Xoa.TabIndex = 13;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.sua;
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(164, 620);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(114, 38);
            this.btn_Sua.TabIndex = 11;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Them;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(29, 620);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(114, 38);
            this.btn_Them.TabIndex = 10;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // pxbox
            // 
            this.pxbox.Location = new System.Drawing.Point(692, 0);
            this.pxbox.Name = "pxbox";
            this.pxbox.Size = new System.Drawing.Size(426, 339);
            this.pxbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pxbox.TabIndex = 30;
            this.pxbox.TabStop = false;
            // 
            // frm_DMKhodia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1117, 669);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.btn_Hienthi);
            this.Controls.Add(this.btn_Timkiem);
            this.Controls.Add(this.btn_Boqua);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.txt_Madia);
            this.Controls.Add(this.cbo_Maloai);
            this.Controls.Add(this.cbo_MaNSX);
            this.Controls.Add(this.txt_Tendia);
            this.Controls.Add(this.txt_Dongiaban);
            this.Controls.Add(this.txt_Dongianhap);
            this.Controls.Add(this.txt_Soluong);
            this.Controls.Add(this.txt_Ghichu);
            this.Controls.Add(this.txt_Anh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_OPEN);
            this.Controls.Add(this.pxbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_Khodia);
            this.Name = "frm_DMKhodia";
            this.Text = "DanhMucKhoDia";
            this.Load += new System.EventHandler(this.frm_Khodia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Khodia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pxbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dg_Khodia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pxbox;
        private System.Windows.Forms.Button btn_OPEN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Anh;
        private System.Windows.Forms.TextBox txt_Ghichu;
        public System.Windows.Forms.TextBox txt_Madia;
        private System.Windows.Forms.ComboBox cbo_Maloai;
        private System.Windows.Forms.ComboBox cbo_MaNSX;
        private System.Windows.Forms.TextBox txt_Tendia;
        private System.Windows.Forms.TextBox txt_Dongiaban;
        private System.Windows.Forms.TextBox txt_Dongianhap;
        private System.Windows.Forms.TextBox txt_Soluong;
        private System.Windows.Forms.Button btn_Dong;
        private System.Windows.Forms.Button btn_Hienthi;
        private System.Windows.Forms.Button btn_Timkiem;
        private System.Windows.Forms.Button btn_Boqua;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Label label10;
    }
}