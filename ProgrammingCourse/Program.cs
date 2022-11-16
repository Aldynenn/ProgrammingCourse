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

            Console.ReadKey();
        }

        private static void OtodikFeladat()
        {

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
