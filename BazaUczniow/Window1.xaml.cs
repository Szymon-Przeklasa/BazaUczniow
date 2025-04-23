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
            string DuzaLitera(string slowo)
            {
                if(slowo != Adres_input.Text)
                {
                    slowo = slowo.Replace(" ", "");
                }
                string duza = slowo[0].ToString().ToUpper();
                string reszta = slowo.Substring(1);
                slowo = duza + reszta;
                return slowo;
            }
            string Telefon(string numer_telefonu)
            {
                numer_telefonu = numer_telefonu.Replace(" ", "");
                if(!numer_telefonu.StartsWith("+48"))
                {
                    numer_telefonu = "+48" + numer_telefonu;
                }
                return numer_telefonu;
            }
            bool CzyPrzestepny(int rok)
            {
                return rok % 4 == 0;
            }
            bool SprawdzPesel(string pesel)
            {
                if(pesel.Length != 11)
                {
                    return false;
                } else
                {
                    int[] cyfry = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                    for(int i = 0; i < pesel.Length; i++)
                    {
                        if (!cyfry.Contains(pesel[i]))
                        {
                            return false;
                        }
                    }

                    int rok = Int32.Parse(pesel.Substring(0, 2));
                    int miesiac = Int32.Parse(pesel.Substring(2, 2));
                    int dzien = Int32.Parse(pesel.Substring(4, 2));

                    if (miesiac >= 1 && miesiac <= 12)
                    {
                        rok += 1900; // Rok: 1900-1999
                    }
                    else if (miesiac >= 21 && miesiac <= 32)
                    {
                        miesiac -= 20;
                        rok += 2000; // Rok: 2000-2099
                    }
                    else if (miesiac >= 41 && miesiac <= 52)
                    {
                        miesiac -= 40;
                        rok += 2100; // Rok: 2100-2199
                    }
                    else if (miesiac >= 61 && miesiac <= 72)
                    {
                        miesiac -= 60;
                        rok += 2200; // Rok: 2200-2299
                    }
                    else if (miesiac >= 81 && miesiac <= 92)
                    {
                        miesiac -= 80;
                        rok += 1800; // Rok: 1800-1899
                    }
                    else
                    {
                        return false; // Nieprawidłowy miesiąc
                    }

                    if (dzien < 1 || dzien > 31) return false;
                    if (miesiac == 4 || miesiac == 6 || miesiac == 9 || miesiac == 11)
                    {
                        if (dzien > 30)
                        {
                            return false;
                        }
                    }

                    if (miesiac == 2)
                    {
                        bool przestepny = CzyPrzestepny(rok);
                        if ((przestepny && dzien > 29) || (!przestepny && dzien > 28))
                        {
                            return false;
                        }
                    }
                    int[] wagi = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
                    int suma = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        suma += Int32.Parse(pesel[i].ToString()) * wagi[i];
                    }
                    int sumaKontrolna = (10 - suma % 10) % 10;
                    if (sumaKontrolna != Int32.Parse(pesel[10].ToString()))
                    {
                        return false;
                    }
                    int plecPesel = Int32.Parse(pesel[9].ToString()); ;
                    if (plecPesel % 2 != 0)
                    {
                        return false;
                    }
                    return true;
                }
            }
            int poprawne = 0;
            if(PESEL_input.Text == "")
            {
                PESEL_input.Background = Brushes.Red;
            } else
            {
                if (SprawdzPesel(PESEL_input.Text))
                {
                    PESEL_Window1 = PESEL_input.Text;
                    PESEL_input.Background = Brushes.White;
                    poprawne++;
                } else
                {
                    PESEL_input.Background = Brushes.Red;
                }
                
            }
            if(Imie_input.Text == "")
            {
                Imie_input.Background = Brushes.Red;
            } else
            {
                Imie_Window1 = DuzaLitera(Imie_input.Text);
                Imie_input.Background = Brushes.White;
                poprawne++;
            }
            if(Imie2_input.Text == "")
            {
                Imie2_Window1 = "-";
            } else
            {
                Imie2_Window1 = DuzaLitera(Imie2_input.Text);
            }
            if(Nazwisko_input.Text == "")
            {
                Nazwisko_input.Background = Brushes.Red;
            } else
            {
                Nazwisko_Window1 = DuzaLitera(Nazwisko_input.Text);
                Nazwisko_input.Background = Brushes.White;
                poprawne++;
            }
            if (DataUrodzenia_input.Text == "")
            {
                DataUrodzenia_input.Background = Brushes.Red;
            } else
            {
                DataUrodzenia_Window1 = DataUrodzenia_input.Text;
                DataUrodzenia_input.Background = Brushes.White;
                poprawne++;
            }
            if (NumerTelefonu_input.Text == "")
            {
                NumerTelefonu_Window1 = "-";
            } else
            {
                NumerTelefonu_Window1 = Telefon(NumerTelefonu_input.Text);
            }
            if (Adres_input.Text == "")
            {
                Adres_input.Background = Brushes.Red;
            } else
            {
                Adres_Window1 = DuzaLitera(Adres_input.Text);
                Adres_input.Background = Brushes.White;
                poprawne++;
            }
            if (Miejscowosc_input.Text == "")
            {
                Miejscowosc_input.Background = Brushes.Red;
            }
            else
            {
                Miejscowosc_Window1 = DuzaLitera(Miejscowosc_input.Text);
                Miejscowosc_input.Background = Brushes.White;
                poprawne++;
            }
            if (KodPocztowy_input.Text == "")
            {
                KodPocztowy_input.Background = Brushes.Red;
            }
            else
            {
                KodPocztowy_Window1 = KodPocztowy_input.Text;
                KodPocztowy_input.Background = Brushes.White;
                poprawne++;
            }
            if(poprawne == 7)
            {
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
