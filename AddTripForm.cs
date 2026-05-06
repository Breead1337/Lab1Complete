using System;
using System.Windows.Forms;

namespace TravelManager
{
    public partial class AddTripForm : Form
    {
        public Tip CreatedTrip { get; private set; }

        public AddTripForm()
        {
            InitializeComponent();
            dtpStart.Value = DateTime.Today;
            dtpEnd.Value = DateTime.Today.AddDays(7);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDestination.Text))
            {
                MessageBox.Show("Введите пункт назначения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDestination.Focus();
                return;
            }
            if (dtpEnd.Value.Date < dtpStart.Value.Date)
            {
                MessageBox.Show("Дата окончания не может быть раньше началЀ!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string budgetStr = txtBudget.Text.Trim().Replace(" ", "");
            if (!decimal.TryParse(budgetStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out decimal budget) || budget <= 0)
            {
                if (!decimal.TryParse(budgetStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out budget) || budget <= 0)
                {
                    MessageBox.Show("Введите корректный бюджет (больше 0)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBudget.Focus();
                    return;
                }
            }
            try
            {
                CreatedTrip = new Tip(txtDestination.Text.Trim(), dtpStart.Value.Date, dtpEnd.Value.Date, budget);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ez)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
