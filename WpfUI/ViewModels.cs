using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Core;

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

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            execute();
        }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        private Photo? selectedPhoto;

        public ObservableCollection<Photo> Photos
        {
            get;
            set;
        }

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

        public MainViewModel()
        {
            Photos = new ObservableCollection<Photo>();

            AddCommand =
                new RelayCommand(AddPhoto);

            DeleteCommand =
                new RelayCommand(DeletePhoto);
        }

        private int counter = 1;

        private void AddPhoto()
        {
            Photos.Add(
                new Photo(
                    $"Photo_{counter++}.jpg",
                    5,
                    "1920x1080"));
        }

        private void DeletePhoto()
        {
            if (SelectedPhoto != null)
                Photos.Remove(SelectedPhoto);
        }

        public event PropertyChangedEventHandler?
            PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(property));
        }
    }
}
