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

namespace Quan_ly_cua_hang_ban_dia.Forms
{
    public partial class frm_DMTheLoai : Form
    {
        public frm_DMTheLoai()
        {
            InitializeComponent();
        }
        DataTable tblTT;

        private void frm_DMTheLoai_Load(object sender, EventArgs e)
        {
            txt_Matheloai.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Boqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT matheloai, tentheloai FROM tblTheloai";
            tblTT = Class.Functions.GetDataToTable(sql);
            Dg_Theloai.DataSource = tblTT;
            Dg_Theloai.Columns[0].HeaderText = "Mã thể loai";
            Dg_Theloai.Columns[1].HeaderText = "Tên thể loại";
            Dg_Theloai.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dg_Theloai.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Dg_Theloai.AllowUserToAddRows = false;
            Dg_Theloai.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void Dg_Theloai_Click(object sender, EventArgs e)
        {
            if (btn_Them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Matheloai.Focus();
                return;
            }
            if (tblTT.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txt_Matheloai.Text = Dg_Theloai.CurrentRow.Cells["matheloai"].Value.ToString();
            txt_Tentheloai.Text = Dg_Theloai.CurrentRow.Cells["tentheloai"].Value.ToString();
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Boqua.Enabled = true;
        }
        private void ResetValues()
        {
            txt_Matheloai.Text = "";
            txt_Tentheloai.Text = "";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Boqua.Enabled = true;
            btn_Luu.Enabled = true;
            btn_Them.Enabled = false;
            ResetValues();
            txt_Matheloai.Enabled = true;
            txt_Matheloai.Focus();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_Matheloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Matheloai.Focus();
                return;
            }
            if (txt_Tentheloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Tentheloai.Focus();
                return;
            }

            sql = "SELECT matheloai FROM tblTheloai WHERE matheloai = N'" + txt_Matheloai.Text + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã thể loại này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Matheloai.Focus();
                txt_Matheloai.Text = "";
                return;
            }
            sql = "INSERT INTO tblTheloai(matheloai,tentheloai) VALUES(N'" + txt_Matheloai.Text + "',N'" + txt_Tentheloai.Text + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Boqua.Enabled = false;
            btn_Luu.Enabled = false;
            txt_Matheloai.Enabled = false;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Matheloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dư liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Tentheloai.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Tentheloai.Focus();
                return;
            }
            sql = "UPDATE tblTheloai SET tentheloai = N'" + txt_Tentheloai.Text + "' WHERE matheloai = N'" + txt_Matheloai.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Boqua.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblTT.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Matheloai.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblTheloai WHERE matheloai=N'" + txt_Matheloai.Text + "'";
                Class.Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btn_Boqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btn_Boqua.Enabled = false;
            btn_Them.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Luu.Enabled = false;
            txt_Matheloai.Enabled = false;
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
