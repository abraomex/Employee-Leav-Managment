using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();

            compStatus.Items.Insert(0, "All departments");
            compStatus.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            AddReportRow("EMP001", "Employee 1", "Female", "Engineering", "Anual Vacation Leave", "20", "2", "0", "22", "3", "14%");
            AddReportRow("EMP002", "Employee 2", "Male", "Finance & Accounting", "Medical / Sick leave", "10", "0", "1", "11", "2", "18%");
            AddReportRow("EMP003", "Employee 3", "Female", "Human Resource", "Maternity / Parental", "90", "0", "0", "90", "30", "33%");
            AddReportRow("EMP004", "Employee 4", "Male", "Legal & Compliance", "Study", "15", "1", "0", "16", "4", "25%");
            AddReportRow("EMP005", "Employee 5", "Female", "Operation & Logestics", "Anual Vacation Leave", "20", "3", "1", "24", "5", "21%");

            textBox1.TextChanged += ReportFilterChanged;
            compStatus.SelectedIndexChanged += ReportFilterChanged;
            comboBox2.SelectedIndexChanged += ReportFilterChanged;
            comboBox1.SelectedIndexChanged += ReportFilterChanged;
            button1.Click += ExportButton_Click;
        }

        private void AddReportRow(string employeeCode, string name, string gender, string department, string leaveType, string baseDays, string carryDays, string bonusDays, string totalDays, string usedDays, string utilization)
        {
            dataGridView3.Rows.Add(employeeCode, name, gender, department, leaveType, baseDays, carryDays, bonusDays, totalDays, usedDays, utilization);
        }

        private void ReportFilterChanged(object? sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string? selectedDepartment = compStatus.SelectedItem?.ToString();
            string? selectedGender = comboBox2.SelectedItem?.ToString();
            string? selectedLeaveType = comboBox1.SelectedItem?.ToString();

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string employeeCode = row.Cells[0].Value?.ToString() ?? string.Empty;
                string employeeName = row.Cells[1].Value?.ToString() ?? string.Empty;
                string gender = row.Cells[2].Value?.ToString() ?? string.Empty;
                string department = row.Cells[3].Value?.ToString() ?? string.Empty;
                string leaveType = row.Cells[4].Value?.ToString() ?? string.Empty;

                bool matchesSearch = string.IsNullOrWhiteSpace(searchText)
                    || employeeCode.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || employeeName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
                bool matchesDepartment = selectedDepartment == "All departments" || department == selectedDepartment;
                bool matchesGender = selectedGender == "All" || gender == selectedGender;
                bool matchesLeaveType = selectedLeaveType == "All Leave Types" || leaveType == selectedLeaveType;

                row.Visible = matchesSearch && matchesDepartment && matchesGender && matchesLeaveType;
            }
        }

        private void ExportButton_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog saveFileDialog = new()
            {
                Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                FileName = "leave-report.csv",
                Title = "Export Leave Report"
            };

            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            StringBuilder csv = new();
            csv.AppendLine(string.Join(",", dataGridView3.Columns.Cast<DataGridViewColumn>().Select(column => EscapeCsv(column.HeaderText))));

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.IsNewRow || !row.Visible)
                {
                    continue;
                }

                csv.AppendLine(string.Join(",", row.Cells.Cast<DataGridViewCell>().Select(cell => EscapeCsv(cell.Value?.ToString() ?? string.Empty))));
            }

            File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);
            MessageBox.Show(this, "The visible report rows were exported successfully.", "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string EscapeCsv(string value)
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }
    }
}
