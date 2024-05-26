using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Model;

namespace WebApplication3
{
    public partial class Contact : Page
    {
        public static int Id { get; set; }
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:44303/api/Library");
                    var contentBody = await response.Content.ReadAsStringAsync();
                    var jsonData = JsonConvert.DeserializeObject<List<DocumentionSection>>(contentBody);
                    DropDownList1.DataSource = jsonData;
                    DropDownList1.DataTextField = "Title";
                    DropDownList1.DataValueField = "Id";
                    DropDownList1.DataBind();
                }
            }
            else
            {
                ButtonSave.Visible = false;
            }
        }

        protected async void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var id = int.Parse(DropDownList1.SelectedItem.Value);

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://localhost:44303/api/Library/{id}");
                var contentBody = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<List<Library>>(contentBody);

                ListBox1.DataSource = jsonData;

                ListBox1.DataTextField = "Name";
                ListBox1.DataValueField = "Id";
                ListBox1.DataBind();

                var s = ListBox1.Items;
            }

        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {

        }

        protected async void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                byte[] fileData = FileUpload1.FileBytes;
                string fileType = "1"; // Пример значения для FileType

                await UploadFileAsync(fileName, fileData, fileType);
            }
            else
            {
                // Обработка случая, когда файл не выбран
                Response.Write("No file selected.");
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonSave.Visible = true;
        }


        private async Task UploadFileAsync(string fileName, byte[] fileData, string fileType)
        {
            string apiUrl = "https://localhost:44303/api/Files/PostSingleFile";

            using (HttpClient client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    // Создаем содержимое файла
                    var fileContent = new ByteArrayContent(fileData);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/vnd.openxmlformats-officedocument.wordprocessingml.document");

                    // Добавляем содержимое файла и другие параметры
                    content.Add(fileContent, "FileDetails", fileName);
                    content.Add(new StringContent(fileType), "FileType");

                    try
                    {
                        HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            // Обработка успешного ответа
                            Response.Write("File uploaded successfully.");
                        }
                        else
                        {
                            // Обработка случая, когда файл не был успешно загружен
                            Response.Write("Error uploading file.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Обработка исключений
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }

        protected async void ButtonSave_Click(object sender, EventArgs e)
        {
            int fileId = 1; // Пример идентификатора файла
            await DownloadFileAsync(fileId);
        }


        private async Task DownloadFileAsync(int fileId)
        {
            string apiUrl = $"https://localhost:44303/api/Files/DownloadFile?id={fileId}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string contentDisposition = response.Content.Headers.ContentDisposition.ToString();
                        string fileName = GetFileNameFromContentDisposition(contentDisposition);
                        byte[] fileData = await response.Content.ReadAsByteArrayAsync();
                        string contentType = response.Content.Headers.ContentType.ToString();

                        Response.Clear();
                        Response.ContentType = contentType;
                        Response.AddHeader("Content-Disposition", $"attachment; filename={fileName}");
                        Response.BinaryWrite(fileData);
                        Response.End();
                    }
                    else
                    {
                        // Обработка случая, когда файл не был успешно загружен
                        Response.Write("Error downloading file.");
                    }
                }
                catch (Exception ex)
                {
                    // Обработка исключений
                    Response.Write("Error: " + ex.Message);
                }
            }
        }

        private string GetFileNameFromContentDisposition(string contentDisposition)
        {
            // Метод для извлечения имени файла из заголовка Content-Disposition
            var fileName = string.Empty;
            var contentDispositionElements = contentDisposition.Split(';');

            foreach (var element in contentDispositionElements)
            {
                if (element.Trim().StartsWith("filename*"))
                {
                    var fileNameElement = element.Split('\'');
                    fileName = Uri.UnescapeDataString(fileNameElement[2]);
                    break;
                }
                else if (element.Trim().StartsWith("filename"))
                {
                    fileName = element.Split('=')[1].Trim('\"');
                }
            }

            return fileName;
        }
    }
}