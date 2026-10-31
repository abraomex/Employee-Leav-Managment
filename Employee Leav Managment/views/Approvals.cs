using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Approvals : Form
    {
        public Approvals()
        {
            InitializeComponent();

            compStatus.Items.AddRange(new object[]
            {
                "All status",
                "Approved",
                "Submitted",
                "Rejected",
                "Pending Clearance",
                "Completed"
            });

            comboBox2.Items.AddRange(new object[]
            {
                "All departments",
                "Department 1",
                "Department 2",
                "Department 3",
                "Department 4",
                "Department 5"
            });

            compStatus.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            dataGridView1.Rows.Add("EMP001", "Employee 1", "Annual Leave", "01/06/2026 - 03/06/2026", "3", "Submitted", "Review");
            dataGridView1.Rows.Add("EMP002", "Employee 2", "Sick Leave", "05/06/2026 - 06/06/2026", "2", "Approved", "Review");
            dataGridView1.Rows.Add("EMP003", "Employee 3", "Annual Leave", "10/06/2026 - 12/06/2026", "3", "Rejected", "Review");
            dataGridView1.Rows.Add("EMP004", "Employee 4", "Emergency Leave", "15/06/2026 - 16/06/2026", "2", "Pending Clearance", "Review");
            dataGridView1.Rows.Add("EMP005", "Employee 5", "Annual Leave", "20/06/2026 - 24/06/2026", "5", "Completed", "Review");

            dataGridView1.Rows[0].Tag = "Department 1";
            dataGridView1.Rows[1].Tag = "Department 2";
            dataGridView1.Rows[2].Tag = "Department 3";
            dataGridView1.Rows[3].Tag = "Department 4";
            dataGridView1.Rows[4].Tag = "Department 5";

            textBox1.TextChanged += ApprovalFilterChanged;
            compStatus.SelectedIndexChanged += ApprovalFilterChanged;
            comboBox2.SelectedIndexChanged += ApprovalFilterChanged;
        }

        private void ApprovalFilterChanged(object? sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string? selectedStatus = compStatus.SelectedItem?.ToString();
            string? selectedDepartment = comboBox2.SelectedItem?.ToString();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string employeeCode = row.Cells[0].Value?.ToString() ?? string.Empty;
                string employeeName = row.Cells[1].Value?.ToString() ?? string.Empty;
                string status = row.Cells[5].Value?.ToString() ?? string.Empty;
                string department = row.Tag?.ToString() ?? string.Empty;

                bool matchesSearch = string.IsNullOrWhiteSpace(searchText)
                    || employeeCode.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || employeeName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
                bool matchesStatus = selectedStatus == "All status" || status == selectedStatus;
                bool matchesDepartment = selectedDepartment == "All departments" || department == selectedDepartment;

                row.Visible = matchesSearch && matchesStatus && matchesDepartment;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
