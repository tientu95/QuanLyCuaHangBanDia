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
    public partial class frm_DMNhanVien : Form
    {
        DataTable tblNV;
        public frm_DMNhanVien()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void frmDMNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            btnLuu.Enabled = false;
            btnBoqua.Enabled = false;
            Load_DataGridView();
            Class.Functions.FillCombo("select macv, tencv from tblCongviec", cboMaCV, "macv", "tencv");
            cboMaCV.SelectedIndex = -1;
            ResetValues();
        }
        private void Load_DataGridView()
        {
            string sql;
            //sql = "Select a.manv, a.tennv, a.gioitinh, a.ngaysinh, a.dienthoai,a.diachi,b.tencv from tblNhanvien as a, tblCongviec as b";
            //where b.macv = N'" + cboMaCV.Text +"'"
            sql = "Select manv, tennv, gioitinh, ngaysinh, dienthoai,diachi,tencv from tblNhanvien join tblCongviec on tblNhanvien.macv=tblCongviec.macv";
            tblNV = Class.Functions.GetDataToTable(sql);
            dgDMNhanVien.DataSource = tblNV;
            dgDMNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgDMNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgDMNhanVien.Columns[2].HeaderText = "Giới tính";
            dgDMNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgDMNhanVien.Columns[4].HeaderText = "Điện thoại";
            dgDMNhanVien.Columns[5].HeaderText = "Địa chỉ";
            dgDMNhanVien.Columns[6].HeaderText = "Tên công việc";
            //Chiều rộng cột phù hợp với nội dung tát cả các ô kể cả tiêu đề

            dgDMNhanVien.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDMNhanVien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDMNhanVien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDMNhanVien.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDMNhanVien.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDMNhanVien.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgDMNhanVien.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgDMNhanVien.AllowUserToAddRows = false;
            dgDMNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgDMNhanVien_Click(object sender, EventArgs e)
        {
            string ma;
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNV.Text = dgDMNhanVien.CurrentRow.Cells["manv"].Value.ToString();
            txtTenNV.Text = dgDMNhanVien.CurrentRow.Cells["tennv"].Value.ToString();
            
            if (dgDMNhanVien.CurrentRow.Cells["gioitinh"].Value.ToString() == "Nam")
                chkGioitinh.Checked = true;
            else
                chkGioitinh.Checked = false;
            ma = dgDMNhanVien.CurrentRow.Cells["tencv"].Value.ToString();
            cboMaCV.Text = Functions.GetFieldValues("SELECT tencv FROM tblCongviec WHERE tencv = N'" + ma + "'");
            txtDiachi.Text = dgDMNhanVien.CurrentRow.Cells["diachi"].Value.ToString();
            mskDienthoai.Text = dgDMNhanVien.CurrentRow.Cells["dienthoai"].Value.ToString();
            mskNgaysinh.Text = dgDMNhanVien.CurrentRow.Cells["ngaysinh"].Value.ToString();
            btnSua.Enabled = true;
            btnBoqua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            chkGioitinh.Checked = false;
            txtDiachi.Text = "";
            mskNgaysinh.Text = "";
            mskDienthoai.Text = "";
            cboMaCV.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValues();
            txtMaNV.Enabled = true;
            txtMaNV.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )     ")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /    ")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (!Class.Functions.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            sql = "Select manv from tblNhanvien where manv = N'" + txtMaNV.Text + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                txtMaNV.Text = "";
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            sql = "insert into tblNhanvien(manv,tennv,gioitinh,ngaysinh,dienthoai,diachi,macv) values(N'" + txtMaNV.Text.Trim() + "',N'" + txtTenNV.Text.Trim() + "',N'" + gt + "','" + Class.Functions.ConvertDateTime(mskNgaysinh.Text) + "','" + mskDienthoai.Text + "',N'" + txtDiachi.Text + "',N'" + cboMaCV.SelectedValue.ToString() + "')";
            Class.Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoqua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNV.Focus();
                return;
            }
            if (txtDiachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiachi.Focus();
                return;
            }
            if (mskDienthoai.Text == "(   )     ")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskDienthoai.Focus();
                return;
            }
            if (mskNgaysinh.Text == "  /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Focus();
                return;
            }
            if (!Functions.IsDate(mskNgaysinh.Text))
            {
                MessageBox.Show("Bạn phải nhập lại ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mskNgaysinh.Text = "";
                mskNgaysinh.Focus();
                return;
            }
            if (chkGioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            sql = "UPDATE tblNhanvien SET  TenNV=N'" +txtTenNV.Text.Trim().ToString() +
                    "',Diachi=N'" + txtDiachi.Text.Trim().ToString() +
                    "',Dienthoai='" + mskDienthoai.Text.ToString() + "',Gioitinh=N'" + gt +
                    "',Ngaysinh='" + Functions.ConvertDateTime(mskNgaysinh.Text) +
                    "',MaCV=N'" + cboMaCV.SelectedValue.ToString() +
                "'WHERE MaNV=N'" + txtMaNV.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btnBoqua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNhanvien WHERE manv=N'" + txtMaNV.Text + "'";
                Class.Functions.RunSqlDel(sql);
                Load_DataGridView();
                ResetValues();
            }
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnBoqua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaNV.Enabled = false;
        }

        
    }
}
