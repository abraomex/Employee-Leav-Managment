using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new object[] { "Male", "Female" });
            comboBox2.Items.AddRange(new object[]
            {
                "Department 1",
                "Department 2",
                "Department 3",
                "Department 4",
                "Department 5"
            });

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            btnAddEmployee.Click += SaveEmployee;
            btnCancel.Click += CloseForm;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SaveEmployee(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CloseForm(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
