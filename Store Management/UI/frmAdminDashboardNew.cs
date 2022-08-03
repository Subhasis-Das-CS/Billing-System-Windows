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
using System.Windows.Forms.DataVisualization.Charting;

namespace Anystore.UI
{
    public partial class frmAdminDashboardNew : Form
    {
        public frmAdminDashboardNew()
        {
            InitializeComponent();
        }
        transactionDetailDAL tdddal = new transactionDetailDAL();
        DataTable datatable = new DataTable();
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void frmAdminDashboardNew_Load(object sender, EventArgs e)
        {
            timer1.Start();
           

            List<Color> colors = new List<Color> { Color.Green, Color.Red, Color.Purple };
            
            datatable = tdddal.Select();

            chart1.DataSource = datatable;
            chart1.Series["Series1"].XValueMember="Rate";
            chart1.Series["Series1"].YValueMembers = "qty";
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.Series["Series1"].IsValueShownAsLabel = true;

            chart1.DataBind();




        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmUsers openuser = new frmUsers();
            openuser.TopLevel = false;
            openuser.AutoScroll = true;

            panel1.Controls.Add(openuser);
            openuser.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmCatagories openuser = new frmCatagories();
            openuser.TopLevel = false;
            openuser.AutoScroll = true;

            panel1.Controls.Add(openuser);
            openuser.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmProducts openuser = new frmProducts();

            openuser.TopLevel = false;
            openuser.AutoScroll = true;

            panel1.Controls.Add(openuser);
            openuser.Show();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            frmPurchaseAndSales openuser = new frmPurchaseAndSales();

          
            openuser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmTransaction openuser = new frmTransaction();
            openuser.TopLevel = false;
            openuser.AutoScroll = true;

            panel1.Controls.Add(openuser);
            openuser.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            panel1.Controls.Clear();
            frmDeaCust openuser = new frmDeaCust();
            openuser.TopLevel = false;
            openuser.AutoScroll = true;

            panel1.Controls.Add(openuser);
            openuser.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            frmGst openuser = new frmGst();

            openuser.TopLevel = false;
            openuser.AutoScroll = true;

            panel1.Controls.Add(openuser);
            openuser.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("hh:mm:ss");
            date.Text = DateTime.Today.ToString("dd / MM / yyyy");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Close();
            frmAdminDashboardNew newww = new frmAdminDashboardNew();
            newww.Show();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void clock_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlMenus_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Refresh();
            this.Close();
            frmAdminDashboardNew newww = new frmAdminDashboardNew();
            newww.Show();
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.BackColor = Color.DarkBlue;
            button6.ForeColor = Color.White;

        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.AliceBlue;
            button6.ForeColor = Color.Black;
        }

        private void button8_MouseHover(object sender, EventArgs e)
        {
            button8.BackColor = Color.DarkBlue;
            button8.ForeColor = Color.White;
        }

        private void button7_MouseHover(object sender, EventArgs e)
        {
            button7.BackColor = Color.DarkBlue;
            button7.ForeColor = Color.White;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.DarkBlue;
            button5.ForeColor = Color.White;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.DarkBlue;
            button1.ForeColor = Color.White;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.DarkBlue;
            button3.ForeColor = Color.White;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.DarkBlue;
            button4.ForeColor = Color.White;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.DarkBlue;
            button2.ForeColor = Color.White;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.AliceBlue;
            button8.ForeColor = Color.Black;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.AliceBlue;
            button7.ForeColor = Color.Black;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.AliceBlue;
            button5.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.AliceBlue;
            button1.ForeColor = Color.Black;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.AliceBlue;
            button3.ForeColor = Color.Black;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.AliceBlue;
            button4.ForeColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.AliceBlue;
            button2.ForeColor = Color.Black;
        }
    }
}
