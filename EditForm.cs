using System;
using System.Windows.Forms;
using JSONDispatcher.Models;

namespace JSONDispatcher.Forms
{
    public partial class EditForm : Form
    {
        public EntityModel Entity { get; private set; }

        public TextBox FullNameTextBox => fullNameTextBox;
        public TextBox FacultyTextBox => facultyTextBox;
        public TextBox DepartmentTextBox => departmentTextBox;
        public TextBox SpecialtyTextBox => specialtyTextBox;
        public DateTimePicker EnrollmentDatePicker => enrollmentDatePicker;
        public DateTimePicker GraduationDatePicker => graduationDatePicker;
        public TextBox WorkHistoryTextBox => workHistoryTextBox;

        private TextBox fullNameTextBox;
        private TextBox facultyTextBox;
        private TextBox departmentTextBox;
        private TextBox specialtyTextBox;
        private DateTimePicker enrollmentDatePicker;
        private DateTimePicker graduationDatePicker;
        private TextBox workHistoryTextBox;
        private Button saveButton;
        private Button cancelButton;
        private readonly EditFormButtonHandlers _buttonHandlers;

        public EditForm(EntityModel entity = null)
        {
            Entity = entity ?? new EntityModel();
            InitializeComponent();
            _buttonHandlers = new EditFormButtonHandlers(this);

            saveButton.Click += _buttonHandlers.SaveButton_Click;
            cancelButton.Click += _buttonHandlers.CancelButton_Click;

            LoadEntityData();
        }

        private void InitializeComponent()
        {
            this.fullNameTextBox = new TextBox { Location = new System.Drawing.Point(10, 30), Size = new System.Drawing.Size(328, 22) };
            this.facultyTextBox = new TextBox { Location = new System.Drawing.Point(10, 80), Size = new System.Drawing.Size(328, 22) };
            this.departmentTextBox = new TextBox { Location = new System.Drawing.Point(10, 130), Size = new System.Drawing.Size(328, 22) };
            this.specialtyTextBox = new TextBox { Location = new System.Drawing.Point(10, 180), Size = new System.Drawing.Size(328, 22) };
            this.enrollmentDatePicker = new DateTimePicker { Location = new System.Drawing.Point(10, 237), Size = new System.Drawing.Size(328, 22) };
            this.graduationDatePicker = new DateTimePicker { Location = new System.Drawing.Point(10, 291), Size = new System.Drawing.Size(328, 22) };
            this.workHistoryTextBox = new TextBox { Location = new System.Drawing.Point(10, 348), Multiline = true, Size = new System.Drawing.Size(328, 75) };

            this.saveButton = new Button { Location = new System.Drawing.Point(56, 448), Size = new System.Drawing.Size(100, 23), Text = "Зберігти зміни" };
            this.cancelButton = new Button { Location = new System.Drawing.Point(191, 448), Size = new System.Drawing.Size(100, 23), Text = "Скасувати" };

            this.Controls.AddRange(new Control[]
            {
                new Label { Location = new System.Drawing.Point(10, 10), Text = "П.І.Б.", Size = new System.Drawing.Size(100, 17) },
                fullNameTextBox,
                new Label { Location = new System.Drawing.Point(10, 60), Text = "Факультет", Size = new System.Drawing.Size(100, 17) },
                facultyTextBox,
                new Label { Location = new System.Drawing.Point(10, 110), Text = "Кафедра", Size = new System.Drawing.Size(100, 17) },
                departmentTextBox,
                new Label { Location = new System.Drawing.Point(10, 160), Text = "Спеціальність", Size = new System.Drawing.Size(100, 17) },
                specialtyTextBox,
                new Label { Location = new System.Drawing.Point(7, 217), Text = "Дата зарахування", Size = new System.Drawing.Size(146, 17) },
                enrollmentDatePicker,
                new Label { Location = new System.Drawing.Point(10, 271), Text = "Дата випуску", Size = new System.Drawing.Size(100, 17) },
                graduationDatePicker,
                new Label { Location = new System.Drawing.Point(10, 328), Text = "Трудова зайнятість", Size = new System.Drawing.Size(152, 17) },
                workHistoryTextBox,
                saveButton,
                cancelButton
            });

            this.ClientSize = new System.Drawing.Size(350, 500);
            this.Text = "Редагування";
        }

        private void LoadEntityData()
        {
            fullNameTextBox.Text = Entity.FullName ?? string.Empty;
            facultyTextBox.Text = Entity.Faculty ?? string.Empty;
            departmentTextBox.Text = Entity.Department ?? string.Empty;
            specialtyTextBox.Text = Entity.Specialty ?? string.Empty;
            enrollmentDatePicker.Value = Entity.EnrollmentDate != default ? Entity.EnrollmentDate : DateTime.Now;
            graduationDatePicker.Value = Entity.GraduationDate != default ? Entity.GraduationDate : DateTime.Now;
            workHistoryTextBox.Text = Entity.WorkHistory ?? string.Empty;
        }
    }
}
