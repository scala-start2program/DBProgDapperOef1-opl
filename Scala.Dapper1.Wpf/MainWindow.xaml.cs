using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Scala.Dapper1.Core.Entities;
using Scala.Dapper1.Core.Services;

namespace Scala.Dapper1.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulatePersonen();
        }
        PersoonService persoonService = new PersoonService();
        bool isNew;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ActivateLeft();
        }
        private void ActivateLeft()
        {
            grpLeft.IsEnabled = true;
            grpRight.IsEnabled = false;
            btnBewaren.Visibility = Visibility.Hidden;
            btnAnnuleren.Visibility = Visibility.Hidden;
        }
        private void ActivateRight()
        {
            grpLeft.IsEnabled = false;
            grpRight.IsEnabled = true;
            btnBewaren.Visibility = Visibility.Visible;
            btnAnnuleren.Visibility = Visibility.Visible;
        }
        private void PopulatePersonen()
        {
            lstPersonen.ItemsSource = persoonService.GetPersonen();
            lstPersonen.Items.Refresh();
        }
        private void ClearControls()
        {
            txtAdres.Text = "";
            txtEmail.Text = "";
            txtGemeente.Text = "";
            txtLand.Text = "";
            txtNaam.Text = "";
            txtTelefoon.Text = "";
            txtVoornaam.Text = "";
        }
        private void LstPersonen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ClearControls();
            if(lstPersonen.SelectedItem != null)
            {
                Persoon persoon = (Persoon)lstPersonen.SelectedItem;
                txtAdres.Text = persoon.Adres ;
                txtEmail.Text = persoon.Email ;
                txtGemeente.Text = persoon.Gemeente ;
                txtLand.Text = persoon.Land ;
                txtNaam.Text = persoon.Naam ;
                txtTelefoon.Text = persoon.Telefoon ;
                txtVoornaam.Text = persoon.Voornaam ;
            }
        }
        private void BtnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            isNew = true;
            ActivateRight();
            ClearControls();
            txtNaam.Focus();
        }

        private void BtnWijzigen_Click(object sender, RoutedEventArgs e)
        {
            if(lstPersonen.SelectedItem != null)
            {
                isNew = false;
                ActivateRight();
                txtNaam.Focus();
            }
        }

        private void BtnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            if (lstPersonen.SelectedItem != null)
            {
                if(MessageBox.Show("Ben je zeker?", "Persoon verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Persoon persoon = (Persoon)lstPersonen.SelectedItem;
                    persoonService.DeletePersoon(persoon);
                    ClearControls();
                    PopulatePersonen();

                }
            }
        }

        private void BtnBewaren_Click(object sender, RoutedEventArgs e)
        {
            Persoon persoon;
            if(isNew)
            {
                persoon = new Persoon();
            }
            else
            {
                persoon = (Persoon)lstPersonen.SelectedItem;
            }
            persoon.Naam = txtNaam.Text.Trim();
            persoon.Voornaam = txtVoornaam.Text.Trim();
            persoon.Adres = txtAdres.Text.Trim();
            persoon.Gemeente = txtGemeente.Text.Trim();
            persoon.Land = txtLand.Text.Trim();
            persoon.Telefoon = txtTelefoon.Text.Trim();
            persoon.Email = txtEmail.Text.Trim();
            if (isNew)
                persoonService.AddPersoon(persoon);
            else
                persoonService.UpdatePersoon(persoon);
            ActivateLeft();
            PopulatePersonen();
            lstPersonen.SelectedValue = persoon.Id;
            LstPersonen_SelectionChanged(null, null);
        }

        private void BtnAnnuleren_Click(object sender, RoutedEventArgs e)
        {
            ClearControls();
            ActivateLeft();
            LstPersonen_SelectionChanged(null, null);
        }


    }
}
