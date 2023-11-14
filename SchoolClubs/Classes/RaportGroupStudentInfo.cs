using SchoolClubs.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class RaportGroupStudentInfo
    {
        public Student student { get; set; }
        public string number { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public Section section { get; set; }

        public RaportGroupStudentInfo()
        {

        }
    }
}
