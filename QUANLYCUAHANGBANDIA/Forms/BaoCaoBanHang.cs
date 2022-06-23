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
    public partial class BaoCaoBanHang : Form
    {
        public BaoCaoBanHang()
        {
            InitializeComponent();
        }
        DataTable tblHoadonban;
        private void BaoCaoBanHang_Load(object sender, EventArgs e)
        {
            
            txtDiachi.Enabled = false;
            txtDienthoai.Enabled = false;
            txtTenkhach.Enabled = false;
            txtTongtienmua.Enabled = false;

            //btnHienthi.Enabled = false;

            btn_In.Enabled = false;
            ResetValues();
            dg_HDBan.DataSource = null;

            Functions.FillCombo("SELECT MaKhach, TenKhach FROM tblKhachhang", cboMaKhach, "MaKhach", "MaKhach");
            cboMaKhach.SelectedIndex = -1;
           
        }
        private void Load_DataGridView()
        {


            dg_HDBan.Columns[0].HeaderText = "Mã hóa đơn";
            dg_HDBan.Columns[1].HeaderText = "Mã nhân viên";
            dg_HDBan.Columns[2].HeaderText = "Ngày bán";
            dg_HDBan.Columns[3].HeaderText = "Mã Khách";
            dg_HDBan.Columns[4].HeaderText = "Thành tiền";
            dg_HDBan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_HDBan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_HDBan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_HDBan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_HDBan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dg_HDBan.AllowUserToAddRows = false;
            dg_HDBan.EditMode = DataGridViewEditMode.EditProgrammatically;

            
        }
        private void ResetValues()
        {
            txtDiachi.Text = "";
            txtDienthoai.Text = "";
            txtTenkhach.Text = "";
            cboMaKhach.Text = "";
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            
            if (cboMaKhach.Text == "")
            {
                MessageBox.Show("Hãy chọn mã khách hàng cần tìm kiếm!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql;
            //sql = "SELECT SoHDB,tennv,NgayBan,tenKhach,TongTien FROM" +
            //    " tblHoadonban WHERE tblHoadonban.MaKhach = N'" + cboMaKhach.SelectedValue + "'";
            sql = "SELECT SoHDB,tblNhanvien.TenNV,NgayBan,tblKhachhang.TenKhach,TongTien " +
                "FROM tblHoadonban join tblNhanvien on tblHoadonban.MaNV = tblNhanvien.MaNV " +
                "join tblKhachhang on tblHoadonban.MaKhach = tblKhachhang.MaKhach" +
                "WHERE tblHoadonban.MaKhach = N'" + cboMaKhach.SelectedValue + "'";
            tblHoadonban = Class.Functions.GetDataToTable(sql);
            

            if (tblHoadonban.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblHoadonban.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            dg_HDBan.DataSource = tblHoadonban;

            btn_In.Enabled = true;
            btnHienthi.Enabled = true;
            //cboMaKhach.SelectedIndex = -1;
            string sql1;
            sql1 = "select Sum(TongTien) from tblHoadonban where tblHoadonban.MaKhach = N'" + cboMaKhach.Text + "'";
            txtTongtienmua.Text = Functions.GetFieldValues(sql1);
            Load_DataGridView();       
        }

        private void cboMaKhach_TextChanged(object sender, EventArgs e)
        {
           
            string str;
            if (cboMaKhach.Text == "")
            {
                txtDiachi.Text = "";
                txtDienthoai.Text = "";
                txtTenkhach.Text = "";
            }
            //btnHienthi.Enabled = true;
            // Khi kich chon Ma hang thi ten hang va gia ban se tu dong hien ra
            str = "Select Tenkhach from tblKhachhang where Makhach = N'" + cboMaKhach.SelectedValue + "'";
            txtTenkhach.Text = Class.Functions.GetFieldValues(str);
            str = "Select Diachi from tblKhachhang where Makhach = N'" + cboMaKhach.SelectedValue + "'";
            txtDiachi.Text = Class.Functions.GetFieldValues(str);
            str = "Select Dienthoai from tblKhachhang where Makhach= N'" + cboMaKhach.SelectedValue + "'";
            txtDienthoai.Text = Class.Functions.GetFieldValues(str);
            txtTongtienmua.Text = "";
            
        }

        private void btn_In_Click(object sender, EventArgs e)
        {

           
            //    sql = "SELECT MaHDB,MaNV,NgayBan,MaKhach,TongTien FROM tblHoadonban " +
            //        "WHERE tblHoadonban.MaKhach = N'" + cboMaKhach.SelectedValue + "'";


            //    sql = "SELECT MaKhach,TenKhach,DienThoai,DiaChi FROM tblKhachhang WHERE tblKhachhang.MaKhach = N'" + cboMaKhach.SelectedValue + "'";
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql, sql1;
            int hang = 0, cot = 0;
            DataTable  DS;
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
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 6666666";


            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Name = "Times new roman";
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán


            sql = "SELECT SoHDB,manv,ngayban,tblhoadonban.makhach,tongtien FROM tblhoadonban join tblkhachhang on tblhoadonban.makhach=tblkhachhang.makhach where tblhoadonban.makhach=N'" + cboMaKhach.Text + "'";
            sql1 = "SELECT Sum(TongTien) from tblHoadonban join tblKhachhang on tblHoadonban.makhach = tblKhachhang.makhach where tblhoadonban.makhach=N'" + cboMaKhach.Text + "'";

            DS = Functions.GetDataToTable(sql);
            
            string TT = Functions.GetFieldValues(sql1);
            //string TT = Functions.GetFieldValues(sql1);
            exRange.Range["B5:G5"].Font.Bold = true;
            exRange.Range["B5:J5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].ColumnWidth = 12;
            exRange.Range["C5:C5"].ColumnWidth = 20;
            exRange.Range["D5:D5"].ColumnWidth = 12;
            exRange.Range["E5:E5"].ColumnWidth = 22;
            exRange.Range["F5:F5"].ColumnWidth = 11;
            exRange.Range["G5:G5"].ColumnWidth = 11;
            

            exRange.Range["C4:C4"].Font.Bold = true;
            exRange.Range["C4:C4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            

            exRange.Range["E5:E5"].Font.Bold = true;
            exRange.Range["E5:E5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã hóa đơn";
            exRange.Range["D5:D5"].Value = "Mã nhân viên";
            exRange.Range["E5:E5"].Value = "Ngày bán";
            exRange.Range["F5:F5"].Value = "Mã Khách";
            exRange.Range["G5:G5"].Value = "Thành tiền";
            exRange.Range["C4:C4"].Value = "Tổng tiền";
            exRange.Range["D4:D4"].Value = TT;


            for (hang = 0; hang < DS.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;
                for (cot = 0; cot < DS.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 6] = DS.Rows[hang][cot].ToString();
                }
            }


            //exRange = exSheet.Cells[2][hang + 8];
            
            exRange.Range["D1:F1"].MergeCells = true;
            exRange.Range["D1:F1"].Font.Italic = true;
            exRange.Range["D1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D1:F1"].Value = "Hà Nội, Ngày " + DateTime.Now.ToShortDateString();
            exSheet.Name = "Báo cáo";
            exApp.Visible = true;
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn đóng mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnTimlai_Click(object sender, EventArgs e)
        {
            
            ResetValues();
            dg_HDBan.DataSource = null;
        }
    }
}
