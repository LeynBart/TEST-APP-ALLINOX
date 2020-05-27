using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace Allinox
{
    /// <summary>
    /// Interaction logic for PageArtikel.xaml
    /// </summary>
    public partial class PageArtikel : Page
    {
        private static readonly string connectionString = "SERVER=ID295848_allinox.db.webhosting.be;DATABASE=ID295848_allinox;UID=ID295848_allinox;PASSWORD=Lingske_01";
        readonly MySqlConnection sqlconn = new MySqlConnection(connectionString);
        public PageArtikel()
        {
            InitializeComponent();

            Fill_Datagrid_Artikel();
            Fill_Datagrid_ArtikelPrio();
            int aantPrio = dgArtikelPrio.Items.Count;
            if (aantPrio < 1)
            {
                dgArtikelPrio.Visibility = Visibility.Hidden;
                lblArtikelPrio.Visibility = Visibility.Hidden;
            }
            else
            {

                dgArtikelPrio.Visibility = Visibility.Visible;
                lblArtikelPrio.Visibility = Visibility.Visible;
            }
            if (txbArtikelNr.Text == "")
            {
                btnPallet.Visibility = Visibility.Hidden;
            }

            if (GlobalVariabelen.strGebruiker == "Donavan")
            {
                if(txbArtikelNr.Text == "")
                {
                    btnAdd.Visibility = Visibility.Hidden;
                }
                else
                {
                    btnAdd.Visibility = Visibility.Visible;
                }
            }
            else
            {
                btnAdd.Visibility = Visibility.Hidden;
            }
 
            _ = new LimitFields();

            if (GlobalVariabelen.intSelectArtikel != 0)
            {
                txbArtikelNr.Text = GlobalVariabelen.intSelectArtikel.ToString();
                txbArtikelOmschrijving.Text = GlobalVariabelen.strSelectArtikel;

                btnPallet.Visibility = Visibility.Visible;

                if (GlobalVariabelen.strGebruiker == "Donavan")
                {
                    btnAdd.Visibility = Visibility.Visible;
                }
            }


        }

        void Fill_Datagrid_Artikel()
        {
            try
            {
                sqlconn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT a.artNr, a.artOmschrijving " +
                                                                   "  FROM Artikel a LEFT OUTER JOIN ArtikelVerpak v ON a.artNr = v.artNr ORDER BY a.artNr", sqlconn))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    dgArtikel.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : Fill_Datagrid_Artikel()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        void Fill_Datagrid_ArtikelPrio()
        {
            try
            {
                sqlconn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT a.artNr, b.artOmschrijving " +
                                                                   "  FROM ArtikelPrio a LEFT OUTER JOIN Artikel b ON a.artNr = b.artNr ORDER BY a.artNr", sqlconn))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    dgArtikelPrio.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : Fill_Datagrid_ArtikelPrio()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txbSearch.Text == "Search artikel" || txbSearch.Text == "")
            {
                return;
            }

            if (txbSearch.Text == " ")
            {
                txbSearch.Text = "";
            }

            try
            {
                sqlconn.Open();
                using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT a.artNr, a.artOmschrijving " +
                                                                   "  FROM Artikel a LEFT OUTER JOIN ArtikelVerpak v ON a.artNr = v.artNr " +
                                                                   " WHERE a.artOmschrijving LIKE '%" + txbSearch.Text + "%' " +
                                                                   "    OR a.artNr LIKE '" + txbSearch.Text + "%' ORDER BY a.artNr", sqlconn))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    dgArtikel.ItemsSource = dt.DefaultView;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : txbSearch_TextChanged()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        private void DgArtikel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dgArtikel = sender as DataGrid;
            if (dgArtikel.SelectedItem is DataRowView dr)
            {
                txbArtikelNr.Text = dr["artNr"].ToString();
                txbArtikelOmschrijving.Text = dr["artOmschrijving"].ToString();

                var SelectArtikel = new SelectedArtikel(txbArtikelNr.Text, txbArtikelOmschrijving.Text);
                GlobalVariabelen.intSelectArtikel = SelectArtikel.SelectArtikel;
                GlobalVariabelen.strSelectArtikel = SelectArtikel.SelectArtikelNaam;
                if (GlobalVariabelen.strGebruiker == "Donavan")
                {
                    btnAdd.Visibility = Visibility.Visible;
                }

                // ophalen palletdata
                Fill_input_fields_pal();

                // ophalen mastercartondata
                Fill_input_fields_mc();

                // ophalen articleboxdata
                Fill_input_fields_ab();

                // ophalen itemdata();
                Fill_input_fields_it();

                btnPallet.Visibility = Visibility.Visible;
            }
        }

        private void DgArtikelPrio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dgArtikelPrio = sender as DataGrid;
            if (dgArtikelPrio.SelectedItem is DataRowView dr)
            {
                txbArtikelNr.Text = dr["artNr"].ToString();
                txbArtikelOmschrijving.Text = dr["artOmschrijving"].ToString();

                var SelectArtikel = new SelectedArtikel(txbArtikelNr.Text, txbArtikelOmschrijving.Text);
                GlobalVariabelen.intSelectArtikel = SelectArtikel.SelectArtikel;
                GlobalVariabelen.strSelectArtikel = SelectArtikel.SelectArtikelNaam;

                if (GlobalVariabelen.strGebruiker == "Donavan")
                {
                    btnAdd.Visibility = Visibility.Hidden;
                }

                // ophalen palletdata
                Fill_input_fields_pal();

                // ophalen mastercartondata
                Fill_input_fields_mc();

                // ophalen articleboxdata
                Fill_input_fields_ab();

                // ophalen itemdata
                Fill_input_fields_it();

                btnPallet.Visibility = Visibility.Visible;
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            txbSearch.Text = "Search artikel";
            txbArtikelNr.Text = "";
            txbArtikelOmschrijving.Text = "";
            //rdbPalletJa.IsChecked = true;
            //txbPallethoogte.Text = "";
            //txbMastercarton.Text = "";
            //txbLagen.Text = "";
            Fill_Datagrid_Artikel();
            Fill_Datagrid_ArtikelPrio();
            int aantPrio = dgArtikelPrio.Items.Count;
            if (aantPrio < 1)
            {
                dgArtikelPrio.Visibility = Visibility.Hidden;
                lblArtikelPrio.Visibility = Visibility.Hidden;
            }
            else
            {

                dgArtikelPrio.Visibility = Visibility.Visible;
                lblArtikelPrio.Visibility = Visibility.Visible;
            }
            btnPallet.Visibility = Visibility.Hidden;
            btnAdd.Visibility = Visibility.Hidden;
        }

        private void BtnPallet_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PagePallet());
        }

        private void Fill_input_fields_pal()
        {
            
            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT artNr, palletHeight, mcPerLayer, numberOfLayers, palletData " +
                                                    "  FROM ArtikelVerpak " +
                                                    " WHERE artNr = @varArtnr", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", txbArtikelNr.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GlobalVariabelen.palletHeight = reader.GetDouble(1);
                            GlobalVariabelen.mcPerLayer = reader.GetDouble(2);
                            GlobalVariabelen.numberOfLayers = reader.GetDouble(3);
                            GlobalVariabelen.paletData = reader.GetBoolean(4);
                        }
                    }
                    else
                    {
                        GlobalVariabelen.palletHeight = 0;
                        GlobalVariabelen.mcPerLayer = 0;
                        GlobalVariabelen.numberOfLayers = 0;
                        GlobalVariabelen.paletData = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : fill_input_fields_pal()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }

        }

        private void Fill_input_fields_mc()
        {

            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT artNr, artLocatie, mcGrossWeight, mcLength, mcWidth, mcHeight, mcPaperTareWeight, mcPlasticTareWeight, artBox " +
                                                    "  FROM ArtikelVerpak " +
                                                    " WHERE artNr = @varArtnr", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", txbArtikelNr.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GlobalVariabelen.mcBrutoInput = reader.GetDouble(2);
                            GlobalVariabelen.mcLengteInput = reader.GetDouble(3);
                            GlobalVariabelen.mcBreedteInput = reader.GetDouble(4);
                            GlobalVariabelen.mcHoogteInput = reader.GetDouble(5);
                            GlobalVariabelen.mcKartonInput = reader.GetDouble(6);
                            GlobalVariabelen.mcPlastiekInput = reader.GetDouble(7);
                            GlobalVariabelen.articleBox = reader.GetBoolean(8);
                        }
                    }
                    else
                    {
                        GlobalVariabelen.mcBrutoInput = 0;
                        GlobalVariabelen.mcLengteInput = 0;
                        GlobalVariabelen.mcBreedteInput = 0;
                        GlobalVariabelen.mcHoogteInput = 0;
                        GlobalVariabelen.mcKartonInput = 0;
                        GlobalVariabelen.mcPlastiekInput = 0;
                        GlobalVariabelen.articleBox = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : fill_input_fields_mc()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        private void Fill_input_fields_ab()
        {

            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT artNr, artLocatie, abGrossWeight, abLength, abWidth, abHeight, abPaperTareWeight, abPlasticTareWeight, abPerMc " +
                                                    "  FROM ArtikelVerpak " +
                                                    " WHERE artNr = @varArtnr", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", txbArtikelNr.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GlobalVariabelen.abBrutoInput = reader.GetDouble(2);
                            GlobalVariabelen.abLengteInput = reader.GetDouble(3);
                            GlobalVariabelen.abBreedteInput = reader.GetDouble(4);
                            GlobalVariabelen.abHoogteInput = reader.GetDouble(5);
                            GlobalVariabelen.abKartonInput = reader.GetDouble(6);
                            GlobalVariabelen.abPlastiekInput = reader.GetDouble(7);
                            GlobalVariabelen.abPerMc = reader.GetDouble(8);
                        }
                    }
                    else
                    {
                        GlobalVariabelen.abBrutoInput = 0;
                        GlobalVariabelen.abLengteInput = 0;
                        GlobalVariabelen.abBreedteInput = 0;
                        GlobalVariabelen.abHoogteInput = 0;
                        GlobalVariabelen.abKartonInput = 0;
                        GlobalVariabelen.abPlastiekInput = 0;
                        GlobalVariabelen.abPerMc = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : fill_input_fields_ab()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        private void Fill_input_fields_it()
        {

            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT artNr, artLocatie, itGrossWeight, itNetWeight, itLength, itWidth, itHeight, itPaperTareWeight, itPlasticTareWeight, itPerMc " +
                                                    "  FROM ArtikelVerpak " +
                                                    " WHERE artNr = @varArtnr", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", txbArtikelNr.Text);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            GlobalVariabelen.itBrutoInput = reader.GetDouble(2);
                            GlobalVariabelen.itNettoInput = reader.GetDouble(3);
                            GlobalVariabelen.itLengteInput = reader.GetDouble(4);
                            GlobalVariabelen.itBreedteInput = reader.GetDouble(5);
                            GlobalVariabelen.itHoogteInput = reader.GetDouble(6);
                            GlobalVariabelen.itKartonInput = reader.GetDouble(7);
                            GlobalVariabelen.itPlastiekInput = reader.GetDouble(8);
                            GlobalVariabelen.itPerMc = reader.GetDouble(9);
                        }
                    }
                    else
                    {
                        GlobalVariabelen.itBrutoInput = 0;
                        GlobalVariabelen.itNettoInput = 0;
                        GlobalVariabelen.itLengteInput = 0;
                        GlobalVariabelen.itBreedteInput = 0;
                        GlobalVariabelen.itHoogteInput = 0;
                        GlobalVariabelen.itKartonInput = 0;
                        GlobalVariabelen.itPlastiekInput = 0;
                        GlobalVariabelen.itPerMc = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : fill_input_fields_it()", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                sqlconn.Close();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT count(*) " +
                                                    "         FROM ArtikelPrio " +
                                                    " WHERE artNr = @varArtnr", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", txbArtikelNr.Text);
                    Int64 countPrio = (Int64)cmd.ExecuteScalar();
                    if (countPrio > 0)
                    {
                        MessageBox.Show("Artikel reeds in prio lijst : " + txbArtikelNr.Text, "Artikel prio", MessageBoxButton.OK, MessageBoxImage.Warning);
                        sqlconn.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : add to prio lijst", MessageBoxButton.OK, MessageBoxImage.Error);
                sqlconn.Close();
                return;
            }
            finally
            {
                sqlconn.Close();
            }

            // insert in artikelprio tabel
            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO ArtikelPrio (artNr) VALUES (@varArtNr)", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", txbArtikelNr.Text);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : add to prio lijst", MessageBoxButton.OK, MessageBoxImage.Error);
                sqlconn.Close();
                return;
            }
            finally
            {
                sqlconn.Close();
            }

            Fill_Datagrid_ArtikelPrio();
            int aantPrio = dgArtikelPrio.Items.Count;
            if (aantPrio < 1)
            {
                dgArtikelPrio.Visibility = Visibility.Hidden;
                lblArtikelPrio.Visibility = Visibility.Hidden;
            }
            else
            {
                dgArtikelPrio.Visibility = Visibility.Visible;
                lblArtikelPrio.Visibility = Visibility.Visible;
            }
            

        }
    }
}
