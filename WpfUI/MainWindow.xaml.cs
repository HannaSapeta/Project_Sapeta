using System.Collections.ObjectModel;
using System.Windows;
using Core;

namespace WpfUI
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Photo> photos =
            new ObservableCollection<Photo>();

        public MainWindow()
        {
            InitializeComponent();

            mediaGrid.ItemsSource = photos;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EditWindow window = new EditWindow();

            if (window.ShowDialog() == true)
            {
                photos.Add(window.Photo);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (mediaGrid.SelectedItem is Photo selected)
            {
                EditWindow window = new EditWindow(selected);

                if (window.ShowDialog() == true)
                {
                    mediaGrid.Items.Refresh();
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (mediaGrid.SelectedItem is Photo selected)
            {
                MessageBoxResult result =
                    MessageBox.Show(
                        "Видалити файл?",
                        "Підтвердження",
                        MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    photos.Remove(selected);
                }
            }
        }
    }
}