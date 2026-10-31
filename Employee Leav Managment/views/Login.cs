using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object? sender, EventArgs e)
        {
            if (usernameTextBox.Text.Trim() == "admin" && passwordTextBox.Text == "admin")
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            errorLabel.Text = "Invalid username or password.";
            passwordTextBox.Clear();
            passwordTextBox.Focus();
        }
    }
}
