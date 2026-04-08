using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelManager
{
    public class AddExpenseForm : Form
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public AddExpenseForm()
        {
            this.Text = "Добавить расход";
            this.Width = 300;
            this.Height = 150;
            CreateControls();
        }

        private void CreateControls()
        {
            var descLabel = new Label { Location = new Point(10, 10), Text = "Описание:", AutoSize = true };
            var amtLabel  = new Label { Location = new Point(10, 40), Text = "Сумма:",    AutoSize = true };

            var descBox = new TextBox { Location = new Point(100, 10), Size = new Size(170, 20) };
            var amtBox  = new TextBox { Location = new Point(100, 40), Size = new Size(170, 20) };

            var okBtn = new Button { Location = new Point(10, 70), Text = "OK", Size = new Size(75, 25) };
            okBtn.Click += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(descBox.Text) && decimal.TryParse(amtBox.Text, out decimal amt))
                {
                    Description = descBox.Text;
                    Amount = amt;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Заполните все поля корректно!");
                }
            };

            var cancelBtn = new Button { Location = new Point(195, 70), Text = "Отмена", Size = new Size(75, 25) };
            cancelBtn.Click += (sender, e) => { DialogResult = DialogResult.Cancel; Close(); };

            this.Controls.Add(descLabel);
            this.Controls.Add(amtLabel);
            this.Controls.Add(descBox);
            this.Controls.Add(amtBox);
            this.Controls.Add(okBtn);
            this.Controls.Add(cancelBtn);
        }
    }
}
