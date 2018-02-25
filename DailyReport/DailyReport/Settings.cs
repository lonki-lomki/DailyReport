
using System.IO;
using System.Windows.Forms;

namespace DailyReport
{
    /// <summary>
    /// Класс для хранения настроек
    /// </summary>
    public class Settings
    {
        private string lastName;
        private string city;

        public Settings(string lastName, string city)
        {
            LastName = lastName;
            City = city;
        }

        public string LastName { get => lastName; set => lastName = value; }
        public string City { get => city; set => city = value; }

        public static Settings LoadFromFile(string filename)
        {
            Settings settings = new Settings("Фамилия", "Город");
            string content = File.ReadAllText(filename);
            foreach (string s in content.Split('\n'))
            {
                string[] arr = s.Split(':');
                if (arr[0].Equals("lastName"))
                {
                    settings.LastName = arr[1];
                }
                if (arr[0].Equals("city"))
                {
                    settings.City = arr[1];
                }
            }
            return settings;
        }

        public void SaveToFile(string filename)
        {
            File.WriteAllText(filename, ToString());
        }

        public override string ToString()
        {
            return "lastName:" + LastName + "\ncity:" + City + "\n";
        }
    }
}
