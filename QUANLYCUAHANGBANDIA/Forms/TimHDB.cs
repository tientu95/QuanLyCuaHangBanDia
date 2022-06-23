using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_cua_hang_ban_dia.Forms
{
    public partial class TimHDB : Form
    {
        public TimHDB()
        {
            InitializeComponent();
        }
        DataTable tblHDB;
        private void frm_timkiemHDban_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgTimhoadonban.DataSource = null;
        }

        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txtSoHDB.Focus();
        }

        private void Load_DataGridView()
        {
            dgTimhoadonban.Columns[0].HeaderText = "Số HĐB";
            dgTimhoadonban.Columns[1].HeaderText = "Mã nhân viên";
            dgTimhoadonban.Columns[2].HeaderText = "Mã khách";
            dgTimhoadonban.Columns[3].HeaderText = "Mã Đĩa";
            dgTimhoadonban.Columns[4].HeaderText = "Tổng tiền";
            dgTimhoadonban.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells ;
            dgTimhoadonban.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgTimhoadonban.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgTimhoadonban.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgTimhoadonban.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgTimhoadonban.AllowUserToAddRows = false;
            dgTimhoadonban.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        

        

        

        private void Timkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txtSoHDB.Text == "") && (txtManhanvien.Text == "") && (txtMakhach.Text == "") && (txt_MaDia.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT tblhoadonban.sohdb,tblhoadonban.manv,tblhoadonban.makhach,tblChitietHDB.madia,tblHoadonban.tongtien" +
                " FROM tblhoadonban join tblchitiethdb on tblhoadonban.sohdb=tblchitiethdb.sohdb WHERE 1=1";

            if (txtSoHDB.Text != "")
                sql = sql + " AND tblhoadonban.sohdb Like N'%" + txtSoHDB.Text + "%'"; ;
            if (txtManhanvien.Text != "")
                sql = sql + " AND tblhoadonban.manv Like N'%" + txtManhanvien.Text + "%'";
            if (txtMakhach.Text != "")
                sql = sql + " AND tblhoadonban.makhach Like N'%" + txtMakhach.Text + "%'";
            if (txt_MaDia.Text != "")
                sql = sql + " AND tblchitiethdb.madia Like N'%" + txt_MaDia.Text + "%'";
            tblHDB = Class.Functions.GetDataToTable(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dgTimhoadonban.DataSource = tblHDB;
            Load_DataGridView();
        }

        private void Timlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgTimhoadonban.DataSource = null;
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn đóng mục này","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            this.Close();
        }

        private void dgTimhoadonban_Click(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgTimhoadonban.CurrentRow.Cells["Sohdb"].Value.ToString();
                frm_Hoadonban frm = new frm_Hoadonban();

                frm.txtMaHDBan.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }
    }
}
