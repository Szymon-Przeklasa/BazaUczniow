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
using System.Windows.Shapes;

namespace BazaUczniow
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string PESEL_Window1;
        public string Imie_Window1;
        public string Imie2_Window1;
        public string Nazwisko_Window1;
        public string DataUrodzenia_Window1;
        public string NumerTelefonu_Window1;
        public string Adres_Window1;
        public string Miejscowosc_Window1;
        public string KodPocztowy_Window1;
        public Window1()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            PESEL_Window1 = PESEL_input.Text;
            Imie_Window1 = Imie_input.Text;
            Imie2_Window1 = Imie2_input.Text;
            Nazwisko_Window1 = Nazwisko_input.Text;
            DataUrodzenia_Window1 = DataUrodzenia_input.Text;
            NumerTelefonu_Window1 = NumerTelefonu_input.Text;
            Adres_Window1 = Adres_input.Text;
            Miejscowosc_Window1 = Miejscowosc_input.Text;
            KodPocztowy_Window1 = KodPocztowy_input.Text;
        }
        private void Anuluj_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(PESEL_input.Text) ||
                !String.IsNullOrEmpty(Imie_input.Text) ||
                !String.IsNullOrEmpty(Imie2_input.Text) ||
                !String.IsNullOrEmpty(Nazwisko_input.Text) ||
                !String.IsNullOrEmpty(DataUrodzenia_input.Text) ||
                !String.IsNullOrEmpty(NumerTelefonu_input.Text) ||
                !String.IsNullOrEmpty(Adres_input.Text) ||
                !String.IsNullOrEmpty(Miejscowosc_input.Text) ||
                !String.IsNullOrEmpty(KodPocztowy_input.Text))
            {
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz zamknąć okno bez zapisywania?", "Potwierdzenie", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    this.Close();
                }
                else
                {

                }
            } else
            {
                this.Close();
            }
        }
    }
}
