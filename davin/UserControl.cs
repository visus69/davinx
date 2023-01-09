using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Davin
{
    public partial class UserControl : Form
    {
        public UserControl()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LihatData d1 = new LihatData();
            d1.ShowDialog();
        }

        private void btnInput_Data_Click(object sender, EventArgs e)
        {
            this.Hide();
            InputBarang b1 = new InputBarang();
            b1.ShowDialog();

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();

        /*    Login f = Application.OpenForms.OfType<Login>().FirstOrDefault();
            if (f != null) f.Show();
            this.Hide(); */
        }
    }
}
