using System;

namespace Lab._2
{
    class Program
    {
        public enum Result
        {
            Mz0,
            Mz1,
            Mz2
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj liczbe a:");
            string a = Console.ReadLine();
            Console.WriteLine("Podaj liczbe b:");
            string b = Console.ReadLine();
            Console.WriteLine("Podaj liczbe c:");
            string c = Console.ReadLine();
            
            bool checkA = double.TryParse(a, out double numberA);
            bool checkB = double.TryParse(b, out double numberB);
            bool checkC = double.TryParse(c, out double numberC);
            
            if (checkA == true && checkB == true && checkC == true)
            {
                double delta = (double)Math.Pow(numberB, 2) - 4 * (numberA * numberC);

                Console.WriteLine($"Twoja delta wynosi: {delta}");

                double pdelta = Math.Sqrt(delta);
                
                Result result; 

                if (delta < 0)
                {
                    result = Result.Mz0;
                }
                else if(delta == 0)
                {
                    result = Result.Mz1;
                }
                else
                {
                    result = Result.Mz2;
                }
                
                switch (result)
                {
                    case Result.Mz0:
                            Console.WriteLine("Brak miejsc zerowych");
                            break;
                    case Result.Mz1:
                            Console.WriteLine("Jedno miejsce zerowe");
                            Console.WriteLine("Miejsce zerowe wynosi: " + (-numberB-pdelta/2*numberB));
                            break;
                    case Result.Mz2:
                            Console.WriteLine("Dwa miejsca zerowe");
                            Console.WriteLine("Miejsce zerowe 1 wynosi: " + (-numberB-pdelta/2*numberB));
                            Console.WriteLine("Miejsce zerowe 2 wynosi: " + (-numberB+pdelta/2*numberB));
                        break;
                    default:
                            Console.WriteLine("Nothing");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Można tylko podawać liczby!");
            }
        }
    }
}