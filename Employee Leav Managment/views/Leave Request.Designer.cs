namespace Employee_Leav_Managment.views
{
    partial class Leave_Request
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
            leaveRequestTab = new TabControl();
            tabPage2 = new TabPage();
            button1 = new Button();
            textBox1 = new TextBox();
            comboBox2 = new ComboBox();
            compStatus = new ComboBox();
            pnlTotalLeave = new TabPage();
            tabPage1 = new TabPage();
            button2 = new Button();
            dataGridView2 = new DataGridView();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            button3 = new Button();
            textBox3 = new TextBox();
            dataGridView3 = new DataGridView();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            leaveRequestTab.SuspendLayout();
            tabPage2.SuspendLayout();
            pnlTotalLeave.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // leaveRequestTab
            // 
            leaveRequestTab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            leaveRequestTab.Controls.Add(tabPage2);
            leaveRequestTab.Controls.Add(pnlTotalLeave);
            leaveRequestTab.Controls.Add(tabPage1);
            leaveRequestTab.Location = new Point(17, 21);
            leaveRequestTab.Margin = new Padding(2);
            leaveRequestTab.Name = "leaveRequestTab";
            leaveRequestTab.Padding = new Point(18, 6);
            leaveRequestTab.SelectedIndex = 0;
            leaveRequestTab.Size = new Size(1119, 710);
            leaveRequestTab.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(compStatus);
            tabPage2.Location = new Point(4, 30);
            tabPage2.Margin = new Padding(2);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(8, 7, 8, 7);
            tabPage2.Size = new Size(1111, 672);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "My Requests";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(975, 8);
            button1.Name = "button1";
            button1.Size = new Size(118, 23);
            button1.TabIndex = 12;
            button1.Text = "+ New Request";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 4);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Search name or employee code";
            textBox1.Size = new Size(220, 23);
            textBox1.TabIndex = 8;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "All Employee", "My Request" });
            comboBox2.Location = new Point(258, 4);
            comboBox2.Margin = new Padding(2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(108, 23);
            comboBox2.TabIndex = 11;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // compStatus
            // 
            compStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            compStatus.FormattingEnabled = true;
            compStatus.Items.AddRange(new object[] { "All Status", "Submited", "Under Review", "Approved", "Rejected", "Canceled" });
            compStatus.Location = new Point(136, 4);
            compStatus.Margin = new Padding(2);
            compStatus.Name = "compStatus";
            compStatus.Size = new Size(108, 23);
            compStatus.TabIndex = 10;
            // 
            // pnlTotalLeave
            // 
            pnlTotalLeave.Controls.Add(button2);
            pnlTotalLeave.Controls.Add(dataGridView2);
            pnlTotalLeave.Controls.Add(textBox2);
            pnlTotalLeave.Location = new Point(4, 30);
            pnlTotalLeave.Margin = new Padding(2);
            pnlTotalLeave.Name = "pnlTotalLeave";
            pnlTotalLeave.Padding = new Padding(8, 7, 8, 7);
            pnlTotalLeave.Size = new Size(1111, 672);
            pnlTotalLeave.TabIndex = 2;
            pnlTotalLeave.Text = "Leave Types";
            pnlTotalLeave.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridView3);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Location = new Point(4, 30);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1111, 672);
            tabPage1.TabIndex = 3;
            tabPage1.Text = "Entitlements";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(975, 8);
            button2.Name = "button2";
            button2.Size = new Size(118, 23);
            button2.TabIndex = 15;
            button2.Text = "+ New Type";
            button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            dataGridView2.Location = new Point(8, 42);
            dataGridView2.Margin = new Padding(2);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.Size = new Size(1090, 620);
            dataGridView2.TabIndex = 14;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(10, 3);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Search name or employee code";
            textBox2.Size = new Size(108, 23);
            textBox2.TabIndex = 13;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column5, Column7, Column6, Column8, Column9, Column10 });
            dataGridView1.Location = new Point(8, 42);
            dataGridView1.Margin = new Padding(2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1090, 620);
            dataGridView1.TabIndex = 15;
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
            // Column5
            // 
            Column5.HeaderText = "Leave Type";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            // 
            // Column7
            // 
            Column7.HeaderText = "Start Date";
            Column7.MinimumWidth = 8;
            Column7.Name = "Column7";
            // 
            // Column6
            // 
            Column6.HeaderText = "End Date";
            Column6.Name = "Column6";
            // 
            // Column8
            // 
            Column8.HeaderText = "Days";
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
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Type Code";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "leave type";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Anual Quota";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Min Service";
            dataGridViewTextBoxColumn5.MinimumWidth = 8;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Clearance Required";
            dataGridViewTextBoxColumn6.MinimumWidth = 8;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "action";
            dataGridViewTextBoxColumn7.MinimumWidth = 8;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(975, 8);
            button3.Name = "button3";
            button3.Size = new Size(118, 23);
            button3.TabIndex = 17;
            button3.Text = "Generate";
            button3.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(5, 5);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Search name or employee code";
            textBox3.Size = new Size(108, 23);
            textBox3.TabIndex = 16;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn8, Column4, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13, dataGridViewTextBoxColumn14, dataGridViewTextBoxColumn15 });
            dataGridView3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView3.Location = new Point(8, 42);
            dataGridView3.Margin = new Padding(2);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 62;
            dataGridView3.Size = new Size(1100, 650);
            dataGridView3.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Emp Code";
            dataGridViewTextBoxColumn9.MinimumWidth = 8;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Name";
            dataGridViewTextBoxColumn8.MinimumWidth = 8;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // Column4
            // 
            Column4.HeaderText = "Department";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "Base";
            dataGridViewTextBoxColumn11.MinimumWidth = 8;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.HeaderText = "Carry";
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.HeaderText = "Bonus";
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.HeaderText = "Total";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            dataGridViewTextBoxColumn15.HeaderText = "Used";
            dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // Leave_Request
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(leaveRequestTab);
            Name = "Leave_Request";
            Text = "Leave_Request";
            Load += Leave_Request_Load;
            leaveRequestTab.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            pnlTotalLeave.ResumeLayout(false);
            pnlTotalLeave.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            button1.BringToFront();
            button2.BringToFront();
            button3.BringToFront();
            ResumeLayout(false);
        }

        #endregion

        private TabControl leaveRequestTab;
        private TabPage tabPage2;
        private TabPage pnlTotalLeave;
        private TabPage tabPage1;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private ComboBox compStatus;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView2;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Button button3;
        private TextBox textBox3;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn Column11;
    }
}