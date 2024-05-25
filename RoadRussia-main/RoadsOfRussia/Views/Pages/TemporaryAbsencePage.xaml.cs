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
    /// Логика взаимодействия для TemporaryAbsencePage.xaml
    /// </summary>
    public partial class TemporaryAbsencePage : Page
    {
        private List<JobTitleModel> positions;
        public TemporaryAbsencePage()
        {
            InitializeComponent();
            LoadDivision();
            LoadData();
        }

        public async void LoadData()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:44303/api/TemporaryAbsence");

                var contentBody = await response.Content.ReadAsStringAsync();
                var absenceList = JsonConvert.DeserializeObject<List<AbsenceModel>>(contentBody);
                dataGridAbsence.ItemsSource = absenceList;
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
        private async void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            if (sender is TreeViewItem item)
            {
                int? idStructuralDivision = item.Tag as int?;
                if (idStructuralDivision.HasValue)
                {
                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync("https://localhost:44303/api/Employee");
                        var contentBody = await response.Content.ReadAsStringAsync();
                        var employeeList = JsonConvert.DeserializeObject<List<EmployeeModel>>(contentBody);

                        var employeeSelectedDivision = employeeList.Where(p => p.IdStructuralDivision == idStructuralDivision).ToList();
                        dataGridAbsence.ItemsSource = employeeSelectedDivision;
                    }
                }
            }
            e.Handled = true;
        }

        private async void dataGridAbsence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedEmployee = dataGridAbsence.SelectedItem as EmployeeModel;

            if (selectedEmployee != null)
            {

                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = await client.GetAsync($"https://localhost:44303/api/TemporaryAbsence/{selectedEmployee.Id}");
                        var contentBody = await response.Content.ReadAsStringAsync();
                        var absense = JsonConvert.DeserializeObject<AbsenceModel>(contentBody);

                        if (absense != null)
                        {
                            txbVacantion.Text = $"Отпуск до: {(absense.VacantionUntil.HasValue ? absense.VacantionUntil.Value.ToShortDateString() : "Отсутствует")}";
                            txbBusinnes.Text = $"Командировка до: {(absense.BusinessTripUntil.HasValue ? absense.BusinessTripUntil.Value.ToShortDateString() : "Отсутствует")}";
                        }
                        else
                        {
                            MessageBox.Show("У данного сотрудника отсуствуют отпуски/командировки");
                            txbBusinnes.Text = string.Empty;
                            txbVacantion.Text = string.Empty;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("У данного сотрудника отсуствуют отпуски/командировки");
                    }
                }
            }

        }
    }

}

