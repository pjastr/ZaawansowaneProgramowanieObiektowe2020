using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZpoWyklad2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Osoba o1 = new Osoba(30, "Olsztyn"); //tworzy pierwszy obiekt i nadajemy mu wiek 30
            Osoba o2 = new Osoba(); //tworzymy drugi obiekt
            o2 = o1.GlebokaKopia(); //kopiowanie z uzyżciem głębokiej kopii

            //wartości po kopiowaniu
            Console.WriteLine("Wiek pierwszej osoby {0}", o1.PobierzWiek());
            Console.WriteLine("Miejsce urodzin pierwszej osoby {0}", o1.ur.PobierzMiejsceUr());
            Console.WriteLine("Wiek drugiej osoby {0}", o2.PobierzWiek());
            Console.WriteLine("Miejsce urodzin drugiej osoby {0}", o2.ur.PobierzMiejsceUr());

            o1.UstawWiek(31); //zmiana wieku pierwszej osoby
            o1.ur.UstawMiejsceUr("Gdańsk"); //zmiana miejsca urodzin pierwszej osoby

            //wartości po zmianie
            Console.WriteLine("Po zmianie");
            Console.WriteLine("Wiek pierwszej osoby {0}", o1.PobierzWiek());
            Console.WriteLine("Miejsce urodzin pierwszej osoby {0}", o1.ur.PobierzMiejsceUr());
            Console.WriteLine("Wiek drugiej osoby {0}", o2.PobierzWiek());
            Console.WriteLine("Miejsce urodzin drugiej osoby {0}", o2.ur.PobierzMiejsceUr());

            //sprawdzenie referencji
            if (Object.ReferenceEquals(o1.ur, o2.ur))
                Console.WriteLine("Referencje odwołują się do tego samego obiektu");
            else
                Console.WriteLine("Referencje nie odwołują się do tego samego obiektu");
            Console.ReadKey();
        }
    }

    class Urodziny
    {
        private string miejsceUr; //deklaracja pola
        public Urodziny() { } //konstruktor domyślny

        //konstruktor parametryczny
        public Urodziny(string miejsceUr)
        {
            this.miejsceUr = miejsceUr;
        }

        //metoda na ustawienie miejsca urodzin
        public void UstawMiejsceUr(string miejsceUr)
        {
            this.miejsceUr = miejsceUr;
        }

        //metoda na pobranie miejsca urodzenia
        public string PobierzMiejsceUr()
        {
            return miejsceUr;
        }
    }

    class Osoba
    {
        private int wiek; //deklaracja pola
        public Urodziny ur; //pole referencyjne

        //konstruktor domyślny (uzupełniamy o tworzenie obiektu)
        public Osoba()
        {
            ur = new Urodziny();
        }

        //konstruktor parametryczny
        public Osoba(int wiek, string miejsce)
        {
            this.wiek = wiek;
            ur = new Urodziny();
            ur.UstawMiejsceUr(miejsce);
        }

        public void UstawWiek(int wiek) //metoda na ustawienie wieku
        {
            this.wiek = wiek;
        }

        public int PobierzWiek() //metoda na pobranie wieku
        {
            return wiek;
        }

        public Osoba GlebokaKopia() //implementacja głębokiej kopii
        {
            Osoba tempOsoba = new Osoba();
            tempOsoba.wiek = this.wiek;
            tempOsoba.ur.UstawMiejsceUr(this.ur.PobierzMiejsceUr());
            return tempOsoba;

        }

    }


}
