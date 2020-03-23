using Lab_04_Romanenko.Models;
using Lab_04_Romanenko.ViewModels;

namespace Lab_04_Romanenko.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PersonWindow
    {
        public PersonWindow(MainWindowViewModel m, Person p = null)
        {
            InitializeComponent();
            DataContext = new PersonWindowViewModel(this, m, p);
        }
    }
}