namespace WinFormsUI
{
    partial class EditForm
    {
        private TextBox txtName;
        private TextBox txtResolution;
        private NumericUpDown numSize;
        private Button btnSave;

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtResolution = new TextBox();
            numSize = new NumericUpDown();
            btnSave = new Button();

            SuspendLayout();

            txtName.PlaceholderText = "Назва";
            txtName.Location = new System.Drawing.Point(12, 12);

            txtResolution.PlaceholderText = "Resolution";
            txtResolution.Location = new System.Drawing.Point(12, 40);

            numSize.Location = new System.Drawing.Point(12, 70);

            btnSave.Text = "Зберегти";
            btnSave.Location = new System.Drawing.Point(12, 100);
            btnSave.Click += btnSave_Click;

            ClientSize = new System.Drawing.Size(200, 140);
            Controls.Add(txtName);
            Controls.Add(txtResolution);
            Controls.Add(numSize);
            Controls.Add(btnSave);

            ResumeLayout(false);
        }
    }
}