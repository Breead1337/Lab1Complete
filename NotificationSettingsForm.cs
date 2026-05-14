using System;
using System.Windows.Forms;

namespace TravelManager
{
    public class NotificationSettingsForm : Form
    {
        private Label lblDays;
        private NumericUpDown numDays;
        private Button btnOk;
        private Button btnCancel;

        public int SelectedDays => (int)numDays.Value;

        public NotificationSettingsForm(int currentDays)
        {
            Text = "Настройки уведомлений";
            Size = new System.Drawing.Size(300, 150);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            lblDays = new Label();
            lblDays.Text = "Уведомлять за (дней):";
            lblDays.Location = new System.Drawing.Point(15, 20);
            lblDays.AutoSize = true;

            numDays = new NumericUpDown();
            numDays.Location = new System.Drawing.Point(170, 17);
            numDays.Width = 60;
            numDays.Minimum = 0;
            numDays.Maximum = 365;
            numDays.Value = currentDays;

            btnOk = new Button();
            btnOk.Text = "ОК";
            btnOk.Location = new System.Drawing.Point(120, 70);
            btnOk.DialogResult = DialogResult.OK;

            btnCancel = new Button();
            btnCancel.Text = "Отмена";
            btnCancel.Location = new System.Drawing.Point(200, 70);
            btnCancel.DialogResult = DialogResult.Cancel;

            Controls.Add(lblDays);
            Controls.Add(numDays);
            Controls.Add(btnOk);
            Controls.Add(btnCancel);

            AcceptButton = btnOk;
            CancelButton = btnCancel;
        }
    }
}
