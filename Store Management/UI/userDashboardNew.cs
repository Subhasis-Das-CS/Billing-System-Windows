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
    public partial class userDashboardNew : Form
    {
        public userDashboardNew()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmInventory openuser = new frmInventory();

            openuser.TopLevel = false;
            openuser.AutoScroll = true;

            panel1.Controls.Add(openuser);
            openuser.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Close();
            userDashboardNew newww = new userDashboardNew();

            newww.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPurchaseAndSales openuser = new frmPurchaseAndSales();


            openuser.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("hh:mm:ss");
            date.Text = DateTime.Today.ToString("dd / MM / yyyy");
        }
    }
}
