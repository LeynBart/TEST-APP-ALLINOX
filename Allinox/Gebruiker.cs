using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Allinox
{
    public class Gebruiker
    {
        private static readonly string connectionString = "SERVER=ID295848_allinox.db.webhosting.be;DATABASE=ID295848_allinox;UID=ID295848_allinox;PASSWORD=Lingske_01";
        readonly MySqlConnection sqlconn = new MySqlConnection(connectionString);

        public string GebruikerNaamApp { get; set; }
        public string GebruikerAcronymApp { get; set; }
        public int GebruikerIdApp { get; set; }

        public Gebruiker(string gebruikernaam, string gebruikerpaswoord)
        {
            try
            {
                sqlconn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT UserId," +
                                                    "       UserVnaam," +
                                                    "       UserPaswoord," +
                                                    "       UserAcronym " +
                                                    "  FROM Users " +
                                                    " WHERE UserVnaam = @varUserNaam " +
                                                    "   AND UserPaswoord = @varUserPaswoord", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varUserNaam", gebruikernaam);
                    cmd.Parameters.AddWithValue("@varUserPaswoord", gebruikerpaswoord);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        GebruikerNaamApp = reader.GetString(1);
                        GebruikerAcronymApp = reader.GetString(3);
                        GebruikerIdApp = reader.GetInt32(0);
                        sqlconn.Close();
                    }
                    else
                    {
                        sqlconn.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                sqlconn.Close();
                MessageBox.Show("Something went wrong : " + ex.Message);
            }
        }
    }
}
