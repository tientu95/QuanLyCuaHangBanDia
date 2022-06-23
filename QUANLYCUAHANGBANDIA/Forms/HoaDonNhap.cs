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
    public partial class frmHoadonnhap : Form
    {
        public frmHoadonnhap()
        {
            InitializeComponent();
        }
        DataTable tblCTHDN;
        private void HoaDonNhap_Load(object sender, EventArgs e)
        {

        }

        private void frmHoadonnhap_Load(object sender, EventArgs e)
        {
                btn_Them.Enabled = true;
            btn_Luu.Enabled = false;
            btn_Huy.Enabled = false;
            btn_In.Enabled = false;
            txt_MaHDN.ReadOnly = true;
            txt_TenNV.ReadOnly = true;
            
            txt_Diachi.ReadOnly = true;
            txt_Dienthoai.ReadOnly = true;
            txt_Tendia.ReadOnly = true;
            txt_Dongia.ReadOnly = false;
            txt_Thanhtien.ReadOnly = true;
            txt_Tongtien.ReadOnly = true;
            txt_Giamgia.Text = "0";
            txt_Tongtien.Text = "0";
            Class.Functions.FillCombo("SELECT mancc, tenncc FROM tblNhacungcap", cbo_MaNCC, "mancc", "mancc");
            cbo_MaNCC.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT manv, tennv FROM tblNhanvien", cbo_MaNV, "manv", "manv");
            cbo_MaNV.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT madia, tendia FROM tblKhodia", cbo_Madia, "madia", "madia");
            cbo_Madia.SelectedIndex = -1;
            Class.Functions.FillCombo("SELECT sohdn FROM tblHoadonnhap", cboSoHDN, "sohdn", "sohdn");
            cboSoHDN.SelectedIndex = -1;
            if (txt_MaHDN.Text != "")
            {
                Load_ThongtinHD();
                btn_Huy.Enabled = true;
                btn_In.Enabled = true;
                Load_DataGridView();
            }
        }

        private void Load_DataGridView()
        {
            string sql;
            sql = "SELECT a.madia, b.tendia, a.soluong, a.dongia, a.giamgia, a.thanhtien FROM tblChitiethdn AS a, tblKhodia AS b WHERE a.sohdn = N'" + txt_MaHDN.Text + "' AND a.madia=b.madia";
            tblCTHDN = Class.Functions.GetDataToTable(sql);
            dg_Hoadonnhap.DataSource = tblCTHDN;
            dg_Hoadonnhap.Columns[0].HeaderText = "Mã đĩa";
            dg_Hoadonnhap.Columns[1].HeaderText = "Tên đĩa";
            dg_Hoadonnhap.Columns[2].HeaderText = "Số lượng";
            dg_Hoadonnhap.Columns[3].HeaderText = "Đơn giá";
            dg_Hoadonnhap.Columns[4].HeaderText = "Giảm giá %";
            dg_Hoadonnhap.Columns[5].HeaderText = "Thành tiền";
            //Chiều rộng cột phù hợp với nội dung tất cả cá ô kể cả tiêu đề
            dg_Hoadonnhap.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Hoadonnhap.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Hoadonnhap.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Hoadonnhap.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Hoadonnhap.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Hoadonnhap.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Hoadonnhap.AllowUserToAddRows = false;
            dg_Hoadonnhap.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Huy.Enabled = false;
            btn_Luu.Enabled = true;
            btn_In.Enabled = false;
            btn_Them.Enabled = false;
            ResetValues();
            
            txt_MaHDN.Text = Class.Functions.CreateKey("HDN_");
            Load_DataGridView();
        }

        private void ResetValues()
        {
            txt_MaHDN.Text = "";
            txt_Ngaynhap.Text = DateTime.Now.ToShortDateString();
            cbo_MaNV.Text = "";
            cbo_MaNCC.Text = "";
            txt_Tongtien.Text = "0";
            lbl_Bangchu.Text = "Bằng chữ: ";
            cbo_Madia.Text = "";
            txt_Soluong.Text = "";
            txt_Giamgia.Text = "0";
            txt_Thanhtien.Text = "0";
            txt_Diachi.Text = "";
            txt_Dienthoai.Text = "";
            txt_TenNV.Text = "";
            txt_TenNCC.Text = "";
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string sql;
            double sl, SLcon, tong, Tongmoi, dongiamoi;
            sql = "SELECT sohdn FROM tblHoadonnhap WHERE sohdn=N'" + txt_MaHDN.Text + "'";
            if (!Class.Functions.CheckKey(sql))
            {
                if (txt_Ngaynhap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Ngaynhap.Focus();
                    return;
                }
                if (cbo_MaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_MaNV.Focus();
                    return;
                }
                if (cbo_MaNCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_MaNCC.Focus();
                    return;
                }
                sql = "INSERT INTO tblHoadonnhap(sohdn, manv, ngaynhap, mancc, tongtien) VALUES(N'" + txt_MaHDN.Text.Trim() + "',N'" + cbo_MaNV.SelectedValue + "', '" +
                        Class.Functions.ConvertDateTime(txt_Ngaynhap.Text.Trim()) + "',N'" +
                        cbo_MaNCC.SelectedValue + "'," + txt_Tongtien.Text + ")";
                Class.Functions.RunSql(sql);
            }
                if (cbo_Madia.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã đĩa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_Madia.Focus();
                    return;
                }
                if ((txt_Soluong.Text.Trim().Length == 0) || (txt_Soluong.Text == "0"))
                {
                    MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Soluong.Text = "";
                    txt_Soluong.Focus();
                    return;
                }
                if (txt_Giamgia.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Giamgia.Focus();
                    return;
                }
                sql = "SELECT madia FROM tblChitietHDN WHERE madia = N'" + cbo_Madia.SelectedValue + "' AND sohdn = N'" + txt_MaHDN.Text.Trim() + "'";
                if (Class.Functions.CheckKey(sql))
                {
                    MessageBox.Show("Mã đĩa này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetValuesDia();
                    cbo_Madia.Focus();
                    return;
                }

                sl = Convert.ToDouble(Class.Functions.GetFieldValues("SELECT soluong FROM tblKhodia WHERE madia = N'" + cbo_Madia.SelectedValue + "'"));

                sql = "INSERT INTO tblChitietHDN(sohdn, madia, soluong, dongia, giamgia, thanhtien) VALUES(N'" + txt_MaHDN.Text.Trim() + "', N'" + 
                cbo_Madia.SelectedValue + "','" + txt_Soluong.Text + "','" + txt_Dongia.Text + "', '" + txt_Giamgia.Text + "','" + txt_Thanhtien.Text + "')";
                Class.Functions.RunSql(sql);              
                dongiamoi = Convert.ToDouble(txt_Dongia.Text);

                //Cập nhật lại đơn giá nhập và đơn giá bán theo giá nhập mới

                sql = "UPDATE tblKhodia SET dongianhap ='" + dongiamoi + "' WHERE madia = N'" + cbo_Madia.SelectedValue + "'";
                Class.Functions.RunSql(sql);

                sql = "UPDATE tblKhodia SET dongiaban ='" + (dongiamoi * 1.1) + "' WHERE madia = N'" + cbo_Madia.SelectedValue + "'";
                Class.Functions.RunSql(sql);

                // Cập nhật lại số lượng đĩa vào bảng Kho đĩa
                sl = Convert.ToDouble(Class.Functions.GetFieldValues("SELECT SoLuong FROM tblKhodia WHERE Madia = N'" + cbo_Madia.SelectedValue + "'"));
                double slmoi = Convert.ToDouble(txt_Soluong.Text);
                SLcon = sl + slmoi;
                sql = "UPDATE tblKhodia SET SoLuong =" + SLcon + " WHERE MaDia= N'" + cbo_Madia.SelectedValue + "'";
                Class.Functions.RunSql(sql);

                // Cập nhật lại tổng tiền cho hóa đơn nhập

                tong = Convert.ToDouble(Class.Functions.GetFieldValues("SELECT tongtien FROM tblHoadonnhap WHERE sohdn = N'" + txt_MaHDN.Text + "'"));
                Tongmoi = tong + Convert.ToDouble(txt_Thanhtien.Text);
                sql = "UPDATE tblHoadonnhap SET tongtien =" + Tongmoi + " WHERE sohdn = N'" + txt_MaHDN.Text + "'";
                Class.Functions.RunSql(sql);
                txt_Tongtien.Text = Tongmoi.ToString();
                lbl_Bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txt_Tongtien.Text.ToString()));
                Load_DataGridView();
                ResetValuesDia();

                btn_Huy.Enabled = true;
                btn_Them.Enabled = true;
                btn_In.Enabled = true;
            
        }

        private void ResetValuesDia()
        {
            cbo_Madia.Text = "";
            txt_Soluong.Text = "";
            txt_Giamgia.Text = "0";
            txt_Thanhtien.Text = "0";
            txt_Tendia.Text = "";
            txt_Dongia.Text = "";
        }

        private void cbo_MaNV_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbo_MaNV.Text == "")
                txt_TenNV.Text = "";
            // Khi kich chon Ma nhan vien thi ten nhan vien se tu dong hien ra
            str = "Select tennv from tblNhanvien where manv = N'" + cbo_MaNV.SelectedValue + "'";
            txt_TenNV.Text = Class.Functions.GetFieldValues(str);
        }

        private void cbo_MaNCC_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbo_MaNCC.Text == "")
            {
                txt_TenNCC.Text = "";
                txt_Diachi.Text = "";
                txt_Dienthoai.Text = "";
            }
            //Khi kich chon Ma khach thi ten khach, dia chi, dien thoai se tu dong hien ra
            str = "Select tenncc from tblNhacungcap where mancc = N'" + cbo_MaNCC.SelectedValue + "'";
            txt_TenNCC.Text = Class.Functions.GetFieldValues(str);
            str = "Select diachi from tblNhacungcap where mancc = N'" + cbo_MaNCC.SelectedValue + "'";
            txt_Diachi.Text = Class.Functions.GetFieldValues(str);
            str = "Select dienthoai from tblNhacungcap where mancc = N'" + cbo_MaNCC.SelectedValue + "'";
            txt_Dienthoai.Text = Class.Functions.GetFieldValues(str);
        }

        private void cbo_Madia_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cbo_Madia.Text == "")
            {
                txt_Tendia.Text = "";
                txt_Dongia.Text = "";
            }
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "SELECT tendia FROM tblKhodia WHERE madia = N'" + cbo_Madia.SelectedValue + "'";
            txt_Tendia.Text = Class.Functions.GetFieldValues(str);
            str = "SELECT dongianhap FROM tblKhodia WHERE madia = N'" + cbo_Madia.SelectedValue + "'";
            txt_Dongia.Text = Class.Functions.GetFieldValues(str);
        }

        private void txt_Soluong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txt_Soluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txt_Soluong.Text);
            if (txt_Giamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txt_Giamgia.Text);
            if (txt_Dongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txt_Dongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txt_Thanhtien.Text = tt.ToString();
        }

        private void txt_Giamgia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txt_Soluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txt_Soluong.Text);
            if (txt_Giamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txt_Giamgia.Text);
            if (txt_Dongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txt_Dongia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txt_Thanhtien.Text = tt.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();

        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string[] Mahang = new string[20];
                string sql;
                int n = 0;
                int i;
                sql = "SELECT madia FROM tblChitiethdn WHERE sohdn = N'" + txt_MaHDN.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, Class.Functions.Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mahang[n] = reader.GetString(0).ToString();
                    n = n + 1;
                }
                reader.Close();
                //Xóa danh sách các mặt hàng của hóa đơn
                for (i = 0; i <= n - 1; i++)
                    DelHang(txt_MaHDN.Text, Mahang[i]);
                //Xóa hóa đơn
                sql = "DELETE tblHoadonnhap WHERE sohdn=N'" + txt_MaHDN.Text + "'";
                Class.Functions.RunSqlDel(sql);
                ResetValues();
                Load_DataGridView();
                btn_Huy.Enabled = false;
                btn_In.Enabled = false;
            }
        }

        private void DelHang(string Mahoadon, string Mahang)
        {
            Double s, sl, SLcon;
            string sql;
            sql = "SELECT soluong FROM tblChitiethdn WHERE sohdn = N'" + Mahoadon + "' AND madia = N'" + Mahang + "'";
            s = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
            sql = "DELETE tblChitiethdn WHERE sohdn=N'" + Mahoadon + "' AND madia = N'" + Mahang + "'";
            Class.Functions.RunSqlDel(sql);
            // Cập nhật lại số lượng cho các mặt hàng
            sql = "SELECT soluong FROM tblKhodia WHERE madia = N'" + Mahang + "'";
            sl = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
            SLcon = sl + s;
            sql = "UPDATE tblKhodia SET soluong =" + SLcon + " WHERE madia= N'" + Mahang + "'";
            Class.Functions.RunSql(sql);
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboSoHDN.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDN.Focus();
                return;
            }
            txt_MaHDN.Text = cboSoHDN.Text;
            Load_ThongtinHD();
            Load_DataGridView();
            btn_Huy.Enabled = true;
            btn_Luu.Enabled = true;
            btn_In.Enabled = true;
            cboSoHDN.SelectedIndex = -1;
        }

        private void Load_ThongtinHD()
        {
            string str;
            str = "SELECT ngaynhap FROM tblHoadonnhap WHERE sohdn = N'" + txt_MaHDN.Text + "'";
            txt_Ngaynhap.Text = Class.Functions.ConvertDateTime(Class.Functions.GetFieldValues(str));
            str = "SELECT manv FROM tblHoadonnhap WHERE sohdn = N'" + txt_MaHDN.Text + "'";
            cbo_MaNV.Text = Class.Functions.GetFieldValues(str);

            str = "SELECT mancc FROM tblHoadonnhap WHERE sohdn = N'" + txt_MaHDN.Text + "'";
            cbo_MaNCC.Text = Class.Functions.GetFieldValues(str);

            str = "SELECT tongtien FROM tblHoadonnhap WHERE sohdn = N'" + txt_MaHDN.Text + "'";
            txt_Tongtien.Text = Class.Functions.GetFieldValues(str);
        }

        private void btn_In_Click(object sender, EventArgs e)
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
            exRange.Range["A3:B3"].Value = "Điện thoại: (05)6666666";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN NHẬP";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.sohdn, a.ngaynhap, a.tongtien, b.tenncc, b.diachi, b.dienthoai, c.tennv FROM tblHoadonnhap AS a, tblNhacungcap AS b, tblNhanvien AS c WHERE a.sohdn = N'" + txt_MaHDN.Text + "' AND a.mancc = b.mancc AND a.manv =c.manv";
            tblThongtinHD = Class.Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Nhà cung cấp:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblThongtinHD.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblThongtinHD.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.tendia, a.Soluong, b.dongianhap, a.giamgia, a.thanhtien " +
                  "FROM tblChitiethdn AS a , tblKhodia AS b WHERE a.sohdn = N'" +
                  txt_MaHDN.Text + "' AND a.madia = b.madia";
            tblThongtinHang = Class.Functions.GetDataToTable(sql);
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
            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (cboSoHDN.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSoHDN.Focus();
                return;
            }
            txt_MaHDN.Text = cboSoHDN.Text;
            Load_ThongtinHD();
            Load_DataGridView();
            btn_Huy.Enabled = true;
            btn_Luu.Enabled = true;
            btn_In.Enabled = true;
            cboSoHDN.SelectedIndex = -1;
        }
        public void DelUpdateTongtien(string MaHoaDon, double thanhtien)
        {
            Double tong, tongmoi;
            string sql = "SELECT tongtien FROM tblHoadonnhap WHERE sohdn =N'" + MaHoaDon + "'";
            tong = Convert.ToDouble(Class.Functions.GetFieldValues(sql));
            tongmoi = tong - thanhtien;
            sql = "UPDATE tblHoadonnhap SET tongtien=" + tongmoi + "WHERE sohdn +N'" + MaHoaDon + "'";
            Class.Functions.RunSql(sql);
            txt_Thanhtien.Text = tongmoi.ToString();
            lbl_Bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txt_Tongtien.Text.ToString()));
        }

        private void dg_Hoadonnhap_DoubleClick(object sender, EventArgs e)
        {
            string madiaxoa, sql;
            Double thanhtienxoa, soluongxoa, sl, slcon, tong, tongmoi;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                //Xóa và cập nhật lại số lượng đĩa
                madiaxoa = dg_Hoadonnhap.CurrentRow.Cells["madia"].Value.ToString();
                soluongxoa = Convert.ToDouble(dg_Hoadonnhap.CurrentRow.Cells["soluong"].Value.ToString());
                thanhtienxoa = Convert.ToDouble(dg_Hoadonnhap.CurrentRow.Cells["thanhtien"].Value.ToString());
                sql = "DELETE tblChitietHDN WHERE sohdn =N'" + txt_MaHDN.Text + "' AND madia = N'" + madiaxoa + "'";
                Class.Functions.RunSql(sql);

                // Cập nhật lại số lượng cho các loại dia
                sl = Convert.ToDouble(Class.Functions.GetFieldValues("SELECT soluong FROM tblKhodia WHERE madia = N'" + madiaxoa + "'"));
                slcon = sl - soluongxoa;
                sql = "UPDATE tblKhodia SET soluong =" + slcon + " WHERE madia= N'" + madiaxoa + "'";
                Class.Functions.RunSql(sql);

                // Cập nhật lại tổng tiền cho hóa đơn nhập
                tong = Convert.ToDouble(Class.Functions.GetFieldValues("SELECT TongTien FROM tblHoadonnhap WHERE SoHDN = N'" + txt_MaHDN.Text + "'"));
                tongmoi = tong - thanhtienxoa;
                sql = "UPDATE tblHoadonnhap SET TongTien =" + tongmoi + " WHERE sohdn = N'" + txt_MaHDN.Text + "'";
                Class.Functions.RunSql(sql);
                txt_Tongtien.Text = tongmoi.ToString();
                lbl_Bangchu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txt_Tongtien.Text.ToString()));
                Load_DataGridView();
            }
        }

        private void txt_Dongia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (txt_Dongia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txt_Dongia.Text);
            if (txt_Giamgia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txt_Giamgia.Text);
            if (txt_Soluong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txt_Soluong.Text);
            tt = dg * sl - dg * sl * gg / 100;
            txt_Thanhtien.Text = tt.ToString();
        }

        private void dg_Hoadonnhap_Click(object sender, EventArgs e)
        {
            string ma;
            if (tblCTHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ma = dg_Hoadonnhap.CurrentRow.Cells["madia"].Value.ToString();
            cbo_Madia.Text = dg_Hoadonnhap.CurrentRow.Cells["madia"].Value.ToString();
            txt_Tendia.Text = dg_Hoadonnhap.CurrentRow.Cells["tendia"].Value.ToString();
            txt_Dongia.Text = dg_Hoadonnhap.CurrentRow.Cells["dongia"].Value.ToString();
            txt_Soluong.Text = dg_Hoadonnhap.CurrentRow.Cells["soluong"].Value.ToString();
            txt_Giamgia.Text = dg_Hoadonnhap.CurrentRow.Cells["giamgia"].Value.ToString();
            txt_Thanhtien.Text = dg_Hoadonnhap.CurrentRow.Cells["thanhtien"].Value.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

