using System;
using System.Windows.Forms;
using JSONDispatcher.Models;

namespace JSONDispatcher.Forms
{
    public class EditFormButtonHandlers
    {
        private readonly EditForm _editForm;

        public EditFormButtonHandlers(EditForm editForm)
        {
            _editForm = editForm;
        }

        public void SaveButton_Click(object sender, EventArgs e)
        {
            _editForm.Entity.FullName = _editForm.FullNameTextBox.Text.Trim();
            _editForm.Entity.Faculty = _editForm.FacultyTextBox.Text.Trim();
            _editForm.Entity.Department = _editForm.DepartmentTextBox.Text.Trim();
            _editForm.Entity.Specialty = _editForm.SpecialtyTextBox.Text.Trim();
            _editForm.Entity.EnrollmentDate = _editForm.EnrollmentDatePicker.Value;
            _editForm.Entity.GraduationDate = _editForm.GraduationDatePicker.Value;
            _editForm.Entity.WorkHistory = _editForm.WorkHistoryTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(_editForm.Entity.FullName))
            {
                MessageBox.Show("Введіть дані ПІБ!", "ПОМИЛКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _editForm.DialogResult = DialogResult.OK;
            _editForm.Close();
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            _editForm.Close();
        }
    }
}
