using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using RoadsOfRussia.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace RoadsOfRussia.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResumeSelectionPage.xaml
    /// </summary>
    public partial class ResumeSelectionPage : Page
    {
        public string PathToResume {  get; set; }
        public ResumeSelectionPage()
        {
            InitializeComponent();

            LoadData();
        }

        private async void LoadData()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/Candidates");

                var contentBody = await response.Content.ReadAsStringAsync();
                var candidatesList = JsonConvert.DeserializeObject<List<CandidatesModel>>(contentBody);


                dataGridResume.ItemsSource = candidatesList;
            }
        }

        public static string ReadDocument(string filePath)
        {

            StringBuilder documentText = new StringBuilder();

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                var body = wordDoc.MainDocumentPart.Document.Body;
                foreach (var paragraph in body.Elements<Paragraph>())
                {
                    // Чтение текста каждого параграфа и добавление переносов строк
                    documentText.AppendLine(paragraph.InnerText);
                }
                return documentText.ToString();
            }
        }


        private void OpenResume_Click(object sender, RoutedEventArgs e)
        {
            var path = Environment.CurrentDirectory;

            var candidate = dataGridResume.SelectedItem as CandidatesModel;
            if (candidate != null)
            {
                var text = ReadDocument(path + "\\Resume\\" + candidate.PathToResume);
                txbResume.Text = text;
            }
        }
    }
}
