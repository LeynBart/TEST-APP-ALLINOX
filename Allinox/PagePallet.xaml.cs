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
    /// Interaction logic for PagePallet.xaml
    /// </summary>
    public partial class PagePallet : Page
    {
        public PagePallet()
        {
            InitializeComponent();
            txbArtikelNr.Text = GlobalVariabelen.intSelectArtikel.ToString();
            txbArtikelOmschrijving.Text = GlobalVariabelen.strSelectArtikel;
            txbPallethoogte.Text = GlobalVariabelen.palletHeight == 0 ? "" : GlobalVariabelen.palletHeight.ToString();
            txbMastercarton.Text = GlobalVariabelen.mcPerLayer == 0 ? "" : GlobalVariabelen.mcPerLayer.ToString();
            txbLagen.Text = GlobalVariabelen.numberOfLayers == 0 ? "" : GlobalVariabelen.numberOfLayers.ToString();

            if (GlobalVariabelen.paletData == true)
            {
                rdbPalletJa.IsChecked = true;
                //btnItem.Visibility = Visibility.Hidden;
                //btnArtikelBox.Visibility = Visibility.Visible;
            }
            else
            {
                rdbPalletNee.IsChecked = true;
                //btnItem.Visibility = Visibility.Visible;
                //btnArtikelBox.Visibility = Visibility.Hidden;
            }
        }

        private void RdbPalletJa_Unchecked(object sender, RoutedEventArgs e)
        {
            lbl1.Visibility = Visibility.Hidden;
            lbl2.Visibility = Visibility.Hidden;
            lbl3.Visibility = Visibility.Hidden;
            lbl4.Visibility = Visibility.Hidden;
            lbl5.Visibility = Visibility.Hidden;
            lbl6.Visibility = Visibility.Hidden;

            txbPallethoogte.Visibility = Visibility.Hidden;
            txbMastercarton.Visibility = Visibility.Hidden;
            txbLagen.Visibility = Visibility.Hidden;

        }

        private void RdbPalletNee_Unchecked(object sender, RoutedEventArgs e)
        {
            lbl1.Visibility = Visibility.Visible;
            lbl2.Visibility = Visibility.Visible;
            lbl3.Visibility = Visibility.Visible;
            lbl4.Visibility = Visibility.Visible;
            lbl5.Visibility = Visibility.Visible;
            lbl6.Visibility = Visibility.Visible;

            txbPallethoogte.Visibility = Visibility.Visible;
            txbMastercarton.Visibility = Visibility.Visible;
            txbLagen.Visibility = Visibility.Visible;

        }

        private void BtnMaster_Click(object sender, RoutedEventArgs e)
        {
            if (rdbPalletJa.IsChecked == true)
            {
                txbPallethoogte.Text = txbPallethoogte.Text.Replace(".", ",");
                txbMastercarton.Text = txbMastercarton.Text.Replace(".", ",");
                txbLagen.Text = txbLagen.Text.Replace(".", ",");

                // controle limieten pallethoogte, aantal mastercarton per laag en aantal lagen
                if (double.Parse(txbPallethoogte.Text) < GlobalVariabelen.MinPalHoogte || double.Parse(txbPallethoogte.Text) > GlobalVariabelen.MaxPalHoogte)
                {
                    MessageBox.Show("Pallethoogte verkeerd : min 50 cm en max 250 cm", "Pallethoogte", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (double.Parse(txbMastercarton.Text) < GlobalVariabelen.MinAantLayer || double.Parse(txbMastercarton.Text) > GlobalVariabelen.MaxAantLayer)
                {
                    MessageBox.Show("Mastercarton/laag verkeerd : min 1 stuk en max 20 stuks", "Mastercarton/laag", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (double.Parse(txbLagen.Text) < GlobalVariabelen.MinAantLayer || double.Parse(txbLagen.Text) > GlobalVariabelen.MaxAantLayer)
                {
                    MessageBox.Show("Aantal lagen verkeerd : min 1 stuk en max 20 stuks", "Aantal lagen", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                GlobalVariabelen.paletData = true;
                GlobalVariabelen.palletHeight = double.Parse(txbPallethoogte.Text);
                GlobalVariabelen.mcPerLayer = double.Parse(txbMastercarton.Text);
                GlobalVariabelen.numberOfLayers = double.Parse(txbLagen.Text);
            }
            else
            {
                GlobalVariabelen.paletData = false;
                GlobalVariabelen.palletHeight = 0;
                GlobalVariabelen.mcPerLayer = 0;
                GlobalVariabelen.numberOfLayers = 0;
            }
;

            this.NavigationService.Navigate(new PageMastercarton());
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // nog variabelen reset checken !!
            GlobalVariabelen.intSelectArtikel = 0;
            GlobalVariabelen.strSelectArtikel = "";

            this.NavigationService.Navigate(new PageArtikel());
        }
    }
}
