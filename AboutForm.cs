using System;
using System.Windows.Forms;

namespace JSONDispatcher.Forms
{
    public partial class AboutForm : Form
    {
        private Label infoLabel;
        private Button closeButton;

        public AboutForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.infoLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(15, 15);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(521, 128);
            this.infoLabel.TabIndex = 0;
            this.infoLabel.Text = "Лабораторна робота № 3. ДИСПЕТЧЕР ДЛЯ JSON.\n\nЛабораторну виконала: Щербенок Марина" +
    "\nКурс: 2 курс;\nГрупа: К-25;\nРік навчання: 2024;\n\nОпис лабораторної: РОЗРОБКА" +
    "ПРОГРАМ ОБРОБКИ ФАЙЛІВ У ФОРМАТІ JSON.";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(246, 175);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 30);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "Закрити";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AboutForm
            // 
            this.ClientSize = new System.Drawing.Size(563, 217);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.closeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Про програму";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CloseButton_Click(object sender, EventArgs e) { this.Close(); }
    }
}
