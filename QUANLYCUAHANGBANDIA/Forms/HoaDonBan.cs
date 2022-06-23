using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;
using Quan_ly_cua_hang_ban_dia.Class;

namespace Quan_ly_cua_hang_ban_dia.Forms
{
    public partial class frm_Hoadonban : Form
    {
        DataTable tblCTHDB;
        public frm_Hoadonban()
        {
            InitializeComponent();
        }

        private void frm_HoaDonBan_Load(object sender, EventArgs e)
        {
            btnThemhoadon.Enabled = true;
            btnLuu.Enabled = false;
            btnHuyHD.Enabled = false;
            btnInHD.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtTenkhach.ReadOnly = true;
            txtDiachi.ReadOnly = true;
            txtDienthoai.ReadOnly = true;
            txtTendia.ReadOnly = true;
            txtDongiaban.ReadOnly = true;
            txtThanhtien.ReadOnly = true;
            txtTongtien.ReadOnly = true;
            txtgGiamgia.Text = "0";
            txtTongtien.Text = "0";
            Class.Functions.FillCombo("SELECT Makhach, Tenkhach FROM tblKhachhang", cboMaKH,"Makhach", "makhach");
            cboMaKH.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT Manv, Tennv FROM tblNhanvien",cboMaNV, "Manv", "manv");
            cboMaNV.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT Madia, Tendia FROM tblKhodia", cboMadia,"Madia", "madia");
            cboMadia.SelectedIndex = -1;

            Class.Functions.FillCombo("SELECT sohdb FROM tblHoadonban", cboMaHD,
           "sohdb", "sohdb");
            cboMaHD.SelectedIndex = -1;
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoaDon();
                btnHuyHD.Enabled = true;
                btnInHD.Enabled = true;
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.Madia, b.Tendia, a.Soluong, b.Dongiaban, a.Giamgia, a.Thanhtien FROM tblChitietHDB AS a, tblKhodia AS b WHERE a.sohdb = N'" + txtMaHDBan.Text + "' AND a.Madia=b.Madia";
            tblCTHDB = Functions.GetDataToTable(sql);
            dgchitiethdban.DataSource = tblCTHDB;
            dgchitiethdban.Columns[0].HeaderText = "Mã đĩa";
            dgchitiethdban.Columns[1].HeaderText = "Tên đĩa";
            dgchitiethdban.Columns[2].HeaderText = "Số lượng";
            dgchitiethdban.Columns[3].HeaderText = "Đơn giá";
            dgchitiethdban.Columns[4].HeaderText = "Giảm giá %";
            dgchitiethdban.Columns[5].HeaderText = "Thành tiền";
            dgchitiethdban.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgchitiethdban.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgchitiethdban.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgchitiethdban.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgchitiethdban.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgchitiethdban.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dgchitiethdban.AllowUserToAddRows = false;
            dgchitiethdban.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {

            string str;
            str = "SELECT Ngayban FROM tblHoadonban WHERE sohdb = N'" + txtMaHDBan.Text + "'";
            txtNgayban.Text = Functions.ConvertDateTime(Functions.GetFieldValues(str));
            str = "SELECT Manv FROM tblHoadonban WHERE sohdb = N'" + txtMaHDBan.Text + "'";
            cboMaNV.Text = Functions.GetFieldValues(str);

            str = "SELECT Makhach FROM tblHoadonban WHERE sohdb = N'" + txtMaHDBan.Text + "'";
            cboMaKH.Text = Functions.GetFieldValues(str);

            str = "SELECT Tongtien FROM tblHoadonban WHERE sohdb = N'" + txtMaHDBan.Text + "'";
            txtTongtien.Text = Functions.GetFieldValues(str);

            //lblBangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(txtTongtien.Text);
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txtTongtien.Text.ToString()));

        }

        private void btnThemhoadon_Click(object sender, EventArgs e)
        {
            cboMaNV.Enabled = true;
            cboMaKH.Enabled = true;
            cboMadia.Enabled = true;
            btnHuyHD.Enabled = false;
            
            btnLuu.Enabled = true;
            btnInHD.Enabled = false;
            btnThemhoadon.Enabled = false;
            ResetValues();
            ResetValuesHang();
            txtMaHDBan.Text = Class.Functions.CreateKey("HDB_");
            LoadDataGridView();
            

        }
        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            txtNgayban.Text = DateTime.Now.ToShortDateString();
            cboMaNV.Text = "";
            cboMaKH.Text = "";
            txtTongtien.Text = "0";
            lblBangchu.Text = "Bằng chữ: ";
            cboMadia.Text = "";
            txtSoluong.Text = "";
            txtgGiamgia.Text = "0";
            txtThanhtien.Text = "0";
            txtTenNV.Text = "";
            txtDiachi.Text = "";
            txtDienthoai.Text = "";          
            txtTenkhach.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi;
            sql = "SELECT sohdb FROM tblHoadonban WHERE sohdb=N'" + txtMaHDBan.Text + "'";
            if (!Functions.CheckKey(sql))
            {
                
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (txtNgayban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayban.Focus();
                    return;
                }
                if (cboMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaNV.Focus();
                    return;
                }
                if (cboMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaKH.Focus();
                    return;
                }
                sql = "INSERT INTO tblHoadonban(sohdb, Ngayban, Manv, Makhach, Tongtien) VALUES(N'" + txtMaHDBan.Text.Trim() + "', '" +
                        Functions.ConvertDateTime(txtNgayban.Text.Trim()) + "',N'" + cboMaNV.SelectedValue + "',N'" +
                        cboMaKH.SelectedValue + "'," + txtTongtien.Text + ")";
                Functions.RunSql(sql);
            }

