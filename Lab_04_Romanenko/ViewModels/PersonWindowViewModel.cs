using System;
using System.ComponentModel;
using System.Windows;
using Lab_04_Romanenko.Models;
using Lab_04_Romanenko.Tools;
using Lab_04_Romanenko.Views;

namespace Lab_04_Romanenko.ViewModels
{
    public class PersonWindowViewModel : INotifyPropertyChanged
    {
        private MainWindowViewModel _mwvm;
        private readonly Person _person;
        private readonly PersonWindow _pw;

        public PersonWindowViewModel(PersonWindow pw,MainWindowViewModel m, Person p)
        {
            ProceedCommand = new ProceedCommand(this);
            _mwvm = m;
            _pw = pw;

            if (p != null)
            {
                _person = p;
                FirstNameValue = p.Name;
                LastNameValue = p.Surname;
                DateValue = p.BirthDate;
                EMailValue = p.EMail;
            }
            else
            {
                DateValue = new DateTime(2000, 1, 1);
            }
        }

        public ProceedCommand ProceedCommand { get; set; }

        public string FirstNameValue { get; set; }

        public string LastNameValue { get; set; }

        public string EMailValue { get; set; }

        public DateTime DateValue { get; set; }


        public bool CanProceed()
        {
            return FirstNameValue != null && !FirstNameValue.Equals("") &&
                   LastNameValue != null && !LastNameValue.Equals("")
                   && EMailValue != null && !EMailValue.Equals("");
        }

        public async void Proceed()
        {
           
            if (!Person.IsUserBorn(DateValue) ||!Person.IsUserNotDead(DateValue))
            {
                MessageBox.Show("Incorrect birth date. Birth date must" +
                                " not be in the future and not more than 135 years from now.");
                return;
            }

            if (!Person.IsEMailValid(EMailValue))
            {
                MessageBox.Show("Incorrect E-Mail format.");
                return;
            }

            if (_person == null)
            {
                _mwvm.AddNewUser(new Person(FirstNameValue, LastNameValue, EMailValue, DateValue));
            }
            else
            {
                _mwvm.EditUser(new Person(FirstNameValue, LastNameValue, EMailValue, DateValue));
            }
            _pw.Close();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}