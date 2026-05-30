using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using Photo = Core.Photo;

namespace WpfUI.ViewModels
{
    
        public class RelayCommand : ICommand
        {
            private readonly Action execute;

            public RelayCommand(Action execute)
            {
                this.execute = execute;
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter) => true;

            public void Execute(object? parameter) => execute();
        }
    
    public class MainViewModel : INotifyPropertyChanged
    {
        private Photo? selectedPhoto;
        private readonly string filePath = "photos.json";

        public ObservableCollection<Photo> Photos { get; set; }

        public Photo? SelectedPhoto
        {
            get => selectedPhoto;
            set
            {
                selectedPhoto = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }

        public MainViewModel()
        {
            Photos = new ObservableCollection<Photo>();

            AddCommand = new RelayCommand(AddPhoto);
            DeleteCommand = new RelayCommand(DeletePhoto);
            SaveCommand = new RelayCommand(SaveToFile);
            LoadCommand = new RelayCommand(LoadFromFile);
        }

        private void AddPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.png;*.jpeg"
            };

            if (dialog.ShowDialog() == true)
            {
                Photos.Add(new Photo
                {
                    FileName = Path.GetFileName(dialog.FileName),
                    FullPath = dialog.FileName,
                    FileSizeMb = 0,
                    Resolution = "unknown"
                });
            }
        }

        private void DeletePhoto()
        {
            if (SelectedPhoto != null)
                Photos.Remove(SelectedPhoto);
        }

        private void SaveToFile()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(Photos);
            File.WriteAllText(filePath, json);
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath)) return;

            var json = File.ReadAllText(filePath);
            var items = System.Text.Json.JsonSerializer.Deserialize<ObservableCollection<Photo>>(json);

            if (items != null)
                Photos = items;

            OnPropertyChanged(nameof(Photos));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}