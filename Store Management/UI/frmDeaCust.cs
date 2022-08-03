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
    public partial class frmDeaCust : Form
    {
        public frmDeaCust()
        {
            InitializeComponent();
        }
        DeaCustBll dc = new DeaCustBll();
        DeaCustDAL dcdal = new DeaCustDAL();
        userDAL udal = new userDAL();


        private void btnAdd_Click(object sender, EventArgs e)
        {
            dc.id = txtDeaCustID.Text;
            dc.type = cnbDeaCustType.Text;
            dc.name = txtName.Text;
            dc.email = txtEmail.Text;
            dc.contact = txtContact.Text;
            dc.address = txtAddress.Text;
            dc.added_date = DateTime.Now;

            bool success = dcdal.Insert(dc);

            if (success == true)
            {
                MessageBox.Show("Dealer/Customer Added Successfully");
                Clear();

                DataTable dt = dcdal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Dealer/Customer Not Added");
            }

        }

        public void Clear()
        {

            txtDeaCustID.Text = "";
           cnbDeaCustType.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            
        }

        private void frmDeaCust_Load(object sender, EventArgs e)
        {
            DataTable dt = dcdal.Select();
            dgvDeaCust.DataSource = dt;
        }

        private void dgvDeaCust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int rowIndex = e.RowIndex;

            txtDeaCustID.Text = dgvDeaCust.Rows[rowIndex].Cells[0].Value.ToString();
            cnbDeaCustType.Text = dgvDeaCust.Rows[rowIndex].Cells[1].Value.ToString();
            txtName.Text = dgvDeaCust.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvDeaCust.Rows[rowIndex].Cells[3].Value.ToString();
            txtContact.Text = dgvDeaCust.Rows[rowIndex].Cells[4].Value.ToString();
            txtAddress.Text = dgvDeaCust.Rows[rowIndex].Cells[5].Value.ToString();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            dc.id = txtDeaCustID.Text;
            dc.type = cnbDeaCustType.Text;
            dc.name = txtName.Text;
            dc.email = txtEmail.Text;
            dc.contact = txtContact.Text;
            dc.address = txtAddress.Text;
            dc.added_date = DateTime.Now;

            bool success = dcdal.Update(dc);

            if (success == true)
            {
                MessageBox.Show("Dealer/Customer Updated Successfully");
                Clear();

                DataTable dt = dcdal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Dealer/Customer Not Updated");
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dc.id = txtDeaCustID.Text;

            bool success = dcdal.Delete(dc);
            if (success == true)
            {
                MessageBox.Show("Dealer/Customer Deleted Successfully");
                Clear();

                DataTable dt = dcdal.Select();
                dgvDeaCust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Dealer/Customer Not Deleted");
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                DataTable dt = dcdal.Search(keywords);
                dgvDeaCust.DataSource = dt;

            }
            else
            {
                DataTable dt = dcdal.Select();
                dgvDeaCust.DataSource = dt;


            }

        }
    }
}
