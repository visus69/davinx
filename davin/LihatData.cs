using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class LihatData : Form
    {
        public LihatData()
        {
            InitializeComponent();
        }
        BARANG barang = new BARANG();

        private void dgBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void LihatData_Load(object sender, EventArgs e)
        {
            dgBarang.DataSource = barang.LihatData();
            dgBarang.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dgBarang.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
            dgBarang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgBarang.EnableHeadersVisualStyles = false;
        }

        private void dgBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserControl c = Application.OpenForms.OfType<UserControl>().FirstOrDefault();
            if (c != null) c.Show();
            this.Hide();
        }
    }
}
