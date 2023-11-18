using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.ADOApp
{
    public class TeacherRatingView
    {
        public TeacherRatingView(string fullName, double points)
        {
            FullName = fullName;
            Points = points;
            Number = -1;
        }

        public string FullName { get; set; }
        public int Number { get; set; }
        public double Points { get; set; }
    }
}
