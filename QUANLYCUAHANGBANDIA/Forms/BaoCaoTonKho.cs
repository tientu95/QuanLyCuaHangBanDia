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
    public partial class frm_BCTonKho : Form
    {
        public frm_BCTonKho()
        {
            InitializeComponent();
        }
        DataTable tblBCHangton;


        private void BaoCaoTonKho_Load(object sender, EventArgs e)
        {
            
            cboQui.Enabled = false;
            txtNam.Enabled = false;
            btn_Baocao.Enabled = true;
            btn_Dong.Enabled = true;
            btn_InBC.Enabled = false;
            btn_Hienthi.Enabled = false;
            //Đổ 4 quí vào ComboBox
            cboQui.Items.Add("1");
            cboQui.Items.Add("2");
            cboQui.Items.Add("3");
            cboQui.Items.Add("4");
            
        }

        private void btn_Baocao_Click(object sender, EventArgs e)
        {
            cboQui.Enabled = true;
            txtNam.Enabled = true;
            btn_Hienthi.Enabled = true;
            txtNam.Text = "";
            cboQui.Text = "";
            cboQui.Focus();
            dg_Tonkho.DataSource = null;
        }

        private void btn_InBC_Click(object sender, EventArgs e)
        {
            if (txtNam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNam.Focus();
                return;
            }
            if (cboQui.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn quí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboQui.Focus();
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
            exRange.Range["A1:Z200"].Font.Name = "Times new roman";
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
            exRange.Range["A3:B3"].Value = "Điện thoại: (05) 66666666";
            exRange.Range["C2:G2"].Font.Size = 16;
            exRange.Range["C2:G2"].Font.Bold = true;
            exRange.Range["C2:G2"].Font.ColorIndex = 3;
            exRange.Range["C2:G2"].MergeCells = true;
            exRange.Range["C2:G2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:G2"].Value = "Báo cáo hàng không bán được theo quí";
            exRange.Range["D3:F3"].Font.Size = 14;
            exRange.Range["D3:F3"].Font.Bold = true;
            exRange.Range["D3:F3"].Font.ColorIndex = 3;
            exRange.Range["D3:F3"].MergeCells = true;
            exRange.Range["D3:F3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["D3:F3"].Value = "Quí " + cboQui.SelectedItem+ " Năm " + txtNam.Text; //In ra quí + năm báo cáo
            //sql = "select a.MaDia, a.TenDia, a.SoLuong from tblKhodia as a where a.MaDia not in (select tblKhodia.MaDia from tblKhodia join tblChitietHDB on tblKhodia.MaDia=tblChitietHDB.MaDia join tblHoadonban on tblChitietHDB.SoHDB=tblHoadonban.SoHDB where (datepart(QQ,NgayBan) = '" + cboQui.Text + "') AND (YEAR(NgayBan) = '" + txtNam.Text + "'))";
            sql = "select a.MaDia, a.TenDia, a.SoLuong from tblKhodia as a where a.MaDia not in (select tblChitietHDB.MaDia from tblChitietHDB join tblHoadonban on tblChitietHDB.SoHDB=tblHoadonban.SoHDB where (datepart(QQ,NgayBan) = '" + cboQui.Text + "') AND (YEAR(NgayBan) = '" + txtNam.Text + "'))";

            danhsach = Functions.GetDataToTable(sql);//đổ dữ liệu từ lệnh sql vào biến "danhsach"

            exRange.Range["B5:F5"].Font.Bold = true;//In đậm các chữ 
            exRange.Range["B5:F5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].ColumnWidth = 14;
            exRange.Range["C5:C5"].ColumnWidth = 13;
            exRange.Range["D5:D5"].ColumnWidth = 26;
            exRange.Range["E5:E5"].ColumnWidth = 26;
            exRange.Range["G9:G9"].ColumnWidth = 26;

            sql = "select Sum(Soluong) from tblKhodia as a where a.MaDia not in (select tblChitietHDB.MaDia " +
               "from tblChitietHDB join tblHoadonban on tblChitietHDB.SoHDB=tblHoadonban.SoHDB where " +
               "(datepart(QQ,NgayBan) = '" + cboQui.Text + "') AND (YEAR(NgayBan) = '" +
               txtNam.Text + "'))";
            string SL = Functions.GetFieldValues(sql);


            exRange.Range["E5:E5"].Font.Bold = true;
            exRange.Range["E5:E5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B5:B5"].Value = "STT";
            exRange.Range["C5:C5"].Value = "Mã đĩa";
            exRange.Range["D5:D5"].Value = "Tên đĩa";
            exRange.Range["E5:E5"].Value = "Số lượng tồn kho";

            //vòng lặp để đổ dữ liệu từ biến "danhsach" vào excel
            for (hang = 0; hang < danhsach.Rows.Count; hang++)
            {
                exSheet.Cells[2][hang + 6] = hang + 1;//điền số thứ tự vào cột 2 bắt đầu từ hàng 6 (mở excel ra hình dung)
                for (cot = 0; cot < danhsach.Columns.Count; cot++)
                {
                    exSheet.Cells[cot + 3][hang + 6] = danhsach.Rows[hang][cot].ToString();//điền thông tin các cột còn lại từ dữ liệu đã đc đổ vào từ biến "danhsach" bắt đầu từ cột 3, hàng 6
                }
            }


            exRange = exSheet.Cells[1][hang + 8];//chỗ này là đánh dấu vị trí viết cái dòng "Hà Nội, ngày..."
            exRange.Range["E1:G1"].MergeCells = true;
            exRange.Range["E1:G1"].Font.Italic = true;
            exRange.Range["E1:G1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["E1:G1"].Value = "Hà Nội, Ngà y " + DateTime.Now.Day + " tháng "+DateTime.Now.Month+" năm "+DateTime.Now.Year;
            exRange.Range["E2:E2"].Value = "Tổng số lượng";
            exRange.Range["F2:F2"].Value = SL;
            exSheet.Name = "Báo cáo";           
            exApp.Visible = true;
        }

        private void cboQui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btn_Hienthi_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboQui.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn quí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboQui.Focus();
                return;
            }
            if (txtNam.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNam.Focus();
                return;
            }
            
             sql = "select a.MaDia, a.TenDia, a.SoLuong from tblKhodia as a where a.MaDia not in (select tblChitietHDB.MaDia " +
                "from tblChitietHDB join tblHoadonban on tblChitietHDB.SoHDB=tblHoadonban.SoHDB where " +
                "(datepart(QQ,NgayBan) = '" + cboQui.Text + "') AND (YEAR(NgayBan) = '" + 
                txtNam.Text + "'))" ;

            tblBCHangton = Functions.GetDataToTable(sql);
            dg_Tonkho.DataSource = tblBCHangton;
            dg_Tonkho.Columns[0].HeaderText = "Mã đĩa"; 
            dg_Tonkho.Columns[1].HeaderText = "Tên đĩa";
            dg_Tonkho.Columns[2].HeaderText = "Số lượng tồn kho";
            //Chiều rộng cột phù hợp với nội dung tất cả các ô kể cả tiêu đề

            dg_Tonkho.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Tonkho.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dg_Tonkho.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dg_Tonkho.AllowUserToAddRows = false;
            dg_Tonkho.EditMode = DataGridViewEditMode.EditProgrammatically;
            
            cboQui.Enabled = false;
            txtNam.Enabled = false;
            btn_Baocao.Enabled = true;
            btn_InBC.Enabled = true;
            btn_Hienthi.Enabled = false;
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đóng mục này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
