namespace Kovacs_Istvan_12_console
{
    internal class Program
    {
        static List<Konyv> konyvek = new List<Konyv>();
        static List<Vasarlo> vasarlok = new List<Vasarlo>();
        static void Main(string[] args)
        {
            adatokBetoltese();
            feladat01();
            feladat02();
            feladat03();
            Console.WriteLine("Program vége");
            Console.ReadKey();
        }

        private static void feladat03()
        {
            int legdragabb = konyvek.Max(x => x.Ar);
            Console.WriteLine($"2. feladat: A legdrágább könyv: {konyvek.Find(x => x.Ar == legdragabb).Cim}: {legdragabb} Ft");
        }

        private static void feladat02()
        {
            Console.WriteLine($"3. feladat: Doyle Arthur Conan");
            konyvek.Where(x => x.Szerzo == "Doyle Arthur Conan").ToList().ForEach(x => Console.WriteLine($"\t{x.Cim}"));
        }

        private static void feladat01()
        {
            Console.WriteLine($"1. feladat: Beolvasott könyvek száma: {konyvek.Count}");
        }

        private static void adatokBetoltese()
        {
            Database db = new Database();

            konyvek.AddRange(db.getKonyv());
            vasarlok.AddRange(db.getVasarlo());
        }
    }
}