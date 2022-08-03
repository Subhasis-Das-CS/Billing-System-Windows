using Anystore.BLL;
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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        catagoriesDAL cdal = new catagoriesDAL();
        ProductsBll p = new ProductsBll();
        ProductsDAL pdal = new ProductsDAL();


        private void frmProducts_Load(object sender, EventArgs e)
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //Crate table to hold catagories

            DataTable catagoriesdt = cdal.Select();
            cnbCatagory.DataSource = catagoriesdt;
            cnbCatagory.DisplayMember = "title";
            cnbCatagory.ValueMember = "title";
            DataTable dt = pdal.Select();
            dgvProducts.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            p.id = long.Parse(txtId.Text);
            p.name = txtName.Text;
            p.catagory = cnbCatagory.Text;


            p.description= txtDescription.Text;
            p.rate = decimal.Parse(txtRate.Text);
            p.qty = decimal.Parse(txtQty.Text);
            p.added_date = DateTime.Now;


            bool success = pdal.Insert(p);

            if (success==true)
            {
                Clear();
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;
            }
            else
            {

            }
          


        }

        public void Clear()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtDescription.Text = "0";
            txtRate.Text = "";
            txtQty.Text = "0";
            cnbCatagory.Text = "0";
            







        }

        private void dgvProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            txtId.Text = dgvProducts.Rows[rowIndex].Cells[0].Value.ToString();

            txtName.Text = dgvProducts.Rows[rowIndex].Cells[1].Value.ToString();

            cnbCatagory.Text = dgvProducts.Rows[rowIndex].Cells[2].Value.ToString();

            txtDescription.Text = dgvProducts.Rows[rowIndex].Cells[3].Value.ToString();

            txtRate.Text = dgvProducts.Rows[rowIndex].Cells[4].Value.ToString();

            txtQty.Text = dgvProducts.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the Values from UI or Product Form
            p.id = Int64.Parse(txtId.Text);
            p.name = txtName.Text;
            p.catagory = cnbCatagory.Text;
            p.description = txtDescription.Text;
            p.rate = decimal.Parse(txtRate.Text);
            p.added_date = DateTime.Now;
            p.qty = decimal.Parse(txtQty.Text);
            //Getting Username of logged in user for added by
            String loggedUsr = frmLogin.loggedIn;
           // userBLL usr = udal.GetIDFromUsername(loggedUsr);

          //  p.added_by = usr.id;

            //Create a boolean variable to check if the product is updated or not
            bool success = pdal.Update(p);
            //If the prouct is updated successfully then the value of success will be true else it will be false
            if (success == true)
            {
                //Product updated Successfully
                MessageBox.Show("Product Successfully Updated");
                Clear();
                //REfresh the Data Grid View
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;
            }
            else
            {
                //Failed to Update Product
                MessageBox.Show("Failed to Update Product");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            p.id = Int64.Parse(txtId.Text);

            bool success = pdal.Delete(p);

            if (success == true)
            {
                MessageBox.Show("Product Deleted");
                Clear();

                cnbCatagory.Text = "";
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Product Deletion Failed");
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                DataTable DT = pdal.Search(keywords);
                dgvProducts.DataSource = DT;
            }
            else
            {
                DataTable dt = pdal.Select();
                dgvProducts.DataSource = dt;
            }

        }
    }



}
