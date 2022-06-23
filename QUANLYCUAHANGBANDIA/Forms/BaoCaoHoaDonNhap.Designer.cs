
namespace Quan_ly_cua_hang_ban_dia.Forms
{
    partial class BaoCaoHoaDonNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dg_Baocaohdn = new System.Windows.Forms.DataGridView();
            this.txt_Nam = new System.Windows.Forms.TextBox();
            this.cbo_Thang = new System.Windows.Forms.ComboBox();
            this.btn_Dong = new System.Windows.Forms.Button();
            this.btn_In = new System.Windows.Forms.Button();
            this.btn_Timlai = new System.Windows.Forms.Button();
            this.btn_Hienthi = new System.Windows.Forms.Button();
            this.txt_Tongtiennhap = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Baocaohdn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(426, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(426, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tháng :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(396, 375);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tổng tiền";
            // 
            // dg_Baocaohdn
            // 
            this.dg_Baocaohdn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Baocaohdn.Location = new System.Drawing.Point(21, 211);
            this.dg_Baocaohdn.Margin = new System.Windows.Forms.Padding(2);
            this.dg_Baocaohdn.Name = "dg_Baocaohdn";
            this.dg_Baocaohdn.RowHeadersWidth = 62;
            this.dg_Baocaohdn.RowTemplate.Height = 28;
            this.dg_Baocaohdn.Size = new System.Drawing.Size(575, 145);
            this.dg_Baocaohdn.TabIndex = 4;
            // 
            // txt_Nam
            // 
            this.txt_Nam.Location = new System.Drawing.Point(483, 147);
            this.txt_Nam.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Nam.Name = "txt_Nam";
            this.txt_Nam.Size = new System.Drawing.Size(113, 20);
            this.txt_Nam.TabIndex = 5;
            // 
            // cbo_Thang
            // 
            this.cbo_Thang.FormattingEnabled = true;
            this.cbo_Thang.Location = new System.Drawing.Point(483, 66);
            this.cbo_Thang.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_Thang.Name = "cbo_Thang";
            this.cbo_Thang.Size = new System.Drawing.Size(113, 21);
            this.cbo_Thang.TabIndex = 6;
            // 
            // btn_Dong
            // 
            this.btn_Dong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Thoat;
            this.btn_Dong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dong.Location = new System.Drawing.Point(198, 136);
            this.btn_Dong.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(109, 43);
            this.btn_Dong.TabIndex = 7;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Dong.UseVisualStyleBackColor = true;
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // btn_In
            // 
            this.btn_In.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_In.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Xuat_excel;
            this.btn_In.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_In.Location = new System.Drawing.Point(49, 135);
            this.btn_In.Margin = new System.Windows.Forms.Padding(2);
            this.btn_In.Name = "btn_In";
            this.btn_In.Size = new System.Drawing.Size(117, 43);
            this.btn_In.TabIndex = 8;
            this.btn_In.Text = "In báo cáo";
            this.btn_In.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_In.UseVisualStyleBackColor = true;
            this.btn_In.Click += new System.EventHandler(this.btn_In_Click);
            // 
            // btn_Timlai
            // 
            this.btn_Timlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Timlai.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Hopstarter_Soft_Scraps_Document_Preview;
            this.btn_Timlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Timlai.Location = new System.Drawing.Point(198, 55);
            this.btn_Timlai.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Timlai.Name = "btn_Timlai";
            this.btn_Timlai.Size = new System.Drawing.Size(109, 43);
            this.btn_Timlai.TabIndex = 9;
            this.btn_Timlai.Text = "Tìm lại";
            this.btn_Timlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Timlai.UseVisualStyleBackColor = true;
            this.btn_Timlai.Click += new System.EventHandler(this.btn_Timlai_Click);
            // 
            // btn_Hienthi
            // 
            this.btn_Hienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Hienthi.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Hopstarter_Soft_Scraps_Edit_Document;
            this.btn_Hienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Hienthi.Location = new System.Drawing.Point(49, 54);
            this.btn_Hienthi.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Hienthi.Name = "btn_Hienthi";
            this.btn_Hienthi.Size = new System.Drawing.Size(117, 43);
            this.btn_Hienthi.TabIndex = 10;
            this.btn_Hienthi.Text = "Hiển thị";
            this.btn_Hienthi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Hienthi.UseVisualStyleBackColor = true;
            this.btn_Hienthi.Click += new System.EventHandler(this.btn_Hienthi_Click);
            // 
            // txt_Tongtiennhap
            // 
            this.txt_Tongtiennhap.Location = new System.Drawing.Point(464, 374);
            this.txt_Tongtiennhap.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Tongtiennhap.Name = "txt_Tongtiennhap";
            this.txt_Tongtiennhap.Size = new System.Drawing.Size(132, 20);
            this.txt_Tongtiennhap.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(149, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(320, 24);
            this.label5.TabIndex = 30;
            this.label5.Text = "Báo Cáo Nhập Hàng Theo Tháng";
            // 
            // BaoCaoHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(626, 434);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Tongtiennhap);
            this.Controls.Add(this.btn_Hienthi);
            this.Controls.Add(this.btn_Timlai);
            this.Controls.Add(this.btn_In);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.cbo_Thang);
            this.Controls.Add(this.txt_Nam);
            this.Controls.Add(this.dg_Baocaohdn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BaoCaoHoaDonNhap";
            this.Text = "Báo_cáo_hóa_đơn_nhập";
            this.Load += new System.EventHandler(this.frmBaocaohdn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Baocaohdn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dg_Baocaohdn;
        private System.Windows.Forms.TextBox txt_Nam;
        private System.Windows.Forms.ComboBox cbo_Thang;
        private System.Windows.Forms.Button btn_Dong;
        private System.Windows.Forms.Button btn_In;
        private System.Windows.Forms.Button btn_Timlai;
        private System.Windows.Forms.Button btn_Hienthi;
        private System.Windows.Forms.TextBox txt_Tongtiennhap;
        private System.Windows.Forms.Label label5;
    }
}