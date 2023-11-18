using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClubs.Classes
{
    public class TeacherSectionInfo
    {
        public ADOApp.Section Section { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Title { get; set; }

        public TeacherSectionInfo(ADOApp.Section section)
        {
            Section = section;
            Name = App.Connection.User.Where(x => x.idUser == section.idUser).FirstOrDefault().Name;
            Surname = App.Connection.User.Where(x => x.idUser == section.idUser).FirstOrDefault().Surname;
            Patronymic = App.Connection.User.Where(x => x.idUser == section.idUser).FirstOrDefault().Patronymic;
            Title = section.Title;
        }
    }
}
