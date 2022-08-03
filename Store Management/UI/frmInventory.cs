using Anystore.DAL;
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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }
        ProductsDAL pdal = new ProductsDAL();

        private void frmInventory_Load(object sender, EventArgs e)
        {

            DataTable pdt = pdal.Select();
           
            dgvShowProducts.DataSource = pdt;
            dgvShowProducts.Sort(dgvShowProducts.Columns["added_date"], System.ComponentModel.ListSortDirection.Ascending);
            dgvShowProducts.Refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                DataTable DT = pdal.Search(keywords);
                dgvShowProducts.DataSource = DT;
            }
            else
            {
                DataTable dt = pdal.Select();
                dgvShowProducts.DataSource = dt;
            }
        }

        private void dgvShowProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
