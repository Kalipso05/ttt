using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;
using RoadsOfRussia.Views.Pages;
using System.Windows;
using System.Windows.Threading;
using System;
using System.Windows.Navigation;
using System.Collections.Generic;
using RoadsOfRussia.ViewModel;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Net.Http;
using Newtonsoft.Json;

namespace RoadsOfRussia
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            mainFrame.Navigate(new EmployeeDirectory());
            txbNameModule.Text = "Сотрудники";


            LoadData();
            LoadDataEvent();

        }

        public async void LoadDataEvent()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/Event");
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<EventModel>>(content);

                txbEvent1.Text = $"{data[0].NameEvent}\n{data[0].DateTimeEvent}";
                txbEvent2.Text = $"{data[1].NameEvent}\n{data[1].DateTimeEvent}";
                txbEvent3.Text = $"{data[2].NameEvent}\n{data[2].DateTimeEvent}";
            }
        }

        public void LoadData()
        {
            var list = new List<Test>();

            string url = "https://ria.ru/export/rss2/archive/index.xml";

            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();

                int count = 0;
                foreach (SyndicationItem item in feed.Items)
                {
                    var news = new Test
                    {
                        Title = item.Title.Text,
                        PublishDate = item.PublishDate.DateTime,
                    };
                    list.Add(news);
                    
                    count++;
                    if (count == 3)
                        break;
                }
                ListDataView.ItemsSource = list;
            }
        }

        private void SendNotifiDateOfBirth(object sender, EventArgs e)
        {
        }

        private void pageEmployee_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new EmployeeDirectory());
            txbNameModule.Text = "Сотрудники";
        }

        private void ResumeSelection_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new ResumeSelectionPage());
            txbNameModule.Text = "Подбор резюме";
        }

        private void AbsenceSelection_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new TemporaryAbsencePage());
            txbNameModule.Text = "Список отсутсвующих работников";
        }

        private void CalendarTraining_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new EmployeeEventsCalendarPage());
        }

        private void ProjectManagment_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate (new ProjectManagmentPage());
            txbNameModule.Text = "Управление проектами";
        }

        private void PersonalAccount_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new PersonalAccountPage());
        }

        private void LegalActivity_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new LegalActivityPage());
        }
    }
}
