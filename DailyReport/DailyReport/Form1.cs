using System;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace DailyReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog settingsDialog = new SettingsDialog();
            Settings settings = settingsDialog.Show(Settings.LoadFromFile("settings.ini"));
            settings.SaveToFile("settings.ini");
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            // Прочитать настройки
            Settings settings = Settings.LoadFromFile("settings.ini");
            // Получить текущую дату
            DateTime dt = DateTime.Now;
            // Выбор пути к файлу для сохранения резульата
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "docx";
            sfd.Filter = "docx files (*.docx)|*.docx|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.FileName = settings.LastName + "_" + settings.City + "_" + dt.ToString("yyyyMMdd") + ".docx";
            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                // Ничего не сохраняем, нажата кнопка отмены
                return;
            }
            //MessageBox.Show(sfd.FileName);

            using (DocX document = DocX.Create(sfd.FileName, DocumentTypes.Document))
            {
                // Добавить заголовок
                document.InsertParagraph("Ежедневный отчет").FontSize(15d).SpacingAfter(50d).Alignment = Alignment.center;
                // Добавить обычный текст
                Paragraph p = document.InsertParagraph("Тест Проверка Пример.");
                // Добавить таблицу
                Table t = document.AddTable(5, 2);
                t.Design = TableDesign.ColorfulGridAccent1;
                t.Alignment = Alignment.center;
                // Добавить строки
                t.Rows[0].Cells[0].Paragraphs[0].Append("1");
                t.Rows[0].Cells[1].Paragraphs[0].Append("One");
                t.Rows[1].Cells[0].Paragraphs[0].Append("2");
                t.Rows[1].Cells[1].Paragraphs[0].Append("Two");
                t.Rows[2].Cells[0].Paragraphs[0].Append("3");
                t.Rows[2].Cells[1].Paragraphs[0].Append("Three");
                t.Rows[3].Cells[0].Paragraphs[0].Append("4");
                t.Rows[3].Cells[1].Paragraphs[0].Append("Four");
                t.Rows[4].Cells[0].Paragraphs[0].Append("5");
                t.Rows[4].Cells[1].Paragraphs[0].Append("Five");

                t.AutoFit = AutoFit.Contents;

                // Добавить таблицу после последнего параграфа
                p.InsertTableAfterSelf(t);

                // Сохранить файл
                document.Save();
            }
        }
    }
}
