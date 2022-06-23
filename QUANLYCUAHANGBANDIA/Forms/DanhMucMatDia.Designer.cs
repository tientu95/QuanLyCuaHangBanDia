
namespace Quan_ly_cua_hang_ban_dia.Forms
{
    partial class frm_DMMatDia
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
            this.dg_Matdia = new System.Windows.Forms.DataGridView();
            this.msk_Ngaymat = new System.Windows.Forms.MaskedTextBox();
            this.txt_Solanmat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Soluongmat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Dong = new System.Windows.Forms.Button();
            this.btn_Boqua = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.cbo_Madia = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Matdia)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Matdia
            // 
            this.dg_Matdia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Matdia.Location = new System.Drawing.Point(46, 269);
            this.dg_Matdia.Margin = new System.Windows.Forms.Padding(2);
            this.dg_Matdia.Name = "dg_Matdia";
            this.dg_Matdia.RowHeadersWidth = 51;
            this.dg_Matdia.RowTemplate.Height = 24;
            this.dg_Matdia.Size = new System.Drawing.Size(668, 176);
            this.dg_Matdia.TabIndex = 10;
            this.dg_Matdia.Click += new System.EventHandler(this.dg_Matdia_Click);
            // 
            // msk_Ngaymat
            // 
            this.msk_Ngaymat.Location = new System.Drawing.Point(520, 102);
            this.msk_Ngaymat.Margin = new System.Windows.Forms.Padding(2);
            this.msk_Ngaymat.Mask = "00/00/0000";
            this.msk_Ngaymat.Name = "msk_Ngaymat";
            this.msk_Ngaymat.Size = new System.Drawing.Size(194, 20);
            this.msk_Ngaymat.TabIndex = 2;
            this.msk_Ngaymat.ValidatingType = typeof(System.DateTime);
            // 
            // txt_Solanmat
            // 
            this.txt_Solanmat.Location = new System.Drawing.Point(142, 104);
            this.txt_Solanmat.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Solanmat.Name = "txt_Solanmat";
            this.txt_Solanmat.Size = new System.Drawing.Size(170, 20);
            this.txt_Solanmat.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Số lần mất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Mã đĩa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(404, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Ngày mất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(404, 214);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Số lượng mất";
            // 
            // txt_Soluongmat
            // 
            this.txt_Soluongmat.Location = new System.Drawing.Point(520, 213);
            this.txt_Soluongmat.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Soluongmat.Name = "txt_Soluongmat";
            this.txt_Soluongmat.Size = new System.Drawing.Size(194, 20);
            this.txt_Soluongmat.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(267, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 24);
            this.label8.TabIndex = 41;
            this.label8.Text = "Danh Mục Mất Đĩa";
            // 
            // btn_Dong
            // 
            this.btn_Dong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Thoat;
            this.btn_Dong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dong.Location = new System.Drawing.Point(621, 466);
            this.btn_Dong.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(97, 38);
            this.btn_Dong.TabIndex = 9;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Dong.UseVisualStyleBackColor = true;
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // btn_Boqua
            // 
            this.btn_Boqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Boqua.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.next;
            this.btn_Boqua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Boqua.Location = new System.Drawing.Point(506, 466);
            this.btn_Boqua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Boqua.Name = "btn_Boqua";
            this.btn_Boqua.Size = new System.Drawing.Size(97, 38);
            this.btn_Boqua.TabIndex = 8;
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
            this.btn_Luu.Location = new System.Drawing.Point(391, 466);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(97, 38);
            this.btn_Luu.TabIndex = 7;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.sua;
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(276, 466);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(97, 38);
            this.btn_Sua.TabIndex = 6;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Xoa4;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(161, 466);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(97, 38);
            this.btn_Xoa.TabIndex = 5;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Them;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(46, 466);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(97, 38);
            this.btn_Them.TabIndex = 4;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // cbo_Madia
            // 
            this.cbo_Madia.FormattingEnabled = true;
            this.cbo_Madia.Location = new System.Drawing.Point(142, 210);
            this.cbo_Madia.Name = "cbo_Madia";
            this.cbo_Madia.Size = new System.Drawing.Size(170, 21);
            this.cbo_Madia.TabIndex = 42;
            // 
            // frm_DMMatDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(759, 532);
            this.Controls.Add(this.cbo_Madia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Soluongmat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Solanmat);
            this.Controls.Add(this.msk_Ngaymat);
            this.Controls.Add(this.dg_Matdia);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.btn_Boqua);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_DMMatDia";
            this.Text = "Mất đĩa";
            this.Load += new System.EventHandler(this.DanhMucMatDia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Matdia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Dong;
        private System.Windows.Forms.Button btn_Boqua;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.DataGridView dg_Matdia;
        private System.Windows.Forms.MaskedTextBox msk_Ngaymat;
        private System.Windows.Forms.TextBox txt_Solanmat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Soluongmat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbo_Madia;
    }
}