namespace Employee_Leav_Managment.views
{
    partial class AddEmployee
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
            components = new System.ComponentModel.Container();
            pnlHeader = new Panel();
            lblTitle = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            comboBox1 = new ComboBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            comboBox2 = new ComboBox();
            contextMenuStrip2 = new ContextMenuStrip(components);
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            btnAddEmployee = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Location = new Point(40, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(720, 55);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(166, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Add new Employee";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(40, 110);
            textBox1.Size = new Size(180, 31);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Employee code";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 80);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 2;
            label1.Text = "Emp code";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(290, 80);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 3;
            label2.Text = "First Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(540, 80);
            label3.Name = "label3";
            label3.Size = new Size(95, 25);
            label3.TabIndex = 4;
            label3.Text = "Last Name";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(290, 230);
            label4.Name = "label4";
            label4.Size = new Size(132, 25);
            label4.TabIndex = 5;
            label4.Text = "Phone Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 155);
            label5.Name = "label5";
            label5.Size = new Size(54, 25);
            label5.TabIndex = 6;
            label5.Text = "Email";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(540, 155);
            label6.Name = "label6";
            label6.Size = new Size(69, 25);
            label6.TabIndex = 7;
            label6.Text = "Gender";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 355);
            label7.Name = "label7";
            label7.Size = new Size(84, 25);
            label7.TabIndex = 8;
            label7.Text = "Hire date";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox2
            // 
            textBox2.Location = new Point(290, 110);
            textBox2.Size = new Size(180, 31);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "First name";
            textBox2.Size = new Size(150, 31);
            textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(540, 110);
            textBox3.Size = new Size(180, 31);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Last name";
            textBox3.Size = new Size(150, 31);
            textBox3.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(40, 385);
            dateTimePicker1.Size = new Size(220, 31);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 12;
            dateTimePicker1.Value = new DateTime(2026, 10, 31, 14, 28, 5, 0);
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(540, 185);
            comboBox1.Size = new Size(180, 33);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 13;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(40, 185);
            textBox4.Size = new Size(180, 31);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Email address";
            textBox4.Size = new Size(150, 31);
            textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(290, 185);
            textBox5.Size = new Size(180, 31);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Password";
            textBox5.Size = new Size(150, 31);
            textBox5.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 230);
            label8.Name = "label8";
            label8.Size = new Size(107, 25);
            label8.TabIndex = 16;
            label8.Text = "Department";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(540, 230);
            label9.Name = "label9";
            label9.Size = new Size(77, 25);
            label9.TabIndex = 17;
            label9.Text = "Job Title";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(290, 155);
            label10.Name = "label10";
            label10.Size = new Size(87, 25);
            label10.TabIndex = 18;
            label10.Text = "Password";
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(40, 260);
            comboBox2.Size = new Size(180, 33);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(182, 33);
            comboBox2.TabIndex = 19;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(24, 24);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // textBox6
            // 
            textBox6.Location = new Point(540, 260);
            textBox6.Size = new Size(180, 31);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(150, 31);
            textBox6.TabIndex = 21;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(290, 260);
            textBox7.Size = new Size(180, 31);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(150, 31);
            textBox7.TabIndex = 22;
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Location = new Point(608, 385);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(112, 34);
            btnAddEmployee.TabIndex = 23;
            btnAddEmployee.Text = "Save Employee";
            btnAddEmployee.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(790, 414);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 24;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddEmployee
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnAddEmployee);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(comboBox2);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(comboBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(pnlHeader);
            Name = "AddEmployee";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Employee";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBox2;
        private TextBox textBox3;
        private DateTimePicker dateTimePicker1;
        private ComboBox comboBox1;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox comboBox2;
        private ContextMenuStrip contextMenuStrip2;
        private TextBox textBox6;
        private TextBox textBox7;
        private Button btnAddEmployee;
        private Button btnCancel;
    }
}