            // Lưu thông tin của các mặt hàng
            if (cboMadia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMadia.Focus();
                return;
            }
            if ((txtSoluong.Text.Trim().Length == 0) || (txtSoluong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            if (txtgGiamgia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgGiamgia.Focus();
                return;
            }
            sql = "SELECT Madia FROM tblChitietHDB WHERE Madia=N'" + cboMadia.SelectedValue + "' AND sohdb = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ResetValuesHang();
                cboMadia.Focus();
                return;
            }

            // Kiểm tra xem số lượng hàng trong kho còn đủ để cung cấp không?
            sl = Convert.ToDouble(Functions.GetFieldValues("SELECT Soluong FROM tblkhodia WHERE Madia = N'" + cboMadia.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoluong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Text = "";
                txtSoluong.Focus();
                return;
            }
            sql = "INSERT INTO tblChitietHDB(sohdb,Madia,Soluong,dongia,Giamgia, Thanhtien) VALUES(N'" + txtMaHDBan.Text.Trim() + "', N'" +
                cboMadia.SelectedValue + "'," + txtSoluong.Text + "," + txtSoluong.Text+ "," + txtgGiamgia.Text + "," + txtThanhtien.Text + ")";
            Functions.RunSql(sql);
            LoadDataGridView();
            // Cập nhật lại số lượng của mặt hàng vào bảng tblHang
            SLcon = sl - Convert.ToDouble(txtSoluong.Text);
            sql = "UPDATE tblKhodia SET Soluong =" + SLcon + " WHERE Madia= N'" + cboMadia.SelectedValue + "'";
            Functions.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán

            tong = Convert.ToDouble(Functions.GetFieldValues("SELECT Tongtien FROM tblHoadonban WHERE sohdb = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhtien.Text);
            sql = "UPDATE tblHoadonban SET Tongtien =" + Tongmoi + " WHERE sohdb = N'" + txtMaHDBan.Text + "'";
            Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            //lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChu(Tongmoi.ToString());
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txtTongtien.Text.ToString()));
            ResetValuesHang();
            btnHuyHD.Enabled = true;
            btnThemhoadon.Enabled = true;
            btnInHD.Enabled = true;
        }
        private void ResetValuesHang()
        {
            cboMadia.Text = "";
            txtSoluong.Text = "";
            txtgGiamgia.Text = "0";
            txtThanhtien.Text = "0";
            txtTendia.Text = "";
            txtDongiaban.Text = "";
            
           
            
        }

        private void cboMaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaNV.Text == "")
                txtTenNV.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tennv from tblNhanvien where manv =N'" + cboMaNV.SelectedValue + "'";
            txtTenNV.Text = Class.Functions.GetFieldValues(str);
        }

        private void cboMaKH_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaKH.Text == "")
            {
                txtTenkhach.Text = "";
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select Tenkhach from tblKhachhang where Makhach = N'" + cboMaKH.SelectedValue + "'";
            txtTenkhach.Text = Class.Functions.GetFieldValues(str);
            str = "Select Diachi from tblKhachhang where Makhach = N'" + cboMaKH.SelectedValue + "'";
            txtDiachi.Text = Class.Functions.GetFieldValues(str);
            str = "Select Dienthoai from tblKhachhang where Makhach= N'" + cboMaKH.SelectedValue + "'";
            txtDienthoai.Text = Class.Functions.GetFieldValues(str);
        }

        private void cboMadia_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMadia.Text == "")
            {
                txtTendia.Text = "";
                txtDongiaban.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT Tendia FROM tblKhodia WHERE Madia =N'" + cboMadia.SelectedValue + "'";
            txtTendia.Text = Class.Functions.GetFieldValues(str);
            str = "SELECT Dongiaban FROM tblKhodia WHERE Madia =N'" + cboMadia.SelectedValue + "'";
            txtDongiaban.Text = Class.Functions.GetFieldValues(str);
        }

        private void txtgGiamgia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtgGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtgGiamgia.Text);
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();
        }

        private void txtSoluong_TextChanged_1(object sender, EventArgs e)
        {
            //Khi thay doi So luong, Giam gia thi Thanh tien tu dong cap nhat lai gia tri
            double tt, sl, dg, gg;
            if (txtSoluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoluong.Text);
            if (txtgGiamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtgGiamgia.Text);
            if (txtDongiaban.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDongiaban.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhtien.Text = tt.ToString();

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            cboMadia.Enabled = false;
            cboMaKH.Enabled = false;
            cboMaNV.Enabled = false;
            if (cboMaHD.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHD.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHD.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnHuyHD.Enabled = true;
            btnLuu.Enabled = true;
            btnInHD.Enabled = true;
            cboMaHD.SelectedIndex = -1;
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop Audio";

            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";

            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 66666666";
             

            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán

            sql = "SELECT a.sohdb, a.Ngayban, a.Tongtien, b.Tenkhach, b.Diachi, b.Dienthoai, c.Tennv FROM tblHoadonban AS a, tblKhachhang AS b, tblNhanvien AS c WHERE a.sohdb = N'" + 
                txtMaHDBan.Text + "' AND a.Makhach = b.Makhach AND a.Manv =c.Manv";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Số hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.Tendia, a.Soluong, b.Dongiaban, a.Giamgia, a.Thanhtien " +
                  "FROM tblChitietHDB AS a , tblKhodia AS b WHERE a.sohdb = N'" +
                  txtMaHDBan.Text + "' AND a.Madia = b.Madia";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên đĩa";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
            }

            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            //exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tblThongtinHD.Rows[0][2].ToString()));

            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][6];
            exSheet.Name = "Hóa đơn ";
            exApp.Visible = true;
        }
        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT Madia FROM tblChitietHDB WHERE Sohdb = N'" + txtMaHDBan.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Functions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txtMaHDBan.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE tblHoadonban WHERE sohdb=N'" + txtMaHDBan.Text + "'";
                Functions.RunSqlDel(sql);
                ResetValues();
                ResetValuesHang();
                LoadDataGridView();
                btnHuyHD.Enabled = false;
                btnInHD.Enabled = false;
            }
        }
        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT Soluong FROM tblChitietHDB WHERE sohdb = N'" + Mahoadon + "' AND madia = N'" + Mahang + "'";
            s = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
            sql = "DELETE tblChitietHDB WHERE sohdb=N'" + Mahoadon + "' AND madia = N'" + Mahang + "'";
            Class.Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT Soluong FROM tblKhodia WHERE madia = N'" + Mahang + "'";
            sl = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblKhodia SET Soluong =" + SLcon + " WHERE madia= N'" + Mahang + "'";
            Class.Functions.RunSql(sql);
        }

        private void DelUpdateTongtien(string Mahoadon, double Thanhtien)
        {
            Double Tong, Tongmoi;
            string sql;
            sql = "SELECT tongtien FROM tblhoadonban WHERE sohdb = N'" + Mahoadon + "'";
            Tong = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
            Tongmoi = Tong - Thanhtien;
            sql = "UPDATE tblHoadonban SET tongtien =" + Tongmoi + " WHERE sohdb = N'" + Mahoadon + "'";
            Class.Functions.RunSql(sql);
            txtTongtien.Text = Tongmoi.ToString();
            // lblBangchu.Text = "Bằng chữ: " + Class.Functions.ChuyenSoSangChu(Tongmoi.ToString());
            lblBangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txtTongtien.Text.ToString()));
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();

        }

        private void dgchitiethdban_DoubleClick(object sender, EventArgs e)
        {
            string mahang;
            Double Thanhtien;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa hàng và cập nhật lại số lượng hàng 
                mahang = dgchitiethdban.CurrentRow.Cells["madia"].Value.ToString();
                DelHang(txtMaHDBan.Text, mahang);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                Thanhtien = Convert.ToDouble(dgchitiethdban.CurrentRow.Cells["thanhtien"].Value.ToString());
                DelUpdateTongtien(txtMaHDBan.Text, Thanhtien);
                LoadDataGridView();
            }
        }

        private void dgchitiethdban_Click(object sender, EventArgs e)
        {
            string ma;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ma = dgchitiethdban.CurrentRow.Cells["madia"].Value.ToString();
            cboMadia.Text = dgchitiethdban.CurrentRow.Cells["madia"].Value.ToString();
            txtTendia.Text= dgchitiethdban.CurrentRow.Cells["tendia"].Value.ToString();
            txtDongiaban.Text= dgchitiethdban.CurrentRow.Cells["dongiaban"].Value.ToString();
            txtSoluong.Text= dgchitiethdban.CurrentRow.Cells["soluong"].Value.ToString();
            txtgGiamgia.Text= dgchitiethdban.CurrentRow.Cells["giamgia"].Value.ToString();
            txtThanhtien.Text= dgchitiethdban.CurrentRow.Cells["thanhtien"].Value.ToString();

        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8) )
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtgGiamgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (e.KeyChar == '.') || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void cboMaHD_DropDown(object sender, EventArgs e)
        {
            Class.Functions.FillCombo("SELECT sohdb FROM tblChitietHDB", cboMaHD,
           "sohdb", "sohdb");
            cboMaHD.SelectedIndex = -1;
        }

        private void frm_Hoadonban_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        

        
    }
}
