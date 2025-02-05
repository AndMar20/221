using System.IO;
using System.Windows;


namespace Task1._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedFolder = Directory.GetCurrentDirectory();

        public MainWindow()
        {
            InitializeComponent();
            selectedFolderLabel.Content = selectedFolder;
        }

        private void selectFolder_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    selectedFolder = dialog.SelectedPath;
                    selectedFolderLabel.Content = selectedFolder;
                }
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            resultsListBox.Items.Clear();
            if (string.IsNullOrWhiteSpace(fileNameTextBox.Text))
            {
                System.Windows.MessageBox.Show("Введите часть имени файла.");
                return;
            }

            string search = $"*{fileNameTextBox.Text}*";
            bool searchSubfolders = searchSubfoldersRadio.IsChecked == true;
            bool filterBySize = sizeFilterCheckBox.IsChecked == true;
            bool filterByDate = dateFilterCheckBox.IsChecked == true;

            long minSize = 0, maxSize = long.MaxValue;
            if (filterBySize)
            {
                if (!long.TryParse(minSizeTextBox.Text, out minSize)) minSize = 0;
                if (!long.TryParse(maxSizeTextBox.Text, out maxSize)) maxSize = long.MaxValue;
                minSize *= 1024;
                maxSize *= 1024;
            }

            DateTime minDate = DateTime.MinValue;
            if (filterByDate && creationDatePicker.SelectedDate.HasValue)
            {
                minDate = creationDatePicker.SelectedDate.Value;
            }

            try
            {
                var files = Directory.GetFiles(selectedFolder, search, searchSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                    .Where(f => (!filterBySize || (new FileInfo(f).Length >= minSize && new FileInfo(f).Length <= maxSize)))
                    .Where(f => (!filterByDate || File.GetCreationTime(f) >= minDate));

                foreach (var file in files)
                {
                    resultsListBox.Items.Add(file);
                }

                if (resultsListBox.Items.Count == 0)
                {
                    resultsListBox.Items.Add("Файлы не найдены.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void sizeFilterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            minSizeTextBox.IsEnabled = true;
            maxSizeTextBox.IsEnabled = true;
        }

        private void sizeFilterCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            minSizeTextBox.IsEnabled = false;
            maxSizeTextBox.IsEnabled = false;
            minSizeTextBox.Text = "";
            maxSizeTextBox.Text = "";
        }

        private void dateFilterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            creationDatePicker.IsEnabled = true;
        }

        private void dateFilterCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            creationDatePicker.IsEnabled = false;
            creationDatePicker.SelectedDate = null;
        }
    }
}