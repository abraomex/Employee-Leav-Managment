namespace Employee_Leav_Managment.views
{
    partial class Employee
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
            textSerch = new TextBox();
            comDepart = new ComboBox();
            comStatus = new ComboBox();
            btnAddEmployee = new Button();
            dataGridView1 = new DataGridView();
            empCode = new DataGridViewTextBoxColumn();
            empName = new DataGridViewTextBoxColumn();
            empGender = new DataGridViewTextBoxColumn();
            empDepart = new DataGridViewTextBoxColumn();
            empJob = new DataGridViewTextBoxColumn();
            empHireDate = new DataGridViewTextBoxColumn();
            empEmail = new DataGridViewTextBoxColumn();
            empTenur = new DataGridViewTextBoxColumn();
            empStatus = new DataGridViewTextBoxColumn();
            action = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textSerch
            // 
            textSerch.Location = new Point(12, 21);
            textSerch.Name = "textSerch";
            textSerch.PlaceholderText = "Search name or employee code";
            textSerch.Size = new Size(231, 31);
            textSerch.TabIndex = 0;
            // 
            // comDepart
            // 
            comDepart.DropDownStyle = ComboBoxStyle.DropDownList;
            comDepart.FormattingEnabled = true;
            comDepart.Location = new Point(249, 21);
            comDepart.Name = "comDepart";
            comDepart.Size = new Size(182, 33);
            comDepart.TabIndex = 1;
            // 
            // comStatus
            // 
            comStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comStatus.FormattingEnabled = true;
            comStatus.Location = new Point(452, 19);
            comStatus.Name = "comStatus";
            comStatus.Size = new Size(182, 33);
            comStatus.TabIndex = 2;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddEmployee.Location = new Point(1019, 19);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(112, 34);
            btnAddEmployee.TabIndex = 3;
            btnAddEmployee.Text = "Add New";
            btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { empCode, empName, empGender, empDepart, empJob, empHireDate, empEmail, empTenur, empStatus, action });
            dataGridView1.Location = new Point(12, 73);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1119, 650);
            dataGridView1.TabIndex = 4;
            // 
            // empCode
            // 
            empCode.HeaderText = "Emp code";
            empCode.MinimumWidth = 8;
            empCode.Name = "empCode";
            empCode.Width = 150;
            // 
            // empName
            // 
            empName.HeaderText = "Employee";
            empName.MinimumWidth = 8;
            empName.Name = "empName";
            empName.Width = 150;
            // 
            // empGender
            // 
            empGender.HeaderText = "Gender";
            empGender.MinimumWidth = 8;
            empGender.Name = "empGender";
            empGender.Width = 150;
            // 
            // empDepart
            // 
            empDepart.HeaderText = "Department";
            empDepart.MinimumWidth = 8;
            empDepart.Name = "empDepart";
            empDepart.Width = 150;
            // 
            // empJob
            // 
            empJob.HeaderText = "Job Title";
            empJob.MinimumWidth = 8;
            empJob.Name = "empJob";
            empJob.Width = 150;
            // 
            // empHireDate
            // 
            empHireDate.HeaderText = "Hire Date";
            empHireDate.MinimumWidth = 8;
            empHireDate.Name = "empHireDate";
            empHireDate.Width = 150;
            // 
            // empEmail
            // 
            empEmail.HeaderText = "Email";
            empEmail.MinimumWidth = 8;
            empEmail.Name = "empEmail";
            empEmail.Width = 150;
            // 
            // empTenur
            // 
            empTenur.HeaderText = "Tenure";
            empTenur.MinimumWidth = 8;
            empTenur.Name = "empTenur";
            empTenur.Width = 150;
            // 
            // empStatus
            // 
            empStatus.HeaderText = "Status";
            empStatus.MinimumWidth = 8;
            empStatus.Name = "empStatus";
            empStatus.Width = 150;
            // 
            // action
            // 
            action.HeaderText = "Action";
            action.MinimumWidth = 8;
            action.Name = "action";
            action.Width = 150;
            // 
            // Employee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(dataGridView1);
            Controls.Add(btnAddEmployee);
            Controls.Add(comStatus);
            Controls.Add(comDepart);
            Controls.Add(textSerch);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Employee";
            Text = "Employee";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textSerch;
        private ComboBox comDepart;
        private ComboBox comStatus;
        private Button btnAddEmployee;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn empCode;
        private DataGridViewTextBoxColumn empName;
        private DataGridViewTextBoxColumn empGender;
        private DataGridViewTextBoxColumn empDepart;
        private DataGridViewTextBoxColumn empJob;
        private DataGridViewTextBoxColumn empHireDate;
        private DataGridViewTextBoxColumn empEmail;
        private DataGridViewTextBoxColumn empTenur;
        private DataGridViewTextBoxColumn empStatus;
        private DataGridViewTextBoxColumn action;
    }
}