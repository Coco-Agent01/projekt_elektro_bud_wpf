
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace projekt_elektro_bud_wpf
{
    public partial class MainWindow : Window
    {
        // Klasa opisująca produkt i jego lokalizację w magazynie
        public class Produkt
        {
            public string Nazwa { get; set; }
            public string EAN { get; set; }
            public string Sektor { get; set; }
            public string Regal { get; set; }
            public string Polka { get; set; }

            // Konstruktor przypisuje dane produktu i miejsce przechowywania
            public Produkt(string nazwa, string ean,
                           string sektor, string regal, string polka)
            {
                Nazwa = nazwa;
                EAN = ean;
                Sektor = sektor;
                Regal = regal;
                Polka = polka;
            }
        }

        // Lista produktów znajdujących się w magazynie
        // Lokalizacje są przykładowe i można je zmienić
        List<Produkt> produkty = new List<Produkt>()
        {
            new Produkt("Kabel elektryczny", "5901234567890",
                        "Sektor 1", "Regał 1", "Półka 1"),

            new Produkt("Gniazdko elektryczne", "5909876543210",
                        "Sektor 2", "Regał 1", "Półka 2"),

            new Produkt("Żarówka LED", "5901111222233",
                        "Sektor 3", "Regał 2", "Półka 1")
        };

        // Uruchomienie głównego okna aplikacji
        public MainWindow()
        {
            InitializeComponent();

            // Po uruchomieniu wyświetla wszystkie trzy produkty
            listaProduktow.ItemsSource = produkty;
        }

        // Wyszukiwanie po nazwie lub kodzie EAN
        private void szukaj_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Pobiera tekst wpisany w wyszukiwarce
            string tekst = szukaj.Text.Trim();

            // Wybiera produkty pasujące do nazwy lub kodu EAN
            listaProduktow.ItemsSource = produkty
                .Where(p =>
                    p.Nazwa.Contains(
                        tekst,
                        System.StringComparison.OrdinalIgnoreCase)
                    || p.EAN.Contains(tekst))
                .ToList();
        }
    }
}

/*
Źródła:
Microsoft Learn – Dokumentacja języka C#.
Microsoft Learn - Również do zrozumienia xaml 
Chat gpt który dał kod początkowy żebym nie zaczynał od zera oraz użycie go do debugowania i zrozumienia troche bardziej poszczególnych linijek kodu 
*/