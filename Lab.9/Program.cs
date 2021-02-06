using System;
using System.Collections.Generic;

namespace Lab._9
{
    public class Uzytkownik
    {
        public int id;
        public string nazwa;

        public Uzytkownik(int Id ,string Nazwa)
        {
            id = Id;
            nazwa = Nazwa;
        }

        public void subskrybujKanal(Kanal kanal)
        {
            kanal.Subskrybuj();
            kanal.wyswietlFilm(1);
            kanal.OpublikowanoFilm += Opublikowanofilm;
        }
        
        private void Opublikowanofilm(object sender, EventArgs e)
        {
            Console.WriteLine("Użyktownik " + nazwa + " otrzymał powiadomnienie o nowym filmie.");
        }
    }
    
    public class Kanal
    {
        public int id;
        public string nazwa;
        public int licznikWyswietlen;
        public int subskrypcje;
        public event EventHandler OpublikowanoFilm;
        
        public Kanal(int Id, string Nazwa)
        {
            id = Id;
            nazwa = Nazwa;
        }
        
        public void wyswietlFilm(int id)
        {
            licznikWyswietlen++;
        }

        public void opublikujFilm()
        {
            OpublikowanoFilm.Invoke(this, EventArgs.Empty);
        }

        public void Subskrybuj()
        {
            subskrypcje++;
        }
        
        public void ExtensionMethod(Kanal kanal)
        {
            Console.WriteLine($"Nazwa kanalu: {kanal.nazwa},\n" +
                              $"{kanal.subskrypcje} Subskrybujących\n" +
                              $"{kanal.licznikWyswietlen} Wyświetleń");

        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Uzytkownik> uzytkownicy = new List<Uzytkownik>();
            uzytkownicy.Add(new Uzytkownik(1,"Jacek"));
            uzytkownicy.Add(new Uzytkownik(2,"Grzegorz"));
            uzytkownicy.Add(new Uzytkownik(3,"Maciek"));
            uzytkownicy.Add(new Uzytkownik(4,"Arnold"));
            Kanal kanal = new Kanal(1,"Dovhakin");
            
            foreach (var value in uzytkownicy) 
            {
                value.subskrybujKanal(kanal);
            }
            
            kanal.opublikujFilm();
            kanal.ExtensionMethod(kanal);
            
        }
    }
}
