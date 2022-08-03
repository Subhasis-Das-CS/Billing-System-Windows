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
    public partial class frmGst : Form
    {
        public frmGst()
        {
            InitializeComponent();
        }

        gstinBll b = new gstinBll();
        gstinDAL d = new gstinDAL();



        private void btnAdd_Click(object sender, EventArgs e)
        {
            b.id = 1;
            b.gstin = txtGst.Text;
            b.phone = enterPhone.Text;
            b.name = enterName.Text;
            b.tagline = enterTag.Text;
            b.address = enterAddress.Text;
            b.website = enterWeb.Text;


            bool success = d.Insert(b);

            if (success == true)
            {
                MessageBox.Show("Data Inserted");
                

                //refresh Datagrid View
                DataTable dt = d.Select();
                dgvGst.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Data Not Inserted");
            }



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            b.gstin = txtGst.Text;
            b.phone = enterPhone.Text;
            b.id = 1;
            b.name = enterName.Text;
            b.tagline = enterTag.Text;
            b.address = enterAddress.Text;
            b.website = enterWeb.Text;
            bool success = d.Update(b);

            if (success == true)
            {
                MessageBox.Show("GSTIN Updated");


                //refresh Datagrid View
                DataTable dt = d.Select();
                dgvGst.DataSource = dt;

            }
            else
            {
                MessageBox.Show("GSTIN Not Updated");
            }





        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool successs = d.Delete();

            if (successs == true)
            {
                MessageBox.Show("Data Deleted");

                DataTable dt = d.Select();
                dgvGst.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Data Not Deleted");
            }

        }

        private void frmGst_Load(object sender, EventArgs e)
        {
            //refresh Datagrid View
            DataTable dt = d.Select();
            dgvGst.DataSource = dt;
        }

        private void txtGst_TextChanged(object sender, EventArgs e)
        {

        }

        private void enterPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

