using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace LabWork14
{
    public class FileDuplicateInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public DateTime LastModified { get; set; }
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        private string _selectedDirectory;
        private FileDuplicateInfo _selectedFile;

        public string SelectedDirectory
        {
            get => _selectedDirectory;
            set { _selectedDirectory = value; OnPropertyChanged(nameof(SelectedDirectory)); }
        }

        public ObservableCollection<FileDuplicateInfo> DuplicateFiles { get; set; } = new();
        public FileDuplicateInfo SelectedFile
        {
            get => _selectedFile;
            set { _selectedFile = value; OnPropertyChanged(nameof(SelectedFile)); }
        }

        public bool SearchByName { get; set; } = true;
        public bool SearchBySize { get; set; } = false;
        public bool SearchByDate { get; set; } = false;

        public void SelectFolder()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedDirectory = dialog.SelectedPath;
                FindDuplicateFiles();
            }
        }

        private void FindDuplicateFiles()
        {
            DuplicateFiles.Clear();
            if (string.IsNullOrEmpty(SelectedDirectory) || !Directory.Exists(SelectedDirectory))
            {
                System.Windows.MessageBox.Show("Выберите папку для поиска!");
                return;
            }

            var files = Directory.GetFiles(SelectedDirectory, "*.*", SearchOption.AllDirectories)
                .Select(f => new FileInfo(f))
                .ToList();

            var groupedFiles = files.GroupBy(f => new
            {
                Name = SearchByName ? f.Name : null,
                Size = SearchBySize ? f.Length : (long?)null,
                Date = SearchByDate ? f.LastWriteTime.Date : (DateTime?)null
            });

            foreach (var group in groupedFiles)
            {
                if (group.Count() > 1)
                {
                    foreach (var file in group)
                    {
                        DuplicateFiles.Add(new FileDuplicateInfo
                        {
                            Name = file.Name,
                            Path = file.FullName,
                            Size = file.Length,
                            LastModified = file.LastWriteTime
                        });
                    }
                }
            }

            if (DuplicateFiles.Count == 0)
            {
                System.Windows.MessageBox.Show("Дубликаты не найдены.");
            }
        }

        public void OpenFile()
        {
            if (SelectedFile != null)
            {
                System.Diagnostics.Process.Start("explorer.exe", $"/select,\"{SelectedFile.Path}\"");
            }
        }

        public void DeleteFile()
        {
            if (SelectedFile != null && System.Windows.MessageBox.Show("Удалить этот файл?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    File.Delete(SelectedFile.Path);
                    DuplicateFiles.Remove(SelectedFile);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

