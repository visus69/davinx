using MySql.Data.MySqlClient;
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
            /*dgBarang.Columns.Add("Column1", "no");

            dgBarang.DataSource = barang.LihatData();
            for (int i = 0; i < dgBarang.Rows.Count; i++)
            {
                dgBarang.Rows[i].Cells[0].Value = i + 1;
            }*/

            dgBarang.DataSource = barang.LihatData();
            dgBarang.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
            dgBarang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void dgBarang_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgBarang.DataSource = null;     
            dgBarang.DataSource = barang.LihatData();
            for (int i = 0; i < dgBarang.Rows.Count; i++)
            {
                dgBarang.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MYDB db = new MYDB();

            string cari = txtSearch.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand(
                "SELECT * FROM `datainventaris` WHERE `nama_barang`=@namabarang", db.getConnection());

            command.Parameters.Add("@namabarang", MySqlDbType.VarChar).Value = cari;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            txtSearch.Text = "";

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Ternyata datanya ada",
                                "",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                dgBarang.DataSource = table;


            }
            else
            {
                if (cari.Trim().Equals(""))
                {
                    MessageBox.Show("Enter Your Data",
                                    "Empty Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Datanya nda ada",
                                    "Wrong Data",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                }

            }
        }
    
    }
}
