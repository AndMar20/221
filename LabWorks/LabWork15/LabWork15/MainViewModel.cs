using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace LabWork15
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _filePath;
        private string _statusText;
        private double _imageScale = 1.0;
        private BitmapImage _image;

        public string WindowTitle => string.IsNullOrEmpty(_filePath) ? "Просмотр изображений" : Path.GetFileName(_filePath);
        public BitmapImage ImageSource { get => _image; set { _image = value; OnPropertyChanged("ImageSource"); } }
        public string StatusText { get => _statusText; set { _statusText = value; OnPropertyChanged("StatusText"); } }
        public double ImageScale { get => _imageScale; set { _imageScale = value; OnPropertyChanged("ImageScale"); } }

        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения|*.bmp;*.jpg;*.jpeg;*.png"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                LoadImage(_filePath);
            }
        }

        public void Exit() 
        { 
            Application.Current.Shutdown();
        }

        private void LoadImage(string path)
        {
            try
            {
                BitmapImage bitmap = new BitmapImage(new Uri(path));
                ImageSource = bitmap;
                FileInfo fileInfo = new FileInfo(path);
                StatusText = $"Размер файла: {fileInfo.Length / 1024} KB | Размер: {bitmap.PixelWidth}x{bitmap.PixelHeight}";
                OnPropertyChanged("WindowTitle");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}