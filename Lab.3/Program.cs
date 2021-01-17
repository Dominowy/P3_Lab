using System;
using System.Text;

namespace Lab._3
{
    class Program
    {
        static void count(ref int[][] irregulartab)
        {
            int result = 0;

            for (int i = 0; i < irregulartab.Length; i++)
            {
                for (int j = 0; j < irregulartab.Length; j++)
                {
                    result += irregulartab[i][j];
                }
            }
            
            Console.WriteLine("Wynik = " + result);
        }

        static void CheckSentence(ref string sentenceCheck)
        {
            string s = char.ToUpper(sentenceCheck[0]) + sentenceCheck.Substring(1);
            
            if (s.EndsWith("."))
            {
                Console.WriteLine(s);
            }
            else
            {
                StringBuilder stringBuilder = new StringBuilder(s);
                stringBuilder.Append(".");
                Console.WriteLine(stringBuilder);  
            }
        }

        static void Main(string[] args)
        {
            int[][] irregular = new int[3][];
            Random rnd = new Random();
            

            for (int i = 0; i < irregular.Length; i++)
            {
                irregular[i] = new int[3];
            }

            for (int i = 0; i < irregular.Length; i++)
            {
                for (int j = 0; j < irregular[i].Length; j++)
                {
                    irregular[i][j] = rnd.Next(0, 5);
                }
            }
            
            for (int i = 0; i < irregular.Length; i++)
            {
                for (int j = 0; j < irregular[i].Length; j++)
                {
                    Console.WriteLine("[" + i + "][" + j + "]" + irregular[i][j]);
                }
            }
            
            count(ref irregular);
            
            Console.WriteLine("Napisz coś: ");
            string sentence = Console.ReadLine();
            CheckSentence(ref sentence);
        }
    }
}