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

namespace BazaUczniow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Uczen
        {
            public string list_PESEL { get; set; }
            public string list_Imie { get; set; }
            public string list_Imie2 { get; set; }
            public string list_Nazwisko { get; set; }
            public string list_DataUrodzenia { get; set; }
            public string list_NumerTelefonu { get; set; }
            public string list_Adres { get; set; }
            public string list_Miejscowosc { get; set; }
            public string list_KodPocztowy { get; set; }

            public Uczen()
            {

            }

            public void Przypisz(string _listPESEL, string _listImie, string _listImie2, string _listNazwisko, string _listDataUrodzenia, string _listNumerTelefonu, string _listAdres, string _listMiejscowosc, string _listKodPocztowy)
            {
                list_PESEL = _listPESEL;
                list_Imie = _listImie;
                list_Imie2 = _listImie2;
                list_Nazwisko = _listNazwisko;
                list_DataUrodzenia = _listDataUrodzenia;
                list_NumerTelefonu = _listNumerTelefonu;
                list_Adres = _listAdres;
                list_Miejscowosc = _listMiejscowosc;
                list_KodPocztowy = _listKodPocztowy;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void przycisk_Click(object sender, RoutedEventArgs e)
        {
            var okno = new Window1();
            okno.ShowDialog();
        }
    }
}