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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        LoginBll l = new LoginBll();
        LoginDAL dal = new LoginDAL();
      public static string loggedIn;
       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            l.username = txtUsername.Text.Trim();
            l.password = txtPassword.Text.Trim();
            l.user_type = cnbUserType.Text.Trim();

            bool success = dal.loginCheck(l);

            if (success == true)
            {
                MessageBox.Show("Login Successful");
                loggedIn = l.username;

                switch (l.user_type)
                {
                    case "Admin":
                        {
                            frmAdminDashboardNew admin = new frmAdminDashboardNew();
                            admin.Show();
                            this.Hide();
                        }
                        break;

                    case "User":
                        {
                            userDashboardNew user = new userDashboardNew();

                            user.Show();
                            this.Hide();

                        }
                        break;

                    default:
                        {

                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Login Failed");
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            

        }

        private void cnbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
