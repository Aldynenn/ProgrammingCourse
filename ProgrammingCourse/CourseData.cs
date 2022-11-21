using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingCourse
{
    class CourseData
    {
        public string name;
        public char gender;
        public int code;
        public int paidSum;
        public Dictionary<string, int> results = new Dictionary<string, int>();
        public const int HONAP = 5;

        public CourseData(string row)
        {
            List<string> temp = row.Split(';').ToList();

            this.name = temp[0];
            this.gender = Convert.ToChar(temp[1]);
            this.code = Convert.ToInt32(temp[2]);
            this.paidSum = Convert.ToInt32(temp[3].TrimStart('$'));
            this.results.Add("prog", Convert.ToInt32(temp[4]));
            this.results.Add("graf", Convert.ToInt32(temp[5]));
            this.results.Add("architekt", Convert.ToInt32(temp[6]));
            this.results.Add("mestint", Convert.ToInt32(temp[7]));
        }
    }
}
