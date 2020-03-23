using System;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Lab_04_Romanenko.Tools.Exceptions;

namespace Lab_04_Romanenko.Models
{
[Serializable]
    public class Person 
    {
        private static readonly string[] Chinese =
            {"Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat"};

        private static readonly string[] Western =
        {
            "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra",
            "Scorpio", "Sagittarius"
        };

        
        private static readonly int MAX_AGE = 135;

        //All the "complex" calculations are carried out during the construction of a Person.
        //For signs, an int value is stored, which is an index of a corresponding
        //sign name in a static array of signs.
        private DateTime _birthDate;
        private string _eMail;
        private string _firstName;
        private string _lastName;
        private int _western;
        private int _chinese;
        
        public Person(string firstName, string lastName, string eMail, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _eMail = eMail;
            _birthDate = birthDate;
            _chinese = CalculateChinese();
            _western = CalculateWestern();
            ThrowExceptionsIfNecessary();
        }

        public String Name => _firstName;

        public String Surname => _lastName;

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                ThrowExceptionsIfNecessary();
            }
        }
        
        public String BirthDateString => _birthDate.ToString("yyyy MMMM dd");

        public string EMail
        {
            get => _eMail;
            set
            {
                _eMail = value;
                ThrowExceptionsIfNecessary();}
        }

        public string ChineseSign => Chinese[_chinese];

        public string WesternSign => Western[_western];
        
        //IMHO making IsBirthday and IsAdult non-dynamic is a pretty bad decision.
        //The calculations are almost as complex as O(1) anyway.
        public bool IsBirthday => Birthday();

        public bool IsAdult => Adult();
        
        
        public int Age => CalculateAge();

        private int CalculateAge()
        {
            var y = _birthDate.Year;
            var m = _birthDate.Month;
            var d = _birthDate.Day;
            var todayM = DateTime.Today.Month;
            var todayD = DateTime.Today.Day;
            var age = DateTime.Today.Year - y;
            if (m > todayM || m == todayM && d > todayD)
                --age;
            return age;
        }

        public static bool IsEMailValid(String email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }
        
        public static bool IsUserNotDead(DateTime birthDate)
        {
            return  birthDate.Year > DateTime.Today.Year - MAX_AGE;;
        }

        public static bool IsUserBorn(DateTime birthDate)
        {
            return  birthDate.CompareTo(DateTime.Today) < 0;
        }

        private void ThrowExceptionsIfNecessary()
        {
            if (!IsUserBorn(_birthDate))
            {
                throw new TimeContinuumException("Birth date in future: " + _birthDate.Date);
            }

            if (!IsUserNotDead(_birthDate))
            {
                throw new UserIsProbablyDeadException("Birth date is 135 or more years away: " + _birthDate.Date.Year);
            }

            if (!IsEMailValid(_eMail))
            {
                throw new InvalidEMailException("E-Mail does not match e-mail standards: "+ _eMail);
            }
        }
        private int CalculateChinese()
        {
            return _birthDate.Year % 12;
        }

        private int CalculateWestern()
        {
            var m = _birthDate.Month;
            var d = _birthDate.Day;
            var thresh = Threshold(m);
            if (d <= thresh) m = (m + 11);
            return m%12;
        }

        private static int Threshold(int m)
        {
            var thresh = -1;
            if (m >= 1 && m <= 6)
                thresh = 21;
            else if (m == 2)
                thresh = 20;
            else
                thresh = 22;
            return thresh;
        }
        
        
        private bool Adult()
        {
            return CalculateAge() >= 18;
        }

        private bool Birthday()
        {
            return _birthDate.Month == DateTime.Today.Month && _birthDate.Day == DateTime.Today.Day;
        }

        
    }
}