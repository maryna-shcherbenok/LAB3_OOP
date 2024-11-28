using System;
using System.Linq;
using System.Windows.Forms;
using JSONDispatcher.Models;

namespace JSONDispatcher.Forms
{
    public class MainFormButton
    {
        private readonly MainForm _mainForm;

        public MainFormButton(MainForm mainForm)
        {
            _mainForm = mainForm;
        }

        public void AddButton_Click(object sender, EventArgs e)
        {
            var editForm = new EditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _mainForm.Data.Add(editForm.Entity);
                _mainForm.RefreshGrid();
            }
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            if (_mainForm.DataGridView.SelectedRows.Count > 0)
            {
                var selectedRowIndex = _mainForm.DataGridView.SelectedRows[0].Index;
                var selectedEntity = _mainForm.Data[selectedRowIndex];

                var editForm = new EditForm(selectedEntity);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _mainForm.Data[selectedRowIndex] = editForm.Entity;
                    _mainForm.RefreshGrid();
                }
            }
            else
            {
                MessageBox.Show("Виберіть рядок для редагування.", "Помилка редагування", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_mainForm.DataGridView.SelectedRows.Count > 0)
            {
                var selectedEntity = (EntityModel)_mainForm.DataGridView.SelectedRows[0].DataBoundItem;
                _mainForm.Data.Remove(selectedEntity);
                _mainForm.RefreshGrid();
            }
        }

        public void SearchButton_Click(object sender, EventArgs e)
        {
            string query = _mainForm.SearchTextBox.Text.ToLower();

            DateTime.TryParse(query, out DateTime parsedDate);

            var result = _mainForm.Data.Where(x =>
                (x.FullName != null && x.FullName.ToLower().Contains(query)) ||
                (x.Faculty != null && x.Faculty.ToLower().Contains(query)) ||
                (x.Department != null && x.Department.ToLower().Contains(query)) ||
                (x.Specialty != null && x.Specialty.ToLower().Contains(query)) ||
                (parsedDate != DateTime.MinValue &&
                    (x.EnrollmentDate.Date == parsedDate.Date || x.GraduationDate.Date == parsedDate.Date)) ||
                (x.EnrollmentDate.ToString("yyyy-MM-dd").Contains(query)) ||
                (x.GraduationDate.ToString("yyyy-MM-dd").Contains(query)) ||
                (x.WorkHistory != null && x.WorkHistory.ToLower().Contains(query))
            ).ToList();

            if (result.Count == 0)
            {
                MessageBox.Show("Жодних записів не знайдено. Перевірте введені дані та спробуйте ще раз.", "Результати пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _mainForm.DataGridView.DataSource = null;
            _mainForm.DataGridView.DataSource = result;
        }
    }
}
