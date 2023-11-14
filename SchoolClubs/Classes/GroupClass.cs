using SchoolClubs.BD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class GroupClass
    {
        public int number { get; set; }
        public Group group { get; set; }

        public string countOfStudents { get; set; }
        
        public GroupClass(Group _group, int _countOfStudents, int _number)
        {
            group = _group;
            number = _number;
            switch (_countOfStudents)
            {
                case 1:
                    {
                        countOfStudents = $"{_countOfStudents} ученик";
                        return;
                    }
                case 2:
                    {
                        countOfStudents = $"{_countOfStudents} ученика";
                        return;
                    }
                case 3:
                    {
                        countOfStudents = $"{_countOfStudents} ученика";
                        return;
                    }
                case 4:
                    {
                        countOfStudents = $"{_countOfStudents} ученика";
                        return;
                    }
                default:
                    {

                        countOfStudents = $"{_countOfStudents} учеников";
                        return;
                    }
            }
        }
    }
}
