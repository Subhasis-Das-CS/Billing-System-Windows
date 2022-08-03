using Anystore.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anystore
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void lb_Click(object sender, EventArgs e)
        {

        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            lblLoggedInUser.Text = frmLogin.loggedIn;


        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();
        }

        private void frmAdminDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();

        }

        private void catagoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatagories catagory = new frmCatagories();
            catagory.Show();


        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts product = new frmProducts();
            product.Show();
        }

        private void dealerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeaCust dealer = new frmDeaCust();
            dealer.Show();

        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventory inventory = new frmInventory();
            inventory.Show();

            

        }

        private void transactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTransaction tran = new frmTransaction();
            tran.Show();

        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchaseAndSales frm = new frmPurchaseAndSales();
            frm.Show();

        }

        private void enterGSTINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGst gst = new frmGst();
            gst.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
