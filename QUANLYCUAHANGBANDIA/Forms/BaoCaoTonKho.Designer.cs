
namespace Quan_ly_cua_hang_ban_dia.Forms
{
    partial class frm_BCTonKho
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
            this.dg_Tonkho = new System.Windows.Forms.DataGridView();
            this.cboQui = new System.Windows.Forms.ComboBox();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Dong = new System.Windows.Forms.Button();
            this.btn_InBC = new System.Windows.Forms.Button();
            this.btn_Hienthi = new System.Windows.Forms.Button();
            this.btn_Baocao = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tonkho)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_Tonkho
            // 
            this.dg_Tonkho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Tonkho.Location = new System.Drawing.Point(39, 250);
            this.dg_Tonkho.Name = "dg_Tonkho";
            this.dg_Tonkho.Size = new System.Drawing.Size(477, 152);
            this.dg_Tonkho.TabIndex = 39;
            // 
            // cboQui
            // 
            this.cboQui.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboQui.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboQui.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQui.FormattingEnabled = true;
            this.cboQui.Location = new System.Drawing.Point(145, 201);
            this.cboQui.Name = "cboQui";
            this.cboQui.Size = new System.Drawing.Size(106, 28);
            this.cboQui.TabIndex = 0;
            this.cboQui.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboQui_KeyPress);
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(410, 201);
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(106, 26);
            this.txtNam.TabIndex = 1;
            this.txtNam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNam_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Quí báo cáo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(297, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Năm báo cáo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(120, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Báo Cáo Hàng Không Bán Được";
            // 
            // btn_Dong
            // 
            this.btn_Dong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dong.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Thoat;
            this.btn_Dong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Dong.Location = new System.Drawing.Point(368, 115);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(148, 49);
            this.btn_Dong.TabIndex = 43;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Dong.UseVisualStyleBackColor = true;
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // btn_InBC
            // 
            this.btn_InBC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InBC.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Xuat_excel;
            this.btn_InBC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_InBC.Location = new System.Drawing.Point(368, 58);
            this.btn_InBC.Name = "btn_InBC";
            this.btn_InBC.Size = new System.Drawing.Size(148, 51);
            this.btn_InBC.TabIndex = 42;
            this.btn_InBC.Text = "In BC";
            this.btn_InBC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_InBC.UseVisualStyleBackColor = true;
            this.btn_InBC.Click += new System.EventHandler(this.btn_InBC_Click);
            // 
            // btn_Hienthi
            // 
            this.btn_Hienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Hienthi.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Hopstarter_Soft_Scraps_Edit_Document;
            this.btn_Hienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Hienthi.Location = new System.Drawing.Point(40, 115);
            this.btn_Hienthi.Name = "btn_Hienthi";
            this.btn_Hienthi.Size = new System.Drawing.Size(148, 49);
            this.btn_Hienthi.TabIndex = 41;
            this.btn_Hienthi.Text = "Hiển thị";
            this.btn_Hienthi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Hienthi.UseVisualStyleBackColor = true;
            this.btn_Hienthi.Click += new System.EventHandler(this.btn_Hienthi_Click);
            // 
            // btn_Baocao
            // 
            this.btn_Baocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Baocao.Image = global::Quan_ly_cua_hang_ban_dia.Properties.Resources.Hopstarter_Soft_Scraps_File_New;
            this.btn_Baocao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Baocao.Location = new System.Drawing.Point(40, 58);
            this.btn_Baocao.Name = "btn_Baocao";
            this.btn_Baocao.Size = new System.Drawing.Size(148, 51);
            this.btn_Baocao.TabIndex = 40;
            this.btn_Baocao.Text = "Tạo báo cáo";
            this.btn_Baocao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Baocao.UseVisualStyleBackColor = true;
            this.btn_Baocao.Click += new System.EventHandler(this.btn_Baocao_Click);
            // 
            // frm_BCTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(544, 450);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.btn_InBC);
            this.Controls.Add(this.btn_Hienthi);
            this.Controls.Add(this.btn_Baocao);
            this.Controls.Add(this.dg_Tonkho);
            this.Controls.Add(this.cboQui);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_BCTonKho";
            this.Text = "BaoCaoTonKho";
            this.Load += new System.EventHandler(this.BaoCaoTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Tonkho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_Tonkho;
        private System.Windows.Forms.ComboBox cboQui;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Hienthi;
        private System.Windows.Forms.Button btn_InBC;
        private System.Windows.Forms.Button btn_Dong;
        private System.Windows.Forms.Button btn_Baocao;
    }
}