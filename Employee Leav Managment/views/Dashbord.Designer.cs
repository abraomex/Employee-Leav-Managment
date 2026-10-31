namespace Employee_Leav_Managment.views
{
    partial class Dashbord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            employeesTab = new TabControl();
            tabPage2 = new TabPage();
            pnlTotalLeave = new TabPage();
            pnlTotalEmployees = new Panel();
            employeeCardsLayout = new TableLayoutPanel();
            totalemployee = new Label();
            onLeaveEmp = new Label();
            totalDepartment = new Label();
            panel1 = new Panel();
            leaveCardsLayout = new TableLayoutPanel();
            totalRequest = new Label();
            pendingRequest = new Label();
            approvedRequests = new Label();
            rejectedRequest = new Label();
            employeesTab.SuspendLayout();
            tabPage2.SuspendLayout();
            pnlTotalLeave.SuspendLayout();
            pnlTotalEmployees.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // employeesTab
            // 
            employeesTab.Controls.Add(tabPage2);
            employeesTab.Controls.Add(pnlTotalLeave);
            employeesTab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            employeesTab.Location = new Point(20, 20);
            employeesTab.Name = "employeesTab";
            employeesTab.Padding = new Point(18, 6);
            employeesTab.SelectedIndex = 0;
            employeesTab.Size = new Size(1103, 680);
            employeesTab.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pnlTotalEmployees);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(12);
            tabPage2.Size = new Size(1046, 167);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Employees";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlTotalLeave
            // 
            pnlTotalLeave.Controls.Add(panel1);
            pnlTotalLeave.Location = new Point(4, 34);
            pnlTotalLeave.Name = "pnlTotalLeave";
            pnlTotalLeave.Padding = new Padding(12);
            pnlTotalLeave.Size = new Size(1046, 167);
            pnlTotalLeave.TabIndex = 2;
            pnlTotalLeave.Text = "Leaves ";
            pnlTotalLeave.UseVisualStyleBackColor = true;
            // 
            // pnlTotalEmployees
            // 
            pnlTotalEmployees.Controls.Add(employeeCardsLayout);
            pnlTotalEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTotalEmployees.Location = new Point(12, 12);
            pnlTotalEmployees.Name = "pnlTotalEmployees";
            pnlTotalEmployees.Size = new Size(996, 155);
            pnlTotalEmployees.TabIndex = 0;
            // 
            // totalemployee
            // 
            totalemployee.AutoSize = false;
            totalemployee.BorderStyle = BorderStyle.FixedSingle;
            totalemployee.Dock = DockStyle.Fill;
            totalemployee.Margin = new Padding(8);
            totalemployee.Location = new Point(15, 15);
            totalemployee.Name = "totalemployee";
            totalemployee.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            totalemployee.Size = new Size(300, 125);
            totalemployee.TabIndex = 0;
            totalemployee.Text = "120\nTotal Employees";
            totalemployee.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // onLeaveEmp
            // 
            onLeaveEmp.AutoSize = false;
            onLeaveEmp.BorderStyle = BorderStyle.FixedSingle;
            onLeaveEmp.Dock = DockStyle.Fill;
            onLeaveEmp.Margin = new Padding(8);
            onLeaveEmp.Location = new Point(345, 15);
            onLeaveEmp.Name = "onLeaveEmp";
            onLeaveEmp.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            onLeaveEmp.Size = new Size(300, 125);
            onLeaveEmp.TabIndex = 1;
            onLeaveEmp.Text = "12\nEmployees On Leave";
            onLeaveEmp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalDepartment
            // 
            totalDepartment.AutoSize = false;
            totalDepartment.BorderStyle = BorderStyle.FixedSingle;
            totalDepartment.Dock = DockStyle.Fill;
            totalDepartment.Margin = new Padding(8);
            totalDepartment.Location = new Point(675, 15);
            totalDepartment.Name = "totalDepartment";
            totalDepartment.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            totalDepartment.Size = new Size(300, 125);
            totalDepartment.TabIndex = 2;
            totalDepartment.Text = "5\nDepartments";
            totalDepartment.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(leaveCardsLayout);
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(996, 155);
            panel1.TabIndex = 0;
            // 
            // totalRequest
            // 
            totalRequest.AutoSize = false;
            totalRequest.BorderStyle = BorderStyle.FixedSingle;
            totalRequest.Dock = DockStyle.Fill;
            totalRequest.Margin = new Padding(8);
            totalRequest.Location = new Point(15, 15);
            totalRequest.Name = "totalRequest";
            totalRequest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            totalRequest.Size = new Size(220, 125);
            totalRequest.TabIndex = 0;
            totalRequest.Text = "45\nTotal Requests";
            totalRequest.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pendingRequest
            // 
            pendingRequest.AutoSize = false;
            pendingRequest.BorderStyle = BorderStyle.FixedSingle;
            pendingRequest.Dock = DockStyle.Fill;
            pendingRequest.Margin = new Padding(8);
            pendingRequest.Location = new Point(265, 15);
            pendingRequest.Name = "pendingRequest";
            pendingRequest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            pendingRequest.Size = new Size(220, 125);
            pendingRequest.TabIndex = 1;
            pendingRequest.Text = "10\nPending Requests";
            pendingRequest.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // approvedRequests
            // 
            approvedRequests.AutoSize = false;
            approvedRequests.BorderStyle = BorderStyle.FixedSingle;
            approvedRequests.Dock = DockStyle.Fill;
            approvedRequests.Margin = new Padding(8);
            approvedRequests.Location = new Point(515, 15);
            approvedRequests.Name = "approvedRequests";
            approvedRequests.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            approvedRequests.Size = new Size(220, 125);
            approvedRequests.TabIndex = 2;
            approvedRequests.Text = "28\nApproved Requests";
            approvedRequests.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rejectedRequest
            // 
            rejectedRequest.AutoSize = false;
            rejectedRequest.BorderStyle = BorderStyle.FixedSingle;
            rejectedRequest.Dock = DockStyle.Fill;
            rejectedRequest.Margin = new Padding(8);
            rejectedRequest.Location = new Point(765, 15);
            rejectedRequest.Name = "rejectedRequest";
            rejectedRequest.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rejectedRequest.Size = new Size(220, 125);
            rejectedRequest.TabIndex = 3;
            rejectedRequest.Text = "7\nRejected Requests";
            rejectedRequest.TextAlign = ContentAlignment.MiddleCenter;
            employeeCardsLayout.ColumnCount = 3;
            employeeCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            employeeCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            employeeCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            employeeCardsLayout.Controls.Add(totalemployee, 0, 0);
            employeeCardsLayout.Controls.Add(onLeaveEmp, 1, 0);
            employeeCardsLayout.Controls.Add(totalDepartment, 2, 0);
            employeeCardsLayout.Dock = DockStyle.Fill;
            employeeCardsLayout.Location = new Point(0, 0);
            employeeCardsLayout.Name = "employeeCardsLayout";
            employeeCardsLayout.Padding = new Padding(8);
            employeeCardsLayout.RowCount = 1;
            employeeCardsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            employeeCardsLayout.TabIndex = 0;
            leaveCardsLayout.ColumnCount = 4;
            leaveCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            leaveCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            leaveCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            leaveCardsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            leaveCardsLayout.Controls.Add(totalRequest, 0, 0);
            leaveCardsLayout.Controls.Add(pendingRequest, 1, 0);
            leaveCardsLayout.Controls.Add(approvedRequests, 2, 0);
            leaveCardsLayout.Controls.Add(rejectedRequest, 3, 0);
            leaveCardsLayout.Dock = DockStyle.Fill;
            leaveCardsLayout.Location = new Point(0, 0);
            leaveCardsLayout.Name = "leaveCardsLayout";
            leaveCardsLayout.Padding = new Padding(8);
            leaveCardsLayout.RowCount = 1;
            leaveCardsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            leaveCardsLayout.TabIndex = 0;
            // 
            // Dashbord
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(employeesTab);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Dashbord";
            Text = "Dashbord";
            employeesTab.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            pnlTotalLeave.ResumeLayout(false);
            pnlTotalEmployees.ResumeLayout(false);
            pnlTotalEmployees.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl employeesTab;
        private TabPage tabPage2;
        private TabPage pnlTotalLeave;
        private Panel pnlTotalEmployees;
        private TableLayoutPanel employeeCardsLayout;
        private Label totalDepartment;
        private Label onLeaveEmp;
        private Label totalemployee;
        private Panel panel1;
        private TableLayoutPanel leaveCardsLayout;
        private Label rejectedRequest;
        private Label approvedRequests;
        private Label pendingRequest;
        private Label totalRequest;
    }
}