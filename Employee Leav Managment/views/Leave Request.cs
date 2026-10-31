using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Leave_Request : Form
    {
        public Leave_Request()
        {
            InitializeComponent();

            compStatus.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            AddRequestRow("LR001", "Employee 1", "EMP001", "Annual Leave", "01/06/2026", "03/06/2026", "3", "Submitted", "My Request");
            AddRequestRow("LR002", "Employee 2", "EMP002", "Sick Leave", "05/06/2026", "06/06/2026", "2", "Approved", "Other Request");
            AddRequestRow("LR003", "Employee 3", "EMP003", "Annual Leave", "10/06/2026", "12/06/2026", "3", "Under Review", "Other Request");
            AddRequestRow("LR004", "Employee 4", "EMP004", "Emergency Leave", "15/06/2026", "16/06/2026", "2", "Rejected", "Other Request");

            textBox1.TextChanged += LeaveRequestFilterChanged;
            compStatus.SelectedIndexChanged += LeaveRequestFilterChanged;
            comboBox2.SelectedIndexChanged += LeaveRequestFilterChanged;
            button1.Click += NewRequestButton_Click;

            AddLeaveTypeRow("AL", "Annual Leave", "20", "0", "No", "Edit");
            AddLeaveTypeRow("SL", "Sick Leave", "10", "3 months", "No", "Edit");
            AddLeaveTypeRow("EL", "Emergency Leave", "5", "6 months", "Yes", "Edit");
            textBox2.TextChanged += LeaveTypeFilterChanged;
            button2.Click += NewTypeButton_Click;

            AddEntitlementRow("EMP001", "Employee 1", "Department 1", "Annual Leave", "20", "2", "0", "22", "3", "14%");
            AddEntitlementRow("EMP002", "Employee 2", "Department 2", "Sick Leave", "10", "0", "1", "11", "2", "18%");
            AddEntitlementRow("EMP003", "Employee 3", "Department 3", "Annual Leave", "20", "1", "0", "21", "5", "24%");
            textBox3.TextChanged += EntitlementFilterChanged;
            button3.Click += GenerateButton_Click;
        }

        private void AddRequestRow(
            string requestId,
            string name,
            string employeeCode,
            string leaveType,
            string startDate,
            string endDate,
            string days,
            string status,
            string requestScope)
        {
            int rowIndex = dataGridView1.Rows.Add(
                requestId,
                name,
                employeeCode,
                leaveType,
                startDate,
                endDate,
                days,
                status,
                "Review");

            dataGridView1.Rows[rowIndex].Tag = requestScope;
        }

        private void LeaveRequestFilterChanged(object? sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();
            string? selectedStatus = compStatus.SelectedItem?.ToString();
            string? selectedView = comboBox2.SelectedItem?.ToString();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                string requestId = row.Cells[0].Value?.ToString() ?? string.Empty;
                string employeeName = row.Cells[1].Value?.ToString() ?? string.Empty;
                string employeeCode = row.Cells[2].Value?.ToString() ?? string.Empty;
                string status = row.Cells[7].Value?.ToString() ?? string.Empty;
                string requestScope = row.Tag?.ToString() ?? string.Empty;

                bool matchesSearch = string.IsNullOrWhiteSpace(searchText)
                    || requestId.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || employeeName.Contains(searchText, StringComparison.CurrentCultureIgnoreCase)
                    || employeeCode.Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
                bool matchesStatus = selectedStatus == "All Status" || status == selectedStatus;
                bool matchesView = selectedView == "All Employee"
                    || selectedView == "My Request" && requestScope == "My Request";

                row.Visible = matchesSearch && matchesStatus && matchesView;
            }
        }

        private void NewRequestButton_Click(object? sender, EventArgs e)
        {
            using LeaveRequestDialog dialog = new();

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            string requestId = $"LR{dataGridView1.Rows.Count + 1:000}";
            int days = (dialog.EndDate.Date - dialog.StartDate.Date).Days + 1;

            AddRequestRow(
                requestId,
                dialog.EmployeeName,
                dialog.EmployeeCode,
                dialog.LeaveType,
                dialog.StartDate.ToString("dd/MM/yyyy"),
                dialog.EndDate.ToString("dd/MM/yyyy"),
                days.ToString(),
                "Submitted",
                "My Request");

            LeaveRequestFilterChanged(null, EventArgs.Empty);
        }

        private void AddLeaveTypeRow(string code, string leaveType, string quota, string minimumService, string clearanceRequired, string action)
        {
            dataGridView2.Rows.Add(code, leaveType, quota, minimumService, clearanceRequired, action);
        }

        private void LeaveTypeFilterChanged(object? sender, EventArgs e)
        {
            string searchText = textBox2.Text.Trim();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                bool matchesSearch = string.IsNullOrWhiteSpace(searchText)
                    || string.Join(" ", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString()))
                        .Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
                row.Visible = matchesSearch;
            }
        }

        private void NewTypeButton_Click(object? sender, EventArgs e)
        {
            using LeaveTypeDialog dialog = new();

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            AddLeaveTypeRow(
                dialog.TypeCode,
                dialog.LeaveType,
                dialog.AnnualQuota,
                dialog.MinimumService,
                dialog.ClearanceRequired ? "Yes" : "No",
                "Edit");
            LeaveTypeFilterChanged(null, EventArgs.Empty);
        }

        private void AddEntitlementRow(string employeeCode, string name, string department, string leaveType, string baseDays, string carryDays, string bonusDays, string totalDays, string usedDays, string utilization)
        {
            dataGridView3.Rows.Add(employeeCode, name, department, leaveType, baseDays, carryDays, bonusDays, totalDays, usedDays, utilization);
        }

        private void EntitlementFilterChanged(object? sender, EventArgs e)
        {
            string searchText = textBox3.Text.Trim();

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                bool matchesSearch = string.IsNullOrWhiteSpace(searchText)
                    || string.Join(" ", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value?.ToString()))
                        .Contains(searchText, StringComparison.CurrentCultureIgnoreCase);
                row.Visible = matchesSearch;
            }
        }

        private void GenerateButton_Click(object? sender, EventArgs e)
        {
            using EntitlementDialog dialog = new();

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            AddEntitlementRow(dialog.EmployeeCode, dialog.EmployeeName, dialog.Department, dialog.LeaveType, "20", "0", "0", "20", "0", "0%");
            EntitlementFilterChanged(null, EventArgs.Empty);
        }

        private void Leave_Request_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private sealed class LeaveTypeDialog : Form
        {
            private readonly TextBox typeCodeTextBox = new();
            private readonly TextBox leaveTypeTextBox = new();
            private readonly TextBox annualQuotaTextBox = new();
            private readonly TextBox minimumServiceTextBox = new();
            private readonly CheckBox clearanceCheckBox = new();

            public string TypeCode => typeCodeTextBox.Text.Trim();
            public string LeaveType => leaveTypeTextBox.Text.Trim();
            public string AnnualQuota => annualQuotaTextBox.Text.Trim();
            public string MinimumService => minimumServiceTextBox.Text.Trim();
            public bool ClearanceRequired => clearanceCheckBox.Checked;

            public LeaveTypeDialog()
            {
                Text = "New Leave Type";
                ClientSize = new Size(400, 280);
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                StartPosition = FormStartPosition.CenterParent;

                AddField("Type code", typeCodeTextBox, 20);
                AddField("Leave type", leaveTypeTextBox, 60);
                AddField("Annual quota", annualQuotaTextBox, 100);
                AddField("Minimum service", minimumServiceTextBox, 140);

                clearanceCheckBox.AutoSize = true;
                clearanceCheckBox.Location = new Point(120, 180);
                clearanceCheckBox.Text = "Clearance required";
                Controls.Add(clearanceCheckBox);

                Button cancelButton = new() { DialogResult = DialogResult.Cancel, Location = new Point(215, 225), Size = new Size(75, 30), Text = "Cancel" };
                Button saveButton = new() { Location = new Point(300, 225), Size = new Size(75, 30), Text = "Save" };
                saveButton.Click += SaveButton_Click;
                Controls.Add(cancelButton);
                Controls.Add(saveButton);
                AcceptButton = saveButton;
                CancelButton = cancelButton;
            }

            private void AddField(string labelText, TextBox textBox, int top)
            {
                Controls.Add(new Label { AutoSize = true, Location = new Point(20, top + 5), Text = labelText });
                textBox.Location = new Point(120, top);
                textBox.Size = new Size(255, 27);
                Controls.Add(textBox);
            }

            private void SaveButton_Click(object? sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(TypeCode) || string.IsNullOrWhiteSpace(LeaveType)
                    || string.IsNullOrWhiteSpace(AnnualQuota) || string.IsNullOrWhiteSpace(MinimumService))
                {
                    MessageBox.Show(this, "Complete all leave type fields.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private sealed class EntitlementDialog : Form
        {
            private readonly ComboBox employeeComboBox = new();

            public string EmployeeName => employeeComboBox.Text.Split(" - ")[0];
            public string EmployeeCode => employeeComboBox.Text.Split(" - ")[1];
            public string Department => employeeComboBox.SelectedIndex switch
            {
                0 => "Department 1",
                1 => "Department 2",
                2 => "Department 3",
                _ => "Department 1"
            };
            public string LeaveType => "Annual Leave";

            public EntitlementDialog()
            {
                Text = "Generate Entitlement";
                ClientSize = new Size(400, 150);
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                StartPosition = FormStartPosition.CenterParent;

                Controls.Add(new Label { AutoSize = true, Location = new Point(20, 25), Text = "Employee" });
                employeeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                employeeComboBox.Items.AddRange(new object[] { "Employee 1 - EMP001", "Employee 2 - EMP002", "Employee 3 - EMP003" });
                employeeComboBox.SelectedIndex = 0;
                employeeComboBox.Location = new Point(120, 20);
                employeeComboBox.Size = new Size(250, 27);
                Controls.Add(employeeComboBox);

                Button cancelButton = new() { DialogResult = DialogResult.Cancel, Location = new Point(205, 90), Size = new Size(75, 30), Text = "Cancel" };
                Button generateButton = new() { Location = new Point(290, 90), Size = new Size(80, 30), Text = "Generate" };
                generateButton.Click += (_, _) => { DialogResult = DialogResult.OK; Close(); };
                Controls.Add(cancelButton);
                Controls.Add(generateButton);
                AcceptButton = generateButton;
                CancelButton = cancelButton;
            }
        }

        private sealed class LeaveRequestDialog : Form
        {
            private readonly ComboBox employeeComboBox = new();
            private readonly ComboBox leaveTypeComboBox = new();
            private readonly DateTimePicker startDatePicker = new();
            private readonly DateTimePicker endDatePicker = new();
            private readonly TextBox reasonTextBox = new();

            public string EmployeeName => employeeComboBox.Text.Split(" - ")[0];
            public string EmployeeCode => employeeComboBox.Text.Split(" - ")[1];
            public string LeaveType => leaveTypeComboBox.Text;
            public DateTime StartDate => startDatePicker.Value.Date;
            public DateTime EndDate => endDatePicker.Value.Date;

            public LeaveRequestDialog()
            {
                Text = "New Leave Request";
                ClientSize = new Size(420, 330);
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;
                StartPosition = FormStartPosition.CenterParent;

                employeeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                employeeComboBox.Items.AddRange(new object[]
                {
                    "Employee 1 - EMP001",
                    "Employee 2 - EMP002",
                    "Employee 3 - EMP003",
                    "Employee 4 - EMP004"
                });
                employeeComboBox.SelectedIndex = 0;

                leaveTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                leaveTypeComboBox.Items.AddRange(new object[]
                {
                    "Annual Leave",
                    "Sick Leave",
                    "Emergency Leave"
                });
                leaveTypeComboBox.SelectedIndex = 0;

                startDatePicker.Format = DateTimePickerFormat.Short;
                endDatePicker.Format = DateTimePickerFormat.Short;
                endDatePicker.Value = DateTime.Today.AddDays(1);

                reasonTextBox.Multiline = true;
                reasonTextBox.ScrollBars = ScrollBars.Vertical;

                AddField("Employee", employeeComboBox, 20);
                AddField("Leave type", leaveTypeComboBox, 65);
                AddField("Start date", startDatePicker, 110);
                AddField("End date", endDatePicker, 155);
                AddField("Reason", reasonTextBox, 200);

                Button cancelButton = new()
                {
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(220, 275),
                    Size = new Size(80, 30),
                    Text = "Cancel"
                };
                Button submitButton = new()
                {
                    Location = new Point(310, 275),
                    Size = new Size(90, 30),
                    Text = "Submit"
                };
                submitButton.Click += SubmitButton_Click;

                Controls.Add(cancelButton);
                Controls.Add(submitButton);
                AcceptButton = submitButton;
                CancelButton = cancelButton;
            }

            private void AddField(string labelText, Control control, int top)
            {
                Controls.Add(new Label
                {
                    AutoSize = true,
                    Location = new Point(20, top + 5),
                    Text = labelText
                });

                control.Location = new Point(120, top);
                control.Size = new Size(280, labelText == "Reason" ? 60 : 27);
                Controls.Add(control);
            }

            private void SubmitButton_Click(object? sender, EventArgs e)
            {
                if (EndDate < StartDate)
                {
                    MessageBox.Show(this, "The end date must be on or after the start date.", "Invalid dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
