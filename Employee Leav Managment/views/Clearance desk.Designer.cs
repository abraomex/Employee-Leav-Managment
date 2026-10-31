namespace Employee_Leav_Managment.views
{
    partial class Clearance_desk
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
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
            compStatus = new ComboBox();
            comboBox1 = new ComboBox();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column7, Column6, Column8, Column9, Column10 });
            dataGridView1.Location = new Point(10, 53);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(781, 387);
            dataGridView1.TabIndex = 14;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 12);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search name or Clearance";
            textBox1.Size = new Size(129, 23);
            textBox1.TabIndex = 13;
            // 
            // compStatus
            // 
            compStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            compStatus.FormattingEnabled = true;
            compStatus.Items.AddRange(new object[] { "Pending Clearance", "Complated Clearance", "All Clearance" });
            compStatus.Location = new Point(143, 12);
            compStatus.Margin = new Padding(2);
            compStatus.Name = "compStatus";
            compStatus.Size = new Size(129, 23);
            compStatus.TabIndex = 15;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "All Employee", "My Department", "My Clearance" });
            comboBox1.Location = new Point(276, 12);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(129, 23);
            comboBox1.TabIndex = 15;
            // 
            // Column1
            // 
            Column1.HeaderText = "ClearanceID";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Name";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Emp Code";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Department";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Leave Type";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            // 
            // Column7
            // 
            Column7.HeaderText = "Study Period";
            Column7.MinimumWidth = 8;
            Column7.Name = "Column7";
            // 
            // Column6
            // 
            Column6.HeaderText = "Days";
            Column6.Name = "Column6";
            // 
            // Column8
            // 
            Column8.HeaderText = "Clearance Ha...";
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "Status";
            Column9.Name = "Column9";
            // 
            // Column10
            // 
            Column10.HeaderText = "Action";
            Column10.Name = "Column10";
            // 
            // Clearance_desk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(compStatus);
            Name = "Clearance_desk";
            Text = "Clearance_desk";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private TextBox textBox1;
        private ComboBox compStatus;
        private ComboBox comboBox1;
    }
}