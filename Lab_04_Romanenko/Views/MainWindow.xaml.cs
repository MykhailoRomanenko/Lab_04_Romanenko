using System.Windows;
using Lab_04_Romanenko.ViewModels;

namespace Lab_04_Romanenko.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _mainWindowViewModel = new MainWindowViewModel(this);
            DataContext = _mainWindowViewModel;
        }
        
        private void AddUserClick(object sender, RoutedEventArgs e){
            _mainWindowViewModel.ShowAddUserDialog();
        }
        private void EditUserClick(object sender, RoutedEventArgs e){
            _mainWindowViewModel.ShowEditUserDialog();
        }
        private void RemoveUserClick(object sender, RoutedEventArgs e){
            _mainWindowViewModel.ShowRemoveUserDialog();
        }
        private void SaveClick(object sender, RoutedEventArgs e){
            _mainWindowViewModel.ShowSaveDialog();
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.ShowLoadDialog();
        }
    }
    
    
}