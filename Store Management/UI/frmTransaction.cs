using Anystore.BLL;
using Anystore.DAL;
using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anystore.UI
{
    public partial class frmTransaction : Form
    {
        public frmTransaction()
        {
            InitializeComponent();
        }
        transactionDetailDAL tdddal = new transactionDetailDAL();
        gstinDAL gdal = new gstinDAL();
        decimal tt;

        DataTable datatable = new DataTable();


        private void frmTransaction_Load(object sender, EventArgs e)
        {
            DataTable dt = tdddal.Select();
            dgcShowTransaction.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool successs = tdddal.Delete();

            if (successs == true)
            {
                MessageBox.Show("Data Deleted");

                DataTable dt = tdddal.Select();
                dgcShowTransaction.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Data Not Deleted");
            }




        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            int ab = 1;
            gstinBll g = gdal.GetProductIDFromName(ab);
            string name = g.name;
            printer.Title = name;
            //   printer.SubTitle = "Ayurvedic Kendra ";
            //   printer.SubTitle = "Shyamnagar";
            //  printer.SubTitle = "b";
            // printer.SubTitle = "8335898966/ 9230123937";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;


            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            //printer.SubTitle = "Ayurvedic Kendra  \r\n Shyamnagar  \r\n Transaction Detail";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgcShowTransaction);

        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < datatable.Rows.Count; i++)
            {

                tt = tt + decimal.Parse(datatable.Rows[i][4].ToString());
                ShowTotal.Text = tt.ToString();
                
            }
            tt = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keywords = dateTimePick.Text;


            if (keywords != null)
            {
                //show user based on keywords
                datatable = tdddal.Search(keywords);
                dgcShowTransaction.Sort(dgcShowTransaction.Columns["added_date"], System.ComponentModel.ListSortDirection.Ascending);
                dgcShowTransaction.DataSource = datatable;


              

            }
            else
            {
                DataTable dt = tdddal.Select();
                dgcShowTransaction.DataSource = dt;
                //show all users

                ShowTotal.Text = "";
                tt = 0;

            }
        }

        private void dgcShowTransaction_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

