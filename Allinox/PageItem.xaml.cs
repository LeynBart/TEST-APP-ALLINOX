using MySql.Data.MySqlClient;
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

namespace Allinox
{
    /// <summary>
    /// Interaction logic for PageItem.xaml
    /// </summary>
    public partial class PageItem : Page
    {
        private static readonly string connectionString = "SERVER=ID295848_allinox.db.webhosting.be;DATABASE=ID295848_allinox;UID=ID295848_allinox;PASSWORD=Lingske_01";
        readonly MySqlConnection sqlconn = new MySqlConnection(connectionString);

        public PageItem()
        {
            InitializeComponent();

            txbArtikelNr.Text = GlobalVariabelen.intSelectArtikel.ToString();
            txbArtikelOmschrijving.Text = GlobalVariabelen.strSelectArtikel;

            if (!GlobalVariabelen.articleBox)
            {
                txbItMc.Text = GlobalVariabelen.itPerMc == 0 ? "" : GlobalVariabelen.itPerMc.ToString();
                txbBruto.Text = GlobalVariabelen.itBrutoInput == 0 ? "" : GlobalVariabelen.itBrutoInput.ToString();
                txbKarton.Text = GlobalVariabelen.itKartonInput == 0 ? "" : GlobalVariabelen.itKartonInput.ToString();
                txbPlastiek.Text = GlobalVariabelen.itPlastiekInput == 0 ? "" : GlobalVariabelen.itPlastiekInput.ToString();
            }
            else
            {
                lblItMc.Visibility = Visibility.Hidden;
                lblBruto.Visibility = Visibility.Hidden;
                lblKarton.Visibility = Visibility.Hidden;
                lblPlastiek.Visibility = Visibility.Hidden;

                lblItMc.Visibility = Visibility.Hidden;
                lbl1.Visibility = Visibility.Hidden;
                lbl2.Visibility = Visibility.Hidden;
                lbl7.Visibility = Visibility.Hidden;
                lbl8.Visibility = Visibility.Hidden;

                txbItMc.Visibility = Visibility.Hidden;
                txbBruto.Visibility = Visibility.Hidden;
                txbKarton.Visibility = Visibility.Hidden;
                txbPlastiek.Visibility = Visibility.Hidden;
            }

            txbNetto.Text = GlobalVariabelen.itNettoInput == 0 ? "" : GlobalVariabelen.itNettoInput.ToString();
            txbLengte.Text = GlobalVariabelen.itLengteInput == 0 ? "" : GlobalVariabelen.itLengteInput.ToString();
            txbBreedte.Text = GlobalVariabelen.itBreedteInput == 0 ? "" : GlobalVariabelen.itBreedteInput.ToString();
            txbHoogte.Text = GlobalVariabelen.itHoogteInput == 0 ? "" : GlobalVariabelen.itHoogteInput.ToString();

        }

