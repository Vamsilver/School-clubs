using SchoolClubs.ADOApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class TeachersClubs
    {
        public User user { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public int idUser { get; set; }
        public int idAuth { get; set; }
        public string sections { get; set; }
        public int countStudent { get; set; }

        public List<Section> sectionList { get; set; }

        public TeachersClubs(User _user)
        {
            user = _user;
            surname = user.Surname;
            name = user.Name;
            patronymic = user.Patronymic;
            idUser = user.idUser;
            idAuth = user.idAuthorization;
            var sectionList = App.Connection.Section.Where(x => x.idUser == user.idUser).ToList();
            
            foreach (ADOApp.Section section in sectionList)
            {
                sections += section.Title + Environment.NewLine;
                countStudent += App.Connection.Group_Student.Where(x => x.Group.idSection == section.idSection).Count();
            }
        }
    }
}
