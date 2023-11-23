using System;
using System.Globalization;
using System.IO;

namespace LebronGemis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            String dobasokFile = "dobasok.txt";
            string osvenyekFile = "osvenyek.txt";
            List<string> dobasok = new List<string>();
            List<string> osvenyek = new List<string>();
            dobasok = File.ReadAllLines(dobasokFile).ToList();
            osvenyek = File.ReadAllLines(osvenyekFile).ToList();
            dobasok = dobasok[0].Split(' ').ToList();

            //2
            Console.WriteLine("2. feladat");
            Console.WriteLine("A dobasok.txt " + dobasok.Count + " elemet tartalmaz");
            Console.WriteLine("Az osvenyek.txt " + osvenyek.Count + " elemet tartalmaz");

            //3
            Console.WriteLine();
            int osvenyIndex = 0;
            int osvenyekHossza = osvenyek[0].Length;
            for (int i = 1; i < osvenyek.Count; i++)
            {
                if (osvenyek[osvenyIndex].Length < osvenyek[i].Length)
                {
                    osvenyIndex = i;
                }
            }
            osvenyekHossza = osvenyek[osvenyIndex].Length;
            osvenyIndex++;
            Console.WriteLine("3. feladat");
            Console.WriteLine("Az egyik leghosszabb a(z) " + osvenyIndex + ". ösvény, hossza: " + osvenyekHossza);

            //4
            Console.WriteLine();

            Console.Write("Adja meg egy ösvény sorszámát! ");
            int osvenySzama = int.Parse(Console.ReadLine());
            while (true)
            {

                if (osvenySzama > osvenyek.Count || osvenySzama < 0)
                {
                    Console.WriteLine("Nem megfelelő szám!");
                    Console.Write("Adja meg egy ösvény sorszámát! ");
                    osvenySzama = int.Parse(Console.ReadLine());
                }
                if (osvenySzama <= osvenyek.Count && osvenySzama >= 0)
                {
                    break;
                }

            }
            osvenySzama--;
            Console.Write("Adja meg a játékosok számát! ");

            int jatekosokSzama = int.Parse(Console.ReadLine());
            while (true)
            {
                if (jatekosokSzama < 2 || jatekosokSzama > 5)
                {
                    Console.Write("Adja meg a játékosok számát! ");
                    Console.WriteLine("Nem megfelelő szám!");
                    jatekosokSzama = int.Parse(Console.ReadLine());
                }
                if (jatekosokSzama >= 2 && jatekosokSzama <= 5)
                {
                    break;
                }
            }

            //5
            Console.WriteLine();
            string osvenyVizsgalat;
            osvenyVizsgalat = osvenyek[osvenySzama];
            int E = osvenyVizsgalat.Split('E').Length - 1;
            int V = osvenyVizsgalat.Split('V').Length - 1;
            int M = osvenyVizsgalat.Split('M').Length - 1;



            Console.WriteLine("5. feladat");
            if (M > 0)
            {
                Console.WriteLine("M: " + M + " darab");
            }
            if (V > 0)
            {
                Console.WriteLine("V: " + V + " darab");
            }
            if (E > 0)
            {
                Console.WriteLine("E: " + E + " darab");
            }

            //6
            Console.WriteLine();
            List<string> fileKi = new List<string>();

            for (int i = 0; i < osvenyVizsgalat.Length; i++)
            {
                if (osvenyVizsgalat[i] == 'V' || osvenyVizsgalat[i] == 'E')
                {
                    string kiSor = i + "\t" + osvenyVizsgalat[i];
                    fileKi.Add(kiSor);
                }
            }
            File.WriteAllLines("kulonleges.txt", fileKi.ToArray());

            //7
            Console.WriteLine();
            int kor = 0;
            int nyertesJatelkos = -1;
            int mostDobas = 0;
            List<int> jatekosok = new List<int>();
            for (int i = 0; i < jatekosokSzama; i++)
            {
                jatekosok.Add(0);
            }
            while (true)
            {
                kor++;
                for (int i = 0; i < jatekosokSzama; i++)
                {
                    jatekosok[i] += Convert.ToInt32(dobasok[mostDobas]);
                    mostDobas++;
                    if (jatekosok[i] >= osvenyVizsgalat.Length)
                    {
                        nyertesJatelkos = i;
                        break;
                    }
                }
                if (nyertesJatelkos != -1)
                {
                    break;
                }
            }
            Console.WriteLine("7. feladat");
            Console.WriteLine($"A játék a(z) {kor}. körben fejeződött be. A legtávolabb jutó(k) sorszáma: {nyertesJatelkos+1}");
        }
    }
}