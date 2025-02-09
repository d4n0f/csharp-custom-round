using System;

internal class Program
{
    private static void Main(string[] args)
    {
        SzamBekeres();

        Console.ReadLine();
    }
    // Adatbekérésre szolgáló függvény
    private static void SzamBekeres()
    {
        bool kerekitesVege = false;
        while (!kerekitesVege)
        {
            Console.Write("Adj meg egy lebegőpontos számot: ");
            String bekertSzam = Console.ReadLine();

            /* Az alábbi függvények megvizsgálják a bekért számot és ha kell átírják, hogy megfeleljen a 
             * Kerekites() függvény követelményeinek és ne dobjanak Exceptiont */
            bekertSzam = TizedesvesszoVizsgalat(bekertSzam);
            bekertSzam = TobbNullaKivetele(bekertSzam);
            bekertSzam = VesszovelKezdodik(bekertSzam);

            if (bekertSzam == "0") // Nullával való osztás Exception
            {
                Console.WriteLine("A NULLÁVAL való osztást nem értelmezzük!\n");
                continue;
            }
            try
            {
                double ellenorzoSzam = Convert.ToDouble(bekertSzam);
            }
            catch (Exception) // Megnézi hogy használtunk-e számokon kívül mást is
            {
                Console.WriteLine("Ez nem egy szám volt!\n");
                continue;
            }
            if (!(bekertSzam.Contains(".") || bekertSzam.Contains(","))) // Ellenőrizzük, hogy lebegőpontos-e a szám
            {
                Console.WriteLine("Nem lebegőpontos számot adott meg!\n");
                continue;
            }
            

            int mennyire = 0;
            Console.Write("Add meg hogy hány tizedesjegyre kerekítsem (egész szám): ");
            try
            {
                mennyire = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception) // Megnézi hogy használtunk-e számokon kívül mást is
            {
                Console.WriteLine("Nem megfelelően adtad meg a kerekítési értéket!\n");
                continue;
            }

            Kerekites(bekertSzam, mennyire);

            Console.WriteLine("\nSzeretne még egy számot kerekíteni? I = igen | N = nem");
            String szeretneE = Console.ReadLine().ToUpper();
            Console.WriteLine(); // Új sor a jobb átláthatóság érdekében

            if (szeretneE == "N") // Ha a felhasználó már nem szeretne több számot kerekíteni akkor vége a ciklusnak
            {
                kerekitesVege = true;
            }
        }
    }

