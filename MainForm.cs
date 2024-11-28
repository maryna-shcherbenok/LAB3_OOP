using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JSONDispatcher.Models;
using JSONDispatcher.Services;

namespace JSONDispatcher.Forms
{
    public partial class MainForm : Form
    {
        public List<EntityModel> Data { get; private set; } = new List<EntityModel>();
        public DataGridView DataGridView => dataGridView;
        public TextBox SearchTextBox => searchTextBox;

        private readonly DispatcherService<EntityModel> _dispatcher = new DispatcherService<EntityModel>();
        private readonly MainFormButton _buttonHandlers;

        private DataGridView dataGridView;
        private Button addButton;
        private Button deleteButton;
        private Button searchButton;
        private Button editButton;
        private TextBox searchTextBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem openFileMenuItem;
        private ToolStripMenuItem saveFileMenuItem;
        private ToolStripMenuItem aboutMenuItem;

        public MainForm()
        {
            InitializeComponent();
            _buttonHandlers = new MainFormButton(this);

            addButton.Click += _buttonHandlers.AddButton_Click;
            editButton.Click += _buttonHandlers.EditButton_Click;
            deleteButton.Click += _buttonHandlers.DeleteButton_Click;
            searchButton.Click += _buttonHandlers.SearchButton_Click;
        }

        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 40);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(1282, 301);
            this.dataGridView.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(761, 4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 30);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Додати";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(923, 4);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 30);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Видалити";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(1219, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 30);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Пошук";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(842, 4);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 30);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Змінити";
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(1013, 8);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 22);
            this.searchTextBox.TabIndex = 4;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.aboutMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1306, 28);
            this.menuStrip.TabIndex = 6;
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileMenuItem,
            this.saveFileMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(59, 24);
            this.fileMenuItem.Text = "Файл";
            // 
            // openFileMenuItem
            // 
            this.openFileMenuItem.Name = "openFileMenuItem";
            this.openFileMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openFileMenuItem.Text = "Відкрити файл";
            this.openFileMenuItem.Click += OpenFile_Click;
            // 
            // saveFileMenuItem
            // 
            this.saveFileMenuItem.Name = "saveFileMenuItem";
            this.saveFileMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveFileMenuItem.Text = "Зберегти файл";
            this.saveFileMenuItem.Click += SaveFile_Click;
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(124, 24);
            this.aboutMenuItem.Text = "Про програму";
            this.aboutMenuItem.Click += AboutButton_Click;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1306, 357);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "ДИСПЕТЧЕР ДЛЯ JSON";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON Files (*.json)|*.json";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Data = _dispatcher.LoadFromFile(dialog.FileName);
                    RefreshGrid();
                }
            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "JSON Files (*.json)|*.json";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _dispatcher.SaveToFile(dialog.FileName, Data);
                }
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog();
            }
        }

        public void RefreshGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = Data;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
