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
    /// Interaction logic for PageMastercarton.xaml
    /// </summary>
    public partial class PageMastercarton : Page
    {
        public PageMastercarton()
        {
            InitializeComponent();

            txbArtikelNr.Text = GlobalVariabelen.intSelectArtikel.ToString();
            txbArtikelOmschrijving.Text = GlobalVariabelen.strSelectArtikel;

            txbBruto.Text = GlobalVariabelen.mcBrutoInput == 0 ? "" : GlobalVariabelen.mcBrutoInput.ToString();
            txbLengte.Text = GlobalVariabelen.mcLengteInput == 0 ? "" : GlobalVariabelen.mcLengteInput.ToString();
            txbBreedte.Text = GlobalVariabelen.mcBreedteInput == 0 ? "" : GlobalVariabelen.mcBreedteInput.ToString();
            txbHoogte.Text = GlobalVariabelen.mcHoogteInput == 0 ? "" : GlobalVariabelen.mcHoogteInput.ToString();
            txbKarton.Text = GlobalVariabelen.mcKartonInput == 0 ? "" : GlobalVariabelen.mcKartonInput.ToString();
            txbPlastiek.Text = GlobalVariabelen.mcPlastiekInput == 0 ? "" : GlobalVariabelen.mcPlastiekInput.ToString();

            if (GlobalVariabelen.articleBox == true)
            {
                rdbBoxJa.IsChecked = true;
                btnItem.Visibility = Visibility.Hidden;
                btnArtikelBox.Visibility = Visibility.Visible;
            }
            else
            {
                rdbBoxNee.IsChecked = true;
                btnItem.Visibility = Visibility.Visible;
                btnArtikelBox.Visibility = Visibility.Hidden;
            }
        }

        private void BtnPallet_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService.Navigate(new PagePallet());
        }

        private void BtnArtikelBox_Click(object sender, RoutedEventArgs e)
        {
            var checkError = Check_input_fields();
            if (!checkError)
            {
                this.NavigationService.Navigate(new PageArticlebox());
            }
        }

        private void BtnItem_Click(object sender, RoutedEventArgs e)
        {
            var checkError = Check_input_fields();
            if (!checkError)
            {
                this.NavigationService.Navigate(new PageItem());
            }            
        }

        private void RdbBoxJa_Unchecked(object sender, RoutedEventArgs e)
        {
            btnArtikelBox.Visibility = Visibility.Hidden;
            btnItem.Visibility = Visibility.Visible;
            GlobalVariabelen.articleBox = false;
        }
        
        private void RdbBoxNee_Unchecked(object sender, RoutedEventArgs e)
        {
            btnArtikelBox.Visibility = Visibility.Visible;
            btnItem.Visibility = Visibility.Hidden;
            GlobalVariabelen.articleBox = true;
        }

        private bool Check_input_fields()
        {
            txbBruto.Text = txbBruto.Text.Replace(".", ",");
            txbLengte.Text = txbLengte.Text.Replace(".", ",");
            txbBreedte.Text = txbBreedte.Text.Replace(".", ",");
            txbHoogte.Text = txbHoogte.Text.Replace(".", ",");
            txbKarton.Text = txbKarton.Text.Replace(".", ",");
            txbPlastiek.Text = txbPlastiek.Text.Replace(".", ",");

            if (double.Parse(txbBruto.Text) < GlobalVariabelen.MclimGrossweightMin || double.Parse(txbBruto.Text) > GlobalVariabelen.MclimGrossweightMax)
            {
                MessageBox.Show(String.Format("Brutogewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.MclimGrossweightMin, GlobalVariabelen.MclimGrossweightMax), "Brutogewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbLengte.Text) < GlobalVariabelen.MclimLengthMin || double.Parse(txbLengte.Text) > GlobalVariabelen.MclimLengthMax)
            {
                MessageBox.Show(String.Format("Lengte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.MclimLengthMin, GlobalVariabelen.MclimLengthMax), "Lengte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbBreedte.Text) < GlobalVariabelen.MclimWidthMin || double.Parse(txbBreedte.Text) > GlobalVariabelen.MclimWidthMax)
            {
                MessageBox.Show(String.Format("Breedte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.MclimWidthMin, GlobalVariabelen.MclimWidthMax), "Breedte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbHoogte.Text) < GlobalVariabelen.MclimHeightMin || double.Parse(txbHoogte.Text) > GlobalVariabelen.MclimHeightMax)
            {
                MessageBox.Show(String.Format("Hoogte verkeerd, min {0}" + " cm en max {1}" + " cm", GlobalVariabelen.MclimHeightMin, GlobalVariabelen.MclimHeightMax), "Hoogte", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbKarton.Text) < GlobalVariabelen.MclimPaperTareMin || double.Parse(txbKarton.Text) > GlobalVariabelen.MclimPaperTareMax)
            {
                MessageBox.Show(String.Format("Karton gewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.MclimPaperTareMin, GlobalVariabelen.MclimPaperTareMax), "Karton gewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            if (double.Parse(txbPlastiek.Text) < GlobalVariabelen.MclimPlasticTareMin || double.Parse(txbPlastiek.Text) > GlobalVariabelen.MclimPlasticTareMax)
            {
                MessageBox.Show(String.Format("Plastiek gewicht verkeerd, min {0}" + " kg en max {1}" + " kg", GlobalVariabelen.MclimPlasticTareMin, GlobalVariabelen.MclimPlasticTareMax), "Plastiek gewicht", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }

            if (rdbBoxJa.IsChecked == true)
            {
                GlobalVariabelen.articleBox = true;
                GlobalVariabelen.mcBrutoInput = double.Parse(txbBruto.Text);
                GlobalVariabelen.mcLengteInput = double.Parse(txbLengte.Text);
                GlobalVariabelen.mcBreedteInput = double.Parse(txbBreedte.Text);
                GlobalVariabelen.mcHoogteInput = double.Parse(txbHoogte.Text);
                GlobalVariabelen.mcKartonInput = double.Parse(txbKarton.Text);
                GlobalVariabelen.mcPlastiekInput = double.Parse(txbPlastiek.Text);
            }
            else
            {
                GlobalVariabelen.articleBox = false;
                GlobalVariabelen.abBrutoInput = 0;
                GlobalVariabelen.abLengteInput = 0;
                GlobalVariabelen.abBreedteInput = 0;
                GlobalVariabelen.abHoogteInput = 0;
                GlobalVariabelen.abKartonInput = 0;
                GlobalVariabelen.abPlastiekInput = 0;
            }

            return false;
        }
    }
}
