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
    public partial class frm_DMNhaCungCap : Form
    {
        public frm_DMNhaCungCap()
        {
            InitializeComponent();
        }
        DataTable tblNhacungcap;

        private void DanhMucNhaCungCap_Load(object sender, EventArgs e)
        {
            txt_MaNCC.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Boqua.Enabled = false;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaNCC, TenNCC, DienThoai, DiaChi FROM tblNhacungcap";
            tblNhacungcap = Functions.GetDataToTable(sql);
            dg_Nhacungcap.DataSource = tblNhacungcap;
            dg_Nhacungcap.Columns[0].HeaderText = "Mã nhà cung cấp";
            dg_Nhacungcap.Columns[1].HeaderText = "Tên nhà cung cấp";
            dg_Nhacungcap.Columns[2].HeaderText = "Điện thoại";
            dg_Nhacungcap.Columns[3].HeaderText = "Địa chỉ";
            dg_Nhacungcap.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Nhacungcap.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Nhacungcap.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Nhacungcap.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dg_Nhacungcap.AllowUserToAddRows = false;
            dg_Nhacungcap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void dg_Nhacungcap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_Them_Click_1(object sender, EventArgs e)
        {
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Boqua.Enabled = true;
            btn_Luu.Enabled = true;
            btn_Them.Enabled = false;
            ResetValues();
            txt_MaNCC.Enabled = true;
            txt_MaNCC.Focus();
        }
        private void ResetValues()
        {
            txt_MaNCC.Text = "";
            txt_TenNCC.Text = "";
            txt_Diachi.Text = "";
            msk_Dienthoai.Text = "";
        }
        private void btn_Luu_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (txt_MaNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaNCC.Focus();
                return;
            }
            if (txt_TenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenNCC.Focus();
                return;
            }
            if (txt_Diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Diachi.Focus();
                return;
            }
            if (msk_Dienthoai.Text == "(   ) ")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msk_Dienthoai.Focus();
                return;
            }
            //sql = "SELECT ManNCC FROM tblNhacungcap WHERE MaNCC=N'" + txt_MaNCC.Text.Trim() + "'";
            sql = "SELECT MaNCC FROM tblNhacungcap WHERE MaNCC=N'" + txt_MaNCC.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhà cung cấp này đã có, bạn phải nhập mã khác", "Thông  báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_MaNCC.Focus();
                txt_MaNCC.Text = "";
                return;
            }
            sql = "INSERT INTO tblNhacungcap(MaNCC,TenNCC,DiaChi,DienThoai) VALUES(N'" + txt_MaNCC.Text.Trim() + "', N'" + txt_TenNCC.Text.Trim() + "', N'" + txt_Diachi.Text.Trim() + "', '" + msk_Dienthoai.Text + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Boqua.Enabled = false;
            btn_Luu.Enabled = false;
            txt_MaNCC.Enabled = false;
        }
        private void btn_Sua_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (tblNhacungcap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_MaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_TenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenNCC.Focus();
                return;
            }
            if (txt_Diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Diachi.Focus();
                return;
            }
            if (msk_Dienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                msk_Dienthoai.Focus();
                return;
            }
            sql = "UPDATE tblNhacungcap SET  TenNCC=N'" + txt_TenNCC.Text.Trim().ToString() + "',DiaChi=N'" + txt_Diachi.Text.Trim().ToString() + "',Dienthoai='" + msk_Dienthoai.Text.ToString() + "'  WHERE MaNCC=N'" + txt_MaNCC.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Boqua.Enabled = false;
        }
        private void btn_Xoa_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (tblNhacungcap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_MaNCC.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNhacungcap WHERE mancc=N'" + txt_MaNCC.Text + "'";
                Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }
      
        private void btn_Boqua_Click_1(object sender, EventArgs e)
        {
            ResetValues();
            btn_Boqua.Enabled = false;
            btn_Them.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Luu.Enabled = false;
            txt_MaNCC.Enabled = false;
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn đóng mục này?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            this.Close();
        }

        private void dg_Nhacungcap_Click(object sender, EventArgs e)
        {
            if (btn_Them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_MaNCC.Focus();
                return;
            }
            if (tblNhacungcap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_MaNCC.Text = dg_Nhacungcap.CurrentRow.Cells["MaNCC"].Value.ToString();
            txt_TenNCC.Text = dg_Nhacungcap.CurrentRow.Cells["TenNCC"].Value.ToString();
            txt_Diachi.Text = dg_Nhacungcap.CurrentRow.Cells["DiaChi"].Value.ToString();
            msk_Dienthoai.Text = dg_Nhacungcap.CurrentRow.Cells["DienThoai"].Value.ToString();
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Boqua.Enabled = true;
        }

        
    }

}
