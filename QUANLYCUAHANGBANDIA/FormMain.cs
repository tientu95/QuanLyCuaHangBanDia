using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_ly_cua_hang_ban_dia.Class;
using Quan_ly_cua_hang_ban_dia.Forms;


namespace Quan_ly_cua_hang_ban_dia
{
    public partial class frmQLBD : Form
    {
        public frmQLBD()
        {
            InitializeComponent();
        }

        private void frmQLBD_Load(object sender, EventArgs e)
        {
            Functions.Connect();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Forms.frm_DMNhanVien f = new Forms.frm_DMNhanVien();
            f.Show();
        }

        private void côngViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frm_DMCongViec f = new Forms.frm_DMCongViec();
            f.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát chương trình?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Application.Exit();
            }    
        }

        private void khoĐĩaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Forms.frm_DMKhodia f = new Forms.frm_DMKhodia();
            f.Show();
        }

        private void thểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frm_DMTheLoai f = new Forms.frm_DMTheLoai();
            f.Show();

        }

        private void nơiSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.frm_DMNoiSanXuat f = new Forms.frm_DMNoiSanXuat();
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DMKhachhang f = new frm_DMKhachhang();
            f.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DMNhaCungCap f = new frm_DMNhaCungCap();
            f.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Hoadonban f = new frm_Hoadonban();
            f.Show();
        }

        private void tìmĐĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_TimkiemDia f = new frm_TimkiemDia();
            f.Show();
        }

        private void mấtHỏngĐĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DMMatDia f = new frm_DMMatDia();
            f.Show();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoadonnhap f = new frmHoadonnhap();
            f.Show();
        }

        private void danhSáchHàngKhôngBánĐượcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BCTonKho f = new frm_BCTonKho();
            f.Show();
        }

        private void tìmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimHDB f = new TimHDB();
            f.Show();
        }

        private void danhSách5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoTopNCC f = new BaoCaoTopNCC();
            f.Show();

        }

        private void danhSáchNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoHoaDonNhap f = new BaoCaoHoaDonNhap();
            f.Show();
        }

        private void danhSáchKháchMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoBanHang f = new BaoCaoBanHang();
            f.Show();
        }
    }
}
