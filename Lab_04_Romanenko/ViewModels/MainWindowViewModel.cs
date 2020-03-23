using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using Lab_04_Romanenko.Models;
using Lab_04_Romanenko.Tools;
using Lab_04_Romanenko.Views;
using Microsoft.Win32;

namespace Lab_04_Romanenko.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly MainWindow _owner;
        
        public MainWindowViewModel(MainWindow owner)
        {
            Users = UserTableGenerator.GenerateUserTable();
            _owner = owner;
        }

        public ObservableCollection<Person> Users { get; set; }

        public Person SelectedPerson { get; set; }


        public void AddNewUser(Person p)
        {
            Users.Add(p);
        }

        public void EditUser(Person p)
        {
            Users.Remove(SelectedPerson);
            Users.Add(p);
        }
        
        public void ShowAddUserDialog()
        {
            Console.Out.WriteLine("Add dialog");
            PersonWindow pw = new PersonWindow(this) {Owner = _owner, Title = "Add user"};
            pw.ShowDialog();
        }

        public void ShowEditUserDialog()
        {
            Console.Out.WriteLine("Edit dialog");
            PersonWindow pw = new PersonWindow(this, SelectedPerson) {Owner = _owner, Title = "Edit user"};
            pw.ShowDialog();
        }

        public void ShowRemoveUserDialog()
        {
            Users.Remove(SelectedPerson);
        }

        public void ShowSaveDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                String path = saveFileDialog.SafeFileName;
                SerializationManager.Serialize(Users, path);
            }
        }

        public void ShowLoadDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                String path = openFileDialog.SafeFileName;
                try
                {
                    Users = SerializationManager.Deserialize<ObservableCollection<Person>>(path);
                    OnPropertyChanged("Users");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while opening the save file. " +
                                    "Please check if the file is chosen correctly.");
                }
            }

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