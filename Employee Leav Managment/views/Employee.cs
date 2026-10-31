using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();

            comDepart.Items.AddRange(new object[]
            {
                "All departments",
                "Department 1",
                "Department 2",
                "Department 3",
                "Department 4",
                "Department 5"
            });

            comStatus.Items.AddRange(new object[]
            {
                "All status",
                "Active",
                "Deactivated",
                "Suspended"
            });

            comDepart.SelectedIndex = 0;
            comStatus.SelectedIndex = 0;

            AddEmployee("EMP001", "Employee 1", "Female", "Department 1", "Accountant", "01/02/2022", "employee1@example.com", "4 years", "Active");
            AddEmployee("EMP002", "Employee 2", "Male", "Department 2", "Developer", "15/04/2021", "employee2@example.com", "5 years", "Active");
            AddEmployee("EMP003", "Employee 3", "Female", "Department 3", "Designer", "20/08/2023", "employee3@example.com", "2 years", "Suspended");
            AddEmployee("EMP004", "Employee 4", "Male", "Department 4", "Manager", "10/01/2020", "employee4@example.com", "6 years", "Deactivated");
            AddEmployee("EMP005", "Employee 5", "Female", "Department 5", "Assistant", "05/06/2024", "employee5@example.com", "1 year", "Active");

            textSerch.TextChanged += EmployeeFilterChanged;
            comDepart.SelectedIndexChanged += EmployeeFilterChanged;
            comStatus.SelectedIndexChanged += EmployeeFilterChanged;
            btnAddEmployee.Click += OpenAddEmployee;
        }

        private void AddEmployee(params string[] values)
        {
            DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Add(values)];
            row.Tag = new[] { values[3], values[8] };
        }

        private void EmployeeFilterChanged(object? sender, EventArgs e)
        {
            string searchText = textSerch.Text.Trim();
            string department = comDepart.SelectedItem?.ToString() ?? "All departments";
            string status = comStatus.SelectedItem?.ToString() ?? "All status";

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string code = row.Cells[0].Value?.ToString() ?? string.Empty;
                string name = row.Cells[1].Value?.ToString() ?? string.Empty;
                string rowDepartment = row.Tag is string[] values ? values[0] : string.Empty;
                string rowStatus = row.Tag is string[] statusValues ? statusValues[1] : string.Empty;

                bool matchesSearch = string.IsNullOrWhiteSpace(searchText)
                    || code.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
                bool matchesDepartment = department == "All departments" || rowDepartment == department;
                bool matchesStatus = status == "All status" || rowStatus == status;

                row.Visible = matchesSearch && matchesDepartment && matchesStatus;
            }
        }

        private void OpenAddEmployee(object? sender, EventArgs e)
        {
            using AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog(this);
        }
    }
}
