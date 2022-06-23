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
    public partial class frm_DMMatDia : Form
    {
        public frm_DMMatDia()
        {
            InitializeComponent();
        }
        DataTable tblCV;
        private void DanhMucMatDia_Load(object sender, EventArgs e)
        {
            txt_Solanmat.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Boqua.Enabled = false;
            Functions.FillCombo("Select madia,tendia from tblKhodia ", cbo_Madia, "madia", "tendia");
            cbo_Madia.SelectedIndex = -1;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT Solanmat, tendia,Soluongmat,Ngaymat FROM tblMatdia join tblKhodia on tblMatdia.madia=tblKhodia.madia";
            tblCV = Class.Functions.GetDataToTable(sql);
            dg_Matdia.DataSource = tblCV;
            dg_Matdia.Columns[0].HeaderText = "Số lần mất";
            dg_Matdia.Columns[1].HeaderText = "Tên đĩa";
            dg_Matdia.Columns[2].HeaderText = "Số lượng mất";
            dg_Matdia.Columns[3].HeaderText = "Ngày mất";
            //Chiều rộng của cột phù hợp với nội dung tất cả các ô kể cả tiêu đề
            dg_Matdia.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Matdia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Matdia.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Matdia.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Matdia.AllowUserToAddRows = false;
            dg_Matdia.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Boqua.Enabled = true;
            btn_Luu.Enabled = true;
            btn_Them.Enabled = false;
            ResetValues();
            txt_Solanmat.Enabled = true;
            txt_Solanmat.Focus();
        }
        private void ResetValues()
        {
            txt_Solanmat.Text = "";
            txt_Solanmat.Text = "";
            txt_Soluongmat.Text = "";
            msk_Ngaymat.Text = "";
            cbo_Madia.Text = "";
        }

       

        private void dg_Matdia_Click(object sender, EventArgs e)
        {
            if (btn_Them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Solanmat.Focus();
                return;
            }
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string ma = dg_Matdia.CurrentRow.Cells["tendia"].Value.ToString();
            cbo_Madia.Text = Functions.GetFieldValues("SELECT tendia FROM tblKhodia WHERE tendia = N'" + ma + "' ");
            txt_Solanmat.Text = dg_Matdia.CurrentRow.Cells["Solanmat"].Value.ToString();
            txt_Soluongmat.Text = dg_Matdia.CurrentRow.Cells["Soluongmat"].Value.ToString();
            msk_Ngaymat.Text = dg_Matdia.CurrentRow.Cells["Ngaymat"].Value.ToString();

            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Boqua.Enabled = true;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_Solanmat.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Solanmat.Focus();
                return;
            }
            if (cbo_Madia.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Solanmat.Focus();
                return;
            }
            if (txt_Soluongmat.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng mất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Solanmat.Focus();
                return;
            }
            if (msk_Ngaymat.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày mất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msk_Ngaymat.Focus();
                return;
            }
            if (!Class.Functions.IsDate(msk_Ngaymat.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày mất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msk_Ngaymat.Text = "";
                msk_Ngaymat.Focus();
                return;
            }

            sql = "SELECT solanmat FROM tblMatdia WHERE Madia = N'" + txt_Solanmat.Text + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Solanmat.Focus();
                txt_Solanmat.Text = "";
                return;
            }
            sql = "insert into tblMatdia(Madia,Solanmat,Soluongmat,Ngaymat) values(N'" + cbo_Madia.SelectedValue + "',N'" + txt_Solanmat.Text.Trim() + "',N'" + txt_Soluongmat.Text + "',N'" + Class.Functions.ConvertDateTime(msk_Ngaymat.Text) + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Boqua.Enabled = false;
            btn_Luu.Enabled = false;
            txt_Solanmat.Enabled = false;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Solanmat.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Solanmat.Focus();
                return;
            }
            if (cbo_Madia.Text == "")
            {
                MessageBox.Show("Bạn phải chọn đĩa mất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_Madia.Focus();
                return;
            }
            if (txt_Soluongmat.Text == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng mất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Soluongmat.Focus();
                return;
            }
            if (msk_Ngaymat.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày mất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msk_Ngaymat.Focus();
                return;
            }
            if (!Class.Functions.IsDate(msk_Ngaymat.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày mất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msk_Ngaymat.Text = "";
                msk_Ngaymat.Focus();
                return;
            }
            sql = "UPDATE tblMatdia SET  madia=N'" + cbo_Madia.SelectedValue +
                   "',Soluongmat='" + txt_Soluongmat.Text +
                   "',Ngaymat='" + Class.Functions.ConvertDateTime(msk_Ngaymat.Text) +
               "'WHERE solanmat=N'" + txt_Solanmat.Text + "'";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Boqua.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Solanmat.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblMatdia WHERE solanmat=N'" + txt_Solanmat.Text + "'";
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
            txt_Solanmat.Enabled = false;
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
