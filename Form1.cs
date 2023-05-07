using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using ClosedXML.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsFromDB_dotnet_4._7._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnnew_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(false);
            if(f2.ShowDialog() == DialogResult.OK) GridRefresh(dgv);
        }
        private void GridRefresh(DataGridView grid)
        {
            grid.DataSource = null;
            ClearBoxes();
            try
            {
                grid.DataSource = DBcontroller.GetContacts(chkdel.Checked);
                dgv.Columns[3].Visible = false;
                dgv.Columns[4].Visible = false;
                ColorDeletedRows();
        }
            catch
            {
                MessageBox.Show("Could not fetch data from server, a potential network error has occured" + "\n" + "Make sure the DB server is running and try again.");
                Application.Exit();
                this.Dispose();
            }
        }
        private void ClearBoxes()
        {
            txtid2.Text = String.Empty;
            txtname2.Text = String.Empty;
            txtnumber2.Text = String.Empty;
            if (pbform1.Image != null)
            {
                pbform1.Image.Dispose();
                pbform1.Image = null;
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                ClearBoxes();
                txtid2.Text = dgv.CurrentRow.Cells[0].Value.ToString();
                txtname2.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                txtnumber2.Text = dgv.CurrentRow.Cells[2].Value.ToString();
                byte[] binImage = ((System.Data.Linq.Binary)dgv.CurrentRow.Cells[3].Value).ToArray();
                using (var ms = new MemoryStream(binImage))
                {
                    pbform1.Image = Image.FromStream(ms);
                }
                btndel.Enabled = true;
                btnedit.Enabled = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GridRefresh(dgv);
        }
        private void btndel_Click(object sender, EventArgs e)
        {
            DBcontroller.DeleteRecord(int.Parse(txtid2.Text));
            dgv.ClearSelection();
            GridRefresh(dgv);
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(txtid2.Text, txtname2.Text, txtnumber2.Text, pbform1.Image, true, false,"Edit Contact");           
            if(f2.ShowDialog() == DialogResult.OK)
            {
                GridRefresh(dgv);
            }
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            FindAndFill();
        }

        private void chkdel_CheckedChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text == "") GridRefresh(dgv);
            else FindAndFill();

        }
        private void FindAndFill()
        {
            ClearBoxes();
            try
            {
                dgv.DataSource = DBcontroller.search(txtsearch.Text, chkdel.Checked);
                dgv.Columns[3].Visible = false;
                dgv.Columns[4].Visible = false;
                ColorDeletedRows();
            }
            catch
            {
                MessageBox.Show("Could not fetch data from server, a potential network error has occured" + "\n" + "Make sure the DB server is running and try again.");
                this.Dispose();
            }
        }
        private void ColorDeletedRows()
        {
            foreach(DataGridViewRow row in dgv.Rows)
            {
                if ((bool)row.Cells[4].Value == true) row.DefaultCellStyle.BackColor = Color.Red;
            }
        }
        private void btnexport_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            string ExportPath = GetDownloadFolderPath();
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)dgv.DataSource;
                wb.Worksheets.Add(dt, "WorksheetName");
                wb.SaveAs(ExportPath + @"\ContactsData.xlsx");
                dt.Dispose();
                MessageBox.Show("Excel file saved in : " + ExportPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during saving the excel file : " + "\n" + ex.ToString());
            }
            wb.Dispose();
        }
        public string GetDownloadFolderPath()
        {
            return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
        }
    }
}