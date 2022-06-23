
namespace Quan_ly_cua_hang_ban_dia.Forms
{
    partial class frm_DMNoiSanXuat
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
            this.Dg_Noisanxuat = new System.Windows.Forms.DataGridView();
            this.txt_Mansx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Tennsx = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Dong = new System.Windows.Forms.Button();
            this.btn_Boqua = new System.Windows.Forms.Button();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Dg_Noisanxuat)).BeginInit();
            this.SuspendLayout();
            // 
            // Dg_Noisanxuat
            // 
            this.Dg_Noisanxuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dg_Noisanxuat.Location = new System.Drawing.Point(34, 180);
            this.Dg_Noisanxuat.Margin = new System.Windows.Forms.Padding(2);
            this.Dg_Noisanxuat.Name = "Dg_Noisanxuat";
            this.Dg_Noisanxuat.RowHeadersWidth = 51;
            this.Dg_Noisanxuat.RowTemplate.Height = 24;
            this.Dg_Noisanxuat.Size = new System.Drawing.Size(670, 146);
            this.Dg_Noisanxuat.TabIndex = 8;
            this.Dg_Noisanxuat.Click += new System.EventHandler(this.Dg_Noisanxuat_Click);
            // 
            // txt_Mansx
            // 
            this.txt_Mansx.Location = new System.Drawing.Point(165, 83);
            this.txt_Mansx.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Mansx.Multiline = true;
            this.txt_Mansx.Name = "txt_Mansx";
            this.txt_Mansx.Size = new System.Drawing.Size(174, 27);
            this.txt_Mansx.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 18);
            this.label1.TabIndex = 47;
            this.label1.Text = "Mã nơi sản xuất";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(374, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 26);
            this.label2.TabIndex = 48;
            this.label2.Text = "Tên nơi sản xuất";
            // 
            // txt_Tennsx
            // 
            this.txt_Tennsx.Location = new System.Drawing.Point(506, 83);
            this.txt_Tennsx.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Tennsx.Multiline = true;
            this.txt_Tennsx.Name = "txt_Tennsx";
            this.txt_Tennsx.Size = new System.Drawing.Size(174, 27);
            this.txt_Tennsx.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(239, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(234, 24);
            this.label8.TabIndex = 49;
            this.label8.Text = "Danh Mục Nơi Sản Xuất";
            // 
            // btn_Dong
            // 
            this.btn_Dong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Thoat;
            this.btn_Dong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dong.Location = new System.Drawing.Point(604, 372);
            this.btn_Dong.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(100, 38);
            this.btn_Dong.TabIndex = 7;
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
            this.btn_Boqua.Location = new System.Drawing.Point(493, 372);
            this.btn_Boqua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Boqua.Name = "btn_Boqua";
            this.btn_Boqua.Size = new System.Drawing.Size(100, 38);
            this.btn_Boqua.TabIndex = 6;
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
            this.btn_Luu.Location = new System.Drawing.Point(377, 372);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(100, 38);
            this.btn_Luu.TabIndex = 5;
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
            this.btn_Sua.Location = new System.Drawing.Point(263, 372);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(100, 38);
            this.btn_Sua.TabIndex = 4;
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
            this.btn_Xoa.Location = new System.Drawing.Point(142, 372);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(100, 38);
            this.btn_Xoa.TabIndex = 3;
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
            this.btn_Them.Location = new System.Drawing.Point(28, 372);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(100, 38);
            this.btn_Them.TabIndex = 2;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // frm_DMNoiSanXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(734, 431);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_Tennsx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Mansx);
            this.Controls.Add(this.Dg_Noisanxuat);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.btn_Boqua);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_DMNoiSanXuat";
            this.Text = "frm_Noisanxuat";
            this.Load += new System.EventHandler(this.DanhMucNoiSanXuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dg_Noisanxuat)).EndInit();
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
        private System.Windows.Forms.DataGridView Dg_Noisanxuat;
        private System.Windows.Forms.TextBox txt_Mansx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Tennsx;
        private System.Windows.Forms.Label label8;
    }
}