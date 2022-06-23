
namespace Quan_ly_cua_hang_ban_dia.Forms
{
    partial class BaoCaoTopNCC
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
            this.dg_Top5NCC = new System.Windows.Forms.DataGridView();
            this.txt_Nam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_InBC = new System.Windows.Forms.Button();
            this.btn_hienthi = new System.Windows.Forms.Button();
            this.btn_Baocao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Top5NCC)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(122, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 24);
            this.label1.TabIndex = 48;
            this.label1.Text = "Báo Cáo Top 5 Nhà Cung Cấp";
            // 
            // dg_Top5NCC
            // 
            this.dg_Top5NCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Top5NCC.Location = new System.Drawing.Point(41, 240);
            this.dg_Top5NCC.Name = "dg_Top5NCC";
            this.dg_Top5NCC.Size = new System.Drawing.Size(476, 152);
            this.dg_Top5NCC.TabIndex = 49;
            // 
            // txt_Nam
            // 
            this.txt_Nam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Nam.Location = new System.Drawing.Point(252, 205);
            this.txt_Nam.Name = "txt_Nam";
            this.txt_Nam.Size = new System.Drawing.Size(135, 26);
            this.txt_Nam.TabIndex = 50;
            this.txt_Nam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Nam_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Năm báo cáo:";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Thoat;
            this.btn_Thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Thoat.Location = new System.Drawing.Point(369, 131);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(148, 49);
            this.btn_Thoat.TabIndex = 47;
            this.btn_Thoat.Text = "Đóng";
            this.btn_Thoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_InBC
            // 
            this.btn_InBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InBC.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Xuat_excel;
            this.btn_InBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_InBC.Location = new System.Drawing.Point(369, 74);
            this.btn_InBC.Name = "btn_InBC";
            this.btn_InBC.Size = new System.Drawing.Size(148, 51);
            this.btn_InBC.TabIndex = 46;
            this.btn_InBC.Text = "In BC";
            this.btn_InBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_InBC.UseVisualStyleBackColor = true;
            this.btn_InBC.Click += new System.EventHandler(this.btn_InBC_Click);
            // 
            // btn_hienthi
            // 
            this.btn_hienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hienthi.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Hopstarter_Soft_Scraps_Edit_Document;
            this.btn_hienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_hienthi.Location = new System.Drawing.Point(41, 131);
            this.btn_hienthi.Name = "btn_hienthi";
            this.btn_hienthi.Size = new System.Drawing.Size(148, 49);
            this.btn_hienthi.TabIndex = 45;
            this.btn_hienthi.Text = "Hiển thị";
            this.btn_hienthi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_hienthi.UseVisualStyleBackColor = true;
            this.btn_hienthi.Click += new System.EventHandler(this.btn_Thongke_Click);
            // 
            // btn_Baocao
            // 
            this.btn_Baocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Baocao.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Hopstarter_Soft_Scraps_File_New;
            this.btn_Baocao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Baocao.Location = new System.Drawing.Point(41, 74);
            this.btn_Baocao.Name = "btn_Baocao";
            this.btn_Baocao.Size = new System.Drawing.Size(148, 51);
            this.btn_Baocao.TabIndex = 44;
            this.btn_Baocao.Text = "Tạo báo cáo";
            this.btn_Baocao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Baocao.UseVisualStyleBackColor = true;
            this.btn_Baocao.Click += new System.EventHandler(this.btn_Baocao_Click);
            // 
            // BaoCaoTopNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(544, 454);
            this.Controls.Add(this.txt_Nam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dg_Top5NCC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_InBC);
            this.Controls.Add(this.btn_hienthi);
            this.Controls.Add(this.btn_Baocao);
            this.Name = "BaoCaoTopNCC";
            this.Text = "BaoCaoTopNCC";
            this.Load += new System.EventHandler(this.BaoCaoTopNCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Top5NCC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_InBC;
        private System.Windows.Forms.Button btn_hienthi;
        private System.Windows.Forms.Button btn_Baocao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dg_Top5NCC;
        private System.Windows.Forms.TextBox txt_Nam;
        private System.Windows.Forms.Label label2;
    }
}