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
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;


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
        private void wczytaj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            openFileDialog.Title = "Otwórz plik CSV";
            if (openFileDialog.ShowDialog() == true)
            {
                listview.Items.Clear();
                string filePath = openFileDialog.FileName;
                int selectedFilterIndex = openFileDialog.FilterIndex;
                string delimiter = ";";
                if (selectedFilterIndex == 1)
                {
                    delimiter = ",";
                }
                Encoding encoding = Encoding.UTF8;
                if (File.Exists(filePath))
                {
                    var lines = File.ReadAllLines(filePath, encoding);
                    foreach (var line in lines)
                    {
                        string[] columns = line.Split(delimiter);
                        if (columns != null)
                        {
                            var uczen = new Uczen();
                            uczen.list_PESEL = columns.ElementAtOrDefault(0);
                            uczen.list_Imie = columns.ElementAtOrDefault(1);
                            uczen.list_Imie2 = columns.ElementAtOrDefault(2);
                            uczen.list_Nazwisko = columns.ElementAtOrDefault(3);
                            uczen.list_DataUrodzenia = columns.ElementAtOrDefault(4);
                            uczen.list_NumerTelefonu = columns.ElementAtOrDefault(5);
                            uczen.list_Adres = columns.ElementAtOrDefault(6);
                            uczen.list_Miejscowosc = columns.ElementAtOrDefault(7);
                            uczen.list_KodPocztowy = columns.ElementAtOrDefault(8);
                            listview.Items.Add(uczen);
                        }
                    }
                }
            }

        }
        private void zapisz_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki CSV z separatorem (,) |*.csv|Pliki CSV z separatorem (;) |*.csv";
            saveFileDialog.Title = "Zapisz jako plik CSV";
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string delimiter = ";";
                if (saveFileDialog.FilterIndex == 1)
                {
                    delimiter = ",";
                }
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Uczen item in listview.Items)
                    {
                        var row = $"{item.list_PESEL}{delimiter}{item.list_Imie}" +
                        $"{delimiter}{item.list_Imie2}{delimiter}{item.list_Nazwisko}" +
                        $"{delimiter}{item.list_DataUrodzenia}{delimiter}{item.list_NumerTelefonu}" +
                        $"{delimiter}{item.list_Adres}{delimiter}{item.list_Miejscowosc}{delimiter}{item.list_KodPocztowy}";
                        writer.WriteLine(row);
                    }
                }
            }
        }
        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            var okno = new Window1();
            okno.ShowDialog();

            string pesel = okno.PESEL_Window1;
            string imie = okno.Imie_Window1;
            string imie2 = okno.Imie2_Window1;
            string nazwisko = okno.Nazwisko_Window1;
            string data_urodzenia = okno.DataUrodzenia_Window1;
            string nr_telefonu = okno.NumerTelefonu_Window1;
            string adres = okno.Adres_Window1;
            string miejscowosc = okno.Miejscowosc_Window1;
            string kod_pocztowy = okno.KodPocztowy_Window1;

            var uczen = new Uczen();
            uczen.Przypisz(pesel, imie, imie2, nazwisko, data_urodzenia, nr_telefonu, adres, miejscowosc, kod_pocztowy);
            if(okno.a == true)
            {

            } else
            {
                listview.Items.Add(uczen);
            }
    }
        private void usun_Click(object sender, RoutedEventArgs e)
        {
            while (listview.SelectedItems.Count > 0)
            {
                listview.Items.Remove(listview.SelectedItems[0]);
            }
        }

        private void info_Click(object sender, RoutedEventArgs e)
        {
            var info = new Info();
            info.ShowDialog();
        }
    }
}