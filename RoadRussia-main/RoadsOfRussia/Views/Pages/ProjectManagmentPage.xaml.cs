using Newtonsoft.Json;
using RoadsOfRussia.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ProjectManagmentPage.xaml
    /// </summary>
    public partial class ProjectManagmentPage : Page
    {
        public ProjectManagmentPage()
        {
            InitializeComponent();
            LoadData();
        }


        public async void LoadData()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/Project");
                var content = await response.Content.ReadAsStringAsync();   
                var dataList = JsonConvert.DeserializeObject<List<ProjectModel>>(content);

                listViewProject.ItemsSource = dataList;
            }
        }

        private void listViewProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = listViewProject.SelectedItem as ProjectModel;

            if (item != null)
            {
                cardMaterial.Text = $"Название проекта: {item.NameProject}\nДиректор проекта: {item.DirectorProject}\nНачало проекта: {item.StartProject}\nОкончание проекта: {item.EndProject}";
                developmentStage.Text = $"Название проектирование: {item.Name}\nОписание: {item.Description}\nНачала проектирование: {item.StartDate}\nОкончание проектирования: {item.EndDate}\nСтатус проектирование: {item.Status}";
            }
        }
    }
}
