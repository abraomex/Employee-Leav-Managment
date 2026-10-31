namespace Employee_Leav_Managment.views
{
    partial class AddDepartmet
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
            pnlDepartmentTitle = new Panel();
            labelTitle = new Label();
            labelCode = new Label();
            labelName = new Label();
            labelHead = new Label();
            labelPersonnel = new Label();
            textCode = new TextBox();
            textName = new TextBox();
            textHead = new TextBox();
            textPersonnel = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            pnlDepartmentTitle.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDepartmentTitle
            // 
            pnlDepartmentTitle.Controls.Add(labelTitle);
            pnlDepartmentTitle.Location = new Point(20, 20);
            pnlDepartmentTitle.Name = "pnlDepartmentTitle";
            pnlDepartmentTitle.Size = new Size(560, 55);
            pnlDepartmentTitle.TabIndex = 0;
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(20, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(200, 25);
            labelTitle.Text = "Add New Department";
            labelCode.AutoSize = true;
            labelCode.Location = new Point(40, 100);
            labelCode.Text = "Department Code";
            labelName.AutoSize = true;
            labelName.Location = new Point(320, 100);
            labelName.Text = "Department Name";
            labelHead.AutoSize = true;
            labelHead.Location = new Point(40, 180);
            labelHead.Text = "Department Head";
            labelPersonnel.AutoSize = true;
            labelPersonnel.Location = new Point(320, 180);
            labelPersonnel.Text = "Active Personnel";
            textCode.Location = new Point(40, 130);
            textCode.Name = "textCode";
            textCode.PlaceholderText = "DEP006";
            textCode.Size = new Size(220, 31);
            textName.Location = new Point(320, 130);
            textName.Name = "textName";
            textName.PlaceholderText = "Department name";
            textName.Size = new Size(220, 31);
            textHead.Location = new Point(40, 210);
            textHead.Name = "textHead";
            textHead.PlaceholderText = "Department head";
            textHead.Size = new Size(220, 31);
            textPersonnel.Location = new Point(320, 210);
            textPersonnel.Name = "textPersonnel";
            textPersonnel.PlaceholderText = "Number of employees";
            textPersonnel.Size = new Size(220, 31);
            btnCancel.Location = new Point(320, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 34);
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnSave.Location = new Point(440, 290);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 34);
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // AddDepartmet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 370);
            Controls.Add(labelCode);
            Controls.Add(labelName);
            Controls.Add(labelHead);
            Controls.Add(labelPersonnel);
            Controls.Add(textCode);
            Controls.Add(textName);
            Controls.Add(textHead);
            Controls.Add(textPersonnel);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(pnlDepartmentTitle);
            Name = "AddDepartmet";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Text = "Add Department";
            pnlDepartmentTitle.ResumeLayout(false);
            pnlDepartmentTitle.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlDepartmentTitle;
        private Label labelTitle;
        private Label labelCode;
        private Label labelName;
        private Label labelHead;
        private Label labelPersonnel;
        private TextBox textCode;
        private TextBox textName;
        private TextBox textHead;
        private TextBox textPersonnel;
        private Button btnSave;
        private Button btnCancel;
    }
}