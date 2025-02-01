using Microsoft.Win32;
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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private string _selectPath = Directory.GetCurrentDirectory();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var folderBrowserdialog = new FolderBrowserDialog())
            {
                folderBrowserdialog.SelectedPath = _selectPath;

                if (folderBrowserdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _selectPath = folderBrowserdialog.SelectedPath;
                }
            }
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //dialog.ShowDialog();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
        }
    }
}