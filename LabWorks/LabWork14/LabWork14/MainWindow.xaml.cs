using System.Windows;

namespace LabWork14
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel => DataContext as MainViewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.SelectFolder();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.OpenFile();
        }

        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.DeleteFile();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}