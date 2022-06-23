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
    public partial class BaoCaoTopNCC : Form
    {
        public BaoCaoTopNCC()
        {
            InitializeComponent();
        }
        DataTable tblBCDSNCC;
        private void btn_Baocao_Click(object sender, EventArgs e)
        {
            txt_Nam.Enabled = true;
            btn_InBC.Enabled = true;
            btn_hienthi.Enabled = true;
            txt_Nam.Text = "";
            txt_Nam.Focus();
        }

        private void BaoCaoTopNCC_Load(object sender, EventArgs e)
        {
            txt_Nam.Enabled = false;
            btn_hienthi.Enabled = true;
            btn_Thoat.Enabled = true;
            btn_InBC.Enabled = false;
            btn_hienthi.Enabled = false;
        }

        private void btn_InBC_Click(object sender, EventArgs e)
        {
            if (txt_Nam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Nam.Focus();
                return;
            }
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook;
            COMExcel.Worksheet exSheet;
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable danhsach;

            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman";
            exRange.Range["A1:B3"].Font.Size = 11;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;//đặt màu cho chữ
            exRange.Range["A1:A1"].ColumnWidth = 10;//độ rộng cột
            exRange.Range["B1:B1"].ColumnWidth = 16;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop Audio";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Học viện Ngân Hàng";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (05)66666666";
            exRange.Range["C2:G2"].Font.Size = 16;
            exRange.Range["C2:G2"].Font.Bold = true;
            exRange.Range["C2:G2"].Font.ColorIndex = 3;
            exRange.Range["C2:G2"].MergeCells = true;
            exRange.Range["C2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:G2"].Value = "Báo cáo danh sách 5 nhà cung cấp theo năm";
            exRange.Range["D3:F3"].Font.Size = 14;
            exRange.Range["D3:F3"].Font.Bold = true;
            exRange.Range["D3:F3"].Font.ColorIndex = 3;
            exRange.Range["D3:F3"].MergeCells = true;
            exRange.Range["D3:F3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D3:F3"].Value = " Năm " + txt_Nam.Text;

            //sql = "select top(5)tblNhacungcap.MaNCC, TenNCC, DienThoai, DiaChi, count(tblHoadonnhap.MaNCC) from tblNhacungcap inner join tblHoadonnhap on tblNhacungcap.MaNCC=tblHoadonnhap.MaNCC" +
            //    "group by tblNhacungcap.MaNCC, TenNCC, DienThoai, DiaChi " +
            //    "order by count(tblHoadonnhap.MaNCC) desc" +
            //    "having year(NgayNhap)='" + txt_Nam.Text + "'";
             sql = "SELECT TOP (5) a.MaNCC,a.TenNCC,a.DienThoai,a.DiaChi, SUM(TongTien) from tblNhacungcap as a, tblHoadonnhap as b where a.MaNCC=b.MaNCC AND ((YEAR(b.NgayNhap) = '" + txt_Nam.Text + "')) GROUP BY a.MaNCC,a.TenNCC,a.DiaChi,a.DienThoai ORDER BY SUM(TongTien) desc";


            danhsach = Functions.GetDataToTable(sql);//đổ dữ liệu từ lệnh sql vào biến "danhsach"

            exRange.Range["B5:F5"].Font.Bold = true;//In đậm các chữ 
            exRange.Range["B5:F5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].ColumnWidth = 14;
            exRange.Range["C5:C5"].ColumnWidth = 15;
            exRange.Range["D5:D5"].ColumnWidth = 26;
            exRange.Range["E5:E5"].ColumnWidth = 26;
            exRange.Range["F5:F5"].ColumnWidth = 26;




            exRange.Range["E5:E5"].Font.Bold = true;
            exRange.Range["E5:E5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã nhà cung cấp";
            exRange.Range["D5:D5"].Value = "Tên nhà cung cấp";
            exRange.Range["E5:E5"].Value = "Điện thoại";
            exRange.Range["F5:F5"].Value = "Địa chỉ";
            exRange.Range["G5:G5"].Value = "Tổng tiền";


            for (hang = 0; hang < danhsach.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;//điền số thứ tự vào cột 2 bắt đầu từ hàng 6 (mở excel ra hình dung)
                for (cot = 0; cot < danhsach.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 6] = danhsach.Rows[hang][cot].ToString();//điền thông tin các cột còn lại từ dữ liệu đã đc đổ vào từ biến "danhsach" bắt đầu từ cột 3, hàng 6
                }
            }

            exRange = exSheet.Cells[2][hang + 8];//chỗ này là đánh dấu vị trí viết cái dòng "Hà Nội, ngày..."
            exRange.Range["D1:F1"].MergeCells = true;
            exRange.Range["D1:F1"].Font.Italic = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:F1"].Value = "Hà Nội, Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            exSheet.Name = "Báo cáo";
            exApp.Visible = true;
        }

        private void btn_Thongke_Click(object sender, EventArgs e)
        {
            if (txt_Nam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Nam.Focus();
                return;
            }
            
            string sql = "SELECT TOP (5) a.MaNCC,a.TenNCC,a.DienThoai,a.DiaChi, SUM(TongTien) from tblNhacungcap as a, tblHoadonnhap as b " +
                "where a.MaNCC=b.MaNCC AND ((YEAR(b.NgayNhap) = '" + txt_Nam.Text + "')) " +
                "GROUP BY a.MaNCC,a.TenNCC,a.DiaChi,a.DienThoai ORDER BY SUM(TongTien) desc";

            tblBCDSNCC = Functions.GetDataToTable(sql);
            dg_Top5NCC.DataSource = tblBCDSNCC;
            dg_Top5NCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dg_Top5NCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            dg_Top5NCC.Columns[2].HeaderText = "Điện thoại";
            dg_Top5NCC.Columns[3].HeaderText = "Địa chỉ";
            dg_Top5NCC.Columns[4].HeaderText = "Tổng tiền";
            dg_Top5NCC.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Top5NCC.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Top5NCC.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Top5NCC.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Top5NCC.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Top5NCC.AllowUserToAddRows = false;
            dg_Top5NCC.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void txt_Nam_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
