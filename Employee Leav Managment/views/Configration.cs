using System;
using System.Windows.Forms;

namespace Employee_Leav_Managment.views
{
    public partial class Configration : Form
    {
        public Configration()
        {
            InitializeComponent();

            leaveCategory.Items.AddRange(new object[] { "Annual Leave", "Sick Leave", "Study Leave" });
            approverRole.Items.AddRange(new object[] { "Department Head", "HR Officer", "Finance Officer", "IT Officer" });
            clearanceDepartment.Items.AddRange(new object[] { "Department 1", "Department 2", "Department 3", "Department 4", "Department 5" });

            leaveCategory.SelectedIndex = 0;
            approverRole.SelectedIndex = 0;
            clearanceDepartment.SelectedIndex = 0;
            sequentialApproval.Checked = true;
            sequentialClearance.Checked = true;

            approverSteps.Items.Add("Department Head");
            approverSteps.Items.Add("HR Officer");
            clearanceDepartments.Items.AddRange(new object[] { "Department 1", "Department 2" });
            clearanceItems.Items.AddRange(new object[] { "Finance", "HR", "IT" });

            addApprover.Click += AddApproverStep;
            moveUp.Click += MoveApproverUp;
            moveDown.Click += MoveApproverDown;
            addDepartment.Click += AddClearanceDepartment;
            addItem.Click += AddClearanceItem;
        }

        private void AddApproverStep(object? sender, EventArgs e)
        {
            approverSteps.Items.Add(approverRole.SelectedItem);
        }

        private void MoveApproverUp(object? sender, EventArgs e)
        {
            MoveApprover(-1);
        }

        private void MoveApproverDown(object? sender, EventArgs e)
        {
            MoveApprover(1);
        }

        private void MoveApprover(int direction)
        {
            int index = approverSteps.SelectedIndex;
            int newIndex = index + direction;
            if (index < 0 || newIndex < 0 || newIndex >= approverSteps.Items.Count)
            {
                return;
            }

            object item = approverSteps.Items[index];
            approverSteps.Items.RemoveAt(index);
            approverSteps.Items.Insert(newIndex, item);
            approverSteps.SelectedIndex = newIndex;
        }

        private void AddClearanceDepartment(object? sender, EventArgs e)
        {
            clearanceDepartments.Items.Add(clearanceDepartment.SelectedItem);
        }

        private void AddClearanceItem(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(clearanceItem.Text))
            {
                clearanceItems.Items.Add(clearanceItem.Text.Trim());
                clearanceItem.Clear();
            }
        }
    }
}
