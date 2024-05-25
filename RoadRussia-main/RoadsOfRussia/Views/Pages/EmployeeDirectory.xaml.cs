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
    /// Логика взаимодействия для EmployeeDirectory.xaml
    /// </summary>
    public partial class EmployeeDirectory : Page
    {
        private List<JobTitleModel> positions;
        public EmployeeDirectory()
        {
            InitializeComponent();
            LoadDivision();
            LoadData();
        }

        private async void LoadData()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/Employee");

                var contentBody = await response.Content.ReadAsStringAsync();
                var employeesList = JsonConvert.DeserializeObject<List<EmployeeModel>>(contentBody);
                 
                dataGridEmployee.ItemsSource = employeesList;
            }
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
                        positionItem.Selected += TreeViewItem_Selected;
                        positionItem.Tag = position.IdStructuralDivision; // Сохраняем IdStructuralDivision в Tag
                        divisionItem.Items.Add(positionItem);
                    }
                    TreeView.Items.Add(divisionItem);
                }

            }

        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            if (sender is TreeViewItem item)
            {
                int? idStructuralDivision = item.Tag as int?;
                if (idStructuralDivision.HasValue)
                {
                    JobTitleModel selectedPosition = positions.FirstOrDefault(p => p.IdStructuralDivision == idStructuralDivision);
                    if (selectedPosition != null)
                    {
                        MessageBox.Show($"Selected: {selectedPosition.Title}, IdStructuralDivision: {selectedPosition.IdStructuralDivision}");
                    }
                }
                e.Handled = true;
            }
        }


        private void OpenCardEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selected = dataGridEmployee.SelectedItem as EmployeeModel;

            if (selected != null)
            {
                var window = new EmployeeCardWindow(selected, selected.Id);
                window.Show();
            }
        }
    }
}
