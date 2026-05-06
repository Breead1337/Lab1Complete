using System;
using System.Globalization;
using System.Windows.Forms;

namespace TravelManager
{
    public partial class AddExpenseForm : Form
    {
        public string ExpenseDescription { get; private set; }
        public decimal ExpenseAmount { get; private set; }
        public string ExpenseCategory { get; private set; }
        public DateTime ExpenseDate { get; private set; }

        public new int Width
        {
            get => Visible ? base.Width : 300;
            set => base.Width = value;
        }

        public new int Height
        {
            get => Visible ? base.Height : 150;
            set => base.Height = value;
        }

        public AddExpenseForm()
        {
            InitializeComponent();
            cmbCategory.SelectedIndex = 0;
            dtpDate.Value = DateTime.Today;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание расхода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return;
            }
            string raw = txtAmount.Text.Trim().Replace(" ", "").Replace(",", ".");
            if (!decimal.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amt) || amt <= 0)
            {
                MessageBox.Show("Введите корректную сумму (больше 0)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }
            ExpenseDescription = txtDescription.Text.Trim();
            ExpenseAmount = amt;
            ExpenseCategory = cmbCategory.SelectedItem != null ? cmbCategory.SelectedItem.ToString() : "Прочее";
            ExpenseDate = dtpDate.Value.Date;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
