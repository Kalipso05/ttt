using System;
using System.Net.Http;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using WebApplication3.Model;
using Newtonsoft.Json;

namespace WebApplication3
{
    public partial class _Default : Page
    {

        public List<Event> EventList {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadEvent();

            
        }

        public void LoadData()
        {
            if (!IsPostBack)
            {
                string url = "https://ria.ru/export/rss2/archive/index.xml";

                using (XmlReader reader = XmlReader.Create(url))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);
                    reader.Close();

                    int count = 0;
                    foreach (SyndicationItem item in feed.Items)
                    {
                        // Создание нового элемента Label
                        Label label = new Label();
                        var link = item.Links[0].Uri.ToString();
                        label.Text = $"<a href='{link}' target='_blank'>{item.Title.Text}</a><br />{item.PublishDate.DateTime}<br />";
                        label.CssClass = "bordered-label"; // Применение CSS класса
                        label.Text = label.Text.Replace("\n", "<br />");

                        // Добавление Label в контейнер
                        labelsContainer.Controls.Add(label);
                        count++;
                        if (count == 7)
                            break;
                    }
                }
            }
        }

        public async void LoadEvent()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/Event");
                var contentBody = await response.Content.ReadAsStringAsync();
                EventList = JsonConvert.DeserializeObject<List<Event>>(contentBody);
            }

            labelEvent1.Text = $"{EventList[0].NameEvent}<br />{EventList[0].DateTimeEvent}";
            labelEvent2.Text = $"{EventList[1].NameEvent}<br />{EventList[1].DateTimeEvent}";
        }

        protected void OpenLabrary_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx", false);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        protected  void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            

            var events = EventList.Where(i => i.DateTimeEvent.Date == Calendar1.SelectedDate.Date).FirstOrDefault();

            if (events == null)
            {
                ContentLabel.Text = string.Empty;
                ContentLabel.Visible = false;
                string script = "alert('У этой даты нет никаких событий');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                return;
            }

            ContentLabel.Visible = true;

            ContentLabel.Text = $"<strong>Наименование мероприятия</strong> {events.NameEvent}<br /><strong>Тип мероприятия</strong> {events.TypeEvent}<br /><strong>Статус</strong> {events.StatusEvent}<br /><strong>Описание</strong> {events.Description}";
        }
    }
}