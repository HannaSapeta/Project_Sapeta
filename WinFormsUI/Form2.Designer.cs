namespace WinFormsUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dataGridView1;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSave;
        private Button btnLoad;

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();

            btnSave = new Button();
            btnLoad = new Button();

            btnSave.Text = "Зберегти";
            btnSave.Location = new System.Drawing.Point(200, 220);
            btnSave.Click += btnSave_Click;

            btnLoad.Text = "Завантажити";
            btnLoad.Location = new System.Drawing.Point(300, 220);
            btnLoad.Click += btnLoad_Click;

            Controls.Add(btnSave);
            Controls.Add(btnLoad);

            SuspendLayout();

            dataGridView1.Location = new System.Drawing.Point(12, 12);
            dataGridView1.Size = new System.Drawing.Size(460, 200); 

            btnAdd.Text = "Додати";
            btnAdd.Location = new System.Drawing.Point(12, 220);
            btnAdd.Click += btnAdd_Click;

            btnDelete.Text = "Видалити";
            btnDelete.Location = new System.Drawing.Point(100, 220);
            btnDelete.Click += btnDelete_Click;

            ClientSize = new System.Drawing.Size(500, 260); 
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);

            Text = "Media Manager";

            ResumeLayout(false);
        }
    }
}