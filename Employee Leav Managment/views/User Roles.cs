using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class User_Roles : Form
    {
        public User_Roles()
        {
            InitializeComponent();

            compStatus.SelectedIndex = 0;

            dataGridView1.Rows.Add("Administrator", "ADMIN", "Admin User", "All permissions", "Active", "Edit");
            dataGridView1.Rows.Add("HR Manager", "HR_MANAGER", "HR User", "Employees, Leave requests", "Active", "Edit");
            dataGridView1.Rows.Add("Department Manager", "DEPT_MANAGER", "Manager User", "Leave requests, Approvals", "Active", "Edit");
            dataGridView1.Rows.Add("Employee", "EMPLOYEE", "Employee User", "Leave requests", "InActive", "Edit");

            textBox1.TextChanged += UserRoleFilterChanged;
            compStatus.SelectedIndexChanged += UserRoleFilterChanged;
        }

        private void User_Roles_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using RoleDialog dialog = new();
            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            dataGridView1.Rows.Add(
                dialog.RoleName,
                dialog.RoleKey,
                dialog.AssignedUser,
                dialog.Permissions,
                "Active",
                "Edit");

        }

        private void UserRoleFilterChanged(object? sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string? selectedStatus = compStatus.SelectedItem?.ToString();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string roleName = row.Cells[0].Value?.ToString() ?? string.Empty;
                string roleKey = row.Cells[1].Value?.ToString() ?? string.Empty;
                string status = row.Cells[4].Value?.ToString() ?? string.Empty;

                bool matchesSearch = string.IsNullOrWhiteSpace(searchText)
                    || roleName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || roleKey.Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
                bool matchesStatus = selectedStatus == "All Status" || status == selectedStatus;

                row.Visible = matchesSearch && matchesStatus;
            }

        }

        private sealed class RoleDialog : Form
        {
            private readonly TextBox roleNameTextBox = new();
            private readonly TextBox roleKeyTextBox = new();
            private readonly TextBox assignedUserTextBox = new();
            private readonly TextBox permissionsTextBox = new();

            public RoleDialog()
            {
                Text = "Create Role";
                ClientSize = new Size(360, 250);
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.CenterParent;

                AddField("Role name", roleNameTextBox, 20);
                AddField("Role key", roleKeyTextBox, 65);
                AddField("Assigned user", assignedUserTextBox, 110);
                AddField("Permissions", permissionsTextBox, 155);

                Button cancelButton = new()
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(180, 205),
                    Size = new Size(75, 28)
                };
                Button createButton = new()
                {
                    Text = "Create",
                    Location = new Point(265, 205),
                    Size = new Size(75, 28)
                };
                createButton.Click += CreateButton_Click;

                Controls.Add(cancelButton);
                Controls.Add(createButton);
                AcceptButton = createButton;
                CancelButton = cancelButton;
            }

            public string RoleName => roleNameTextBox.Text.Trim();
            public string RoleKey => roleKeyTextBox.Text.Trim();
            public string AssignedUser => assignedUserTextBox.Text.Trim();
            public string Permissions => permissionsTextBox.Text.Trim();

            private void AddField(string labelText, TextBox textBox, int top)
            {
                Controls.Add(new Label
                {
                    AutoSize = true,
                    Location = new Point(20, top + 4),
                    Text = labelText
                });
                textBox.Location = new Point(125, top);
                textBox.Size = new Size(215, 23);
                Controls.Add(textBox);
            }

            private void CreateButton_Click(object? sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(RoleName)
                    || string.IsNullOrWhiteSpace(RoleKey)
                    || string.IsNullOrWhiteSpace(AssignedUser)
                    || string.IsNullOrWhiteSpace(Permissions))
                {
                    MessageBox.Show(this, "Complete all role fields.", "Create Role", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
