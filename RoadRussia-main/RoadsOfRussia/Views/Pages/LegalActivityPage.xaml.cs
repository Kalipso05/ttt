using DocumentFormat.OpenXml.Packaging;
using Newtonsoft.Json;
using RoadsOfRussia.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoadsOfRussia.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для LegalActivityPage.xaml
    /// </summary>
    public partial class LegalActivityPage : Page
    {
        public LegalActivityPage()
        {
            InitializeComponent();
            LoadData();
        }


        private async Task DownloadFileAsync(string url, string savePath)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        byte[] fileData = await response.Content.ReadAsByteArrayAsync();
                        File.WriteAllBytes(savePath, fileData);
                    }
                    else
                    {
                        MessageBox.Show("Error downloading file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            int fileId = 3; // Пример идентификатора файла
            string apiUrl = $"https://localhost:44303/api/Files/DownloadFile?id={fileId}";
            string saveDirectory = @"C:\Users\ServerPC\Desktop\RoadRussian\RoadRussia-main\RoadsOfRussia\Documents";
            string savePath = System.IO.Path.Combine(saveDirectory, "DownloadedFile.docx");

            await DownloadFileAsync(apiUrl, savePath);
            string fileContent = ReadDocxFile(savePath);
            DisplayContentInFlowDocument(fileContent);
        }

        private async void LoadData()
        {
            using(var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/Library");
                var content = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<LibraryModel>>(content);

                var list = jsonData.Where(i => i.Id > 5).ToList();

                cmbLibrary.ItemsSource = list;
            }
        }

        private string ReadDocxFile(string filePath)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(filePath, false))
            {
                return wordDoc.MainDocumentPart.Document.Body.InnerText;
            }
        }

        private void DisplayContentInFlowDocument(string content)
        {
            flowDoc.Blocks.Clear();
            flowDoc.Blocks.Add(new Paragraph(new Run(content)));
        }
    }
}
