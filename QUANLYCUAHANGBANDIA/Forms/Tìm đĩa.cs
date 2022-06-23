using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quan_ly_cua_hang_ban_dia.Class;

namespace Quan_ly_cua_hang_ban_dia.Forms
{
    public partial class frm_TimkiemDia : Form
    {
        public frm_TimkiemDia()
        {
            InitializeComponent();
        }
        DataTable tblKhodia;

        private void Tìm_đĩa_Load(object sender, EventArgs e)
        {
            ResetValues();
            dg_Thongtindia.DataSource = null;
        }
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txt_MaTL.Focus();
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            txt_MaNSX.Enabled = false;
            txt_MaTL.Enabled = false;
            txt_TenNSX.Enabled = false;
            txt_TenTL.Enabled = false;
            string sql;
            if ((txt_MaTL.Text == "") && (label3.Text == "") && (label2.Text == "") &&
               (label4.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_MaNSX.Text == "" && txt_TenNSX.Text == "" && txt_MaTL.Text == "" && txt_TenTL.Text == "")
            {
                MessageBox.Show("Bạn phải nhập thông tin cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_MaNSX.Focus();
                return;
            }

            else
            {
                sql = "SELECT MaDia, TenDia, TenNSX, TenTheLoai, Soluong, Dongianhap, Dongiaban FROM tblKhodia join tblNoisanxuat " +
                    "on tblKhodia.MaNSX=tblNoisanxuat.MaNSX join tblTheloai on tblKhodia.MaTheLoai=tblTheloai.MaTheLoai WHERE 1=1";
                if (txt_MaNSX.Text != "")
                    sql = sql + " AND tblNoisanxuat.mansx Like N'%" + txt_MaNSX.Text + "%'";
                if (txt_TenNSX.Text != "")
                    sql = sql + " AND tblNoisanxuat.tennsx Like N'%" + txt_TenNSX.Text + "%'";
                if (txt_MaTL.Text != "")
                    sql = sql + " AND tblTheloai.matheloai Like N'%" + txt_MaTL.Text + "%'";
                if (txt_TenTL.Text != "")
                    sql = sql + " AND tblTheloai.tentheloai Like N'%" + txt_TenTL.Text + "%'";

                tblKhodia = Functions.GetDataToTable(sql);
                if (tblKhodia.Rows.Count == 0)
                {
                    MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetValues();
                }
                else
                    MessageBox.Show("Có " + tblKhodia.Rows.Count + " bản ghi thỏa mãn điều kiện!!!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dg_Thongtindia.DataSource = tblKhodia;
                Load_DataGridView();
            }    
            
        }
        private void Load_DataGridView()
        {
            dg_Thongtindia.Columns[0].HeaderText = "Mã đĩa";
            dg_Thongtindia.Columns[1].HeaderText = "Tên đĩa";
            dg_Thongtindia.Columns[2].HeaderText = "Tên nơi sản xuất";
            dg_Thongtindia.Columns[3].HeaderText = "Tên thể loại";
            dg_Thongtindia.Columns[4].HeaderText = "Số lượng";
            dg_Thongtindia.Columns[5].HeaderText = "Đơn giá nhập";
            dg_Thongtindia.Columns[6].HeaderText = "Đơn giá bán";
            dg_Thongtindia.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Thongtindia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Thongtindia.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Thongtindia.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Thongtindia.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Thongtindia.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Thongtindia.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dg_Thongtindia.AllowUserToAddRows = false;
            dg_Thongtindia.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dg_Thongtindia_DoubleClick(object sender, EventArgs e)
        {
            string madia;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                madia = dg_Thongtindia.CurrentRow.Cells["madia"].Value.ToString();
                Forms.frm_DMKhodia frm = new Forms.frm_DMKhodia();
                frm.txt_Madia.Text = madia;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                //frm.Show();
            }
        }

        private void btnTImlai_Click(object sender, EventArgs e)
        {
            txt_MaNSX.Enabled = true;
            txt_MaTL.Enabled = true;
            txt_TenNSX.Enabled = true;
            txt_TenTL.Enabled = true;
            ResetValues();
            dg_Thongtindia.DataSource = null;
            txt_TenTL.Text = "";
            txt_MaNSX.Text = "";
            txt_MaTL.Text = "";
            txt_TenNSX.Text = "";
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        
    }
}
