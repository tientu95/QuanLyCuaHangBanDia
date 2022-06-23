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
    public partial class frm_DMNoiSanXuat : Form
    {
        public frm_DMNoiSanXuat()
        {
            InitializeComponent();
        }
        DataTable tblNSX;
        private void DanhMucNoiSanXuat_Load(object sender, EventArgs e)
        {
            txt_Mansx.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Boqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT mansx, tennsx FROM tblNoisanxuat";
            tblNSX = Class.Functions.GetDataToTable(sql);
            Dg_Noisanxuat.DataSource = tblNSX;
            Dg_Noisanxuat.Columns[0].HeaderText = "Mã nơi sản xuất";
            Dg_Noisanxuat.Columns[1].HeaderText = "Tên nơi sản xuất";
            //Dg_Noisanxuat.Columns[0].Width = 50;
            //Dg_Noisanxuat.Columns[1].Width = 250;
            Dg_Noisanxuat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dg_Noisanxuat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dg_Noisanxuat.AllowUserToAddRows = false;
            Dg_Noisanxuat.EditMode = DataGridViewEditMode.EditProgrammatically;




        }

        private void Dg_Noisanxuat_Click(object sender, EventArgs e)
        {
            if (btn_Them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Mansx.Focus();
                return;
            }
            if (tblNSX.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txt_Mansx.Text = Dg_Noisanxuat.CurrentRow.Cells["mansx"].Value.ToString();
            txt_Tennsx.Text = Dg_Noisanxuat.CurrentRow.Cells["tennsx"].Value.ToString();
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Boqua.Enabled = true;
        }
        private void ResetValues()
        {
            txt_Mansx.Text = "";
            txt_Tennsx.Text = "";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Boqua.Enabled = true;
            btn_Luu.Enabled = true;
            btn_Them.Enabled = false;
            ResetValues();
            txt_Mansx.Enabled = true;
            txt_Mansx.Focus();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_Mansx.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nơi sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Mansx.Focus();
                return;
            }
            if (txt_Tennsx.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nơi sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Tennsx.Focus();
                return;
            }

            sql = "SELECT mansx FROM tblNoisanxuat WHERE mansx = N'" + txt_Mansx.Text + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Mansx.Focus();
                txt_Mansx.Text = "";
                return;
            }
            sql = "INSERT INTO tblNoisanxuat(mansx,tennsx) VALUES(N'" + txt_Mansx.Text + "',N'" + txt_Tennsx.Text + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Boqua.Enabled = false;
            btn_Luu.Enabled = false;
            txt_Mansx.Enabled = false;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNSX.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Mansx.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dư liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Tennsx.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nơi sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Tennsx.Focus();
                return;
            }
            sql = "UPDATE tblNoisanxuat SET tennsx = N'" + txt_Tennsx.Text + "' WHERE mansx = N'" + txt_Mansx.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Boqua.Enabled = false;
        }

        private void btn_Boqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btn_Boqua.Enabled = false;
            btn_Them.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Luu.Enabled = false;
            txt_Mansx.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNSX.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Mansx.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNoisanxuat WHERE mansx=N'" + txt_Mansx.Text + "'";
                Class.Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
