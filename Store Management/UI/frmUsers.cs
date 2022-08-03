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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        userBll u = new userBll();
        userDAL dal = new userDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //getting data from ui
            u.id = txtUserId.Text;
            u.first_name = txtFIrstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cnbGender.Text;
            u.user_type = cnbUserType.Text;
            u.added_date = DateTime.Now;
            //getting username
           // string loggedUser = frmLogin.loggedIn;
          //  userBll usr = dal.getIdFromUsername(loggedUser);

          //  u.added_by = usr.id;

            //insert data into database

            bool success = dal.Insert(u);

            if (success == true)
            {
                MessageBox.Show("User Successfully Created");
                clear();
            }
            else
            {
                MessageBox.Show("User Creation Failed");
            }

            //Refresh data frid view
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }
        private void clear()
        {
            txtUserId.Text = "";
            txtFIrstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cnbGender.Text = "";
            cnbUserType.Text = "";

        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get index of particular row
            int rowIndex = e.RowIndex;
            txtUserId.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFIrstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cnbGender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            cnbUserType.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //getting username
            
            u.id = txtUserId.Text;
            u.first_name = txtFIrstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cnbGender.Text;
            u.user_type = cnbUserType.Text;
            u.added_date = DateTime.Now;

            //getting username
          //  string loggedUser = frmLogin.loggedIn;
           // userBll usr = dal.getIdFromUsername(loggedUser);

     
           // u.added_by = usr.id;



            bool successs = dal.Update(u);
            // if data is updated then value will be true

            if (successs == true)
            {
                MessageBox.Show("User Successfully Updated");
                clear();
            }
            else
            {
                MessageBox.Show("User Updation Failed");
            }
            //Refresh data frid view
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //getting user from Form

            u.id = txtUserId.Text;
            bool successss = dal.Delete(u);

            if (successss == true)
            {
                MessageBox.Show("User Deleted");
                clear();
            }
            else
            {
                MessageBox.Show("User Not Deleted");
            }
            //Refresh data frid view
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //get keyword from textbox

            string keywords = txtSearch.Text;

            if (keywords != null)
            {
                //show user based on keywords
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;

            }
            else
            {
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;
                //show all users
            }
        }
    }
    }

