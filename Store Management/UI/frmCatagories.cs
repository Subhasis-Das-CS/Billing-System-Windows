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
    public partial class frmCatagories : Form
    {
        public frmCatagories()
        {
            InitializeComponent();
        }

        catagoriesBll c = new catagoriesBll();
        catagoriesDAL dal = new catagoriesDAL();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //get values from ui
            c.id = txtCatagoryId.Text;
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;


            //insert data

            bool success = dal.Insert(c);

            if (success==true)
            {
                MessageBox.Show("New Catagory Inserted");
                Clear();

                //refresh Datagrid View
                DataTable dt = dal.Select();
                dgvCatagories.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Catagory Not Inserted");
            }



        }


        public void Clear()
        {
            txtCatagoryId.Text = "";
            txtDescription.Text = "";
            txtTitle.Text = "";
            txtSearch.Text = "";
        }

        private void frmCatagories_Load(object sender, EventArgs e)
        {
            //Display all added catagories

            DataTable dt = dal.Select();
            dgvCatagories.DataSource = dt;

        }

        private void dgvCatagories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RowIndex = e.RowIndex;
            txtCatagoryId.Text = dgvCatagories.Rows[RowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvCatagories.Rows[RowIndex].Cells[1].Value.ToString();
            txtDescription.Text = dgvCatagories.Rows[RowIndex].Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            c.id = txtCatagoryId.Text;
            c.title = txtTitle.Text;
            c.description = txtDescription.Text;
            c.added_date = DateTime.Now;

            // Boolean to check update 
            bool success = dal.Update(c);

            if (success==true)
            {
                MessageBox.Show("Catagory Updated");
                Clear();
                DataTable dt = dal.Select();
                dgvCatagories.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Catagory Updation Failed, ID can not be changed");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get id of catagory

            c.id = txtCatagoryId.Text;

            bool success = dal.Delete(c);

            if (success == true)
            {
                MessageBox.Show("Catagory Deleted");
                Clear();
                DataTable dt = dal.Select();
                dgvCatagories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Catagory Not Deleted");
              
            }


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                DataTable DT = dal.Search(keywords);
                dgvCatagories.DataSource = DT;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvCatagories.DataSource = dt;
            }
        }
    }
}
