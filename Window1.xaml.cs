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
        public bool a = false;
        public Window1()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string DuzaLitera(string slowo)
            {
                if (slowo != Adres_input.Text)
                {
                    slowo = slowo.Replace(" ", "");
                }
                if (slowo.Length == 0) return "";
                string duza = slowo[0].ToString().ToUpper();
                string reszta = slowo.Substring(1);
                slowo = duza + reszta;
                return slowo;
            }

            string Telefon(string numer_telefonu)
            {
                numer_telefonu = numer_telefonu.Replace(" ", "");
                if (!numer_telefonu.StartsWith("+48"))
                {
                    numer_telefonu = "+48" + numer_telefonu;
                }
                return numer_telefonu;
            }

            bool SprawdzPesel(string pesel)
            {
                for(int i = 0; i < pesel.Length; i++)
                {
                    if (pesel.Length != 11 || !char.IsDigit(pesel[i]))
                    {
                        return false;
                    }
                }

                int rok = int.Parse(pesel.Substring(0, 2));
                int miesiac = int.Parse(pesel.Substring(2, 2));
                int dzien = int.Parse(pesel.Substring(4, 2));

                if (miesiac >= 1 && miesiac <= 12)
                {
                    rok += 1900;
                }
                else if (miesiac >= 21 && miesiac <= 32)
                {
                    miesiac -= 20;
                    rok += 2000;
                }
                else if (miesiac >= 41 && miesiac <= 52)
                {
                    miesiac -= 40;
                    rok += 2100;
                }
                else if (miesiac >= 61 && miesiac <= 72)
                {
                    miesiac -= 60;
                    rok += 2200;
                }
                else if (miesiac >= 81 && miesiac <= 92)
                {
                    miesiac -= 80;
                    rok += 1800;
                }
                else
                {
                    return false;
                }

                if (dzien < 1 || dzien > DateTime.DaysInMonth(rok, miesiac))
                {
                    return false;
                }

                int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                int suma = 0;
                for (int i = 0; i < 10; i++)
                {
                    suma += int.Parse(pesel[i].ToString()) * wagi[i];
                }
                int kontrolna = (10 - (suma % 10)) % 10;

                return kontrolna == int.Parse(pesel[10].ToString());
            }

            int poprawne = 0;
            bool wszystkoOk = true;

            string tempPesel = "";
            string tempImie = "";
            string tempImie2 = "-";
            string tempNazwisko = "";
            string tempDataUrodzenia = "";
            string tempTelefon = "-";
            string tempAdres = "";
            string tempMiejscowosc = "";
            string tempKodPocztowy = "";

            if (PESEL_input.Text == "")
            {
                PESEL_input.Background = Brushes.Red;
                wszystkoOk = false;
            }
            else if (SprawdzPesel(PESEL_input.Text))
            {
                tempPesel = PESEL_input.Text;
                PESEL_input.Background = Brushes.White;
                poprawne++;
            }
            else
            {
                PESEL_input.Background = Brushes.Red;
                wszystkoOk = false;
            }

            if (Imie_input.Text == "")
            {
                Imie_input.Background = Brushes.Red;
                wszystkoOk = false;
            }
            else
            {
                tempImie = DuzaLitera(Imie_input.Text);
                Imie_input.Background = Brushes.White;
                poprawne++;
            }

            if (Imie2_input.Text != "")
            {
                tempImie2 = DuzaLitera(Imie2_input.Text);
            }

            if (Nazwisko_input.Text == "")
            {
                Nazwisko_input.Background = Brushes.Red;
                wszystkoOk = false;
            }
            else
            {
                tempNazwisko = DuzaLitera(Nazwisko_input.Text);
                Nazwisko_input.Background = Brushes.White;
                poprawne++;
            }

            if (DataUrodzenia_input.Text == "")
            {
                DataUrodzenia_input.Background = Brushes.Red;
                wszystkoOk = false;
            }
            else
            {
                tempDataUrodzenia = DataUrodzenia_input.Text;
                DataUrodzenia_input.Background = Brushes.White;
                poprawne++;
            }

            if (NumerTelefonu_input.Text != "")
            {
                tempTelefon = Telefon(NumerTelefonu_input.Text);
            }

            if (Adres_input.Text == "")
            {
                Adres_input.Background = Brushes.Red;
                wszystkoOk = false;
            }
            else
            {
                tempAdres = DuzaLitera(Adres_input.Text);
                Adres_input.Background = Brushes.White;
                poprawne++;
            }

            if (Miejscowosc_input.Text == "")
            {
                Miejscowosc_input.Background = Brushes.Red;
                wszystkoOk = false;
            }
            else
            {
                tempMiejscowosc = DuzaLitera(Miejscowosc_input.Text);
                Miejscowosc_input.Background = Brushes.White;
                poprawne++;
            }

            if (KodPocztowy_input.Text == "")
            {
                KodPocztowy_input.Background = Brushes.Red;
                wszystkoOk = false;
            }
            else
            {
                tempKodPocztowy = KodPocztowy_input.Text;
                KodPocztowy_input.Background = Brushes.White;
                poprawne++;
            }

            if (poprawne == 7 && wszystkoOk)
            {
                PESEL_Window1 = tempPesel;
                Imie_Window1 = tempImie;
                Imie2_Window1 = tempImie2;
                Nazwisko_Window1 = tempNazwisko;
                DataUrodzenia_Window1 = tempDataUrodzenia;
                NumerTelefonu_Window1 = tempTelefon;
                Adres_Window1 = tempAdres;
                Miejscowosc_Window1 = tempMiejscowosc;
                KodPocztowy_Window1 = tempKodPocztowy;

                this.Close();
            }
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
                    a = true;
                    this.Close();
                }
                else
                {
                    a = false;
                }
            } else
            {
                a = true;
                this.Close();
            }
        }
    }
}
