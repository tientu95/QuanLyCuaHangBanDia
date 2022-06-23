
namespace Quan_ly_cua_hang_ban_dia.Forms
{
    partial class TimHDB
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
            this.dgTimhoadonban = new System.Windows.Forms.DataGridView();
            this.txtMakhach = new System.Windows.Forms.TextBox();
            this.txtManhanvien = new System.Windows.Forms.TextBox();
            this.txt_MaDia = new System.Windows.Forms.TextBox();
            this.txtSoHDB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Dong = new System.Windows.Forms.Button();
            this.btn_Timlai = new System.Windows.Forms.Button();
            this.btn_Timkiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgTimhoadonban)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTimhoadonban
            // 
            this.dgTimhoadonban.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTimhoadonban.Location = new System.Drawing.Point(3, 197);
            this.dgTimhoadonban.Name = "dgTimhoadonban";
            this.dgTimhoadonban.RowHeadersWidth = 51;
            this.dgTimhoadonban.Size = new System.Drawing.Size(580, 168);
            this.dgTimhoadonban.TabIndex = 80;
            this.dgTimhoadonban.Click += new System.EventHandler(this.dgTimhoadonban_Click);
            // 
            // txtMakhach
            // 
            this.txtMakhach.Location = new System.Drawing.Point(424, 72);
            this.txtMakhach.Name = "txtMakhach";
            this.txtMakhach.Size = new System.Drawing.Size(159, 20);
            this.txtMakhach.TabIndex = 2;
            // 
            // txtManhanvien
            // 
            this.txtManhanvien.Location = new System.Drawing.Point(424, 125);
            this.txtManhanvien.Name = "txtManhanvien";
            this.txtManhanvien.Size = new System.Drawing.Size(159, 20);
            this.txtManhanvien.TabIndex = 3;
            // 
            // txt_MaDia
            // 
            this.txt_MaDia.Location = new System.Drawing.Point(78, 121);
            this.txt_MaDia.Name = "txt_MaDia";
            this.txt_MaDia.Size = new System.Drawing.Size(159, 20);
            this.txt_MaDia.TabIndex = 1;
            // 
            // txtSoHDB
            // 
            this.txtSoHDB.Location = new System.Drawing.Point(78, 75);
            this.txtSoHDB.Name = "txtSoHDB";
            this.txtSoHDB.Size = new System.Drawing.Size(159, 20);
            this.txtSoHDB.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(317, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 75;
            this.label6.Text = "Mã nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(317, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 74;
            this.label4.Text = "Mã khách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 73;
            this.label3.Text = "Mã đĩa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 72;
            this.label1.Text = "Số HDB";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(164, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(285, 29);
            this.label8.TabIndex = 87;
            this.label8.Text = "Tìm Kiếm Hóa Đơn Bán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(16, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 16);
            this.label2.TabIndex = 88;
            this.label2.Text = "Click vào một dòng để hiển thị chi tiết";
            // 
            // btn_Dong
            // 
            this.btn_Dong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Thoat;
            this.btn_Dong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dong.Location = new System.Drawing.Point(426, 406);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(117, 42);
            this.btn_Dong.TabIndex = 6;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Dong.UseVisualStyleBackColor = true;
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // btn_Timlai
            // 
            this.btn_Timlai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Timlai.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Hopstarter_Soft_Scraps_Email_Reply;
            this.btn_Timlai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Timlai.Location = new System.Drawing.Point(244, 406);
            this.btn_Timlai.Name = "btn_Timlai";
            this.btn_Timlai.Size = new System.Drawing.Size(117, 42);
            this.btn_Timlai.TabIndex = 5;
            this.btn_Timlai.Text = "Tìm lại";
            this.btn_Timlai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Timlai.UseVisualStyleBackColor = true;
            this.btn_Timlai.Click += new System.EventHandler(this.Timlai_Click);
            // 
            // btn_Timkiem
            // 
            this.btn_Timkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Timkiem.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Tim__2_;
            this.btn_Timkiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Timkiem.Location = new System.Drawing.Point(62, 406);
            this.btn_Timkiem.Name = "btn_Timkiem";
            this.btn_Timkiem.Size = new System.Drawing.Size(117, 42);
            this.btn_Timkiem.TabIndex = 4;
            this.btn_Timkiem.Text = "Tìm kiếm";
            this.btn_Timkiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Timkiem.UseVisualStyleBackColor = true;
            this.btn_Timkiem.Click += new System.EventHandler(this.Timkiem_Click);
            // 
            // TimHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(587, 453);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.btn_Timlai);
            this.Controls.Add(this.btn_Timkiem);
            this.Controls.Add(this.dgTimhoadonban);
            this.Controls.Add(this.txtMakhach);
            this.Controls.Add(this.txtManhanvien);
            this.Controls.Add(this.txt_MaDia);
            this.Controls.Add(this.txtSoHDB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TimHDB";
            this.Text = "frm_timkiemHDban";
            this.Load += new System.EventHandler(this.frm_timkiemHDban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTimhoadonban)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgTimhoadonban;
        private System.Windows.Forms.TextBox txtMakhach;
        private System.Windows.Forms.TextBox txtManhanvien;
        private System.Windows.Forms.TextBox txt_MaDia;
        private System.Windows.Forms.TextBox txtSoHDB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Dong;
        private System.Windows.Forms.Button btn_Timlai;
        private System.Windows.Forms.Button btn_Timkiem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
    }
}