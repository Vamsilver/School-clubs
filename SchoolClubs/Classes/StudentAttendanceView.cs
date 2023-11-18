using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.ADOApp
{
    public class StudentAttendanceView
    {
        public StudentAttendanceView(string fullName, double procent)
        {
            FullName = fullName;
            Procent = procent;

            Line = new string('|', (int)procent);
        }

        public string FullName { get; set; }
        public string Line { get; set; }
        public double Procent { get; set; }
    }
}
