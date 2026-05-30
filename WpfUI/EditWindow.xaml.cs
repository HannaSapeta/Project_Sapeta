using System;
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
            Photo = new Photo();
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
                Photo = new Photo();

            Photo.FileName = txtName.Text;
            Photo.Resolution = txtResolution.Text;

            // ❗ FIX: int замість double
            Photo.FileSizeMb = int.TryParse(txtSize.Text, out int size)
                ? size
                : 0;

            DialogResult = true;
            Close();
        }
    }
}