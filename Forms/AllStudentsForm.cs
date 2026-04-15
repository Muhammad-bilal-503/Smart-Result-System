using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SmartResultSystem
{
    // ============================================================
    // Q#1 - Part (v): Second Form - All Student Records
    // Data is passed from MainForm (Multiple Form Interaction)
    // ============================================================
    public class AllStudentsForm : Form
    {
        private Label lblTitle;
        private DataGridView dgvStudents;
        private Button btnClose;
        private Label lblCount;

        private List<Student> studentList;

        public AllStudentsForm(List<Student> students)
        {
            studentList = students;
            InitializeComponents();
            LoadData();
        }

        private void InitializeComponents()
        {
            this.Text = "All Student Records";
            this.Size = new Size(720, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;

            lblTitle = new Label();
            lblTitle.Text = "All Student Records";
            lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(670, 28);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            dgvStudents = new DataGridView();
            dgvStudents.Location = new Point(15, 55);
            dgvStudents.Size = new Size(678, 350);
            dgvStudents.ReadOnly = true;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvStudents.AllowUserToAddRows = false;

            lblCount = new Label();
            lblCount.Location = new Point(15, 415);
            lblCount.Size = new Size(300, 25);
            lblCount.Font = new Font("Segoe UI", 9);

            btnClose = new Button();
            btnClose.Text = "Close";
            btnClose.Location = new Point(610, 410);
            btnClose.Size = new Size(83, 30);
            btnClose.BackColor = Color.Tomato;
            btnClose.ForeColor = Color.White;
            btnClose.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] { lblTitle, dgvStudents, lblCount, btnClose });
        }

        private void LoadData()
        {
            dgvStudents.Columns.Add("ID", "Student ID");
            dgvStudents.Columns.Add("Name", "Name");
            dgvStudents.Columns.Add("Age", "Age");
            dgvStudents.Columns.Add("Semester", "Semester");
            dgvStudents.Columns.Add("Department", "Department");
            dgvStudents.Columns.Add("Marks", "Marks");
            dgvStudents.Columns.Add("Result", "Predicted Result");

            foreach (var s in studentList)
            {
                int row = dgvStudents.Rows.Add(s.ID, s.Name, s.Age, s.Semester, s.Department, s.Marks, s.PredictResult());
                var cell = dgvStudents.Rows[row].Cells["Result"];
                cell.Style.ForeColor = s.Marks >= 50 ? Color.DarkGreen : Color.Red;
                cell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            lblCount.Text = $"Total Students: {studentList.Count}";
        }
    }
}