    private static void Kerekites(String bekertSzamStr, int mennyire)
    {
        String[] seged = bekertSzamStr.Split(",");
        double bekertSzamDouble = Convert.ToDouble(bekertSzamStr);

        // Vizsgálás, műveletek elvégzése

        // 1. Ha annyi tizedesjegyre kell kerekíteni ahány alapjáraton van
        if (mennyire == seged[1].Length)
        {
            Console.WriteLine("{0}{1}", Elojel(bekertSzamStr), Math.Abs(Convert.ToDouble(bekertSzamStr)));
        }

        // 2. Ha több tizedesjegyre kell kerekíteni, mint ahány alapjáraton van
        if (mennyire > seged[1].Length)
        {
            string eredmeny = new string('0', mennyire - seged[1].Length);   // Kiegészíti a , utáni számokat hogy annyi legyen ahány volt a megadott kerekítési szám
            Console.WriteLine("{0}{1}{2}", Elojel(bekertSzamStr), Math.Abs(Convert.ToDouble(bekertSzamStr)), eredmeny);
        }

        // 3. Ha kevesebbre, de pozitív számra kell
        if (mennyire < seged[1].Length && mennyire > 0)
        {
            String seged2 = bekertSzamStr;
            bekertSzamStr = seged[0] + ",";
            for (int i = 0; i < mennyire; i++)
            {
                bekertSzamStr += seged[1][i];
            }

            // Kerekítés
            if (bekertSzamDouble - Convert.ToDouble(bekertSzamStr) >= 5 / Math.Pow(10, mennyire + 1))
            {
                bekertSzamDouble = Convert.ToDouble(bekertSzamStr);
                bekertSzamDouble += 1 / Math.Pow(10, mennyire);
                bekertSzamStr = Convert.ToString(bekertSzamDouble);

                Console.WriteLine("{0}{1}", Elojel(bekertSzamStr), Math.Abs(Convert.ToDouble(bekertSzamStr)));
            }
            else
            {
                Console.WriteLine("{0}{1}", Elojel(bekertSzamStr), Math.Abs(Convert.ToDouble(bekertSzamStr)));
            }
        }

        // 4. Ha 0 tizedes jegyre kell kerekíteni
        if (mennyire == 0)
        {
            if (Convert.ToInt32(seged[1]) / Math.Pow(10, seged[1].Length) >= 0.5)
            {
                Console.WriteLine("{0}{1}", Elojel(bekertSzamStr), Math.Abs(Convert.ToDouble(seged[0] + 1)));
            }
            else
            {
                Console.WriteLine("{0}{1}", Elojel(bekertSzamStr), Math.Abs(Convert.ToDouble(seged[0])));
            }
        }

        // 5. Ha negatívra kell kerekíteni
        if (mennyire < 0)
        {   
            /* Ha a tizedesvessző előtt lévő számok hossza kisebb, mint az a szám amire kerekíteni kellene, 
             * akkor annyi nullát ír ki ahány db szám van a tizedesvessző előtt*/
            if (seged[0].ToString().Length < Math.Abs(mennyire))
            {
                int db = seged[0].ToString().Length;

                for (int i = 0; i < db; i++)
                {
                    Console.Write("0");
                }
            }
            else
            {
                // Ha a tizedesvessző előtti számjegyek hossza elég hosszú
                String segedvaltozo = seged[0]; // Elmentjük a szám első részét
                bekertSzamStr = ""; // Lenullázzuk az eredeti számunkat

                for (int i = 0; i < segedvaltozo.Length + mennyire; i++)
                {
                    bekertSzamStr += segedvaltozo[i]; // Hozzáadjuk a plusz kerekítési helyeket
                }

                String eredmeny2 = new String('0', Math.Abs(mennyire)); // Ez a változó annyi nullát tárol ahány számra kerekítünk
                

                String ujszam = bekertSzamStr;
                bekertSzamStr = ujszam + eredmeny2; // Hozzáfűzzük a nullákat

                // Kerekítés
                if (bekertSzamDouble - Convert.ToDouble(bekertSzamStr) > 5 * (Math.Pow(10, Math.Abs(mennyire) - 1)))
                {
                    bekertSzamDouble = Convert.ToDouble(bekertSzamStr);
                    bekertSzamDouble += Math.Pow(10, Math.Abs(mennyire));
                    bekertSzamStr = Convert.ToString(bekertSzamDouble);
                    Console.WriteLine("{0}{1}", Elojel(bekertSzamStr), Math.Abs(Convert.ToDouble(bekertSzamStr)));
                }
                else
                {
                    Console.WriteLine("{0}{1}", Elojel(bekertSzamStr), Math.Abs(Convert.ToDouble(bekertSzamStr)));
                }
            }
        }
    }

    // Ha vesszővel kezdődik a számunk, akkor beilleszt egy nullát az elejére
    private static String VesszovelKezdodik(String bekertSzam)
    {
        if (bekertSzam[0] == ',')
        {
            return "0" + bekertSzam;
        }
        return bekertSzam;
    }

    // Ha több 0 van a tizedesvessző előtt és a szám nagyobb mint egy, akkor kiveszi a szám elejéről a nullákat
    private static String TobbNullaKivetele(String bekertSzam)
    {
        while (bekertSzam.Length > 1 && bekertSzam[0] == '0' && bekertSzam.IndexOf(',') != 1)
        {
            bekertSzam = bekertSzam.Remove(0, 1);
        }
        return bekertSzam;
    }

    // Visszaadja a bekért számunk előjelét
    private static String Elojel(String bekertSzam)
    {
        if (bekertSzam[0] == '-')
        {
            return "-"; //Ha negatív a szám
        }
        return ""; //Ha pozitív a szám
    }

    // Megvizsgálja, hogy lebegőpontos-e a bekért számunk
    private static String TizedesvesszoVizsgalat(String bekertSzam)
    {
        if (!bekertSzam.Contains(","))    // Megvizsgáljuk, hogy van-e a bekért számunkban ","
        {
            bekertSzam = bekertSzam.Replace('.', ','); // Kicseréljük a pontot vesszőre
        }
        return bekertSzam;
    }
}