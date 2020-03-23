using System;
using System.Collections.ObjectModel;
using System.Data;
using Lab_04_Romanenko.Models;

namespace Lab_04_Romanenko.Tools
{
    public static class UserTableGenerator
    {
        private static readonly int USERS_TO_GENERATE = 50;

        private static readonly string[] GenericNames =
        {
            "Mykola", "Volodymyr", "Mykhailo", "Alexander", "Ivan",
            "Vasyl", "Sergiy", "Petro", "Yuriy", "Anatoliy"
        };

        private static readonly string[] GenericSurnames =
        {
            "Melnyk", "Shevchenko", "Shevchuk", "Boyko", "Kovalenko",
            "Bondarenko", "Tkachenko", "Kovalchuk", "Kravchenko", "Oliynyk"
        };

        private static readonly string[] GenericEmails =
        {
            "gmail.com", "ukma.edu.ua", "i.ua", "yahoo.com", "ua.fm"
        };

        public static ObservableCollection<Person> GenerateUserTable()
        {
            var users = new ObservableCollection<Person>();
            var r = new Random();
            Person p;
            for (var i = 0; i < USERS_TO_GENERATE; ++i)
            {
                var name = GenericNames[r.Next(GenericNames.Length)];
                var surname = GenericSurnames[r.Next(GenericSurnames.Length)];
                var dt = GenerateRandomDate();
                var email = name + '.' + surname + dt.Date.Year + '@' + GenericEmails[r.Next(GenericEmails.Length)];
                p = new Person(name, surname, email, dt);
                users.Add(p);
            }

            return users;
        }

        private static DateTime GenerateRandomDate()
        {
            var r = new Random();
            var y = r.Next(DateTime.Today.Year - 134, DateTime.Today.Year - 10);
            var m = r.Next(1, 13);
            var dayBound = -1;
            switch (m)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                {
                    dayBound = 31;
                    break;
                }
                case 2:
                {
                    if (y % 4 == 0)
                    {
                        dayBound = 29;
                        break;
                    }

                    dayBound = 28;
                    break;
                }
                case 4:
                case 6:
                case 9:
                case 11:
                {
                    dayBound = 30;
                    break;
                }
            }

            var d = r.Next(1, dayBound + 1);
            return new DateTime(y, m, d);
        }
    }
}