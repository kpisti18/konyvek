using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Kovacs_Istvan_12_console
{
    internal class Database
    {
        MySqlConnection con = null;
        MySqlCommand sqlCmd = null;

        public Database()
        {
            try
            {
                MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
                sb.Clear();
                sb.Server = "localhost";
                sb.UserID = "root";
                sb.Password = "";
                sb.Database = "konyvesbolt2";

                con = new MySqlConnection(sb.ConnectionString);
                con.Open();
                sqlCmd = con.CreateCommand();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Az alábbi hiba lépett fel: {ex.Message}");
            }
        }

        public List<Konyv> getKonyv()
        {
            List<Konyv> konyvs = new List<Konyv>();
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                    sqlCmd.CommandText = "SELECT * FROM `konyv`";
                    using (MySqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Konyv ujKonyv = new Konyv(
                                dr.GetInt32("konyvid"),
                                dr.IsDBNull(dr.GetOrdinal("szerzo")) ? null : dr.GetString("szerzo"),
                                dr.IsDBNull(dr.GetOrdinal("cim")) ? null : dr.GetString("cim"),
                                dr.IsDBNull(dr.GetOrdinal("isbn")) ? null : dr.GetString("isbn"),
                                dr.IsDBNull(dr.GetOrdinal("ar")) ? 0 : dr.GetInt32("ar"));

                            konyvs.Add(ujKonyv);
                        }
                    }
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Az alábbi hiba lépett fel: {ex.Message}");
                }
            }
            return konyvs;
        }

        public List<Vasarlo> getVasarlo()
        {
            List<Vasarlo> vasarlos = new List<Vasarlo>();
            if (con.State != ConnectionState.Open)
            {
                try
                {
                    con.Open();
                    sqlCmd.CommandText = "SELECT * FROM `vasarlo`";
                    using (MySqlDataReader dr = sqlCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Vasarlo ujVasarlo = new Vasarlo(
                                dr.GetInt32("vasarloid"),
                                dr.IsDBNull(dr.GetOrdinal("nev")) ? null : dr.GetString("nev"),
                                dr.IsDBNull(dr.GetOrdinal("email_cim")) ? null : dr.GetString("email_cim"),
                                dr.IsDBNull(dr.GetOrdinal("felhasznalonev")) ? null : dr.GetString("felhasznalonev"));

                            vasarlos.Add(ujVasarlo);
                        }
                    }
                    con.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"Az alábbi hiba lépett fel: {ex.Message}");
                }
            }
            return vasarlos;
        }

        //Adatbázis műveletek
        public void insertVasarlas(int vasarloAzon, int konyvAzon, int darab)
        {
            sqlCmd.CommandText = $"INSERT INTO vasarlas(datum, vasarloID, konyvID, darab) VALUES ('{DateTime.Now.ToString("yyyy.MM.dd")}', '{vasarloAzon.ToString()}', '{konyvAzon.ToString()}', '{darab.ToString()}')";

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    int affectedRows = sqlCmd.ExecuteNonQuery();
                    if (affectedRows == 1)
                    {
                        MessageBox.Show("Sikeres felvétel!");
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen felvétel!");
                    }
                    con.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Az alábbi hiba lépett fel: {ex.Message}");
            }
        }
    }
}
