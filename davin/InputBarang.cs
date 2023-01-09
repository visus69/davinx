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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Davin
{
    public partial class InputBarang : Form
    {
        public InputBarang()
        {
            InitializeComponent();
        }

        BARANG barang = new BARANG();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nama_barang = txtNama_Barang.Text;
            string kategori = cmbKategori.Text;
            DateTime tanggal_masuk = dtMasuk.Value;
            DateTime tanggal_keluar = dtKeluar.Value;
            int jumlah_barang = Convert.ToInt32(Math.Round(numJumlah_Barang.Value, 0));
           

            if (nama_barang.Trim().Equals("") || kategori.Trim().Equals("") || (jumlah_barang < 1))
            {
                MessageBox.Show("Isi data dengan benar!", "Ada kolom yang belum terisi.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if(barang.addBarang(nama_barang, kategori, tanggal_masuk,tanggal_keluar,jumlah_barang))
                {
                    MessageBox.Show("Data berhasil diinput", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    MessageBox.Show("Data gagal diinput", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);
                string nama_barang = txtNama_Barang.Text;
                string kategori = cmbKategori.Text;
                DateTime? tanggal_masuk = dtMasuk.Value;
                DateTime? tanggal_keluar = dtKeluar.Value;
                int jumlah_barang = Convert.ToInt32(Math.Round(numJumlah_Barang.Value, 0));

                if (nama_barang.Trim().Equals(""))
                {
                    MessageBox.Show("Masukkan Nama Barang",
                                    "Nama Barang Kosong",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    if (barang.editBarang(id, nama_barang, kategori, tanggal_masuk, tanggal_keluar, jumlah_barang))
                    {
                        MessageBox.Show("Update Data Sukses",
                                    "Edit Data Barang",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Update Data Gagal",
                                    "Edit Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ID");
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            UserControl c = Application.OpenForms.OfType<UserControl>().FirstOrDefault();
            if (c != null) c.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtId.Text);

                if (barang.removeBarang(id))
                {
                    MessageBox.Show("Delete Barang Sukses",
                                    "Delete Barang",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    txtId.Text = "";
                    txtNama_Barang.Text = "";
                    cmbKategori.Text = "";
                    dtMasuk = null;
                    dtKeluar = null;
                    numJumlah_Barang.Value = 0;
                } else
                {
                    MessageBox.Show("Delete Barang Gagal",
                                    "Delete Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid ID");
            }
        }

        private void InputBarang_Load(object sender, EventArgs e)
        {
            dgBarang.Columns.Add("Column1", "no");

            dgBarang.DataSource = barang.LihatData();
            for (int i = 0; i < dgBarang.Rows.Count; i++)
            {
                dgBarang.Rows[i].Cells[0].Value = i + 1;
            }

            dgBarang.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            dgBarang.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 14, FontStyle.Bold);
            dgBarang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgBarang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgBarang.EnableHeadersVisualStyles = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
