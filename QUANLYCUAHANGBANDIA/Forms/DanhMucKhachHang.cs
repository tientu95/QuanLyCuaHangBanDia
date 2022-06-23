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
    public partial class frm_DMKhachhang : Form
    {
        public frm_DMKhachhang()
        {
            InitializeComponent();
        }
        DataTable tblKH;
        private void DanhMucKhachHang_Load(object sender, EventArgs e)
        {
            txt_MaKhach.Enabled = false;
            
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = " SELECT makhach,tenkhach, dienthoai, diachi FROM tblkhachhang";
            tblKH = Functions.GetDataToTable(sql);
            dg_Khachhang.DataSource = tblKH;
            dg_Khachhang.Columns[0].HeaderText = "Mã khách hàng";
            dg_Khachhang.Columns[1].HeaderText = "Tên khách hàng";
            dg_Khachhang.Columns[2].HeaderText = "Số điện thoại";
            dg_Khachhang.Columns[3].HeaderText = "Địa chỉ";
            dg_Khachhang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khachhang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khachhang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khachhang.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dg_Khachhang.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dg_Khachhang.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void ResetValues()
        {
            txt_MaKhach.Text = "";
            txt_TenKhach.Text = "";
            txt_DiaChiKhachHang.Text = "";
            msk_DienthoaiKhachHang.Text = "";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Boqua.Enabled = true;
            btn_Luu.Enabled = true;
            btn_Them.Enabled = false;
            ResetValues();
            txt_MaKhach.Enabled = true;
            txt_MaKhach.Focus();
            txt_TenKhach.Enabled = true;
            txt_TenKhach.Focus();
            txt_DiaChiKhachHang.Enabled = true;
            txt_DiaChiKhachHang.Focus();
            msk_DienthoaiKhachHang.Enabled = true;
            msk_DienthoaiKhachHang.Focus();
        }

        private void dg_Khachhang_Click(object sender, EventArgs e)
        {
            if (btn_Them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo",
     MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_MaKhach.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK,
  MessageBoxIcon.Information);
                return;
            }
            txt_MaKhach.Text = dg_Khachhang.CurrentRow.Cells["MaKhach"].Value.ToString();
            txt_TenKhach.Text = dg_Khachhang.CurrentRow.Cells["TenKhach"].Value.ToString();
            txt_DiaChiKhachHang.Text = dg_Khachhang.CurrentRow.Cells["diachi"].Value.ToString();
            msk_DienthoaiKhachHang.Text = dg_Khachhang.CurrentRow.Cells["dienthoai"].Value.ToString();
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Boqua.Enabled = true;

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_MaKhach.Text == " ")
            {
                MessageBox.Show("Bạn phải nhập mã khach", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaKhach.Focus();
                return;
            }
            if (txt_TenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khach", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenKhach.Focus();
                return;
            }
            if (txt_DiaChiKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txt_DiaChiKhachHang.Focus();
                return;
            }
            if (msk_DienthoaiKhachHang.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msk_DienthoaiKhachHang.Focus();
                return;
            }

            sql = "SELECT makhach FROM tblkhachhang WHERE makhach=N'" +
txt_MaKhach.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khach này đã có, bạn phải nhập mã khác", "Thông bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaKhach.Focus();
                txt_MaKhach.Text = "";
                return;
            }
            sql = "INSERT INTO tblkhachhang(makhach,tenkhach,diachi,dienthoai) VALUES (N'" +
 txt_MaKhach.Text.Trim() + "',N'" + txt_TenKhach.Text.Trim() + "',N'" +
 txt_DiaChiKhachHang.Text.Trim() + "','" + msk_DienthoaiKhachHang.Text + "')";

            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Boqua.Enabled = false;
            btn_Luu.Enabled = false;
            txt_MaKhach.Enabled = false;
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txt_MaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_TenKhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenKhach.Focus();
                return;
            }
            if (txt_DiaChiKhachHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Warning);
                txt_DiaChiKhachHang.Focus();
                return;
            }
            if (msk_DienthoaiKhachHang.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msk_DienthoaiKhachHang.Focus();
                return;
            }
            sql = "UPDATE tblkhachhang SET  tenkhach=N'" + txt_TenKhach.Text.Trim().ToString()
                  + "',diachi=N'" + txt_DiaChiKhachHang.Text.Trim().ToString() + "',dienthoai='" +
                msk_DienthoaiKhachHang.Text.ToString() + "' WHERE makhach=N'" + txt_MaKhach.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Boqua.Enabled = false;
            txt_MaKhach.Enabled = true;
            txt_TenKhach.Enabled = true;
            txt_DiaChiKhachHang.Enabled = true;
            msk_DienthoaiKhachHang.Enabled = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK,
MessageBoxIcon.Information);
                return;
            }
            if (txt_MaKhach.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo",
MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblkhachhang WHERE Makhach=N'" + txt_MaKhach.Text + "'";
                Functions.RunSqlDel(sql);
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
            txt_MaKhach.Enabled = false;
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}

