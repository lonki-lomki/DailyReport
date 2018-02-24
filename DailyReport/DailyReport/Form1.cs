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
            using (DocX document = DocX.Create(@"E:\test.docx", DocumentTypes.Document))
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

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog settingsDialog = new SettingsDialog();
            settingsDialog.Show("ФИО", "Город");
        }
    }
}
