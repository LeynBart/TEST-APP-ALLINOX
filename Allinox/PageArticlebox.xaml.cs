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
    /// Interaction logic for PageArticlebox.xaml
    /// </summary>
    public partial class PageArticlebox : Page
    {
        public PageArticlebox()
        {
            InitializeComponent();
            txbArtikelNr.Text = GlobalVariabelen.intSelectArtikel.ToString();
            txbArtikelOmschrijving.Text = GlobalVariabelen.strSelectArtikel;

            txbAbMc.Text = GlobalVariabelen.abPerMc == 0 ? "" : GlobalVariabelen.abPerMc.ToString();
            txbBruto.Text = GlobalVariabelen.abBrutoInput == 0 ? "" : GlobalVariabelen.abBrutoInput.ToString();
            txbLengte.Text = GlobalVariabelen.abLengteInput == 0 ? "" : GlobalVariabelen.abLengteInput.ToString();
            txbBreedte.Text = GlobalVariabelen.abBreedteInput == 0 ? "" : GlobalVariabelen.abBreedteInput.ToString();
            txbHoogte.Text = GlobalVariabelen.abHoogteInput == 0 ? "" : GlobalVariabelen.abHoogteInput.ToString();
            txbKarton.Text = GlobalVariabelen.abKartonInput == 0 ? "" : GlobalVariabelen.abKartonInput.ToString();
            txbPlastiek.Text = GlobalVariabelen.abPlastiekInput == 0 ? "" : GlobalVariabelen.abPlastiekInput.ToString();
        }

        private void BtnMastercarton_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new PageMastercarton());
        }

        private void BtnItem_Click(object sender, RoutedEventArgs e)
        {
            var checkError = Check_input_fields();
            if (!checkError)
            {
                this.NavigationService.Navigate(new PageItem());
            }
        }

        private bool Check_input_fields()
        {
            txbAbMc.Text = txbAbMc.Text.Replace(".", ",");
            txbBruto.Text = txbBruto.Text.Replace(".", ",");
            txbLengte.Text = txbLengte.Text.Replace(".", ",");
            txbBreedte.Text = txbBreedte.Text.Replace(".", ",");
            txbHoogte.Text = txbHoogte.Text.Replace(".", ",");
            txbKarton.Text = txbKarton.Text.Replace(".", ",");
            txbPlastiek.Text = txbPlastiek.Text.Replace(".", ",");

            if (double.Parse(txbAbMc.Text) < GlobalVariabelen.MinAbPerMc || double.Parse(txbAbMc.Text) > GlobalVariabelen.MaxAbPerMc)
            {
                MessageBox.Show("Aantal articlebox/mastercarton verkeerd, min 1 en max 120 stuks", "Articlebox per mastercarton", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }

            if (double.Parse(txbBruto.Text) < GlobalVariabelen.AblimGrossweightMin || double.Parse(txbBruto.Text) > GlobalVariabelen.AblimGrossweightMax)
            {
                MessageBox.Show(String.Format("Brutogewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.AblimGrossweightMin, GlobalVariabelen.AblimGrossweightMax), "Brutogewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbLengte.Text) < GlobalVariabelen.AblimLengthMin || double.Parse(txbLengte.Text) > GlobalVariabelen.AblimLengthMax)
            {
                MessageBox.Show(String.Format("Lengte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.AblimLengthMin, GlobalVariabelen.AblimLengthMax), "Lengte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbBreedte.Text) < GlobalVariabelen.AblimWidthMin || double.Parse(txbBreedte.Text) > GlobalVariabelen.AblimWidthMax)
            {
                MessageBox.Show(String.Format("Breedte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.AblimWidthMin, GlobalVariabelen.AblimWidthMax), "Breedte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbHoogte.Text) < GlobalVariabelen.AblimHeightMin || double.Parse(txbHoogte.Text) > GlobalVariabelen.AblimHeightMax)
            {
                MessageBox.Show(String.Format("Hoogte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.AblimHeightMin, GlobalVariabelen.AblimHeightMax), "Hoogte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbKarton.Text) < GlobalVariabelen.AblimPaperTareMin || double.Parse(txbKarton.Text) > GlobalVariabelen.AblimPaperTareMax)
            {
                MessageBox.Show(String.Format("Karton gewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.AblimPaperTareMin, GlobalVariabelen.AblimPaperTareMax), "Karton gewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbPlastiek.Text) < GlobalVariabelen.AblimPlasticTareMin || double.Parse(txbPlastiek.Text) > GlobalVariabelen.AblimPlasticTareMax)
            {
                MessageBox.Show(String.Format("Plastiek gewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.AblimPlasticTareMin, GlobalVariabelen.AblimPlasticTareMax), "Plastiek gewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }

            GlobalVariabelen.abPerMc = double.Parse(txbAbMc.Text);
            GlobalVariabelen.abBrutoInput = double.Parse(txbBruto.Text);
            GlobalVariabelen.abLengteInput = double.Parse(txbLengte.Text);
            GlobalVariabelen.abBreedteInput = double.Parse(txbBreedte.Text);
            GlobalVariabelen.abHoogteInput = double.Parse(txbHoogte.Text);
            GlobalVariabelen.abKartonInput = double.Parse(txbKarton.Text);
            GlobalVariabelen.abPlastiekInput = double.Parse(txbPlastiek.Text);

            return false;
        }
    }
}
