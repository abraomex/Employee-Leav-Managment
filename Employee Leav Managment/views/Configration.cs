using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Configration : Form
    {
        private readonly Color accentColor = Color.FromArgb(108, 117, 125);
        private readonly Color selectedColor = Color.FromArgb(238, 238, 238);
        private readonly Color pageBackgroundColor = SystemColors.Control;
        private readonly Color borderColor = SystemColors.ControlDark;
        private readonly Color textColor = Color.FromArgb(41, 58, 78);
        private readonly Color mutedColor = Color.FromArgb(112, 132, 154);

        private Panel contentPanel = null!;
        private Panel navigationPanel = null!;
        private TextBox filterTextBox = null!;
        private Button leaveSettingsButton = null!;
        private Button approvalWorkflowsButton = null!;
        private Button clearanceSettingsButton = null!;
        private Panel leaveView = null!;
        private Panel approvalView = null!;
        private Panel clearanceView = null!;
        private DataGridView workflowGrid = null!;
        private DataGridView clearanceGrid = null!;
        private DataGridView leaveGrid = null!;
        private TableLayoutPanel mainLayout = null!;
        private Panel leaveToolbar = null!;
        private Panel leavePolicies = null!;
        private Panel leaveNumbers = null!;
        private Button workflowNewButton = null!;
        private Button clearanceNewButton = null!;
        private ContextMenuStrip? gridActionMenu;
        private TextBox workflowSearchTextBox = null!;
        private TextBox clearanceSearchTextBox = null!;
        private ComboBox workflowTypeComboBox = null!;
        private ComboBox clearanceTypeComboBox = null!;
        private ComboBox leaveCategoryComboBox = null!;
        private NumericUpDown baseEntitlementNumeric = null!;
        private NumericUpDown minimumServiceNumeric = null!;
        private CheckBox attachmentCheckBox = null!;
        private CheckBox clearanceCheckBox = null!;
        private CheckBox carryOverCheckBox = null!;
        private CheckBox activePolicyCheckBox = null!;

        public Configration()
        {
            InitializeComponent();
            BuildConfigurationDesk();
            ShowView(leaveSettingsButton, leaveView);
        }

        private void Configration_Load(object sender, EventArgs e)
        {
        }

        private void BuildConfigurationDesk()
        {
            BackColor = pageBackgroundColor;
            Font = new Font("Segoe UI", 10F);

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                BackColor = pageBackgroundColor,
                Padding = new Padding(12)
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            mainLayout = layout;
            Controls.Add(layout);

            navigationPanel = CreateNavigationPanel();
            contentPanel = new Panel { Dock = DockStyle.Fill, Padding = new Padding(14, 10, 0, 0), BackColor = pageBackgroundColor };
            layout.Controls.Add(navigationPanel, 0, 0);
            layout.Controls.Add(contentPanel, 1, 0);

            leaveView = CreateLeaveSettingsView();
            approvalView = CreateWorkflowView();
            clearanceView = CreateClearanceView();
            contentPanel.Controls.Add(leaveView);
            contentPanel.Controls.Add(approvalView);
            contentPanel.Controls.Add(clearanceView);
            Resize += (_, _) => ResizeConfigurationDesk();
            contentPanel.Resize += (_, _) => ResizeConfigurationDesk();
            ResizeConfigurationDesk();
        }

        private Panel CreateNavigationPanel()
        {
            Panel panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(10, 10, 10, 10) };
            TableLayoutPanel navigationLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.White,
                Margin = Padding.Empty
            };
            navigationLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            navigationLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            navigationLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panel.Controls.Add(navigationLayout);

            Panel navigationHeader = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };
            Label heading = CreateLabel("⚙  CONFIGURATIONS", 10F, true, textColor, new Point(0, 2), new Size(190, 26));
            heading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Label count = CreateLabel("3", 9F, true, mutedColor, new Point(0, 3), new Size(28, 22));
            count.TextAlign = ContentAlignment.MiddleCenter;
            count.BackColor = Color.FromArgb(238, 238, 238);
            count.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            navigationHeader.Controls.Add(heading);
            navigationHeader.Controls.Add(count);
            navigationHeader.Resize += (_, _) =>
            {
                count.Left = Math.Max(0, navigationHeader.ClientSize.Width - count.Width);
                heading.Width = Math.Max(100, count.Left - 8);
            };
            navigationLayout.Controls.Add(navigationHeader, 0, 0);

            filterTextBox = new TextBox { Dock = DockStyle.Fill, PlaceholderText = "Filter settings...", Margin = new Padding(0, 2, 0, 4) };
            filterTextBox.TextChanged += FilterSettings;
            navigationLayout.Controls.Add(filterTextBox, 0, 1);

            FlowLayoutPanel menu = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(0, 8, 0, 0),
                Margin = Padding.Empty
            };
            navigationLayout.Controls.Add(menu, 0, 2);

            leaveSettingsButton = CreateMenuButton("▦  Leave Settings", "Category rules  policy toggles");
            approvalWorkflowsButton = CreateMenuButton("↗  Approval Workflows", "Multi-step hierarchy rules");
            clearanceSettingsButton = CreateMenuButton("⬟  Clearance Settings", "Exit clearances  checkpoints");
            leaveSettingsButton.Click += (_, _) => ShowView(leaveSettingsButton, leaveView);
            approvalWorkflowsButton.Click += (_, _) => ShowView(approvalWorkflowsButton, approvalView);
            clearanceSettingsButton.Click += (_, _) => ShowView(clearanceSettingsButton, clearanceView);
            menu.Controls.Add(leaveSettingsButton);
            menu.Controls.Add(approvalWorkflowsButton);
            menu.Controls.Add(clearanceSettingsButton);
            menu.Resize += (_, _) =>
            {
                int buttonWidth = Math.Max(120, menu.ClientSize.Width - menu.Padding.Horizontal - SystemInformation.VerticalScrollBarWidth);
                leaveSettingsButton.Width = buttonWidth;
                approvalWorkflowsButton.Width = buttonWidth;
                clearanceSettingsButton.Width = buttonWidth;
            };
            return panel;
        }

        private void ResizeConfigurationDesk()
        {
            if (contentPanel == null || leaveView == null || mainLayout == null)
            {
                return;
            }

            int availableWidth = mainLayout.ClientSize.Width;
            bool compact = availableWidth < 850;
            mainLayout.ColumnStyles[0].Width = compact ? 25F : 28F;
            mainLayout.ColumnStyles[1].Width = compact ? 75F : 72F;

            int width = Math.Max(260, contentPanel.ClientSize.Width - contentPanel.Padding.Horizontal);
            ResizeView(leaveView, width);
            ResizeView(approvalView, width);
            ResizeView(clearanceView, width);
            LayoutLeaveView(width);
            LayoutListView(approvalView, workflowGrid, workflowSearchTextBox, workflowTypeComboBox, workflowNewButton, width);
            LayoutListView(clearanceView, clearanceGrid, clearanceSearchTextBox, clearanceTypeComboBox, clearanceNewButton, width);
            ResizeGridToView(leaveView, leaveGrid);
            ResizeGridToView(approvalView, workflowGrid);
            ResizeGridToView(clearanceView, clearanceGrid);

            if (navigationPanel != null)
            {
                int countX = Math.Max(10, navigationPanel.ClientSize.Width - 38);
                foreach (Control control in navigationPanel.Controls)
                {
                    if (control is Label label && label.Text == "3")
                    {
                        label.Left = countX;
                    }
                }
            }
        }

        private void ResizeView(Panel view, int width)
        {
            foreach (Control control in view.Controls)
            {
                if (control is DataGridView grid)
                {
                    grid.Width = width;
                }
                else if (control is Panel panel && panel.BorderStyle == BorderStyle.FixedSingle)
                {
                    panel.Width = width;
                }
            }

        }

        private void ResizeGridToView(Panel view, DataGridView grid)
        {
            grid.Height = Math.Max(0, view.ClientSize.Height - grid.Top - 8);
        }

        private void LayoutLeaveView(int width)
        {
            if (leaveToolbar == null || leavePolicies == null || leaveNumbers == null || leaveGrid == null)
            {
                return;
            }

            Control categoryLabel = leaveToolbar.Controls[0];
            Control categoryCombo = leaveToolbar.Controls[1];
            Control newButton = leaveToolbar.Controls[2];
            Control saveButton = leaveToolbar.Controls[3];
            bool compact = width < 610;
            leaveToolbar.Height = compact ? 72 : 42;
            leavePolicies.Top = 54 + leaveToolbar.Height;
            leaveNumbers.Top = leavePolicies.Bottom + 12;
            leaveGrid.Top = leaveNumbers.Bottom + 12;

            if (compact)
            {
                categoryLabel.Location = new Point(10, 8);
                categoryLabel.Size = new Size(98, 25);
                categoryCombo.Location = new Point(108, 5);
                categoryCombo.Width = Math.Max(120, width - 120);
                newButton.Location = new Point(10, 39);
                saveButton.Location = new Point(Math.Min(width - saveButton.Width - 8, 142), 39);
            }
            else
            {
                categoryLabel.Location = new Point(12, 8);
                categoryLabel.Size = new Size(110, 22);
                int actionWidth = 105;
                int newWidth = 120;
                saveButton.Location = new Point(width - actionWidth - 8, 5);
                newButton.Location = new Point(width - actionWidth - newWidth - 16, 5);
                categoryCombo.Location = new Point(126, 5);
                categoryCombo.Width = Math.Max(150, newButton.Left - categoryCombo.Left - 10);
            }

            int numericRowWidth = Math.Max(500, width);
            bool stackNumbers = width < 570;
            leaveNumbers.Height = stackNumbers ? 88 : 58;
            leaveNumbers.Controls[0].Location = new Point(12, stackNumbers ? 8 : 18);
            baseEntitlementNumeric.Location = new Point(stackNumbers ? 178 : 175, stackNumbers ? 5 : 14);
            leaveNumbers.Controls[2].Location = new Point(stackNumbers ? 12 : Math.Min(280, numericRowWidth / 2), stackNumbers ? 52 : 18);
            minimumServiceNumeric.Location = new Point(stackNumbers ? 190 : Math.Min(456, numericRowWidth - 85), stackNumbers ? 49 : 14);
        }

        private void LayoutListView(Panel view, DataGridView grid, TextBox search, ComboBox typeFilter, Button newButton, int width)
        {
            bool compact = width < 620;
            Label? title = view.Controls.OfType<Label>().FirstOrDefault();
            if (title != null)
            {
                title.Width = width;
            }

            if (width < 420)
            {
                newButton.Location = new Point(0, 40);
                search.Location = new Point(0, 78);
                search.Width = Math.Max(180, width);
                typeFilter.Location = new Point(0, 112);
                typeFilter.Width = Math.Max(180, width);
                grid.Top = 147;
            }
            else if (compact)
            {
                newButton.Location = new Point(Math.Max(0, width - newButton.Width), 0);
                search.Location = new Point(0, 43);
                search.Width = Math.Max(180, width);
                typeFilter.Location = new Point(0, 77);
                typeFilter.Width = Math.Max(180, width);
                grid.Top = 112;
            }
            else
            {
                newButton.Location = new Point(width - newButton.Width, 0);
                search.Location = new Point(0, 45);
                search.Width = Math.Min(220, Math.Max(180, width / 2 - 4));
                typeFilter.Location = new Point(search.Right + 8, 45);
                typeFilter.Width = Math.Min(220, Math.Max(180, width - search.Right - 8));
                grid.Top = 82;
            }
        }

        private Button CreateMenuButton(string title, string subtitle)
        {
            Button button = new Button
            {
                Text = $"{title}\r\n{subTitle(subtitle)}",
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.White,
                ForeColor = textColor,
                Font = new Font("Segoe UI", 10F),
                Size = new Size(230, 64),
                Margin = new Padding(0, 0, 0, 3),
                Padding = new Padding(10, 0, 0, 0),
                UseCompatibleTextRendering = true
            };
            button.Tag = subtitle;
            return button;
        }

        private string subTitle(string value) => value;

        private Panel CreateLeaveSettingsView()
        {
            Panel view = CreateViewPanel();
            view.Controls.Add(CreatePageTitle("Leave Settings"));

            Panel toolbar = CreateBorderPanel(36);
            leaveToolbar = toolbar;
            toolbar.Top = 46;
            toolbar.Controls.Add(CreateLabel("Leave Category:", 10F, true, Color.Black, new Point(14, 8), new Size(110, 22)));
            leaveCategoryComboBox = new ComboBox { Location = new Point(126, 5), Size = new Size(230, 27), DropDownStyle = ComboBoxStyle.DropDownList };
            leaveCategoryComboBox.Items.AddRange(new object[] { "Annual Vacation Leave", "Sick Leave", "Study Leave", "Maternity Leave" });
            leaveCategoryComboBox.SelectedIndex = 0;
            toolbar.Controls.Add(leaveCategoryComboBox);
            Button newButton = CreateActionButton("+ New", Color.FromArgb(235, 240, 246), textColor, new Point(365, 4), new Size(120, 29));
            Button saveButton = CreateActionButton("▣  Save", accentColor, Color.White, new Point(492, 4), new Size(105, 29));
            newButton.Click += (_, _) => AddLeaveCategory();
            saveButton.Click += (_, _) => MessageBox.Show("Leave settings saved for the selected category.", "Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolbar.Controls.Add(newButton);
            toolbar.Controls.Add(saveButton);
            view.Controls.Add(toolbar);

            Panel policies = CreateBorderPanel(164);
            leavePolicies = policies;
            policies.Top = 88;
            attachmentCheckBox = CreatePolicyToggle("Required Attachment / Certificate", "Require official medical certificate or supporting document upon request submission.", false);
            clearanceCheckBox = CreatePolicyToggle("Enforce Clearance Workflow", "Require formal multi-department clearance completion before request can be approved.", false);
            carryOverCheckBox = CreatePolicyToggle("Permit Quota Carry-Over", "Allow remaining unused leave quota days to rollover to the subsequent fiscal year.", true);
            activePolicyCheckBox = CreatePolicyToggle("Active Leave Policy", "Enable this category for employee self-service submission in Leave Requests desk.", true);
            policies.Controls.Add(attachmentCheckBox);
            policies.Controls.Add(clearanceCheckBox);
            policies.Controls.Add(carryOverCheckBox);
            policies.Controls.Add(activePolicyCheckBox);
            view.Controls.Add(policies);

            Panel numbers = CreateBorderPanel(58);
            leaveNumbers = numbers;
            numbers.Top = 260;
            numbers.Controls.Add(CreateLabel("Base Entitlement (Days):", 10F, true, Color.Black, new Point(14, 18), new Size(160, 22)));
            baseEntitlementNumeric = new NumericUpDown { Location = new Point(175, 14), Size = new Size(72, 26), Minimum = 1, Maximum = 365, Value = 21 };
            numbers.Controls.Add(baseEntitlementNumeric);
            numbers.Controls.Add(CreateLabel("Minimum Service (Months):", 10F, true, Color.Black, new Point(280, 18), new Size(175, 22)));
            minimumServiceNumeric = new NumericUpDown { Location = new Point(456, 14), Size = new Size(72, 26), Maximum = 120, Value = 0 };
            numbers.Controls.Add(minimumServiceNumeric);
            view.Controls.Add(numbers);

            leaveGrid = CreateGrid(new[] { "Category", "Category Name", "Base Entitlement", "Attachment", "Clearance", "Carry-over", "Status", "Action" });
            leaveGrid.Top = 330;
            AddRows(leaveGrid, new[] {
                new[] { "ANNUAL", "Annual Vacation", "21 Days", "Optional", "None", "Allowed", "Active", "⋮" },
                new[] { "SICK", "Medical Leave", "14 Days", "Required", "None", "Disabled", "Active", "⋮" },
                new[] { "STUDY", "Study Leave", "45 Days", "Required", "Enforced", "Disabled", "Active", "⋮" },
                new[] { "MATERNITY", "Maternity Leave", "90 Days", "Required", "Enforced", "Disabled", "Active", "⋮" }
            });
            ConfigureGridActions(leaveGrid);
            view.Controls.Add(leaveGrid);
            return view;
        }

        private Panel CreateWorkflowView()
        {
            Panel view = CreateViewPanel();
            view.Controls.Add(CreatePageTitle("Approval Workflows"));
            workflowNewButton = CreateActionButton("+ New Workflow", Color.FromArgb(230, 230, 230), textColor, new Point(470, 0), new Size(145, 34));
            workflowNewButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            workflowNewButton.Click += (_, _) => AddApprovalWorkflow();
            view.Controls.Add(workflowNewButton);

            workflowSearchTextBox = new TextBox { Location = new Point(0, 45), Size = new Size(220, 28), PlaceholderText = "Search approval workflows..." };
            workflowSearchTextBox.TextChanged += (_, _) => FilterGrid(workflowGrid, workflowSearchTextBox.Text);
            view.Controls.Add(workflowSearchTextBox);
            workflowTypeComboBox = CreateFilterCombo(new[] { "All Request Types", "Annual / Medical Leave", "Study & Sabbatical Leave", "Executive Leave" }, new Point(228, 45));
            view.Controls.Add(workflowTypeComboBox);
            workflowGrid = CreateGrid(new[] { "Workflow Name", "Request Type", "Steps", "Status", "Created At", "Actions" });
            workflowGrid.Top = 82;
            AddRows(workflowGrid, new[] {
                new[] { "Standard Leave", "Annual / Medical Leave", "2 Steps", "Active", "2026-01-12", "⋮" },
                new[] { "Academic Study", "Study & Sabbatical Leave", "3 Steps", "Active", "2026-01-12", "⋮" },
                new[] { "Executive & Special", "Executive Leave", "1 Steps", "Active", "2026-01-12", "⋮" }
            });
            ConfigureGridActions(workflowGrid);
            view.Controls.Add(workflowGrid);
            return view;
        }

        private Panel CreateClearanceView()
        {
            Panel view = CreateViewPanel();
            view.Controls.Add(CreatePageTitle("Clearance Settings"));
            clearanceNewButton = CreateActionButton("+ New Policy", Color.FromArgb(230, 230, 230), textColor, new Point(470, 0), new Size(135, 34));
            clearanceNewButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clearanceNewButton.Click += (_, _) => AddClearancePolicy();
            view.Controls.Add(clearanceNewButton);
            clearanceSearchTextBox = new TextBox { Location = new Point(0, 45), Size = new Size(220, 28), PlaceholderText = "Search clearance policies..." };
            clearanceSearchTextBox.TextChanged += (_, _) => FilterGrid(clearanceGrid, clearanceSearchTextBox.Text);
            view.Controls.Add(clearanceSearchTextBox);
            clearanceTypeComboBox = CreateFilterCombo(new[] { "All Request Types", "Annual / Medical Leave", "Study & Sabbatical Leave", "Executive Leave", "Employee Exit", "Inter-Department" }, new Point(228, 45));
            view.Controls.Add(clearanceTypeComboBox);
            clearanceGrid = CreateGrid(new[] { "Policy Name", "Request Type", "Workflow", "Letters", "Checkpoints", "Status", "Created At", "Actions" });
            clearanceGrid.Top = 82;
            AddRows(clearanceGrid, new[] {
                new[] { "Study Clearance", "Study & Sabbatical Leave", "Sequential", "Auto-Sign", "4 Departments", "Active", "2026-01-12", "⋮" },
                new[] { "Employee Exit", "Employee Exit", "Parallel", "Auto-Sign", "4 Departments", "Active", "2026-01-12", "⋮" },
                new[] { "Inter-Department", "Inter-Department", "Sequential", "Disabled", "2 Departments", "Active", "2026-01-12", "⋮" }
            });
            ConfigureGridActions(clearanceGrid);
            view.Controls.Add(clearanceGrid);
            return view;
        }

        private void AddLeaveCategory()
        {
            using LeaveTypePolicyDialog dialog = new LeaveTypePolicyDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK || dialog.Result == null)
            {
                return;
            }

            LeaveTypePolicyData value = dialog.Result;
            bool duplicate = leaveGrid.Rows.Cast<DataGridViewRow>().Any(row =>
                string.Equals(row.Cells[0].Value?.ToString(), value.Code, StringComparison.OrdinalIgnoreCase)
                || string.Equals(row.Cells[1].Value?.ToString(), value.Name, StringComparison.OrdinalIgnoreCase));
            if (duplicate)
            {
                MessageBox.Show(this, "A leave type with this code or name already exists.", "Duplicate Leave Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = leaveGrid.Rows.Add(
                value.Code,
                value.Name,
                $"{value.EntitlementDays} Days",
                value.RequiresCertification ? "Required" : "Optional",
                value.RequiresClearance ? "Enforced" : "None",
                value.CarryForward ? "Allowed" : "Disabled",
                "Active",
                "⋮");
            leaveGrid.Rows[rowIndex].Tag = value;
            if (!leaveCategoryComboBox.Items.Contains(value.Name))
            {
                leaveCategoryComboBox.Items.Add(value.Name);
            }
            leaveCategoryComboBox.SelectedItem = value.Name;
        }

        private void AddApprovalWorkflow()
        {
            using ApprovalWorkflowDialog dialog = new ApprovalWorkflowDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK || dialog.Result == null)
            {
                return;
            }

            ApprovalWorkflowData value = dialog.Result;
            if (workflowGrid.Rows.Cast<DataGridViewRow>().Any(row =>
                    string.Equals(row.Cells[0].Value?.ToString(), value.Name, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(this, "A workflow with this name already exists.", "Duplicate Workflow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = workflowGrid.Rows.Add(
                value.Name,
                value.RequestType,
                $"{value.StepCount} Steps",
                value.Active ? "Active" : "Inactive",
                DateTime.Today.ToString("yyyy-MM-dd"),
                "⋮");
            workflowGrid.Rows[rowIndex].Tag = value;
        }

        private void AddClearancePolicy()
        {
            using ClearancePolicyDialog dialog = new ClearancePolicyDialog(NextClearanceCode());
            if (dialog.ShowDialog(this) != DialogResult.OK || dialog.Result == null)
            {
                return;
            }

            ClearancePolicyData value = dialog.Result;
            bool duplicate = clearanceGrid.Rows.Cast<DataGridViewRow>().Any(row =>
                (row.Tag is ClearancePolicyData policy && string.Equals(policy.Code, value.Code, StringComparison.OrdinalIgnoreCase))
                || string.Equals(row.Cells[0].Value?.ToString(), value.Name, StringComparison.OrdinalIgnoreCase));
            if (duplicate)
            {
                MessageBox.Show(this, "A clearance policy with this code or name already exists.", "Duplicate Clearance Policy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = clearanceGrid.Rows.Add(
                value.Name,
                value.RequestType,
                value.SequentialVerification ? "Sequential" : "Parallel",
                value.GenerateReleaseLetter ? "Auto-Sign" : "Disabled",
                $"{value.CheckpointCount} Departments",
                value.Active ? "Active" : "Inactive",
                DateTime.Today.ToString("yyyy-MM-dd"),
                "⋮");
            clearanceGrid.Rows[rowIndex].Tag = value;
        }

        private string NextClearanceCode()
        {
            int nextNumber = clearanceGrid.Rows.Count + 1;
            foreach (DataGridViewRow row in clearanceGrid.Rows)
            {
                if (row.Tag is ClearancePolicyData policy
                    && int.TryParse(policy.Code.Split('-').LastOrDefault(), out int number))
                {
                    nextNumber = Math.Max(nextNumber, number + 1);
                }
            }

            return $"CLR-{DateTime.Today.Year}-{nextNumber:D2}";
        }

        private string[]? ShowEntryDialog(string title, params (string Label, bool Numeric)[] fields)
        {
            return ShowEntryDialog(title, fields, null);
        }

        private string[]? ShowEntryDialog(string title, (string Label, bool Numeric)[] fields, string[]? initialValues)
        {
            using Form dialog = new Form
            {
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                ShowInTaskbar = false,
                ClientSize = new Size(420, fields.Length * 46 + 68),
                BackColor = SystemColors.Control
            };

            TableLayoutPanel layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = fields.Length + 1,
                Padding = new Padding(12),
                BackColor = SystemColors.Control
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 165F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            for (int i = 0; i < fields.Length; i++)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
                Label label = new Label
                {
                    Text = fields[i].Label,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                };
                Control input = fields[i].Numeric
                    ? new NumericUpDown { Minimum = 1, Maximum = 365, Value = 1, Dock = DockStyle.Fill }
                    : new TextBox { Dock = DockStyle.Fill };
                if (initialValues != null && i < initialValues.Length)
                {
                    if (input is NumericUpDown numericInput && decimal.TryParse(initialValues[i], out decimal number))
                    {
                        numericInput.Value = Math.Clamp(number, numericInput.Minimum, numericInput.Maximum);
                    }
                    else if (input is TextBox textInput)
                    {
                        textInput.Text = initialValues[i];
                    }
                }
                input.Tag = fields[i].Numeric;
                layout.Controls.Add(label, 0, i);
                layout.Controls.Add(input, 1, i);
            }

            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            FlowLayoutPanel buttons = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false
            };
            Button createButton = new Button { Text = "Create", DialogResult = DialogResult.None, Width = 90, Height = 30 };
            Button cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, Width = 90, Height = 30 };
            createButton.Click += (_, _) =>
            {
                Control[] inputs = layout.Controls.Cast<Control>().Where(control => control.TabIndex != int.MaxValue && control is TextBox or NumericUpDown).ToArray();
                if (inputs.OfType<TextBox>().Any(input => string.IsNullOrWhiteSpace(input.Text)))
                {
                    MessageBox.Show(dialog, "Complete all fields before creating the item.", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dialog.DialogResult = DialogResult.OK;
                dialog.Close();
            };
            buttons.Controls.Add(createButton);
            buttons.Controls.Add(cancelButton);
            layout.Controls.Add(buttons, 0, fields.Length);
            layout.SetColumnSpan(buttons, 2);
            dialog.Controls.Add(layout);
            dialog.AcceptButton = createButton;
            dialog.CancelButton = cancelButton;

            if (dialog.ShowDialog(this) != DialogResult.OK)
            {
                return null;
            }

            return layout.Controls.Cast<Control>()
                .Where(control => control is TextBox or NumericUpDown)
                .Select(control => control is NumericUpDown number ? number.Value.ToString("0") : control.Text)
                .ToArray();
        }

        private void ConfigureGridActions(DataGridView grid)
        {
            grid.CellContentClick += (_, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex != grid.Columns.Count - 1)
                {
                    return;
                }

                DataGridViewRow row = grid.Rows[e.RowIndex];
                bool isLeave = grid == leaveGrid;
                bool isWorkflow = grid == workflowGrid;
                string configureText = isLeave ? "Configure Leave Category" : "Configure Workflow";
                string deleteText = isLeave ? "Delete Leave Category" : isWorkflow ? "Delete Workflow" : "Delete Policy";
                components ??= new System.ComponentModel.Container();
                gridActionMenu ??= new ContextMenuStrip(components);
                gridActionMenu.Items.Clear();
                ContextMenuStrip menu = gridActionMenu;
                menu.Items.Add(configureText, null, (_, _) => ConfigureGridRow(grid, row));
                menu.Items.Add(deleteText, null, (_, _) => DeleteGridRow(grid, row, deleteText));
                Rectangle cell = grid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                menu.Show(grid, cell.Left, cell.Bottom);
            };
        }

        private void ConfigureGridRow(DataGridView grid, DataGridViewRow row)
        {
            if (grid == leaveGrid)
            {
                int days = int.TryParse(ExtractNumber(row.Cells[2].Value), out int parsedDays) ? parsedDays : 21;
                LeaveTypePolicyData initial = row.Tag as LeaveTypePolicyData ?? new LeaveTypePolicyData(
                    row.Cells[0].Value?.ToString() ?? string.Empty,
                    row.Cells[1].Value?.ToString() ?? string.Empty,
                    days,
                    6,
                    string.Equals(row.Cells[4].Value?.ToString(), "Enforced", StringComparison.OrdinalIgnoreCase),
                    string.Equals(row.Cells[3].Value?.ToString(), "Required", StringComparison.OrdinalIgnoreCase),
                    string.Equals(row.Cells[5].Value?.ToString(), "Allowed", StringComparison.OrdinalIgnoreCase));

                using LeaveTypePolicyDialog dialog = new LeaveTypePolicyDialog(initial);
                if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Result != null)
                {
                    LeaveTypePolicyData value = dialog.Result;
                    bool duplicateCode = leaveGrid.Rows.Cast<DataGridViewRow>().Any(other =>
                        other != row && string.Equals(other.Cells[0].Value?.ToString(), value.Code, StringComparison.OrdinalIgnoreCase));
                    if (duplicateCode)
                    {
                        MessageBox.Show(this, "A leave type with this code already exists.", "Duplicate Leave Type Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string oldName = row.Cells[1].Value?.ToString() ?? string.Empty;
                    row.Cells[0].Value = value.Code;
                    row.Cells[1].Value = value.Name;
                    row.Cells[2].Value = $"{value.EntitlementDays} Days";
                    row.Cells[3].Value = value.RequiresCertification ? "Required" : "Optional";
                    row.Cells[4].Value = value.RequiresClearance ? "Enforced" : "None";
                    row.Cells[5].Value = value.CarryForward ? "Allowed" : "Disabled";
                    row.Tag = value;

                    if (!string.Equals(oldName, value.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        int oldIndex = leaveCategoryComboBox.Items.IndexOf(oldName);
                        if (oldIndex >= 0)
                        {
                            leaveCategoryComboBox.Items.RemoveAt(oldIndex);
                        }
                        if (!leaveCategoryComboBox.Items.Contains(value.Name))
                        {
                            leaveCategoryComboBox.Items.Add(value.Name);
                        }
                    }
                    leaveCategoryComboBox.SelectedItem = value.Name;
                }
                return;
            }

            if (grid == workflowGrid)
            {
                int stepCount = int.TryParse(ExtractNumber(row.Cells[2].Value), out int parsedSteps) ? parsedSteps : 2;
                string requestType = row.Cells[1].Value?.ToString() ?? "Annual / Medical Leave";
                if (requestType == "Annual / Medical") requestType = "Annual / Medical Leave";
                if (requestType == "Study & Sabbatical") requestType = "Study & Sabbatical Leave";
                ApprovalWorkflowData initial = row.Tag as ApprovalWorkflowData ?? new ApprovalWorkflowData(
                    row.Cells[0].Value?.ToString() ?? string.Empty,
                    requestType,
                    string.Empty,
                    "Department_Head",
                    stepCount >= 2 ? "HR_Manager" : "(None / Optional)",
                    stepCount >= 3 ? "Executive_Officer" : "(None / Optional)",
                    true,
                    string.Equals(row.Cells[3].Value?.ToString(), "Active", StringComparison.OrdinalIgnoreCase));

                using ApprovalWorkflowDialog dialog = new ApprovalWorkflowDialog(initial);
                if (dialog.ShowDialog(this) == DialogResult.OK && dialog.Result != null)
                {
                    ApprovalWorkflowData value = dialog.Result;
                    bool duplicateName = workflowGrid.Rows.Cast<DataGridViewRow>().Any(other =>
                        other != row && string.Equals(other.Cells[0].Value?.ToString(), value.Name, StringComparison.OrdinalIgnoreCase));
                    if (duplicateName)
                    {
                        MessageBox.Show(this, "A workflow with this name already exists.", "Duplicate Workflow", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    row.Cells[0].Value = value.Name;
                    row.Cells[1].Value = value.RequestType;
                    row.Cells[2].Value = $"{value.StepCount} Steps";
                    row.Cells[3].Value = value.Active ? "Active" : "Inactive";
                    row.Tag = value;
                }
                return;
            }

            int checkpoints = int.TryParse(ExtractNumber(row.Cells[4].Value), out int parsedCheckpoints) ? parsedCheckpoints : 0;
            string units = row.Tag is ClearancePolicyData existingPolicy
                ? existingPolicy.RequiredHandoverUnits
                : string.Join(", ", Enumerable.Range(1, checkpoints).Select(number => $"Unit {number}"));
            ClearancePolicyData clearanceInitial = row.Tag as ClearancePolicyData ?? new ClearancePolicyData(
                $"CLR-{DateTime.Today.Year}-{row.Index + 1:D2}",
                row.Cells[0].Value?.ToString() ?? string.Empty,
                row.Cells[1].Value?.ToString() ?? "Study & Sabbatical Leave",
                string.Empty,
                units,
                string.Equals(row.Cells[2].Value?.ToString(), "Sequential", StringComparison.OrdinalIgnoreCase),
                !string.Equals(row.Cells[3].Value?.ToString(), "Disabled", StringComparison.OrdinalIgnoreCase),
                string.Equals(row.Cells[5].Value?.ToString(), "Active", StringComparison.OrdinalIgnoreCase));

             using ClearancePolicyDialog clearanceDialog = new ClearancePolicyDialog(NextClearanceCode(), clearanceInitial);
            if (clearanceDialog.ShowDialog(this) == DialogResult.OK && clearanceDialog.Result != null)
            {
                ClearancePolicyData value = clearanceDialog.Result;
                bool duplicateCode = clearanceGrid.Rows.Cast<DataGridViewRow>().Any(other =>
                    other != row && other.Tag is ClearancePolicyData otherPolicy
                    && string.Equals(otherPolicy.Code, value.Code, StringComparison.OrdinalIgnoreCase));
                if (duplicateCode)
                {
                    MessageBox.Show(this, "A clearance policy with this code already exists.", "Duplicate Policy Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                row.Cells[0].Value = value.Name;
                row.Cells[1].Value = value.RequestType;
                row.Cells[2].Value = value.SequentialVerification ? "Sequential" : "Parallel";
                row.Cells[3].Value = value.GenerateReleaseLetter ? "Auto-Sign" : "Disabled";
                row.Cells[4].Value = $"{value.CheckpointCount} Departments";
                row.Cells[5].Value = value.Active ? "Active" : "Inactive";
                row.Tag = value;
            }
        }

        private void DeleteGridRow(DataGridView grid, DataGridViewRow row, string itemName)
        {
            DialogResult result = MessageBox.Show(this, $"Delete this {itemName.ToLowerInvariant()}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                grid.Rows.Remove(row);
            }
        }

        private string ExtractNumber(object? value)
        {
            string digits = new string((value?.ToString() ?? string.Empty).Where(char.IsDigit).ToArray());
            return int.TryParse(digits, out int number) && number > 0 ? number.ToString() : "1";
        }

        private Panel CreateViewPanel() => new Panel { Dock = DockStyle.Fill, BackColor = pageBackgroundColor, Visible = false };

        private Label CreatePageTitle(string text) => CreateLabel(text, 18F, true, Color.FromArgb(14, 27, 44), new Point(0, 0), new Size(350, 36));

        private Label CreateLabel(string text, float size, bool bold, Color color, Point? location = null, Size? labelSize = null)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", size, bold ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = color,
                Location = location ?? Point.Empty,
                Size = labelSize ?? new Size(220, 25),
                AutoSize = false
            };
        }

        private Panel CreateBorderPanel(int height) => new Panel { Width = 620, Height = height, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.White };

        private Button CreateActionButton(string text, Color backColor, Color foreColor, Point location, Size size)
        {
            return new Button { Text = text, Location = location, Size = size, BackColor = backColor, ForeColor = foreColor, FlatStyle = FlatStyle.Flat, FlatAppearance = { BorderColor = borderColor }, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
        }

        private CheckBox CreatePolicyToggle(string title, string description, bool value)
        {
            CheckBox toggle = new CheckBox
            {
                Text = $"{title}\r\n{description}",
                Checked = value,
                Appearance = Appearance.Button,
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor,
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Height = 41,
                Padding = new Padding(14, 2, 0, 0),
                UseCompatibleTextRendering = true
            };
            toggle.CheckedChanged += (_, _) => toggle.Text = $"{title}\r\n{description}";
            return toggle;
        }

        private ComboBox CreateFilterCombo(string[] values, Point location)
        {
            ComboBox combo = new ComboBox { Location = location, Size = new Size(220, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            combo.Items.AddRange(values);
            combo.SelectedIndex = 0;
            return combo;
        }

        private DataGridView CreateGrid(string[] columns)
        {
            DataGridView grid = new DataGridView
            {
                Location = new Point(0, 0),
                Width = 620,
                Height = 210,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                EnableHeadersVisualStyles = false,
                ColumnHeadersHeight = 34,
                GridColor = Color.FromArgb(232, 236, 240)
            };
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = SystemColors.Control, ForeColor = mutedColor, Font = new Font("Segoe UI", 9F, FontStyle.Bold), Alignment = DataGridViewContentAlignment.MiddleLeft, WrapMode = DataGridViewTriState.True, Padding = new Padding(3) };
            grid.DefaultCellStyle = new DataGridViewCellStyle { ForeColor = textColor, Font = new Font("Segoe UI", 9F), SelectionBackColor = selectedColor, SelectionForeColor = textColor, WrapMode = DataGridViewTriState.True, Padding = new Padding(3) };
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.RowTemplate.MinimumHeight = 30;
            foreach (string column in columns)
            {
                DataGridViewColumn gridColumn;
                if (column.Equals("Action", StringComparison.OrdinalIgnoreCase) || column.Equals("Actions", StringComparison.OrdinalIgnoreCase))
                {
                    gridColumn = new DataGridViewButtonColumn
                    {
                        Name = column,
                        HeaderText = column,
                        Text = "⋮",
                        UseColumnTextForButtonValue = true,
                        FlatStyle = FlatStyle.Standard
                    };
                    grid.Columns.Add(gridColumn);
                }
                else
                {
                    grid.Columns.Add(column, column);
                    gridColumn = grid.Columns[grid.Columns.Count - 1];
                }
                gridColumn.MinimumWidth = 48;
                gridColumn.FillWeight = Math.Max(55, column.Length * 8);
            }
            return grid;
        }

        private void AddRows(DataGridView grid, string[][] rows)
        {
            foreach (string[] row in rows)
            {
                grid.Rows.Add(row);
            }
        }

        private void ShowView(Button selectedButton, Panel selectedView)
        {
            leaveView.Visible = selectedView == leaveView;
            approvalView.Visible = selectedView == approvalView;
            clearanceView.Visible = selectedView == clearanceView;
            SetMenuState(leaveSettingsButton, selectedButton == leaveSettingsButton);
            SetMenuState(approvalWorkflowsButton, selectedButton == approvalWorkflowsButton);
            SetMenuState(clearanceSettingsButton, selectedButton == clearanceSettingsButton);
            selectedView.BringToFront();
        }

        private void SetMenuState(Button button, bool selected)
        {
            button.BackColor = selected ? selectedColor : Color.White;
            button.ForeColor = selected ? accentColor : textColor;
        }

        private void FilterSettings(object? sender, EventArgs e)
        {
            string filter = filterTextBox.Text.Trim();
            leaveSettingsButton.Visible = string.IsNullOrWhiteSpace(filter) || leaveSettingsButton.Text.Contains(filter, StringComparison.CurrentCultureIgnoreCase);
            approvalWorkflowsButton.Visible = string.IsNullOrWhiteSpace(filter) || approvalWorkflowsButton.Text.Contains(filter, StringComparison.CurrentCultureIgnoreCase);
            clearanceSettingsButton.Visible = string.IsNullOrWhiteSpace(filter) || clearanceSettingsButton.Text.Contains(filter, StringComparison.CurrentCultureIgnoreCase);
        }

        private void FilterGrid(DataGridView grid, string filter)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Visible = string.IsNullOrWhiteSpace(filter) || row.Cells.Cast<DataGridViewCell>().Any(cell => cell.Value?.ToString()?.Contains(filter, StringComparison.CurrentCultureIgnoreCase) == true);
            }
        }
    }
}
