using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Lab._7
{
    class Program
    {
        public interface IPrintable
        {
            void Print();
        }
        
        private static readonly Random random = new Random();
        
        class Pierwsza : ICloneable, IComparable<Pierwsza>, IPrintable
        {
            public int Id;
            public string Tekst;
            public int[] Tab = new int [10];
            
            public Pierwsza(int Id, string Tekst, int[] Tab)
            {
                this.Id = Id;
                this.Tekst = Tekst;
                this.Tab = Tab;
            }
            
            public object Clone()
            {
                int[] tabKopia = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    tabKopia[i] = Tab[i];
                }
                return new Pierwsza(Id, Tekst, tabKopia);
                
            }
            
            public int CompareTo(Pierwsza other)
            {

                return Tekst.CompareTo(other.Tekst);

            }
            
            public void Print()
            {
                Console.WriteLine($"Id: {Id}");
                Console.WriteLine($"Tekst: {Tekst}");
                for (int i = 0; i < Tab.Length; i++)
                {
                    Console.WriteLine($"Element tablicy [{i}] = {Tab[i]}");
                }
            }
        }
        public static void wypelnij()
        {
            Pierwsza[] pierwsza = new Pierwsza[100];
            
            for (int i = 0; i < 100; i++)
            {
                string text = "";
                int[] tablica = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    tablica[j] = random.Next(1,20);
                }
                for (int k = 0; k < 10; k++)
                {
                    text += (char)random.Next('a', 'z');
                }
                pierwsza[i] = new Pierwsza(i,text,tablica);
               
            }

            List<Pierwsza> klonTab = new List<Pierwsza>();

            for (int i = 0; i < 100; i++)
            {
                klonTab.Add((Pierwsza)pierwsza[i].Clone());

                for (int j = 0; j < 10; j++)
                {
                    pierwsza[i].Tab[j] = 0;
                }
            }
            
            klonTab.Sort();
            
            for (int i = 0; i < 100; i++)
            {
                klonTab[i].Print();
            }
        }
        static void Main(string[] args)
        {
            wypelnij();
        }
    }
}