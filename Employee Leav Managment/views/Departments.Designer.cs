namespace Employee_Leav_Managment.views
{
    partial class Departments
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
            textSerach = new TextBox();
            btnAddDept = new Button();
            dataGridView1 = new DataGridView();
            depCode = new DataGridViewTextBoxColumn();
            depName = new DataGridViewTextBoxColumn();
            depHead = new DataGridViewTextBoxColumn();
            activePersonel = new DataGridViewTextBoxColumn();
            action = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textSerach
            // 
            textSerach.Location = new Point(31, 12);
            textSerach.Name = "textSerach";
            textSerach.PlaceholderText = "Search department name or code";
            textSerach.Size = new Size(150, 31);
            textSerach.TabIndex = 0;
            // 
            // btnAddDept
            // 
            btnAddDept.Location = new Point(1019, 12);
            btnAddDept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddDept.Name = "btnAddDept";
            btnAddDept.Size = new Size(112, 34);
            btnAddDept.TabIndex = 1;
            btnAddDept.Text = "New Department";
            btnAddDept.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { depCode, depName, depHead, activePersonel, action });
            dataGridView1.Location = new Point(31, 62);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1100, 650);
            dataGridView1.TabIndex = 2;
            // 
            // depCode
            // 
            depCode.HeaderText = "Dep Code";
            depCode.MinimumWidth = 8;
            depCode.Name = "depCode";
            depCode.Width = 150;
            // 
            // depName
            // 
            depName.HeaderText = "Dep Name";
            depName.MinimumWidth = 8;
            depName.Name = "depName";
            depName.Width = 150;
            // 
            // depHead
            // 
            depHead.HeaderText = "Dep Head";
            depHead.MinimumWidth = 8;
            depHead.Name = "depHead";
            depHead.Width = 150;
            // 
            // activePersonel
            // 
            activePersonel.HeaderText = "Active Personel";
            activePersonel.MinimumWidth = 8;
            activePersonel.Name = "activePersonel";
            activePersonel.Width = 150;
            // 
            // action
            // 
            action.HeaderText = "action";
            action.MinimumWidth = 8;
            action.Name = "action";
            action.Width = 150;
            // 
            // Departments
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(dataGridView1);
            Controls.Add(btnAddDept);
            Controls.Add(textSerach);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Departments";
            Text = "Departments";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textSerach;
        private Button btnAddDept;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn depCode;
        private DataGridViewTextBoxColumn depName;
        private DataGridViewTextBoxColumn depHead;
        private DataGridViewTextBoxColumn activePersonel;
        private DataGridViewTextBoxColumn action;
    }
}