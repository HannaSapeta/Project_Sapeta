using System;
using System.Windows.Forms;
using Core;

namespace WinFormsUI
{
    public partial class EditForm : Form
    {
        public Photo Photo { get; private set; }

        public EditForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Photo = new Photo(
                txtName.Text,
                (double)numSize.Value,
                txtResolution.Text
            );

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
