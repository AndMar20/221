using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace LabWork14
{
    public partial class MainViewModel : ViewModelBase
    {
        private string _folderPath;
        private ObservableCollection<IGrouping<string, FileModel>> _duplicate = new ObservableCollection<IGrouping<string, FileModel>>();

        public string FolderPath
        {
            get { return _folderPath; }
            set { _folderPath = value; OnPropertyChanged(nameof(FolderPath)); }
        }

        public ObservableCollection<IGrouping<string, FileModel>> Duplicate
        {
            get { return _duplicate; }
            set { _duplicate = value; OnPropertyChanged(nameof(Duplicate)); }
        }

        public ICommand BrowseFolderCommand { get; }
        public ICommand FindDuplicateCommand { get; }

        public MainViewModel()
        {
            BrowseFolderCommand = new RelayCommand(BrowseFolder);
            FindDuplicateCommand = new RelayCommand(async () => await FindDuplicate());
        }

        private void BrowseFolder()
        {
            var dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FolderPath = dialog.SelectedPath;
            }
        }

        private async Task FindDuplicate()
        {
            if (string.IsNullOrEmpty(FolderPath) || Directory.Exists(FolderPath))
            {
                MessageBox.Show("Каталог выбран неверно");
                return;
            }

            Duplicate = await Task.Run(() => GetDuplicate());
        }

        private ObservableCollection<IGrouping<string, FileModel>> GetDuplicate()
        {
            try
            {
                var files = Directory.GetFiles(FolderPath, "*", SearchOption.AllDirectories);
                var fileModels = files.Select(file => new FileModel(file));
                var duplicateGroups = fileModels
                    .GroupBy(file => file.FileName)
                    .Where(g => g.Count() > 1);
                return new ObservableCollection<IGrouping<string, FileModel>>(duplicateGroups);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
                return new ObservableCollection<IGrouping<string, FileModel>>();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public class RelayCommand : ICommand
        {
            private readonly Action _execute;
            private readonly Func<bool> _canExecute;

            public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                _execute = execute ?? throw new ArgumentNullException(nameof(execute));
                _canExecute = canExecute;
            }
            public bool CanExecute(object parameter)
            {
                return _canExecute == null || _canExecute();
            }
            public void Execute(object parameter)
            {
                _execute();
            }
            public event EventHandler CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }
                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
    }
}
