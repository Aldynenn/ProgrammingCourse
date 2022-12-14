using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingCourse
{
    class Program
    {
        static List<CourseData> data = new List<CourseData>();

        static void Main(string[] args)
        {
            MasodikFeladat();
            HarmadikFeladat();
            NegyedikFeladat();
            OtodikFeladat();
            HatodikFeladat();

            Console.ReadKey();
        }

        private static void HatodikFeladat()
        {
            Console.WriteLine($"6. feladat:\n" +
                $"\tÁllásajánlatot kap:");
            var tanulok = (from d in data where d.code == 2 && d.paidSum == 0 && d.results.Values.Min(x => x) >= 51 select d).ToList();
            foreach (var tanulo in tanulok)
            {
                Console.WriteLine($"\t{tanulo.name, -20}{tanulo.results.Sum(x => x.Value)}");
            }
        }

        private static void OtodikFeladat()
        {
            Console.WriteLine($"5. feladat:\n" +
                $"\tA következő diákoknak van tandíjelmaradása:");
            List<string> diakok = (from d in data
                 where
                 (
                    (d.paidSum < 2600 && d.code == 0) ||
                    (d.paidSum < 312 * CourseData.HONAP && d.code == 1) ||
                    (d.paidSum < 4000 && d.code == 2 && CourseData.HONAP >= 10)
                 ) select d.name).ToList();
            
            foreach (string diak in diakok)
            {
                Console.WriteLine($"\t{diak}");
            }
        }

        private static void NegyedikFeladat()
        {
            double atlag1 = (from d in data where d.gender == 'm' select d.results.Values.Average()).ToList().Average();
            double atlag2 = (from d in data where d.gender == 'f' select d.results.Values.Average()).ToList().Average();
            Console.WriteLine($"4. feladat:\n" +
                $"\tFiúk   átlagteljesítménye: {Math.Round(atlag1, 2)}%\n" +
                $"\tLányok átlagteljesítménye: {Math.Round(atlag2, 2)}%");
        }

        private static void HarmadikFeladat()
        {
            Console.WriteLine($"3. feladat:\n" +
                $"\tA tanfolyamra {data.Count} fő iratkozott be.");
        }

        private static void MasodikFeladat()
        {
            using (StreamReader sr = new StreamReader("coursedata.csv"))
            {
                while (!sr.EndOfStream)
                {
                    data.Add(new CourseData(sr.ReadLine()));
                }
            }
        }
    }
}