        private void BtnArticlebox_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PageArticlebox());
        }

        private void BtnBevestig_Click(object sender, RoutedEventArgs e)
        {
            var checkError = Check_input_fields();
            if (!checkError)
            {
                // controle of in ArtikelVerpak aanwezig : ja = update, nee = insert
                var aanwezigVerpak = Check_aanwezig_verpak();
                if (aanwezigVerpak)
                {
                    Update_ArtikelVerpak();
                }
                else
                {
                    Insert_ArtikelVerpak();
                }

                // controle of in ArtikelPrio aanwezig
                var aanwezigPrio = Check_aanwezig_prio();
                if (aanwezigPrio)
                {
                    Delete_ArtikelPrio();
                }

                this.NavigationService.Navigate(new PageArtikel());
            }
        }

        private bool Check_input_fields()
        {
            if (!GlobalVariabelen.articleBox)
            {
                txbItMc.Text = txbItMc.Text.Replace(".", ",");
                txbBruto.Text = txbBruto.Text.Replace(".", ",");
                txbKarton.Text = txbKarton.Text.Replace(".", ",");
                txbPlastiek.Text = txbPlastiek.Text.Replace(".", ",");
            }
            txbNetto.Text = txbNetto.Text.Replace(".", ",");
            txbLengte.Text = txbLengte.Text.Replace(".", ",");
            txbBreedte.Text = txbBreedte.Text.Replace(".", ",");
            txbHoogte.Text = txbHoogte.Text.Replace(".", ",");

            if (!GlobalVariabelen.articleBox)
            {
                if (double.Parse(txbItMc.Text) < GlobalVariabelen.MinAbPerMc || double.Parse(txbItMc.Text) > GlobalVariabelen.MaxAbPerMc)
                {
                    MessageBox.Show("Aantal items/mastercarton verkeerd, min 1 en max 120 stuks", "Items per mastercarton", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }

                if (double.Parse(txbBruto.Text) < GlobalVariabelen.ItlimGrossweightMin || double.Parse(txbBruto.Text) > GlobalVariabelen.ItlimGrossweightMax)
                {
                    MessageBox.Show(String.Format("Brutogewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.ItlimGrossweightMin, GlobalVariabelen.ItlimGrossweightMax), "Brutogewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
                if (double.Parse(txbKarton.Text) < GlobalVariabelen.ItlimPaperTareMin || double.Parse(txbKarton.Text) > GlobalVariabelen.ItlimPaperTareMax)
                {
                    MessageBox.Show(String.Format("Karton gewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.ItlimPaperTareMin, GlobalVariabelen.ItlimPaperTareMax), "Karton gewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
                if (double.Parse(txbPlastiek.Text) < GlobalVariabelen.ItlimPlasticTareMin || double.Parse(txbPlastiek.Text) > GlobalVariabelen.ItlimPlasticTareMax)
                {
                    MessageBox.Show(String.Format("Plastiek gewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.ItlimPlasticTareMin, GlobalVariabelen.ItlimPlasticTareMax), "Plastiek gewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            }

            if (double.Parse(txbNetto.Text) < GlobalVariabelen.ItlimNetweightMin || double.Parse(txbNetto.Text) > GlobalVariabelen.ItlimNetweightMax)
            {
                MessageBox.Show(String.Format("Nettogewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.ItlimNetweightMin, GlobalVariabelen.ItlimNetweightMax), "Nettogewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbLengte.Text) < GlobalVariabelen.ItlimLengthMin || double.Parse(txbLengte.Text) > GlobalVariabelen.ItlimLengthMax)
            {
                MessageBox.Show(String.Format("Lengte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.ItlimLengthMin, GlobalVariabelen.ItlimLengthMax), "Lengte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbBreedte.Text) < GlobalVariabelen.ItlimWidthMin || double.Parse(txbBreedte.Text) > GlobalVariabelen.ItlimWidthMax)
            {
                MessageBox.Show(String.Format("Breedte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.ItlimWidthMin, GlobalVariabelen.ItlimWidthMax), "Breedte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbHoogte.Text) < GlobalVariabelen.ItlimHeightMin || double.Parse(txbHoogte.Text) > GlobalVariabelen.ItlimHeightMax)
            {
                MessageBox.Show(String.Format("Hoogte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.ItlimHeightMin, GlobalVariabelen.ItlimHeightMax), "Hoogte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }

            if (!GlobalVariabelen.articleBox)
            {
                GlobalVariabelen.itPerMc = double.Parse(txbItMc.Text);
                GlobalVariabelen.itBrutoInput = double.Parse(txbBruto.Text);
                GlobalVariabelen.itKartonInput = double.Parse(txbKarton.Text);
                GlobalVariabelen.itPlastiekInput = double.Parse(txbPlastiek.Text);
            }
            else
            {
                GlobalVariabelen.itPerMc = 0;
                GlobalVariabelen.itBrutoInput = 0;
                GlobalVariabelen.itKartonInput = 0;
                GlobalVariabelen.itPlastiekInput = 0;
            }

            GlobalVariabelen.itNettoInput = double.Parse(txbNetto.Text);
            GlobalVariabelen.itLengteInput = double.Parse(txbLengte.Text);
            GlobalVariabelen.itBreedteInput = double.Parse(txbBreedte.Text);
            GlobalVariabelen.itHoogteInput = double.Parse(txbHoogte.Text);

            return false;
        }

        private bool Check_aanwezig_verpak()
        {
            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SELECT count(*) " +
                                                    "         FROM ArtikelVerpak " +
                                                    " WHERE artNr = @varArtnr", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", txbArtikelNr.Text);
                    Int64 countPrio = (Int64)cmd.ExecuteScalar();
                    if (countPrio > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : check aanwezig ArtikelVerpak", MessageBoxButton.OK, MessageBoxImage.Error);
                sqlconn.Close();
                return false;
            }
            finally
            {
                sqlconn.Close();

            }
        }

        private void Update_ArtikelVerpak()
        {
            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("UPDATE ArtikelVerpak SET palletData = @palletData, palletHeight = @palletHeight, mcPerLayer = @mcPerLayer, numberOfLayers = @numberOfLayers, artbox = @artBox, " +
                                                                                    "mcGrossweight = @mcGrossweight, mcLength = @mcLength, mcWidth = @mcWidth, mcHeight = @mcHeight, mcPaperTareweight = @mcPaperTareweight, mcPlasticTareWeight = @mcPlasticTareweight," +
                                                                                    "abPerMc = @abPerMc, abGrossweight = @abGrossweight, abLength = @abLength, abWidth = @abWidth, abHeight = @abHeight, abPaperTareweight = @abPaperTareweight, abPlasticTareWeight = @abPlasticTareweight," +
                                                                                    "itPerMc = @itPerMc, itGrossweight = @itGrossweight, itNetweight = @itNetweight, itLength = @itLength, itWidth = @itWidth, itHeight = @itHeight, itPaperTareweight = @itPaperTareweight, itPlasticTareWeight = @itPlasticTareweight," +
                                                                                    "updUser = @varUser, updTime = @varTime WHERE artNr = @varArtnr", sqlconn))

                {
                    cmd.Parameters.AddWithValue("@varArtnr", GlobalVariabelen.intSelectArtikel);

                    cmd.Parameters.AddWithValue("@palletData", GlobalVariabelen.paletData);
                    cmd.Parameters.AddWithValue("@palletHeight", GlobalVariabelen.palletHeight);
                    cmd.Parameters.AddWithValue("@mcPerLayer", GlobalVariabelen.mcPerLayer);
                    cmd.Parameters.AddWithValue("@numberOfLayers", GlobalVariabelen.numberOfLayers);
                    cmd.Parameters.AddWithValue("@artBox", GlobalVariabelen.articleBox);

                    cmd.Parameters.AddWithValue("@mcGrossweight", GlobalVariabelen.mcBrutoInput);
                    cmd.Parameters.AddWithValue("@mcLength", GlobalVariabelen.mcLengteInput);
                    cmd.Parameters.AddWithValue("@mcWidth", GlobalVariabelen.mcBreedteInput);
                    cmd.Parameters.AddWithValue("@mcHeight", GlobalVariabelen.mcHoogteInput);
                    cmd.Parameters.AddWithValue("@mcPaperTareweight", GlobalVariabelen.mcKartonInput);
                    cmd.Parameters.AddWithValue("@mcPlasticTareweight", GlobalVariabelen.mcPlastiekInput);

                    cmd.Parameters.AddWithValue("@abPerMc", GlobalVariabelen.abPerMc);
                    cmd.Parameters.AddWithValue("@abGrossweight", GlobalVariabelen.abBrutoInput);
                    cmd.Parameters.AddWithValue("@abLength", GlobalVariabelen.abLengteInput);
                    cmd.Parameters.AddWithValue("@abWidth", GlobalVariabelen.abBreedteInput);
                    cmd.Parameters.AddWithValue("@abHeight", GlobalVariabelen.abHoogteInput);
                    cmd.Parameters.AddWithValue("@abPaperTareweight", GlobalVariabelen.abKartonInput);
                    cmd.Parameters.AddWithValue("@abPlasticTareweight", GlobalVariabelen.abPlastiekInput);

                    cmd.Parameters.AddWithValue("@itPerMc", GlobalVariabelen.itPerMc);
                    cmd.Parameters.AddWithValue("@itGrossweight", GlobalVariabelen.itBrutoInput);
                    cmd.Parameters.AddWithValue("@itNetweight", GlobalVariabelen.itNettoInput);
                    cmd.Parameters.AddWithValue("@itLength", GlobalVariabelen.itLengteInput);
                    cmd.Parameters.AddWithValue("@itWidth", GlobalVariabelen.itBreedteInput);
                    cmd.Parameters.AddWithValue("@itHeight", GlobalVariabelen.itHoogteInput);
                    cmd.Parameters.AddWithValue("@itPaperTareweight", GlobalVariabelen.itKartonInput);
                    cmd.Parameters.AddWithValue("@itPlasticTareweight", GlobalVariabelen.itPlastiekInput);

                    cmd.Parameters.AddWithValue("@varUser", GlobalVariabelen.strGebruikerAcronym);
                    DateTime dt1 = DateTime.Now;
                    cmd.Parameters.AddWithValue("@varTime", dt1);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : update ArtikelVerpak", MessageBoxButton.OK, MessageBoxImage.Error);
                sqlconn.Close();
            }
            finally
            {
                sqlconn.Close();

            }
        }

        private void Insert_ArtikelVerpak()
        {                                     
            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO ArtikelVerpak ( artNr, palletData, palletHeight, mcPerLayer, numberOfLayers, artBox, " +
                                                           "          mcGrossweight, mcLength, mcWidth, mcHeight, mcPaperTareweight, mcPlasticTareWeight," +
                                                           "          abPerMc, abGrossweight, abLength, abWidth, abHeight, abPaperTareweight, abPlasticTareWeight," +
                                                           "          itPerMc, itGrossweight, itNetWeight, itLength, itWidth, itHeight, itPaperTareweight, itPlasticTareWeight," +
                                                           "          CreUser, CreTime)" +
                                                           "    VALUES (@varArtnr,  @palletData, @palletHeight, @mcPerLayer, @numberOfLayers, @artBox, " +
                                                           "            @mcGrossweight, @mcLength, @mcWidth, @mcHeight, @mcPaperTareweight, @mcPlasticTareWeight, " +
                                                           "            @abPerMc, @abGrossweight, @abLength, @abWidth, @abHeight, @abPaperTareweight, @abPlasticTareWeight, " +
                                                           "            @itPerMc, @itGrossweight, @itNetWeight, @itLength, @itWidth, @itHeight, @itPaperTareweight, @itPlasticTareWeight, " +
                                                           "            @varUser, @varTime)", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", GlobalVariabelen.intSelectArtikel);

                    cmd.Parameters.AddWithValue("@palletData", GlobalVariabelen.paletData);
                    cmd.Parameters.AddWithValue("@palletHeight", GlobalVariabelen.palletHeight);
                    cmd.Parameters.AddWithValue("@mcPerLayer", GlobalVariabelen.mcPerLayer);
                    cmd.Parameters.AddWithValue("@numberOfLayers", GlobalVariabelen.numberOfLayers);
                    cmd.Parameters.AddWithValue("@artBox", GlobalVariabelen.articleBox);

                    cmd.Parameters.AddWithValue("@mcGrossweight", GlobalVariabelen.mcBrutoInput);
                    cmd.Parameters.AddWithValue("@mcLength", GlobalVariabelen.mcLengteInput);
                    cmd.Parameters.AddWithValue("@mcWidth", GlobalVariabelen.mcBreedteInput);
                    cmd.Parameters.AddWithValue("@mcHeight", GlobalVariabelen.mcHoogteInput);
                    cmd.Parameters.AddWithValue("@mcPaperTareweight", GlobalVariabelen.mcKartonInput);
                    cmd.Parameters.AddWithValue("@mcPlasticTareweight", GlobalVariabelen.mcPlastiekInput);

                    cmd.Parameters.AddWithValue("@abPerMc", GlobalVariabelen.abPerMc);
                    cmd.Parameters.AddWithValue("@abGrossweight", GlobalVariabelen.abBrutoInput);
                    cmd.Parameters.AddWithValue("@abLength", GlobalVariabelen.abLengteInput);
                    cmd.Parameters.AddWithValue("@abWidth", GlobalVariabelen.abBreedteInput);
                    cmd.Parameters.AddWithValue("@abHeight", GlobalVariabelen.abHoogteInput);
                    cmd.Parameters.AddWithValue("@abPaperTareweight", GlobalVariabelen.abKartonInput);
                    cmd.Parameters.AddWithValue("@abPlasticTareweight", GlobalVariabelen.abPlastiekInput);

                    cmd.Parameters.AddWithValue("@itPerMc", GlobalVariabelen.itPerMc);
                    cmd.Parameters.AddWithValue("@itGrossweight", GlobalVariabelen.itBrutoInput);
                    cmd.Parameters.AddWithValue("@itNetweight", GlobalVariabelen.itNettoInput);
                    cmd.Parameters.AddWithValue("@itLength", GlobalVariabelen.itLengteInput);
                    cmd.Parameters.AddWithValue("@itWidth", GlobalVariabelen.itBreedteInput);
                    cmd.Parameters.AddWithValue("@itHeight", GlobalVariabelen.itHoogteInput);
                    cmd.Parameters.AddWithValue("@itPaperTareweight", GlobalVariabelen.itKartonInput);
                    cmd.Parameters.AddWithValue("@itPlasticTareweight", GlobalVariabelen.itPlastiekInput);

                    cmd.Parameters.AddWithValue("@varUser", GlobalVariabelen.strGebruikerAcronym);
                    DateTime dt1 = DateTime.Now;
                    cmd.Parameters.AddWithValue("@varTime", dt1);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : insert ArtikelVerpak", MessageBoxButton.OK, MessageBoxImage.Error);
                sqlconn.Close();
            }
            finally
            {
                sqlconn.Close();
            }
        }

        private bool Check_aanwezig_prio()
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
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : check aanwezig ArtikelPrio", MessageBoxButton.OK, MessageBoxImage.Error);
                sqlconn.Close();
                return false;
            }
            finally
            {
                sqlconn.Close();

            }
        }

        private void Delete_ArtikelPrio()
        {
            try
            {
                sqlconn.Open();

                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM ArtikelPrio WHERE artNr = @varArtnr", sqlconn))
                {
                    cmd.Parameters.AddWithValue("@varArtnr", GlobalVariabelen.intSelectArtikel);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er liep iets verkeerd : " + ex.Message, "Foutmelding : delete ArtikelPrio", MessageBoxButton.OK, MessageBoxImage.Error);
                sqlconn.Close();
            }
            finally
            {
                sqlconn.Close();
            }
        }

    }
}
