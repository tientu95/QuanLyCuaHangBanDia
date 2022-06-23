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
    public partial class BaoCaoHoaDonNhap : Form
    {
        public BaoCaoHoaDonNhap()
        {
            InitializeComponent();
        }
        DataTable tblBCHDN;


        private void BaoCaoHoaDonNhap_Load(object sender, EventArgs e)
        {

        }
        private void frmBaocaohdn_Load(object sender, EventArgs e)
        {
            ResetValues();
            dg_Baocaohdn.DataSource = null;
            cbo_Thang.Items.Add("1");
            cbo_Thang.Items.Add("2");
            cbo_Thang.Items.Add("3");
            cbo_Thang.Items.Add("4");
            cbo_Thang.Items.Add("5");
            cbo_Thang.Items.Add("6");
            cbo_Thang.Items.Add("7");
            cbo_Thang.Items.Add("8");
            cbo_Thang.Items.Add("9");
            cbo_Thang.Items.Add("10");
            cbo_Thang.Items.Add("11");
            cbo_Thang.Items.Add("12");
        }

        private void ResetValues()
        {
            cbo_Thang.Text = "";
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txt_Nam.Focus();
        }

        private void btn_Hienthi_Click(object sender, EventArgs e)
        {
            string sql, sql1;
            if ((cbo_Thang.Text == "") && (txt_Nam.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yeu cau ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //sql = "SELECT tblhoadonnhap.sohdn,manv,mancc,madia,soluong,ngaynhap,dongianhap,thanhtien FROM tblHoadonnhap join tblChitietHDN on tblHoadonnhap.sohdn=tblChitietHDN.sohdn WHERE 1=1 ";
            //sql = "SELECT a.sohdn, a.manv, c.tenncc, b.madia, b.soluong, a.ngaynhap, b.dongianhap, b.thanhtien FROM tblHoadonnhap AS a, tblChitietHDN AS b, tblNhacungcap AS c WHERE MONTH(Ngaynhap) = '" + cbo_Thang.Text + "' AND a.sohdn = b.sohdn AND a.mancc =c.mancc ";
            sql = "SELECT a.sohdn, a.manv, c.tenncc, b.madia, b.soluong, a.ngaynhap, b.dongia, b.thanhtien " +
                "FROM tblHoadonnhap AS a, tblChitietHDN AS b, " +
                "tblNhacungcap AS c WHERE  a.sohdn = b.sohdn AND a.mancc =c.mancc ";

            if (cbo_Thang.Text != "")
                sql = sql + " AND MONTH(a.Ngaynhap) =" + cbo_Thang.Text;
            if (txt_Nam.Text != "")
                sql = sql + " AND YEAR(a.Ngaynhap) =" + txt_Nam.Text;

            tblBCHDN = Class.Functions.GetDataToTable(sql);
            if (tblBCHDN.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetValues();
            }
            else
                MessageBox.Show("Có " + tblBCHDN.Rows.Count + " bản ghi thỏa mãn điều kiện!!!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            dg_Baocaohdn.DataSource = tblBCHDN;

            sql1 = "select Sum(Tongtien) from tblHoadonnhap where  ((YEAR(Ngaynhap) = '" + txt_Nam.Text + "')" +
                " AND (MONTH(Ngaynhap) = '" + cbo_Thang.Text + "')) ";
            txt_Tongtiennhap.Text = Class.Functions.GetFieldValues(sql1);
            Load_DataGridView();
        }

        private void Load_DataGridView()
        {
            dg_Baocaohdn.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dg_Baocaohdn.Columns[1].HeaderText = "Mã nhân viên";
            dg_Baocaohdn.Columns[2].HeaderText = "Mã nhà cung cấp";
            dg_Baocaohdn.Columns[3].HeaderText = "Mã đĩa";
            dg_Baocaohdn.Columns[4].HeaderText = "Số lượng";
            dg_Baocaohdn.Columns[5].HeaderText = "Ngày nhập";
            dg_Baocaohdn.Columns[6].HeaderText = "Đơn giá nhập";
            dg_Baocaohdn.Columns[7].HeaderText = "Thành tiền";
            //Chiều rộng cột phù hợp với nội dung tất cả các ô kể cả tiêu đề

            dg_Baocaohdn.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Baocaohdn.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Baocaohdn.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Baocaohdn.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Baocaohdn.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Baocaohdn.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Baocaohdn.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Baocaohdn.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Baocaohdn.AllowUserToAddRows = false;
            dg_Baocaohdn.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void btn_Timlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dg_Baocaohdn.DataSource = null;
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btn_In_Click(object sender, EventArgs e)
        {
            if (cbo_Thang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_Thang.Focus();
                return;
            }
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
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5;
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
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 666666666";
            exRange.Range["C2:G2"].Font.Size = 16;
            exRange.Range["C2:G2"].Font.Bold = true;
            exRange.Range["C2:G2"].Font.ColorIndex = 3;
            exRange.Range["C2:G2"].MergeCells = true;
            exRange.Range["C2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:G2"].Value = "Báo cáo nhập hàng tháng " + cbo_Thang.Text + " năm " + txt_Nam.Text;
            exRange.Range["C4:C4"].Font.Bold = true;
            exRange.Range["C4:D4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;

            string sql1;
            //sql1 = "select Sum(Tongtien) from tblHoadonnhap where  ((YEAR(Ngaynhap) = '" + txt_Nam.Text + "') AND (datepart(QQ,Ngaynhap) = '" + cbo_Thang.Text + "')) group by datepart(QQ,Ngaynhap)";
            sql1 = "select Sum(Tongtien) from tblHoadonnhap where  ((YEAR(Ngaynhap) = '" + txt_Nam.Text + "') AND (MONTH(Ngaynhap) = '" + cbo_Thang.Text + "')) ";

            string s = Class.Functions.GetFieldValues(sql1);
            exRange.Range["C4:C4"].Value = "Tổng tiền hàng nhập kho : ";
            exRange.Range["D4:D4"].Value = s;
            sql = "select * from tblHoadonnhap  where (MONTH(Ngaynhap) = '" + cbo_Thang.Text + "') AND (YEAR(Ngaynhap) = '" + txt_Nam.Text + "')";

            //sql = "select * from tblHoadonnhap  where (datepart(QQ,Ngaynhap) = '" + cbo_Thang.Text + "') AND (YEAR(Ngaynhap) = '" + txt_Nam.Text + "')";
            danhsach = Class.Functions.GetDataToTable(sql);

            exRange.Range["B5:J5"].Font.Bold = true;
            exRange.Range["B5:J5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].ColumnWidth = 12;
            exRange.Range["C5:C5"].ColumnWidth = 20;
            exRange.Range["D5:D5"].ColumnWidth = 12;
            exRange.Range["E5:E5"].ColumnWidth = 30;
            exRange.Range["F5:F5"].ColumnWidth = 11;
            exRange.Range["G5:G5"].ColumnWidth = 11;
            exRange.Range["H5:H5"].ColumnWidth = 12;
            exRange.Range["I5:I5"].ColumnWidth = 12;
            exRange.Range["J5:J5"].ColumnWidth = 12;

            sql = "SELECT a.sohdn, a.manv, c.tenncc, b.madia, b.soluong, a.ngaynhap, b.dongia, b.thanhtien FROM tblHoadonnhap AS a, tblChitietHDN AS b, tblNhacungcap AS c WHERE MONTH(Ngaynhap) = '" + cbo_Thang.Text + "' AND a.sohdn = b.sohdn AND a.mancc =c.mancc";
            danhsach = Class.Functions.GetDataToTable(sql);

            exRange.Range["E5:E5"].Font.Bold = true;
            exRange.Range["E5:E5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã hóa đơn nhập";
            exRange.Range["D5:D5"].Value = "Mã nhân viên";
            exRange.Range["E5:E5"].Value = "Mã NCC";
            exRange.Range["F5:F5"].Value = "Mã đĩa";
            exRange.Range["G5:G5"].Value = "Số lượng";
            exRange.Range["H5:H5"].Value = "Ngày nhập";
            exRange.Range["I5:I5"].Value = "Đơn giá nhập";
            exRange.Range["J5:J5"].Value = "Thành tiền";


            for (hang = 0; hang < danhsach.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;
                for (cot = 0; cot < danhsach.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 6] = danhsach.Rows[hang][cot].ToString();
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
    }
}
