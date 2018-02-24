using System.Windows.Forms;

namespace DailyReport
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        public string Show(string lastName, string city)
        {
            textBoxLastName.Text = lastName;
            textBoxCity.Text = city;

            DialogResult resultCode = ShowDialog();
            if (resultCode == DialogResult.OK)
            {
                return textBoxLastName.Text;
            }
            return string.Empty;
        }
    }
}
