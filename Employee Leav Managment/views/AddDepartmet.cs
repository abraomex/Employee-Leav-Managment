using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class AddDepartmet : Form
    {
        public AddDepartmet()
        {
            InitializeComponent();
            btnSave.Click += SaveDepartment;
            btnCancel.Click += CloseForm;
        }

        private void SaveDepartment(object? sender, EventArgs e)
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
