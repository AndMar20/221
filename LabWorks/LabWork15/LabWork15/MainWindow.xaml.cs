using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel => DataContext as MainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            viewModel?.OpenFile();
        }

        private void ExitAplication_Click(object sender, RoutedEventArgs e)
        {
            viewModel?.Exit();
        }
    }
}