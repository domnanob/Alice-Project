namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Feladat

            Console.WriteLine("1.Feladat\nAdja meg, mennyi nevet szeretne tárolni!");
            bool szam_e = false;
            int szam = 0;
            while (szam_e == false)
            {
                szam_e = int.TryParse(Console.ReadLine(), out szam);
            }
            string[] nevek = new string[szam];
            Console.WriteLine("Kérem a neveket!");
            for (int i = 0; i < szam; i++)
            {
                nevek[i] = Console.ReadLine();
            }

            //2. Feladat
            Console.WriteLine("\n2. Feladat");

            int[] szamok = new int[100];
            for (int i = 0; i <= 95; i++)
            {
                szamok[i] = i + 5;
                if (szamok[i] % 4 == 0 && szamok[i] % 6 == 0) Console.Write($"{szamok[i]} ");
            }

            //3. Feladat

            Console.WriteLine("\n\n3. Feladat\nAdjon meg egy szavat!");
            string szo = Console.ReadLine();
            if (szo != "")
            {
                for (int i = 0; i < szo.Length; i++)
                {
                    Console.WriteLine(szo[i]);
                }
            }
            else
            {
                Console.WriteLine("Nem adott meg semmit!");
            }
        }
    }
}
