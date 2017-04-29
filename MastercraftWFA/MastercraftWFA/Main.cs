using System.Windows.Forms;

namespace MastercraftWFA {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
            FillData();
        }

        void FillData() {
            dataGridView1.DataSource = Database.Query("SELECT * FROM professions");
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.ColumnIndex != 0 || e.RowIndex < 0 || e.RowIndex >= dataGridView1.RowCount - 1)
                return;
            // Open Profession Window
            DataGridViewCell field = dataGridView1[e.ColumnIndex, e.RowIndex];
            string query = (string)field.Value;
            Profession profession = new Profession(query) {
                Location = new System.Drawing.Point(this.Size.Width + this.Location.X, this.Location.Y),
                StartPosition = FormStartPosition.Manual,
                Text = query
            };
            profession.Show();
        }
    }
}