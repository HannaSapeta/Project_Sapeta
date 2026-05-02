using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using Core;

namespace WinFormsUI
{
    public partial class MainForm : Form
    {
        private BindingList<Photo> photos = new();

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = photos;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                photos.Add(form.Photo);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var result = MessageBox.Show(
                    "Видалити запис?",
                    "Підтвердження",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes)
                {
                    photos.RemoveAt(dataGridView1.CurrentRow.Index);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "JSON files (*.json)|*.json";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string json = JsonSerializer.Serialize(photos.ToList(), new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(saveDialog.FileName, json);

                MessageBox.Show("Збережено успішно!");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "JSON files (*.json)|*.json";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openDialog.FileName);

                var loaded = JsonSerializer.Deserialize<List<Photo>>(json);

                if (loaded != null)
                {
                    photos.Clear();

                    foreach (var p in loaded)
                    {
                        photos.Add(p);
                    }

                    MessageBox.Show("Завантажено успішно!");
                }
            }
        }
    }
}
