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
    public partial class frm_DMKhodia : Form
    {
        DataTable tblKhodia;
        public frm_DMKhodia()
        {
            InitializeComponent();
        }

        private void frm_Khodia_Load(object sender, EventArgs e)
        {
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = false;
            btn_Luu.Enabled = false;
            btn_Boqua.Enabled = false;
            btn_Timkiem.Enabled = true;
            btn_Hienthi.Enabled = true;
            txt_Madia.Enabled = false;

            Functions.FillCombo("SELECT MaTheLoai,TenTheLoai FROM tblTheloai", cbo_Maloai, "MaTheLoai", "TenTheLoai");
            Functions.FillCombo("SELECT MaNSX,TenNSX FROM tblNoisanxuat", cbo_MaNSX, "MaNSX", "TenNSX");
            cbo_Maloai.SelectedIndex = -1;
            cbo_MaNSX.SelectedIndex = -1;
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT MaDia,TenDia,TenTheLoai,TenNSX,SoLuong,DonGiaNhap,DonGiaBan FROM tblKhodia JOIN tblTheloai ON tblKhodia.MaTheLoai = tblTheloai.MaTheLoai JOIN tblNoisanxuat ON tblKhodia.MaNSX= tblNoisanxuat.MaNSX";
           
            tblKhodia = Functions.GetDataToTable(sql);
            dg_Khodia.DataSource = tblKhodia;
            dg_Khodia.Columns[0].HeaderText = "Mã đĩa";
            dg_Khodia.Columns[1].HeaderText = "Tên đĩa";
            dg_Khodia.Columns[2].HeaderText = "Tên thể loại";
            dg_Khodia.Columns[3].HeaderText = "Tên NSX";
            dg_Khodia.Columns[4].HeaderText = "Số lượng";
            dg_Khodia.Columns[5].HeaderText = "Đơn giá nhập";
            dg_Khodia.Columns[6].HeaderText = "Đơn giá bán";
            dg_Khodia.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khodia.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khodia.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khodia.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khodia.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khodia.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Khodia.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            dg_Khodia.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            dg_Khodia.EditMode = DataGridViewEditMode.EditProgrammatically;
            ResetValues();
        }
        private void ResetValues()
        {
            txt_Madia.Text = "";
            txt_Tendia.Text = "";
            cbo_Maloai.Text = "";
            cbo_MaNSX.Text = "";
            txt_Soluong.Text = "";
            txt_Dongianhap.Text = "";
            txt_Dongiaban.Text = "";
            txt_Soluong.Enabled = true;
            txt_Dongianhap.Enabled = true;
            txt_Dongiaban.Enabled = true;
            txt_Anh.Text = "";
            pxbox.Image = null;
            txt_Ghichu.Text = "";

        }

        private void dg_Khodia_Click(object sender, EventArgs e)
        {
            string ma, ma1;
            if (btn_Them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Madia.Focus();
                return;
            }
            if (tblKhodia.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_Madia.Text = dg_Khodia.CurrentRow.Cells["MaDia"].Value.ToString();
            txt_Tendia.Text = dg_Khodia.CurrentRow.Cells["TenDia"].Value.ToString();

            ma = dg_Khodia.CurrentRow.Cells["TenTheLoai"].Value.ToString();
            cbo_Maloai.Text = Functions.GetFieldValues("SELECT TenTheLoai FROM tblTheloai WHERE TenTheLoai= N'" + ma + "'");

            ma1 = dg_Khodia.CurrentRow.Cells["TenNSX"].Value.ToString();
            cbo_MaNSX.Text = Functions.GetFieldValues("SELECT TenNSX FROM tblNoisanxuat WHERE TenNSX = N'" + ma1 + "' ");

            txt_Soluong.Text = dg_Khodia.CurrentRow.Cells["SoLuong"].Value.ToString();
            txt_Dongianhap.Text = dg_Khodia.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txt_Dongiaban.Text = dg_Khodia.CurrentRow.Cells["DonGiaBan"].Value.ToString();

            txt_Ghichu.Text = Functions.GetFieldValues("SELECT GhiChu FROM tblKhodia WHERE MaDia = N'" + txt_Madia.Text + "'");
            txt_Anh.Text = Functions.GetFieldValues("SELECT Anh FROM tblKhodia WHERE MaDia = N'" + txt_Madia.Text + "' ");
            pxbox.Image = Image.FromFile(txt_Anh.Text);
            btn_Boqua.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Xoa.Enabled = true;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            btn_Boqua.Enabled = true;
            btn_Luu.Enabled = true;
            btn_Them.Enabled = false;
            ResetValues();
            txt_Madia.Enabled = true;
            txt_Madia.Focus();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string sql;

            if (txt_Madia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Madia.Focus();
                return;
            }
            if (txt_Tendia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Tendia.Focus();
                return;
            }
            if (cbo_Maloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_Maloai.Focus();
                return;
            }
            if (cbo_MaNSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nơi sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_Maloai.Focus();
                return;
            }
            if (txt_Anh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn bìa đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Anh.Focus();
                return;
            }
            sql = "SELECT MaDia FROM tblKhodia WHERE MaDia=N'" + txt_Madia.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã đĩa này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Madia.Focus();
                txt_Madia.Text = "";
                return;
            }

            sql = "INSERT INTO tblKhodia(madia,tendia,soluong,dongianhap,dongiaban,mansx,matheloai,anh,ghichu) VALUES(N'" + txt_Madia.Text.Trim() + "',N'"
                + txt_Tendia.Text.Trim() + "'," + txt_Soluong.Text.Trim() + "," + 
                txt_Dongianhap.Text + "," + txt_Dongiaban.Text + ",N'" + cbo_MaNSX.SelectedValue.ToString() + "',N'"
                + cbo_Maloai.SelectedValue.ToString() + "',N'" + txt_Anh.Text + "',N'" + txt_Ghichu.Text.Trim() + "')";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            btn_Boqua.Enabled = false;
            btn_Luu.Enabled = false;
            txt_Madia.Enabled = false;
        }   

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKhodia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Madia.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Tendia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Tendia.Focus();
                return;
            }

            if (txt_Soluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập so luong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Soluong.Focus();
                return;
            }
            if (txt_Dongianhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập don gia nhap", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Dongianhap.Focus();
                return;
            }

            if (txt_Dongiaban.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập don gia ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Dongiaban.Focus();
                return;
            }
            if (cbo_Maloai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_Maloai.Focus();
                return;
            }


            if (cbo_MaNSX.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập nơi sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbo_MaNSX.Focus();
                return;
            }
            if (txt_Anh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn bìa đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Anh.Focus();
                return;
            }
            sql = "UPDATE tblKhodia SET  TenDia=N'" + txt_Tendia.Text.Trim().ToString() +
                "',MaTheLoai=N'" + cbo_Maloai.SelectedValue.ToString() +
                "',MaNSX = N'" + cbo_MaNSX.SelectedValue.ToString() +
                "',Anh=N'" + txt_Anh.Text +
                "',GhiChu=N'" + txt_Ghichu.Text + "',Soluong=" + txt_Soluong.Text + ",Dongiaban=" + txt_Dongiaban.Text + ",dongianhap=" + 
                txt_Dongianhap.Text + " WHERE MaDia=N'" + txt_Madia.Text + "'";
            Functions.RunSql(sql);
            Load_DataGridView();
            ResetValues();
            btn_Boqua.Enabled = false;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKhodia.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_Madia.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblKhodia WHERE MaDia=N'" + txt_Madia.Text + "'";
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
            txt_Madia.Enabled = false;
        
        }

        private void btn_OPEN_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "bitmap(*.bmp)|*.bmp|Gif(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "D:";
            dlgOpen.FilterIndex = 3;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                pxbox.Image = Image.FromFile(dlgOpen.FileName);
                txt_Anh.Text = dlgOpen.FileName;

            }
        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txt_Madia.Text == "") && (txt_Tendia.Text == "") && (cbo_Maloai.Text == "")&&(cbo_MaNSX.Text==""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT MaDia,TenDia,TenTheLoai,TenNSX,SoLuong,DonGiaNhap,DonGiaBan FROM tblKhodia JOIN tblTheloai ON tblKhodia.MaTheLoai = tblTheloai.MaTheLoai" +
                " JOIN tblNoisanxuat ON tblKhodia.MaNSX= tblNoisanxuat.MaNSX WHERE 1=1";
            if (txt_Madia.Text != "")
                sql = sql + " AND MaDia Like N'%" + txt_Madia.Text + "%'";
            if (txt_Tendia.Text != "")
                sql = sql + " AND TenDia Like N'%" + txt_Tendia.Text + "%'";
            if (cbo_Maloai.Text != "")
                sql = sql + " AND tblTheloai.MaTheLoai Like N'%" + cbo_Maloai.SelectedValue + "%'";
            if (cbo_MaNSX.Text != "")
                sql = sql + "AND tblNoisanxuat.MaNSX LIKE N'%" + cbo_MaNSX.SelectedValue + "%'";
            tblKhodia = Functions.GetDataToTable(sql);
            if (tblKhodia.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Có " + tblKhodia.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            dg_Khodia.DataSource = tblKhodia;
            ResetValues();
        }

        private void btn_Hienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaDia,TenDia,TenTheLoai,TenNSX,SoLuong,DonGiaNhap,DonGiaBan FROM tblKhodia JOIN tblTheloai ON tblKhodia.MaTheLoai = tblTheloai.MaTheLoai " +
                "JOIN tblNoisanxuat ON tblKhodia.MaNSX= tblNoisanxuat.MaNSX";
            tblKhodia = Functions.GetDataToTable(sql);
            dg_Khodia.DataSource = tblKhodia;

        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void txt_Dongianhap_TextChanged(object sender, EventArgs e)
        {
            double dgn, dgb;
            if (txt_Dongianhap.Text == "")
                dgn = 0;
            else
                dgn = Convert.ToDouble(txt_Dongianhap.Text);
            dgb = dgn * 1.1;
            txt_Dongiaban.Text = dgb.ToString();
        }

        private void txt_Soluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_Dongianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) ||(e.KeyChar==',')|| (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
