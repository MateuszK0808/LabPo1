using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabPo1
{
    public class Samochod//.......................................................................................................
    {

        private string marka;
        private string model;
        private int iloscDrzwi;
        private int pojemnoscSilnika;
        private double srednieSpalanie;
        private static int iloscSamochodow = 0;
        private string numberRejstracyjny;


        public Samochod() //konstruktor domyślny 
        {
            marka = "nieznana";
            model = "nieznany";
            iloscDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0.0;
            iloscSamochodow++;
            numberRejstracyjny = "nieznana";
        }

        public Samochod(string marka_, string model_, int iloscDrzwi_, int pojemnoscSilnika_, double srednieSpalanie_, string numberRejstracyjny_) //konstruktor przyjmujący paramtery 
        {
            marka = marka_;
            model = model_;
            iloscDrzwi = iloscDrzwi_;
            pojemnoscSilnika = pojemnoscSilnika_;
            srednieSpalanie = srednieSpalanie_;
            iloscSamochodow++;
            numberRejstracyjny = numberRejstracyjny_;
        }

        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int IloscDrzwi
        {
            get { return iloscDrzwi; }
            set { iloscDrzwi = value; }
        }

        public int PojemnoscSilnika
        {
            get { return pojemnoscSilnika; }
            set { pojemnoscSilnika = value; }
        }

        public double SrednieSpalanie
        {
            get { return srednieSpalanie; }
            set { srednieSpalanie = value; }
        }

        public string NumberRejstracyjny
        {
            get { return numberRejstracyjny; }
            set { numberRejstracyjny = value; }
        }


        private double ObliczSpalanie(double dlugoscTrasy)
        {
            double spalanie = (srednieSpalanie * dlugoscTrasy) / 100.0;
            return spalanie;
        }


        public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa)
        {
            double spalanie = ObliczSpalanie(dlugoscTrasy);
            double kosztprzejazdu = spalanie * cenaPaliwa;
            return kosztprzejazdu;
        }


        public void WypiszInfo()
        {
            Console.WriteLine("Marka: " + Marka);
            Console.WriteLine("Model: " + Model);
            Console.WriteLine("Ilość drzwi: " + IloscDrzwi);
            Console.WriteLine("Pojemność silnika: " + PojemnoscSilnika);
            Console.WriteLine("Średnie spalanie: " + SrednieSpalanie);
            Console.WriteLine("nrRejstracyjny: " + NumberRejstracyjny);
        }


        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine("Ilość samochodów: " + iloscSamochodow);
        }


    }//............................


    public class Garaz
    {
        private string adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod[] samochody;

        public Garaz()
        {
            Adres = "nieznany";
            Pojemnosc = 0;
            samochody = null;
        }

        public Garaz(string adres_, int pojemnosc_)
        {
            Adres = adres_;
            Pojemnosc = pojemnosc_;
        }

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        public int Pojemnosc
        {
            get { return pojemnosc; }
            set
            {
                pojemnosc = value;
                samochody = new Samochod[pojemnosc];
            }
        }

        public void WprowadzSamochod(Samochod samochod)
        {
            if (samochody.Length > liczbaSamochodow)
            {
                samochody[liczbaSamochodow] = samochod;
                liczbaSamochodow++;
            }
            else
            {
                Console.WriteLine("Garaż jest pełny");
            }

        }

        public Samochod WyprowadzSamochod()
        {
            if (liczbaSamochodow > 0)
            {
                liczbaSamochodow--;
                Samochod samochod = samochody[liczbaSamochodow];
                samochody[liczbaSamochodow] = null;
                return samochod;
            }
            else
            {
                Console.WriteLine("Garaż jest pusty");
                return samochody[liczbaSamochodow];
            }
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Adres: " + Adres);
            Console.WriteLine("Pojemnosc: " + Pojemnosc);
            Console.WriteLine("Liczba samochodów: " + liczbaSamochodow);
            Console.WriteLine("Samochody: ");

            for (int i = 0; i < liczbaSamochodow; i++)
            {
                samochody[i].WypiszInfo();
            }
        }
    }//...............................................................................................................................

    public class Osoba
    {
        private string imie;
        private string nazwisko;
        private string adresZamieszkania;
        private int iloscSamochodow = 0;
        private string[] samochody = new string[3];

        public Osoba()
        {
            imie = "nieznane";
            nazwisko = "nieznane";
            adresZamieszkania = "nieznany";
        }

        public Osoba(string imie_, string nazwisko_, string adresZamieszkania_)
        {
            imie = imie_;
            nazwisko = nazwisko_;
            adresZamieszkania = adresZamieszkania_;
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }
        public string AdresZamieszkania
        {
            get { return adresZamieszkania; }
            set { adresZamieszkania = value; }
        }

        public void DodajSamochod(string nrRejstracyjny)
        {
            if (iloscSamochodow < 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (samochody[i] == null)
                    {
                        samochody[i] = nrRejstracyjny;
                        iloscSamochodow++;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Jedna osoba nie może posiadać więcej samochodów");
            }
        }
        public void UsunSamochod(string nrRejstracyjny)
        {
            for (int i = 0; i < 3; i++)
            {
                if (samochody[i] == nrRejstracyjny)
                {
                    samochody[i] = null;
                    iloscSamochodow--;
                    break;
                }
            }
        }
        public void WypiszInfo()
        {
            Console.WriteLine("Imie: " + Imie);
            Console.WriteLine("Nazwisko: " + Nazwisko);
            Console.WriteLine("Adres zamieszkania: " + AdresZamieszkania);
            if (iloscSamochodow > 0)
            {
                Console.WriteLine("Samochody: ");
            }
            for (int i = 0; i < 3; i++)
            {
                if (samochody[i] != null)
                {
                    Console.WriteLine("  - " + samochody[i]);
                }
            }
            Console.WriteLine();
        }
    }     //..........................................................................................................

    class Program //>>>> Klasa TESTUJACA2 <<<< ....................................................................
    {
        static void Main(string[] args)
        {
            Zadanie1();
            Zadanie2();
            ZadanieDomowe();
        }
        static void Zadanie1()
        {
            Console.WriteLine("Zadanie 1- Sprawdzenie.............................................................. ");
            Samochod s1 = new Samochod();
            s1.WypiszInfo();
            s1.Marka = "Fiat";
            s1.Model = "126p";
            s1.IloscDrzwi = 2;
            s1.PojemnoscSilnika = 650;
            s1.SrednieSpalanie = 6.0;
            s1.WypiszInfo();
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6, "ABC");
            s2.WypiszInfo();
            double kosztPrzejazdu = s2.ObliczKosztPrzejazdu(30.5, 4.85);
            Console.WriteLine("Koszt przejazdu: " + kosztPrzejazdu);
            Samochod.WypiszIloscSamochodow();
            Console.WriteLine("Zadanie 1- Koniec Sprawdzenia.............................................................. ");
            Console.ReadKey();
        }  // >>>> Koniec Metody Testującej <<<< ......................................................................

        static void Zadanie2()
        {
            Console.WriteLine("Zadanie 2- Sprawdzenie..............................................................");
            Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0, "ABC");
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6, "ABC");
            Garaz g1 = new Garaz();
            g1.Adres = "ul. Garażowa 1";
            g1.Pojemnosc = 1;
            Garaz g2 = new Garaz("ul. Garażowa 2", 2);
            g1.WprowadzSamochod(s1);
            g1.WypiszInfo();
            g1.WprowadzSamochod(s2);
            g2.WprowadzSamochod(s2);
            g2.WprowadzSamochod(s1);
            g2.WypiszInfo();
            g2.WyprowadzSamochod();
            g2.WypiszInfo();
            g2.WyprowadzSamochod();
            g2.WyprowadzSamochod();
            Console.WriteLine("Zadanie 2- Koniec Sprawdzenia.............................................................. ");
            Console.ReadKey();
        }  // >>>> Koniec Metody Testującej <<<< ......................................................................

        public static void ZadanieDomowe()
        {
            Console.WriteLine("Zadanie domowe- Sprawdzenie..............................................................");
            Samochod s1 = new Samochod("Fiat", "126p", 2, 650, 6.0, "ABC 123");
            Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6, "CDE 456");
            Osoba osoba1 = new Osoba();
            osoba1.WypiszInfo();
            osoba1.Imie = "Adam";
            osoba1.Nazwisko = "Nowak";
            osoba1.AdresZamieszkania = "Jakis adres";
            osoba1.WypiszInfo();
            Osoba osoba2 = new Osoba("Jan", "Kowalski", "ul. Lipowa 1");
            osoba2.WypiszInfo();
            osoba2.DodajSamochod(s1.NumberRejstracyjny);
            osoba2.DodajSamochod(s2.NumberRejstracyjny);
            osoba2.WypiszInfo();
            osoba2.DodajSamochod("AVD 627");
            osoba2.DodajSamochod("GGH 009");
            osoba2.UsunSamochod(s1.NumberRejstracyjny);
            osoba2.WypiszInfo();
            Console.WriteLine("Zadanie domowe- Koniec Sprawdzenia.............................................................. ");
            Console.ReadKey();
        }  // >>>> Koniec Metody Testującej <<<< ......................................................................
    }  

}
