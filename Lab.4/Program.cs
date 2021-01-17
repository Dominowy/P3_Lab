using System;

namespace Lab._4
{
    public class Ksiazka
    {
        public string Tytul {set; get;}
        public string Autor {set; get;}
        public int Regal;
        public int Polka;
        public int Miejsce;


        public Ksiazka(string tytul, string autor, int regal, int polka, int miejsce)
        {
            Tytul = tytul;
            Autor = autor;
            Regal = regal;
            Polka = polka;
            Miejsce = miejsce;
        }
            
        public void Wypisz()
        {
            Console.WriteLine("Tytuł: {0} \n Autor: {1} \n Regał: {2} \n Półka: {3} \n Miejsce: {4}"
                , Tytul, Autor, Regal, Polka, Miejsce);
        }

        public void Zmien(string tytul, string autor)
        {
            Tytul = tytul;
            Autor = autor;
        }
    }
    class Program
    {
        static void Wyszukaj(Ksiazka [,,] biblio , string nazwa)
        {
            for (int i = 0; i < biblio.GetLength(0); i++)
            {
                for (int j = 0; j <  biblio.GetLength(1); j++)
                {
                    for (int k = 0; k <  biblio.GetLength(2); k++)
                    {
                        if (biblio[i,j,k].Tytul.Contains(nazwa, StringComparison.OrdinalIgnoreCase) || 
                            biblio[i,j,k].Autor.Contains(nazwa, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("Tytuł: {0} \n Autor: {1} \n Regał: {2} \n Półka: {3} \n Miejsce: {4}"
                                , biblio[i,j,k].Tytul, biblio[i,j,k].Autor, biblio[i,j,k].Regal, biblio[i,j,k].Polka, biblio[i,j,k].Miejsce);
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("Brak wpisanego tytułu");
        }
        
        static void Main()
        {
            Ksiazka [ , , ] nowaKsiazka = new Ksiazka[3,6,10];

            for (int i = 0; i < nowaKsiazka.GetLength(0); i++)
            {
                for (int j = 0; j <  nowaKsiazka.GetLength(1); j++)
                {
                    for (int k = 0; k <  nowaKsiazka.GetLength(2); k++)
                    {
                        nowaKsiazka[i, j, k] = new Ksiazka("Kroniki Diuny", "Frank Herbert", i, j, k);
                    }
                }
            }
            
            nowaKsiazka[2, 5, 7].Zmien("Władca Pierscieni - Dwie Wieże", "J.R.R Tolkien");

            Console.WriteLine("Wpisz tytuł lub autora: ");
            string nazwa = Console.ReadLine();

            Wyszukaj(nowaKsiazka, nazwa);
        }
    }
}