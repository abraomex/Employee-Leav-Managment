using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();

            AddDepartment("DEP001", "Human Resources", "Arthur Pendleton", "12");
            AddDepartment("DEP002", "Engineering", "Marcus Vance", "24");
            AddDepartment("DEP003", "Finance", "Grace Hopper", "8");
            AddDepartment("DEP004", "Operations", "David Miller", "15");
            AddDepartment("DEP005", "Marketing", "Sophia Chen", "10");

            textSerach.TextChanged += DepartmentSearchChanged;
            btnAddDept.Click += OpenAddDepartment;
        }

        private void AddDepartment(string code, string name, string head, string personnel)
        {
            dataGridView1.Rows.Add(code, name, head, personnel, "View");
        }

        private void DepartmentSearchChanged(object? sender, EventArgs e)
        {
            string searchText = textSerach.Text.Trim();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string code = row.Cells[0].Value?.ToString() ?? string.Empty;
                string name = row.Cells[1].Value?.ToString() ?? string.Empty;
                row.Visible = string.IsNullOrWhiteSpace(searchText)
                    || code.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || name.Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
            }
        }

        private void OpenAddDepartment(object? sender, EventArgs e)
        {
            using AddDepartmet addDepartment = new AddDepartmet();
            addDepartment.ShowDialog(this);
        }
    }
}
