using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Clearance_desk : Form
    {
        public Clearance_desk()
        {
            InitializeComponent();

            compStatus.SelectedIndex = 2;
            comboBox1.SelectedIndex = 0;

            AddClearanceRow("CLR001", "Employee 1", "EMP001", "Department 1", "Annual Leave", "01/06/2026 - 03/06/2026", "3", "Finance", "Pending Clearance", "Review", "Department 1|My Clearance");
            AddClearanceRow("CLR002", "Employee 2", "EMP002", "Department 2", "Sick Leave", "05/06/2026 - 06/06/2026", "2", "HR", "Complated Clearance", "Review", "Department 2");
            AddClearanceRow("CLR003", "Employee 3", "EMP003", "Department 1", "Annual Leave", "10/06/2026 - 12/06/2026", "3", "IT", "Pending Clearance", "Review", "Department 1");
            AddClearanceRow("CLR004", "Employee 4", "EMP004", "Department 3", "Emergency Leave", "15/06/2026 - 16/06/2026", "2", "Administration", "Complated Clearance", "Review", "Department 3|My Clearance");
            AddClearanceRow("CLR005", "Employee 5", "EMP005", "Department 1", "Annual Leave", "20/06/2026 - 24/06/2026", "5", "Finance", "Pending Clearance", "Review", "Department 1");

            textBox1.TextChanged += ClearanceFilterChanged;
            compStatus.SelectedIndexChanged += ClearanceFilterChanged;
            comboBox1.SelectedIndexChanged += ClearanceFilterChanged;
        }

        private void AddClearanceRow(
            string clearanceId,
            string name,
            string employeeCode,
            string department,
            string leaveType,
            string studyPeriod,
            string days,
            string clearanceHead,
            string status,
            string action,
            string scope)
        {
            int rowIndex = dataGridView1.Rows.Add(
                clearanceId,
                name,
                employeeCode,
                department,
                leaveType,
                studyPeriod,
                days,
                clearanceHead,
                status,
                action);
            dataGridView1.Rows[rowIndex].Tag = scope;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClearanceFilterChanged(object? sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string? selectedStatus = compStatus.SelectedItem?.ToString();
            string? selectedView = comboBox1.SelectedItem?.ToString();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string clearanceId = row.Cells[0].Value?.ToString() ?? string.Empty;
                string name = row.Cells[1].Value?.ToString() ?? string.Empty;
                string employeeCode = row.Cells[2].Value?.ToString() ?? string.Empty;
                string status = row.Cells[8].Value?.ToString() ?? string.Empty;
                string scope = row.Tag?.ToString() ?? string.Empty;

                bool matchesSearch = string.IsNullOrWhiteSpace(searchText)
                    || clearanceId.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || employeeCode.Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
                bool matchesStatus = selectedStatus == "All Clearance" || status == selectedStatus;
                bool matchesView = selectedView == "All Employee"
                    || selectedView == "My Department" && scope.Contains("Department 1", StringComparison.OrdinalIgnoreCase)
                    || selectedView == "My Clearance" && scope.Contains("My Clearance", StringComparison.OrdinalIgnoreCase);

                row.Visible = matchesSearch && matchesStatus && matchesView;
            }
        }
    }
}
