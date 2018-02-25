using System.Windows.Forms;

namespace DailyReport
{
    public partial class SettingsDialog : Form
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }

        public Settings Show(Settings settings)
        {
            textBoxLastName.Text = settings.LastName;
            textBoxCity.Text = settings.City;

            DialogResult resultCode = ShowDialog();
            if (resultCode == DialogResult.OK)
            {
                settings.LastName = textBoxLastName.Text;
                settings.City = textBoxCity.Text;
            }
            return settings;
        }
    }
}
