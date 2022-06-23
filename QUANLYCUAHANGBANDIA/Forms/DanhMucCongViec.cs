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
    public partial class frm_DMCongViec : Form
    {
        DataTable tblCV;

        public frm_DMCongViec()
        {
            InitializeComponent();
        }

        private void frmDMCongViec_Load(object sender, EventArgs e)
        {
            txtMaCV.Enabled = false;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            Load_DataGridView();
        }
        public void Load_DataGridView()
        {

            string sql;
            sql = "SELECT macv, tencv FROM tblCongviec";
            tblCV = Functions.GetDataToTable(sql);
            dgDMCongViec.DataSource = tblCV;
            dgDMCongViec.Columns[0].HeaderText = "Mã Công việc";
            dgDMCongViec.Columns[1].HeaderText = "Tên công việc";
            dgDMCongViec.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDMCongViec.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dgDMCongViec.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dgDMCongViec.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaCV.Enabled = true;

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnBoqua.Enabled = true;
            ResetValues();
            txtMaCV.Focus();
        }
        public void ResetValues()
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            if (txtTenCV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }

            sql = "SELECT macv FROM tblCongviec WHERE macv=N'" + txtMaCV.Text + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã công việc này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                txtMaCV.Text = "";
                return;
            }
            sql = "INSERT into tblCongviec(macv,tencv) values (N'" + txtMaCV.Text + "',N'" + txtTenCV.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            txtMaCV.Enabled = false;

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCV.Focus();
                return;
            }

            if (txtTenCV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên công việc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCV.Focus();
                return;
            }

            sql = "update tblCongviec set tencv=N'" + txtTenCV.Text.ToString() + "' WHERE macv=N'" + txtMaCV.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void dgDMCongViec_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaCV.Focus();
                return;
            }
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaCV.Text = dgDMCongViec.CurrentRow.Cells["macv"].Value.ToString();
            txtTenCV.Text = dgDMCongViec.CurrentRow.Cells["tencv"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoqua.Enabled = true;
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            txtMaCV.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblCongviec WHERE macv=N'" + txtMaCV.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
