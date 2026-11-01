using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    internal sealed record LeaveTypePolicyData(
        string Code,
        string Name,
        int EntitlementDays,
        int MinimumServiceMonths,
        bool RequiresClearance,
        bool RequiresCertification,
        bool CarryForward);

    internal sealed record ApprovalWorkflowData(
        string Name,
        string RequestType,
        string Description,
        string InitialReviewer,
        string PrimaryAuthorizer,
        string FinalClearer,
        bool StrictSequential,
        bool Active)
    {
        public int StepCount =>
            1 + (IsOptionalStep(PrimaryAuthorizer) ? 0 : 1) + (IsOptionalStep(FinalClearer) ? 0 : 1);

        private static bool IsOptionalStep(string value) =>
            string.IsNullOrWhiteSpace(value) || value == "(None / Optional)";
    }

    internal sealed record ClearancePolicyData(
        string Code,
        string Name,
        string RequestType,
        string Description,
        string RequiredHandoverUnits,
        bool SequentialVerification,
        bool GenerateReleaseLetter,
        bool Active)
    {
        public int CheckpointCount => RequiredHandoverUnits
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Count();
    }

    internal sealed class LeaveTypePolicyDialog : Form
    {
        private readonly TextBox codeTextBox;
        private readonly TextBox nameTextBox;
        private readonly NumericUpDown entitlementNumeric;
        private readonly NumericUpDown serviceNumeric;
        private readonly CheckBox clearanceCheckBox;
        private readonly CheckBox certificationCheckBox;
        private readonly CheckBox carryForwardCheckBox;

        public LeaveTypePolicyData? Result { get; private set; }

        public LeaveTypePolicyDialog(LeaveTypePolicyData? initial = null)
        {
            initial ??= new LeaveTypePolicyData(string.Empty, string.Empty, 21, 6, false, false, false);
            DialogUi.ConfigureForm(this, "Leave Type Policy", new Size(720, 620));

            Panel header = DialogUi.CreateHeader("Create Leave Type Policy", "Configure leave entitlement quotas, rules, and policy clearance.");
            Panel body = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(34, 24, 34, 16) };
            Panel footer = DialogUi.CreateFooter();
            TableLayoutPanel root = DialogUi.CreateRoot(header, body, footer, 112);

            body.Controls.Add(DialogUi.FieldLabel("Leave Type Code", 0, 0, 640));
            codeTextBox = DialogUi.TextBox(0, 25, 640, initial.Code);
            body.Controls.Add(codeTextBox);

            body.Controls.Add(DialogUi.FieldLabel("Leave Type Name", 0, 82, 640));
            nameTextBox = DialogUi.TextBox(0, 107, 640, initial.Name, "e.g. Annual Vacation Leave");
            body.Controls.Add(nameTextBox);

            body.Controls.Add(DialogUi.FieldLabel("Default Entitlement Days", 0, 163, 300));
            body.Controls.Add(DialogUi.FieldLabel("Min Service (Months)", 350, 163, 290));
            entitlementNumeric = DialogUi.Numeric(0, 190, 285, 1, 365, initial.EntitlementDays);
            serviceNumeric = DialogUi.Numeric(350, 190, 285, 0, 120, initial.MinimumServiceMonths);
            body.Controls.Add(entitlementNumeric);
            body.Controls.Add(serviceNumeric);

            clearanceCheckBox = DialogUi.CheckBox("Requires Multi-Department Handover Clearance", 0, 250, initial.RequiresClearance);
            certificationCheckBox = DialogUi.CheckBox("Requires Medical or Supporting Certification", 0, 292, initial.RequiresCertification);
            carryForwardCheckBox = DialogUi.CheckBox("Permit Unused Quota Carry-Forward", 0, 334, initial.CarryForward);
            body.Controls.Add(clearanceCheckBox);
            body.Controls.Add(certificationCheckBox);
            body.Controls.Add(carryForwardCheckBox);

            Button saveButton = DialogUi.SaveButton("Save Policy", 168);
            Button cancelButton = DialogUi.CancelButton(130);
            saveButton.Click += (_, _) => Save();
            DialogUi.AddFooterButtons(footer, saveButton, cancelButton);
            AcceptButton = saveButton;
            CancelButton = cancelButton;
            Controls.Add(root);
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(codeTextBox.Text) || string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                DialogUi.ShowRequiredFields(this, "Enter both a leave type code and name.");
                return;
            }

            Result = new LeaveTypePolicyData(
                codeTextBox.Text.Trim().ToUpperInvariant(),
                nameTextBox.Text.Trim(),
                decimal.ToInt32(entitlementNumeric.Value),
                decimal.ToInt32(serviceNumeric.Value),
                clearanceCheckBox.Checked,
                certificationCheckBox.Checked,
                carryForwardCheckBox.Checked);
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    internal sealed class ApprovalWorkflowDialog : Form
    {
        private static readonly string[] RequestTypes =
        {
            "Annual / Medical Leave",
            "Study & Sabbatical Leave",
            "Executive Leave"
        };

        private static readonly string[] ReviewerOptions =
        {
            "Department_Head",
            "Direct_Manager",
            "HR_Manager",
            "Executive_Officer",
            "(None / Optional)"
        };

        private readonly TextBox nameTextBox;
        private readonly ComboBox requestTypeComboBox;
        private readonly TextBox descriptionTextBox;
        private readonly ComboBox initialReviewerComboBox;
        private readonly ComboBox primaryAuthorizerComboBox;
        private readonly ComboBox finalClearerComboBox;
        private readonly CheckBox strictSequentialCheckBox;
        private readonly CheckBox activeCheckBox;

        public ApprovalWorkflowData? Result { get; private set; }

        public ApprovalWorkflowDialog(ApprovalWorkflowData? initial = null)
        {
            initial ??= new ApprovalWorkflowData(
                string.Empty,
                RequestTypes[0],
                string.Empty,
                "Department_Head",
                "HR_Manager",
                "(None / Optional)",
                true,
                true);
            DialogUi.ConfigureForm(this, "Configure Approval Workflow", new Size(740, 700));

            Panel header = DialogUi.CreateHeader("Configure Approval Workflow");
            Panel body = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(28, 12, 28, 8) };
            Panel footer = DialogUi.CreateFooter();
            TableLayoutPanel root = DialogUi.CreateRoot(header, body, footer, 76);

            body.Controls.Add(DialogUi.FieldLabel("Workflow Name:", 0, 0, 650));
            nameTextBox = DialogUi.TextBox(0, 25, 650, initial.Name);
            body.Controls.Add(nameTextBox);

            body.Controls.Add(DialogUi.FieldLabel("Target Request Desk:", 0, 72, 650));
            requestTypeComboBox = DialogUi.ComboBox(0, 97, 650, RequestTypes, initial.RequestType);
            body.Controls.Add(requestTypeComboBox);

            body.Controls.Add(DialogUi.FieldLabel("Description:", 0, 143, 650));
            descriptionTextBox = DialogUi.TextBox(0, 168, 650, initial.Description, multiline: true, height: 72);
            body.Controls.Add(descriptionTextBox);

            GroupBox steps = new GroupBox
            {
                Text = "Sequential Approval Steps",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = DialogUi.TextColor,
                Location = new Point(0, 254),
                Size = new Size(650, 200),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            steps.Controls.Add(DialogUi.StepLabel("Step 1  Initial Reviewer:", 18, 30, 218));
            steps.Controls.Add(DialogUi.StepLabel("Step 2  Primary Authorizer:", 18, 77, 218));
            steps.Controls.Add(DialogUi.StepLabel("Step 3  Final Clearer / Exec:", 18, 124, 218));
            initialReviewerComboBox = DialogUi.ComboBox(245, 27, 370, ReviewerOptions, initial.InitialReviewer);
            primaryAuthorizerComboBox = DialogUi.ComboBox(245, 74, 370, ReviewerOptions, initial.PrimaryAuthorizer);
            finalClearerComboBox = DialogUi.ComboBox(245, 121, 370, ReviewerOptions, initial.FinalClearer);
            steps.Controls.Add(initialReviewerComboBox);
            steps.Controls.Add(primaryAuthorizerComboBox);
            steps.Controls.Add(finalClearerComboBox);
            body.Controls.Add(steps);

            strictSequentialCheckBox = DialogUi.CheckBox("Strict Sequential Gate (No Skip Allowed)", 0, 466, initial.StrictSequential);
            activeCheckBox = DialogUi.CheckBox("Workflow Active / Operational", 0, 506, initial.Active);
            body.Controls.Add(strictSequentialCheckBox);
            body.Controls.Add(activeCheckBox);

            Button saveButton = DialogUi.SaveButton("Save Workflow", 170);
            Button cancelButton = DialogUi.CancelButton(130);
            saveButton.Click += (_, _) => Save();
            DialogUi.AddFooterButtons(footer, saveButton, cancelButton);
            AcceptButton = saveButton;
            CancelButton = cancelButton;
            Controls.Add(root);
        }

        private void Save()
        {
            string reviewer1 = initialReviewerComboBox.SelectedItem?.ToString() ?? string.Empty;
            string reviewer2 = primaryAuthorizerComboBox.SelectedItem?.ToString() ?? "(None / Optional)";
            string reviewer3 = finalClearerComboBox.SelectedItem?.ToString() ?? "(None / Optional)";
            bool step2Optional = reviewer2 == "(None / Optional)";
            bool step3Optional = reviewer3 == "(None / Optional)";

            if (string.IsNullOrWhiteSpace(nameTextBox.Text) || requestTypeComboBox.SelectedItem == null)
            {
                DialogUi.ShowRequiredFields(this, "Enter a workflow name and select a target request desk.");
                return;
            }

            if (reviewer1 == "(None / Optional)" || (!step2Optional && step3Optional == false && reviewer2 == reviewer3))
            {
                DialogUi.ShowRequiredFields(this, "Choose an initial reviewer. Approval steps must be configured in sequence.");
                return;
            }

            if (step2Optional && !step3Optional)
            {
                DialogUi.ShowRequiredFields(this, "Configure Step 2 before adding a Step 3 reviewer.");
                return;
            }

            Result = new ApprovalWorkflowData(
                nameTextBox.Text.Trim(),
                requestTypeComboBox.SelectedItem.ToString()!,
                descriptionTextBox.Text.Trim(),
                reviewer1,
                reviewer2,
                reviewer3,
                strictSequentialCheckBox.Checked,
                activeCheckBox.Checked);
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    internal sealed class ClearancePolicyDialog : Form
    {
        private static readonly string[] RequestTypes =
        {
            "Annual / Medical Leave",
            "Study & Sabbatical Leave",
            "Executive Leave",
            "Employee Exit",
            "Inter-Department"
        };

        private readonly TextBox codeTextBox;
        private readonly TextBox nameTextBox;
        private readonly ComboBox requestTypeComboBox;
        private readonly TextBox descriptionTextBox;
        private readonly TextBox handoverUnitsTextBox;
        private readonly CheckBox sequentialCheckBox;
        private readonly CheckBox releaseLetterCheckBox;
        private readonly CheckBox activeCheckBox;

        public ClearancePolicyData? Result { get; private set; }

        public ClearancePolicyDialog(string suggestedCode, ClearancePolicyData? initial = null)
        {
            initial ??= new ClearancePolicyData(
                suggestedCode,
                string.Empty,
                "Study & Sabbatical Leave",
                string.Empty,
                "University Library, Department Hardware & Lab Access, Finance Office, HR Coordination",
                true,
                true,
                true);
            DialogUi.ConfigureForm(this, "Configure Clearance Policy", new Size(740, 700));

            Panel header = DialogUi.CreateHeader("Configure Clearance Policy");
            Panel body = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(28, 14, 28, 8) };
            Panel footer = DialogUi.CreateFooter();
            TableLayoutPanel root = DialogUi.CreateRoot(header, body, footer, 76);

            body.Controls.Add(DialogUi.FieldLabel("Policy Code:", 0, 0, 300));
            body.Controls.Add(DialogUi.FieldLabel("Policy Name:", 320, 0, 330));
            codeTextBox = DialogUi.TextBox(0, 25, 290, initial.Code);
            nameTextBox = DialogUi.TextBox(320, 25, 330, initial.Name);
            body.Controls.Add(codeTextBox);
            body.Controls.Add(nameTextBox);

            body.Controls.Add(DialogUi.FieldLabel("Target Request Desk:", 0, 75, 650));
            requestTypeComboBox = DialogUi.ComboBox(0, 100, 650, RequestTypes, initial.RequestType);
            body.Controls.Add(requestTypeComboBox);

            body.Controls.Add(DialogUi.FieldLabel("Policy Description:", 0, 146, 650));
            descriptionTextBox = DialogUi.TextBox(0, 171, 650, initial.Description, multiline: true, height: 72);
            body.Controls.Add(descriptionTextBox);

            body.Controls.Add(DialogUi.FieldLabel("Required Handover Units (Comma-separated):", 0, 256, 650));
            handoverUnitsTextBox = DialogUi.TextBox(0, 281, 650, initial.RequiredHandoverUnits);
            body.Controls.Add(handoverUnitsTextBox);

            sequentialCheckBox = DialogUi.CheckBox("Enforce Sequential Handover Verification", 0, 334, initial.SequentialVerification);
            releaseLetterCheckBox = DialogUi.CheckBox("Generate Official Clearance Release Letter", 0, 375, initial.GenerateReleaseLetter);
            activeCheckBox = DialogUi.CheckBox("Policy Active / Operational", 0, 416, initial.Active);
            body.Controls.Add(sequentialCheckBox);
            body.Controls.Add(releaseLetterCheckBox);
            body.Controls.Add(activeCheckBox);

            Button saveButton = DialogUi.SaveButton("Save Policy", 165);
            Button cancelButton = DialogUi.CancelButton(130);
            saveButton.Click += (_, _) => Save();
            DialogUi.AddFooterButtons(footer, saveButton, cancelButton);
            AcceptButton = saveButton;
            CancelButton = cancelButton;
            Controls.Add(root);
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(codeTextBox.Text)
                || string.IsNullOrWhiteSpace(nameTextBox.Text)
                || requestTypeComboBox.SelectedItem == null)
            {
                DialogUi.ShowRequiredFields(this, "Enter a policy code and name, then select a target request desk.");
                return;
            }

            Result = new ClearancePolicyData(
                codeTextBox.Text.Trim().ToUpperInvariant(),
                nameTextBox.Text.Trim(),
                requestTypeComboBox.SelectedItem.ToString()!,
                descriptionTextBox.Text.Trim(),
                handoverUnitsTextBox.Text.Trim(),
                sequentialCheckBox.Checked,
                releaseLetterCheckBox.Checked,
                activeCheckBox.Checked);
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    internal static class DialogUi
    {
        internal static readonly Color TextColor = Color.FromArgb(41, 58, 78);
        private static readonly Color MutedColor = Color.FromArgb(92, 119, 151);
        private static readonly Color OrangeColor = Color.FromArgb(232, 86, 12);
        private static readonly Color BorderColor = Color.FromArgb(213, 220, 228);

        internal static void ConfigureForm(Form form, string windowTitle, Size clientSize)
        {
            form.Text = windowTitle;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowInTaskbar = false;
            form.AutoScaleMode = AutoScaleMode.Font;
            form.Font = new Font("Segoe UI", 10F);
            form.BackColor = Color.White;
            form.ClientSize = clientSize;
        }

        internal static TableLayoutPanel CreateRoot(Panel header, Panel body, Panel footer, int headerHeight)
        {
            TableLayoutPanel root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                BackColor = Color.White
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, headerHeight));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            root.Controls.Add(header, 0, 0);
            root.Controls.Add(body, 0, 1);
            root.Controls.Add(footer, 0, 2);
            return root;
        }

        internal static Panel CreateHeader(string title, string? subtitle = null)
        {
            Panel header = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(30, 18, 30, 10) };
            Label heading = new Label
            {
                Text = title,
                AutoSize = true,
                Location = new Point(0, 10),
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(18, 34, 53)
            };
            header.Controls.Add(heading);
            if (!string.IsNullOrWhiteSpace(subtitle))
            {
                Label description = new Label
                {
                    Text = subtitle,
                    AutoSize = true,
                    Location = new Point(0, 48),
                    Font = new Font("Segoe UI", 10.5F),
                    ForeColor = MutedColor
                };
                header.Controls.Add(description);
            }
            Panel separator = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 1,
                BackColor = BorderColor
            };
            header.Controls.Add(separator);
            return header;
        }

        internal static Panel CreateFooter()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20, 10, 26, 10)
            };
        }

        internal static Label FieldLabel(string text, int x, int y, int width)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, 22),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = TextColor
            };
        }

        internal static Label StepLabel(string text, int x, int y, int width)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, 30),
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = MutedColor,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        internal static TextBox TextBox(int x, int y, int width, string text, string? placeholder = null, bool multiline = false, int height = 34)
        {
            return new TextBox
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                Text = text,
                PlaceholderText = placeholder ?? string.Empty,
                Multiline = multiline,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 10F),
                ScrollBars = multiline ? ScrollBars.Vertical : ScrollBars.None,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
        }

        internal static NumericUpDown Numeric(int x, int y, int width, int minimum, int maximum, int value)
        {
            return new NumericUpDown
            {
                Location = new Point(x, y),
                Size = new Size(width, 34),
                Minimum = minimum,
                Maximum = maximum,
                Value = Math.Clamp(value, minimum, maximum),
                Font = new Font("Segoe UI", 10F),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
        }

        internal static ComboBox ComboBox(int x, int y, int width, string[] items, string selected)
        {
            ComboBox combo = new ComboBox
            {
                Location = new Point(x, y),
                Size = new Size(width, 34),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            combo.Items.AddRange(items);
            int selectedIndex = Array.IndexOf(items, selected);
            combo.SelectedIndex = selectedIndex >= 0 ? selectedIndex : 0;
            return combo;
        }

        internal static CheckBox CheckBox(string text, int x, int y, bool isChecked)
        {
            return new CheckBox
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(650, 28),
                Checked = isChecked,
                Font = new Font("Segoe UI", 10F),
                ForeColor = MutedColor,
                AutoSize = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
        }

        internal static Button SaveButton(string text, int width)
        {
            return new Button
            {
                Text = text,
                Width = width,
                Height = 44,
                FlatStyle = FlatStyle.Flat,
                BackColor = OrangeColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Margin = new Padding(10, 0, 0, 0),
                UseVisualStyleBackColor = false
            };
        }

        internal static Button CancelButton(int width)
        {
            return new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Width = width,
                Height = 44,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = MutedColor,
                Font = new Font("Segoe UI", 10F),
                Margin = new Padding(10, 0, 0, 0),
                UseVisualStyleBackColor = false
            };
        }

        internal static void AddFooterButtons(Panel footer, Button saveButton, Button cancelButton)
        {
            FlowLayoutPanel buttonLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                WrapContents = false,
                BackColor = Color.White,
                Padding = new Padding(0, 0, 4, 0)
            };
            buttonLayout.Controls.Add(saveButton);
            buttonLayout.Controls.Add(cancelButton);
            footer.Controls.Add(buttonLayout);
        }

        internal static void ShowRequiredFields(IWin32Window owner, string message)
        {
            MessageBox.Show(owner, message, "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
