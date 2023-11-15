﻿using SchoolClubs.BD;
using SchoolClubs.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolClubs.Pages.Teacher
{
    /// <summary>
    /// Логика взаимодействия для ChangeRaportInfo.xaml
    /// </summary>
    public partial class ChangeRaportInfo : Page
    {
        public ChangeRaportInfo(Timetable timetable)
        {
            InitializeComponent();
            List<RaportGroupStudentInfo> list = new List<RaportGroupStudentInfo>();
            List<Raport_GroupStudent> raportGroupStudent = App.connection.Raport_GroupStudent.Where(x => x.idRaport == timetable.idRaport).ToList();
            int number = 1;
            foreach (var raportGrSt in raportGroupStudent)
            {
                RaportGroupStudentInfo info = new RaportGroupStudentInfo(raportGrSt, number);
                list.Add(info);
                number++;
            }
            RaportStudentLV.ItemsSource = list;

            dateTB.Text = timetable.Date.ToShortDateString();
            switch(timetable.Time.Minutes.ToString())
            {
                case "0": timeTB.Text = $"{timetable.Time.Hours}:00";
                    break;
                default: timeTB.Text = $"{timetable.Time.Hours}:{timetable.Time.Minutes}";
                    break;

            }
            sectionNameTB.Text = App.connection.Section.FirstOrDefault(
                x => x.idSection == App.connection.Group.FirstOrDefault(
                    z => z.idGroup == App.connection.Group_Student.FirstOrDefault(
                        c => c.idGroup_Student == App.connection.Raport_GroupStudent.FirstOrDefault(
                            v => v.idRaport == App.connection.Raport.FirstOrDefault(
                                b => b.idRaport == timetable.idRaport).idRaport).idGroup_Student).idGroup).idSection).Title;
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App.currentUser;
        }

        private void SaveChangesBtnClick(object sender, RoutedEventArgs e)
        {
            foreach (RaportGroupStudentInfo stInfo in RaportStudentLV.ItemsSource)
            {
                stInfo.raportGroupStudent.idRaportStatus = stInfo.wasInClass ? 1 : 2;
                Timetable timetable = App.connection.Timetable.FirstOrDefault(x => x.idRaport == stInfo.raportGroupStudent.idRaport);
                timetable.isRaportCreated = true;
                App.connection.Raport_GroupStudent.AddOrUpdate(stInfo.raportGroupStudent);
                App.connection.Timetable.AddOrUpdate(timetable);
                App.connection.SaveChanges();
                MessageBox.Show("Вы успешно создали рапортичку", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                SaveBtn.Background = Brushes.Gray;
                SaveBtn.IsEnabled = false;
            }
        }
    }

}