using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Allinox
{
    public class LimitFields
    {
        private static readonly string connectionString = "SERVER=ID295848_allinox.db.webhosting.be;DATABASE=ID295848_allinox;UID=ID295848_allinox;PASSWORD=Lingske_01";
        readonly MySqlConnection sqlconn = new MySqlConnection(connectionString);

        // extra velden niet in tabel opgenomen
        public double MinPalHoogte { get; set; }
        public double MaxPalHoogte { get; set; }
        public double MinAantMcPerLayer { get; set; }
        public double MaxAantMcPerLayer { get; set; }
        public double MinAantLayer { get; set; }
        public double MaxAantLayer { get; set; }
        public double MinAbPerMc { get; set; }
        public double MaxAbPerMc { get; set; }
        public double MinItemPerAb { get; set; }
        public double MaxItemPerAb { get; set; }


        public double MclimGrossweightMin { get; set; }
        public double MclimGrossweightMax { get; set; }
        public string MclimGrossweightEenheid { get; set; }
        public double MclimLengthMin { get; set; }
        public double MclimLengthMax { get; set; }
        public string MclimLengthEenheid { get; set; }
        public double MclimWidthMin { get; set; }
        public double MclimWidthMax { get; set; }
        public string MclimWidthEenheid { get; set; }
        public double MclimHeightMin { get; set; }
        public double MclimHeightMax { get; set; }
        public string MclimHeightEenheid { get; set; }
        public double MclimPaperTareMin { get; set; }
        public double MclimPaperTareMax { get; set; }
        public string MclimPaperTareEenheid { get; set; }
        public double MclimPlasticTareMin { get; set; }
        public double MclimPlasticTareMax { get; set; }
        public string MclimPlasticTareEenheid { get; set; }

        public double AblimGrossweightMin { get; set; }
        public double AblimGrossweightMax { get; set; }
        public string AblimGrossweightEenheid { get; set; }
        public double AblimLengthMin { get; set; }
        public double AblimLengthMax { get; set; }
        public string AblimLengthEenheid { get; set; }
        public double AblimWidthMin { get; set; }
        public double AblimWidthMax { get; set; }
        public string AblimWidthEenheid { get; set; }
        public double AblimHeightMin { get; set; }
        public double AblimHeightMax { get; set; }
        public string AblimHeightEenheid { get; set; }
        public double AblimPaperTareMin { get; set; }
        public double AblimPaperTareMax { get; set; }
        public string AblimPaperTareEenheid { get; set; }
        public double AblimPlasticTareMin { get; set; }
        public double AblimPlasticTareMax { get; set; }
        public string AblimPlasticTareEenheid { get; set; }

        public double ItlimGrossweightMin { get; set; }
        public double ItlimGrossweightMax { get; set; }
        public string ItlimGrossweightEenheid { get; set; }
        public double ItlimLengthMin { get; set; }
        public double ItlimLengthMax { get; set; }
        public string ItlimLengthEenheid { get; set; }
        public double ItlimWidthMin { get; set; }
        public double ItlimWidthMax { get; set; }
        public string ItlimWidthEenheid { get; set; }
        public double ItlimHeightMin { get; set; }
        public double ItlimHeightMax { get; set; }
        public string ItlimHeightEenheid { get; set; }
        public double ItlimPaperTareMin { get; set; }
        public double ItlimPaperTareMax { get; set; }
        public string ItlimPaperTareEenheid { get; set; }
        public double ItlimPlasticTareMin { get; set; }
        public double ItlimPlasticTareMax { get; set; }
        public string ItlimPlasticTareEenheid { get; set; }

        public LimitFields()
        {
            try
            {
                sqlconn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM ArtikelLimitGroep WHERE artDataGroepId = 3", sqlconn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MclimGrossweightMin = reader.GetDouble(2);
                        MclimGrossweightMax = reader.GetDouble(3);
                        MclimGrossweightEenheid = reader.GetString(4);

                        MclimLengthMin = reader.GetDouble(5);
                        MclimLengthMax = reader.GetDouble(6);
                        MclimLengthEenheid = reader.GetString(7);

                        MclimWidthMin = reader.GetDouble(8);
                        MclimWidthMax = reader.GetDouble(9);
                        MclimWidthEenheid = reader.GetString(10);

                        MclimHeightMin = reader.GetDouble(11);
                        MclimHeightMax = reader.GetDouble(12);
                        MclimHeightEenheid = reader.GetString(13);

                        MclimPaperTareMin = reader.GetDouble(14);
                        MclimPaperTareMax = reader.GetDouble(15);
                        MclimPaperTareEenheid = reader.GetString(16);

                        MclimPlasticTareMin = reader.GetDouble(17);
                        MclimPlasticTareMax = reader.GetDouble(18);
                        MclimPlasticTareEenheid = reader.GetString(19);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : Fill_Limits_Mc()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }

            try
            {
                sqlconn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM ArtikelLimitGroep WHERE artDataGroepId = 4", sqlconn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AblimGrossweightMin = reader.GetDouble(2);
                        AblimGrossweightMax = reader.GetDouble(3);
                        AblimGrossweightEenheid = reader.GetString(4);

                        AblimLengthMin = reader.GetDouble(5);
                        AblimLengthMax = reader.GetDouble(6);
                        AblimLengthEenheid = reader.GetString(7);

                        AblimWidthMin = reader.GetDouble(8);
                        AblimWidthMax = reader.GetDouble(9);
                        AblimWidthEenheid = reader.GetString(10);

                        AblimHeightMin = reader.GetDouble(11);
                        AblimHeightMax = reader.GetDouble(12);
                        AblimHeightEenheid = reader.GetString(13);

                        AblimPaperTareMin = reader.GetDouble(14);
                        AblimPaperTareMax = reader.GetDouble(15);
                        AblimPaperTareEenheid = reader.GetString(16);

                        AblimPlasticTareMin = reader.GetDouble(17);
                        AblimPlasticTareMax = reader.GetDouble(18);
                        AblimPlasticTareEenheid = reader.GetString(19);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : Fill_Limits_Ab()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }

            try
            {
                sqlconn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM ArtikelLimitGroep WHERE artDataGroepId = 5", sqlconn))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ItlimGrossweightMin = reader.GetDouble(2);
                        ItlimGrossweightMax = reader.GetDouble(3);
                        ItlimGrossweightEenheid = reader.GetString(4);

                        ItlimLengthMin = reader.GetDouble(5);
                        ItlimLengthMax = reader.GetDouble(6);
                        ItlimLengthEenheid = reader.GetString(7);

                        ItlimWidthMin = reader.GetDouble(8);
                        ItlimWidthMax = reader.GetDouble(9);
                        ItlimWidthEenheid = reader.GetString(10);

                        ItlimHeightMin = reader.GetDouble(11);
                        ItlimHeightMax = reader.GetDouble(12);
                        ItlimHeightEenheid = reader.GetString(13);

                        ItlimPaperTareMin = reader.GetDouble(14);
                        ItlimPaperTareMax = reader.GetDouble(15);
                        ItlimPaperTareEenheid = reader.GetString(16);

                        ItlimPlasticTareMin = reader.GetDouble(17);
                        ItlimPlasticTareMax = reader.GetDouble(18);
                        ItlimPlasticTareEenheid = reader.GetString(19);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : Fill_Limits_It()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }

            //MinPalHoogte = 50;
            //MaxPalHoogte = 250;
            //MinAantMcPerLayer = 1;
            //MaxAantMcPerLayer = 20;
            //MinAantLayer = 1;
            //MaxAantLayer = 20;
            //MinAbPerMc = 1;
            //MaxAbPerMc = 120;
            //MinItemPerAb = 1;
            //MaxItemPerAb = 120;

            Fill_Global_Variabelen();
        }

        void Fill_Global_Variabelen()
        {
            GlobalVariabelen.MclimGrossweightMin = MclimGrossweightMin;
            GlobalVariabelen.MclimGrossweightMax = MclimGrossweightMax;
            GlobalVariabelen.MclimLengthMin = MclimLengthMin;
            GlobalVariabelen.MclimLengthMax = MclimLengthMax;
            GlobalVariabelen.MclimWidthMin = MclimWidthMin;
            GlobalVariabelen.MclimWidthMax = MclimWidthMax;
            GlobalVariabelen.MclimHeightMin = MclimHeightMin;
            GlobalVariabelen.MclimHeightMax = MclimHeightMax;
            GlobalVariabelen.MclimPaperTareMin = MclimPaperTareMin;
            GlobalVariabelen.MclimPaperTareMax = MclimPaperTareMax;
            GlobalVariabelen.MclimPlasticTareMin = MclimPlasticTareMin;
            GlobalVariabelen.MclimPlasticTareMax = MclimPlasticTareMax;
            GlobalVariabelen.AblimGrossweightMin = AblimGrossweightMin;
            GlobalVariabelen.AblimGrossweightMax = AblimGrossweightMax;
            GlobalVariabelen.AblimLengthMin = AblimLengthMin;
            GlobalVariabelen.AblimLengthMax = AblimLengthMax;
            GlobalVariabelen.AblimWidthMin = AblimWidthMin;
            GlobalVariabelen.AblimWidthMax = AblimWidthMax;
            GlobalVariabelen.AblimHeightMin = AblimHeightMin;
            GlobalVariabelen.AblimHeightMax = AblimHeightMax;
            GlobalVariabelen.AblimPaperTareMin = AblimPaperTareMin;
            GlobalVariabelen.AblimPaperTareMax = AblimPaperTareMax;
            GlobalVariabelen.AblimPlasticTareMin = AblimPlasticTareMin;
            GlobalVariabelen.AblimPlasticTareMax = AblimPlasticTareMax;
            GlobalVariabelen.ItlimGrossweightMin = ItlimGrossweightMin;
            GlobalVariabelen.ItlimGrossweightMax = ItlimGrossweightMax;
            GlobalVariabelen.ItlimLengthMin = ItlimLengthMin;
            GlobalVariabelen.ItlimLengthMax = ItlimLengthMax;
            GlobalVariabelen.ItlimWidthMin = ItlimWidthMin;
            GlobalVariabelen.ItlimWidthMax = ItlimWidthMax;
            GlobalVariabelen.ItlimHeightMin = ItlimHeightMin;
            GlobalVariabelen.ItlimHeightMax = ItlimHeightMax;
            GlobalVariabelen.ItlimPaperTareMin = ItlimPaperTareMin;
            GlobalVariabelen.ItlimPaperTareMax = ItlimPaperTareMax;
            GlobalVariabelen.ItlimPlasticTareMin = ItlimPlasticTareMin;
            GlobalVariabelen.ItlimPlasticTareMax = ItlimPlasticTareMax;
        }
    }
}
