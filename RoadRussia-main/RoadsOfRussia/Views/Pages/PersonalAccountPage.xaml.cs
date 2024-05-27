using Newtonsoft.Json;
using RoadsOfRussia.ViewModel;
using RoadsOfRussia.Views.Windows;
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
    /// Логика взаимодействия для PersonalAccountPage.xaml
    /// </summary>
    public partial class PersonalAccountPage : Page
    {
        private List<JobTitleModel> positions;

        public PersonalAccountPage()
        {
            InitializeComponent();
            LoadDivision();
        }

        private async void LoadDivision()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/JobTitle");
                var contentBody = await response.Content.ReadAsStringAsync();

                positions = JsonConvert.DeserializeObject<List<JobTitleModel>>(contentBody);

                var divisions = positions
                .Where(p => p.StructuralDivision != null)
                .GroupBy(p => new { p.IdStructuralDivision, p.StructuralDivision })
                .Select(g => new
                {
                    Id = g.Key.IdStructuralDivision,
                    Name = g.Key.StructuralDivision,
                    Positions = g.ToList()
                })
                .ToList();

                foreach (var division in divisions)
                {
                    var divisionItem = new TreeViewItem { Header = division.Name };

                    foreach (var position in division.Positions)
                    {
                        var positionItem = new TreeViewItem { Header = position.Title };
                        positionItem.Tag = position.IdStructuralDivision; // Сохраняем IdStructuralDivision в Tag
                        divisionItem.Items.Add(positionItem);
                    }
                    TreeView.Items.Add(divisionItem);
                }

            }

        }

        private async void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/Event");
                var contentBody = await response.Content.ReadAsStringAsync();
                var eventData = JsonConvert.DeserializeObject<List<EventModel>>(contentBody);

                var selectData = eventData.Where(p => calendarEmployee.SelectedDate.Value.ToString("yyy:MM:dd") == p.DateTimeEvent.Date.ToString("yyy:MM:dd") && p.IdTypeEvent != 6).ToList();

                if (selectData == null)
                {
                    MessageBox.Show($"Мероприятий на {calendarEmployee.SelectedDate.Value.ToString("yyy:MM:dd")} не заплонировано");
                    return;
                }
                dataGridEvent.ItemsSource = selectData;
            }
        }
    }
}
