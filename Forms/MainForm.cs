using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SmartResultSystem
{
    // ============================================================
    // Q#1 - Part (iii) & (iv): Main Windows Forms Interface
    // Contains TabControl - Tab1 = Q1, Tab2 = Q2 (ML Prediction)
    // ============================================================
    public class MainForm : Form
    {
        private TabControl tabControl;
        private TabPage tabQ1, tabQ2;

        // Q1 Controls
        private Label lblTitle1, lblName, lblAge, lblID, lblMarks1, lblSemester, lblDept, lblResult1;
        private TextBox txtName, txtAge, txtID, txtMarks1, txtSemester, txtDept, txtResult1;
        private Button btnAddStudent, btnShowResult, btnViewAll, btnClear1;

        // Q2 Controls
        private Label lblTitle2, lblMarks2, lblAttendance, lblAssignments, lblResult2, lblProb;
        private TextBox txtMarks2, txtAttendance, txtAssignments, txtResult2, txtProb;
        private Button btnPredict, btnClear2;

        // Data
        private List<Student> studentList = new List<Student>();
        private MLModelTrainer mlTrainer;

        public MainForm()
        {
            InitializeComponents();
            // Load ML model in background
            try { mlTrainer = new MLModelTrainer(); } catch { }
        }

        private void InitializeComponents()
        {
            this.Text = "Smart Student Result Prediction System - IST KICSIT";
            this.Size = new Size(560, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.WhiteSmoke;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Tab Control
            tabControl = new TabControl();
            tabControl.Location = new Point(10, 10);
            tabControl.Size = new Size(520, 560);
            tabControl.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            tabQ1 = new TabPage("Q1 - OOP System");
            tabQ2 = new TabPage("Q2 - ML Prediction");

            BuildQ1Tab();
            BuildQ2Tab();

            tabControl.TabPages.Add(tabQ1);
            tabControl.TabPages.Add(tabQ2);
            this.Controls.Add(tabControl);
        }

        // ============================================================
        // Q1 Tab - OOP Console + Windows Forms
        // ============================================================
        private void BuildQ1Tab()
        {
            tabQ1.BackColor = Color.WhiteSmoke;

            lblTitle1 = new Label();
            lblTitle1.Text = "Student Result Prediction - OOP System";
            lblTitle1.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTitle1.ForeColor = Color.DarkBlue;
            lblTitle1.Location = new Point(10, 12);
            lblTitle1.Size = new Size(490, 28);
            lblTitle1.TextAlign = ContentAlignment.MiddleCenter;

            // Labels & TextBoxes
            lblName = MakeLabel("Student Name:", 20, 58);
            txtName = MakeTextBox(170, 55);

            lblAge = MakeLabel("Age:", 20, 95);
            txtAge = MakeTextBox(170, 92);

            lblID = MakeLabel("Student ID:", 20, 132);
            txtID = MakeTextBox(170, 129);

            lblMarks1 = MakeLabel("Marks (0-100):", 20, 169);
            txtMarks1 = MakeTextBox(170, 166);

            lblSemester = MakeLabel("Semester:", 20, 206);
            txtSemester = MakeTextBox(170, 203);

            lblDept = MakeLabel("Department:", 20, 243);
            txtDept = MakeTextBox(170, 240);

            lblResult1 = new Label();
            lblResult1.Text = "Predicted Result:";
            lblResult1.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblResult1.Location = new Point(20, 290);
            lblResult1.Size = new Size(140, 25);

            txtResult1 = new TextBox();
            txtResult1.Location = new Point(170, 287);
            txtResult1.Size = new Size(320, 28);
            txtResult1.ReadOnly = true;
            txtResult1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            txtResult1.BackColor = Color.LightYellow;
            txtResult1.ForeColor = Color.DarkGreen;
            txtResult1.TextAlign = HorizontalAlignment.Center;

            // Buttons
            btnAddStudent = MakeButton("Add Student", 20, 335, Color.SteelBlue);
            btnAddStudent.Click += btnAddStudent_Click;

            btnShowResult = MakeButton("Show Result", 155, 335, Color.ForestGreen);
            btnShowResult.Click += btnShowResult_Click;

            btnViewAll = MakeButton("View All Students", 290, 335, Color.DarkOrange);
            btnViewAll.Click += btnViewAll_Click;

            btnClear1 = MakeButton("Clear", 155, 385, Color.Tomato);
            btnClear1.Click += (s, e) =>
            {
                txtName.Clear(); txtAge.Clear(); txtID.Clear();
                txtMarks1.Clear(); txtSemester.Clear(); txtDept.Clear(); txtResult1.Clear();
            };

            tabQ1.Controls.AddRange(new Control[]
            {
                lblTitle1,
                lblName, txtName, lblAge, txtAge, lblID, txtID,
                lblMarks1, txtMarks1, lblSemester, txtSemester, lblDept, txtDept,
                lblResult1, txtResult1,
                btnAddStudent, btnShowResult, btnViewAll, btnClear1
            });
        }

        // ============================================================
        // Q2 Tab - ML.NET Prediction
        // ============================================================
        private void BuildQ2Tab()
        {
            tabQ2.BackColor = Color.WhiteSmoke;

            lblTitle2 = new Label();
            lblTitle2.Text = "ML.NET - Smart Result Predictor";
            lblTitle2.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblTitle2.ForeColor = Color.DarkBlue;
            lblTitle2.Location = new Point(10, 12);
            lblTitle2.Size = new Size(490, 28);
            lblTitle2.TextAlign = ContentAlignment.MiddleCenter;

            lblMarks2 = MakeLabel("Exam Marks (0-100):", 20, 65);
            txtMarks2 = MakeTextBox(220, 62);

            lblAttendance = MakeLabel("Attendance (%):", 20, 105);
            txtAttendance = MakeTextBox(220, 102);

            lblAssignments = MakeLabel("Assignments (%):", 20, 145);
            txtAssignments = MakeTextBox(220, 142);

            lblResult2 = new Label();
            lblResult2.Text = "Predicted Result:";
            lblResult2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblResult2.Location = new Point(20, 210);
            lblResult2.Size = new Size(180, 28);

            txtResult2 = new TextBox();
            txtResult2.Location = new Point(220, 207);
            txtResult2.Size = new Size(270, 30);
            txtResult2.ReadOnly = true;
            txtResult2.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            txtResult2.BackColor = Color.LightYellow;
            txtResult2.TextAlign = HorizontalAlignment.Center;

            lblProb = MakeLabel("Confidence:", 20, 255);
            txtProb = new TextBox();
            txtProb.Location = new Point(220, 252);
            txtProb.Size = new Size(270, 25);
            txtProb.ReadOnly = true;
            txtProb.BackColor = Color.LightCyan;

            btnPredict = MakeButton("Predict Result", 100, 310, Color.SteelBlue);
            btnPredict.Click += btnPredict_Click;

            btnClear2 = MakeButton("Clear", 270, 310, Color.Tomato);
            btnClear2.Click += (s, e) =>
            {
                txtMarks2.Clear(); txtAttendance.Clear();
                txtAssignments.Clear(); txtResult2.Clear(); txtProb.Clear();
                txtResult2.BackColor = Color.LightYellow;
            };

            // Docker info panel
            var lblDocker = new Label();
            lblDocker.Text = "Docker Commands:\n  docker build -t smart-result-app .\n  docker run -d -p 8080:8080 smart-result-app\n  docker ps";
            lblDocker.Font = new Font("Courier New", 8);
            lblDocker.ForeColor = Color.DarkSlateGray;
            lblDocker.BackColor = Color.LightGray;
            lblDocker.Location = new Point(20, 380);
            lblDocker.Size = new Size(470, 80);
            lblDocker.BorderStyle = BorderStyle.FixedSingle;

            tabQ2.Controls.AddRange(new Control[]
            {
                lblTitle2,
                lblMarks2, txtMarks2,
                lblAttendance, txtAttendance,
                lblAssignments, txtAssignments,
                lblResult2, txtResult2,
                lblProb, txtProb,
                btnPredict, btnClear2,
                lblDocker
            });
        }

        // ============================================================
        // Event Handlers - Q#1 Part (iv)
        // ============================================================
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtMarks1.Text))
            {
                MessageBox.Show("Please fill Name and Marks.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var s = new Student(
                    txtName.Text,
                    int.Parse(txtAge.Text == "" ? "0" : txtAge.Text),
                    txtID.Text,
                    double.Parse(txtMarks1.Text),
                    txtSemester.Text,
                    txtDept.Text
                );
                studentList.Add(s);
                txtResult1.Text = s.PredictResult();
                txtResult1.ForeColor = s.Marks >= 50 ? Color.DarkGreen : Color.Red;
                MessageBox.Show($"Student '{s.Name}' added!\nResult: {s.PredictResult()}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Invalid input. Check Age and Marks fields.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarks1.Text))
            {
                MessageBox.Show("Please enter marks.", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                double marks = double.Parse(txtMarks1.Text);
                var temp = new Student("", 0, "", marks, "", "");
                txtResult1.Text = temp.PredictResult();
                txtResult1.ForeColor = marks >= 50 ? Color.DarkGreen : Color.Red;
            }
            catch
            {
                MessageBox.Show("Enter valid marks.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Q#1 Part (v) - Open Second Form
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            var allForm = new AllStudentsForm(studentList);
            allForm.Show();
        }

        // Q#2 Event Handler
        private void btnPredict_Click(object sender, EventArgs e)
        {
            if (mlTrainer == null)
            {
                MessageBox.Show("ML Model not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                float marks = float.Parse(txtMarks2.Text);
                float att = float.Parse(txtAttendance.Text == "" ? "75" : txtAttendance.Text);
                float asgn = float.Parse(txtAssignments.Text == "" ? "70" : txtAssignments.Text);

                var prediction = mlTrainer.Predict(marks, att, asgn);

                if (prediction.PredictedPassFail)
                {
                    txtResult2.Text = "PASS ✓";
                    txtResult2.ForeColor = Color.DarkGreen;
                    txtResult2.BackColor = Color.LightGreen;
                }
                else
                {
                    txtResult2.Text = "FAIL ✗";
                    txtResult2.ForeColor = Color.DarkRed;
                    txtResult2.BackColor = Color.LightCoral;
                }
                txtProb.Text = $"{prediction.Probability * 100:F1}% confidence";
            }
            catch
            {
                MessageBox.Show("Enter valid numeric values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // Helper Methods
        // ============================================================
        private Label MakeLabel(string text, int x, int y)
        {
            return new Label { Text = text, Location = new Point(x, y), Size = new Size(160, 25), Font = new Font("Segoe UI", 9) };
        }

        private TextBox MakeTextBox(int x, int y)
        {
            return new TextBox { Location = new Point(x, y), Size = new Size(310, 25) };
        }

        private Button MakeButton(string text, int x, int y, Color color)
        {
            return new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(125, 38),
                BackColor = color,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
        }
    }
}
