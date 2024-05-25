using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        }

        protected  void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        protected void DropDownList1_Load(object sender, EventArgs e)
        {

        }

        protected async void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string apiUrl = "https://localhost:44303/api/Library";
                HttpClient client = new HttpClient();
                MultipartFormDataContent formData = new MultipartFormDataContent();

                HttpContent fileContent = new StreamContent(FileUpload1.PostedFile.InputStream);
                fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
                {
                    Name = "file",
                    FileName = FileUpload1.FileName,
                };
                formData.Add(fileContent);

                HttpResponseMessage response = await client.PostAsync(apiUrl, formData);

                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine("вроде бы ок");
                }
                else
                {
                    Console.WriteLine(response);

                }

            }
        }
    }
}