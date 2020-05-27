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
    /// Interaction logic for PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var Gebruiker = new Gebruiker(txbUserName.Text, txbUserPassword.Password);
            if(Gebruiker.GebruikerIdApp > 0)
            {
                GlobalVariabelen.strGebruiker = Gebruiker.GebruikerNaamApp;
                GlobalVariabelen.strGebruikerId = Gebruiker.GebruikerIdApp;
                GlobalVariabelen.strGebruikerAcronym = Gebruiker.GebruikerAcronymApp;

                this.NavigationService.Navigate(new PageArtikel());
            }
            else
            {
                MessageBox.Show("Gebruikernaam en/of wachtwoord verkeerd");
            }
        }
    }
}
