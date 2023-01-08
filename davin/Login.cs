using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Davin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
       

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MYDB db = new MYDB();

            string username = txtUsername.Text; 
            string password = txtPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(
                "SELECT * FROM `user` WHERE `username`=@usn AND `password`=@pass", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            txtUsername.Text = "";
            txtPassword.Text = "";

            if (table.Rows.Count > 0 )
            {
                MessageBox.Show("Login Success",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Hide();
                UserControl f1 = new UserControl();
                f1.ShowDialog();
                


            } else
            {
                if (username.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Username to Login",
                                    "Empty Username",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                } else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Password to Login",
                                    "Empty Password",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                } else
                {
                    MessageBox.Show("Wrong Username or Password",
                                    "Wrong Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                }
               
            }
        }

        private void Login_MouseHover(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }


            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
