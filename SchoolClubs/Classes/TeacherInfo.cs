using SchoolClubs.AdoApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class TeacherInfo
    {
        public User User { get; set; }
        public string FullName { get; set; }

        public TeacherInfo(User user) 
        {
            User = user;
            FullName = User.Surname + " " + User.Name[0] + "." + User.Patronymic[0] + "."; 
        }
 
    }
}
