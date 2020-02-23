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

namespace oe_selectie_02.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime now = DateTime.Now;
        int jaar;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            cmbMaanden.Items.Add("januari");
            cmbMaanden.Items.Add("februari");
            cmbMaanden.Items.Add("maart");
            cmbMaanden.Items.Add("april");
            cmbMaanden.Items.Add("mei");
            cmbMaanden.Items.Add("juni");
            cmbMaanden.Items.Add("juli");
            cmbMaanden.Items.Add("augustus");
            cmbMaanden.Items.Add("september");
            cmbMaanden.Items.Add("oktober");
            cmbMaanden.Items.Add("november");
            cmbMaanden.Items.Add("december");
            jaar = now.Year;
            
            txtJaar.Text = jaar.ToString();

        }
        void IsJaarEenSchrikkeljaar(int jaar)
        {

            if (jaar % 4 == 0 && (jaar % 100 != 0 || jaar % 400 == 0)) lblSchrikkeljaar.Content = "dit jaar is een schrikkeljaar";
            else lblSchrikkeljaar.Content = "dit jaar is geen scrhikkeljaar";
        }

        void GeefHetSeizoen(int index)
        {
            string seizoen;
            switch(index)
            {
                case 2:
                case 3:
                case 4:
                    seizoen = "Lente";
                    break;
                case 5 :
                case 6:
                case 7:
                    seizoen = "zomer";
                    break;
                case 8:
                case 9:
                case 10:
                    seizoen = "herfst";
                    break;
                default:
                    seizoen = "winter";

                    break;
         }
            lblSeizoen.Content = seizoen;
        }

        private void TxtJaar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtJaar.IsLoaded)
           {
                txtJaar.MaxLength = 4;
                if (int.TryParse(txtJaar.Text, out int jaar) == true)
                {
                   IsJaarEenSchrikkeljaar(jaar);
                  

                }
                else lblSchrikkeljaar.Content = "geef enkel cijfers in";
                
            }
            
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtJaar.Text, out int jaar) == true)
            {
                jaar++;
                txtJaar.Text = jaar.ToString();
                IsJaarEenSchrikkeljaar(jaar);
            }
            
        }

        private void BtnMin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtJaar.Text, out int jaar)==true)
            {
                jaar--;
                txtJaar.Text = jaar.ToString();
                IsJaarEenSchrikkeljaar(jaar);
            }

        }
 

        private void CmbMaanden_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // meteoroligsche seizoenen
            /*
             * Lente: 1 maart t/m 31 mei
             * Zomer: 1 juni t/m 31 augustus
             * Herfst: 1 september t/m 30 november
             * Winter: 1 december t/m 28 februari
            */
            int index = cmbMaanden.SelectedIndex;
            GeefHetSeizoen(index);
        }

    }
}
