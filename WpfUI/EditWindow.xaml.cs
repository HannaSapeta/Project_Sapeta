using System.Windows;
using Core;

namespace WpfUI
{
    public partial class EditWindow : Window
    {
        public Photo Photo { get; private set; }

        public EditWindow()
        {
            InitializeComponent();
        }

        public EditWindow(Photo photo)
        {
            InitializeComponent();

            Photo = photo;

            txtName.Text = photo.FileName;
            txtResolution.Text = photo.Resolution;
            txtSize.Text = photo.FileSizeMb.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Photo == null)
            {
                Photo = new Photo(
                    txtName.Text,
                    double.Parse(txtSize.Text),
                    txtResolution.Text
                );
            }
            else
            {
                Photo.FileName = txtName.Text;
                Photo.Resolution = txtResolution.Text;
                Photo.FileSizeMb = double.Parse(txtSize.Text);
            }

            DialogResult = true;
            Close();
        }
    }
}