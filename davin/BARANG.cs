using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davin
{
    class BARANG
    {
        MYDB db = new MYDB();
        public Boolean addBarang(string nama_barang, string kategori, DateTime tanggal_masuk, DateTime tanggal_keluar, int jumlah_barang)
        {
            string query = "INSERT INTO `datainventaris` ( `nama_barang`, `kategori`, `tanggal_masuk`, `tanggal_keluar`, `jumlah_barang`)" +
                "VALUES (@nama_barang, @kategori, @dt_masuk, @dt_keluar, @jumlah_barang)";

            MySqlParameter[] parameters = new MySqlParameter[5];
            parameters[0] = new MySqlParameter("@nama_barang", MySqlDbType.VarChar);
            parameters[0].Value = nama_barang;
            parameters[1] = new MySqlParameter("@kategori", MySqlDbType.VarChar);
            parameters[1].Value = kategori;
            parameters[2] = new MySqlParameter("@dt_masuk", MySqlDbType.Date);
            parameters[2].Value = tanggal_masuk;
            parameters[3] = new MySqlParameter("@dt_keluar", MySqlDbType.Date);
            parameters[3].Value = tanggal_keluar;
            parameters[4] = new MySqlParameter("@jumlah_barang", MySqlDbType.Int32);
            parameters[4].Value = jumlah_barang;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean editBarang(int id, string nama_barang, string kategori, DateTime? tanggal_masuk, DateTime? tanggal_keluar, int jumlah_barang)
        {
            string query = "UPDATE `datainventaris` SET `nama_barang`=@nama_barang,`kategori`=@kategori ," +
                "`tanggal_masuk`=@dt_masuk,`tanggal_keluar`=@dt_keluar,`jumlah_barang`=@jumlah_barang WHERE `id`=@id";

            MySqlParameter[] parameters = new MySqlParameter[6];
            parameters[0] = new MySqlParameter("@nama_barang", MySqlDbType.VarChar);
            parameters[0].Value = nama_barang;
            parameters[1] = new MySqlParameter("@kategori", MySqlDbType.VarChar);
            parameters[1].Value = kategori;
            parameters[2] = new MySqlParameter("@dt_masuk", MySqlDbType.Date);
            parameters[2].Value = tanggal_masuk;
            parameters[3] = new MySqlParameter("@dt_keluar", MySqlDbType.Date);
            parameters[3].Value = tanggal_keluar;
            parameters[4] = new MySqlParameter("@jumlah_barang", MySqlDbType.Int32);
            parameters[4].Value = jumlah_barang;
            parameters[5] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[5].Value = id;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean removeBarang(int id)
        {
            string query = "DELETE FROM `datainventaris` WHERE `id`=@id";
            
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id", MySqlDbType.Int32);
            parameters[0].Value = id;

            if (db.setData(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable LihatData()
        {
            DataTable table = new DataTable();
            table = db.getData("SELECT `id` as `Id`,`nama_barang` as `Nama Barang`, `kategori` as `Kategori`, `tanggal_masuk` as `Tanggal Masuk`," +
                " `tanggal_keluar` as `Tanggal Keluar`, `jumlah_barang` as `Jumlah Barang` FROM `datainventaris`", null);

            return table;
        }



    }
}
