
using Employee_Leav_Managment.views;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Employee_Leav_Managment
{
    public partial class Form1 : Form
    {
        private Form? activeForm = null;

        public Form1()
        {
            InitializeComponent();
        }

        // Load child forms inside the display container
        private void OpenView(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm.Dispose();
            }

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            display.Controls.Clear();
            display.Controls.Add(childForm);

            childForm.Show();
        }

        // Load Dashboard when application starts
        private void Form1_Load(object sender, EventArgs e)
        {
            OpenView(new Dashbord());
        }

        private void employee_Click(object sender, EventArgs e)
        {
            OpenView(new Employee());
        }

        private void Departments_Click(object sender, EventArgs e)
        {
            OpenView(new Departments());
        }

        private void UserRoles_Click(object sender, EventArgs e)
        {
            OpenView(new User_Roles());
        }

        private void LeaveRequests_Click(object sender, EventArgs e)
        {
            OpenView(new Leave_Request());
        }

        private void Approval_Click(object sender, EventArgs e)
        {
            OpenView(new Approvals());
        }

        private void ClearanceDesk_Click(object sender, EventArgs e)
        {
            OpenView(new Clearance_desk());
        }

        private void Configuration_Click(object sender, EventArgs e)
        {
            OpenView(new Configration());
        }

        private void Report_Click(object sender, EventArgs e)
        {
            OpenView(new Reports());
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void display_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void Employee_Click_1(object sender, EventArgs e)
        {
            OpenView(new Employee());
        }

        private void Departments_Click_1(object sender, EventArgs e)
        {
            OpenView(new Departments());
        }

        private void UserRoles_Click_1(object sender, EventArgs e)
        {
            OpenView(new User_Roles());
        }

        private void LeaveRequests_Click_1(object sender, EventArgs e)
        {
            OpenView(new Leave_Request());
        }

        private void Approval_Click_1(object sender, EventArgs e)
        {
            OpenView(new Approvals());
        }

        private void ClearanceDesk_Click_1(object sender, EventArgs e)
        {
            OpenView(new Clearance_desk());
        }

        private void Configuration_Click_1(object sender, EventArgs e)
        {
            OpenView(new Configration());
        }

        private void Report_Click_1(object sender, EventArgs e)
        {
            OpenView(new Reports());
        }

        private void dashbord_Click(object sender, EventArgs e)
        {
            OpenView(new Dashbord());
        }
    }
}
