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
using System.Windows.Shapes;

namespace RoadsOfRussia.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmployeeCardWindow.xaml
    /// </summary>
    public partial class EmployeeCardWindow : Window
    {
        public int Id { get; set; }
        public EmployeeCardWindow()
        {
            InitializeComponent();
        }
        public EmployeeCardWindow(EmployeeModel employee, int id)
        {
            InitializeComponent();
            Id = id;
            fullName.Content = $"ФИО: {employee.Surname} {employee.Name} {employee.MiddleName}";
            structuralDivision.Content = $"Структурное подразделение: {employee.StructuralDivision}";
            jobTitle.Content = $"Должность: {employee.JobTitle}";
            director.Content = $"Руководитель: {employee.Director}";
            asisstantDirector.Content = $"Помощник руководителя: {employee.AsssistantDirector}";
            workPhone.Content = $"Рабочий телефон: {employee.WorkPhone}";
            cabinet.Content = $"Кабинет: {employee.Cabinet}";
            otherInformation.Text = employee.OtherInformation;
            txbPhone.Text = employee.Phone;
            dpDateOfBirth.Text = employee.DateOfBirth.ToString();
        }
        bool isEdit = false;
        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit == false)
            {
                btnEditEmployee.Content = "Отменить редактирование";
                btnSaveEmployee.Visibility = Visibility.Visible;
                txbPhone.IsEnabled = true;
                dpDateOfBirth.IsEnabled = true;
                isEdit = true;
            }
            else
            {

                btnEditEmployee.Content = "Редактировать";
                btnSaveEmployee.Visibility = Visibility.Collapsed;
                txbPhone.IsEnabled = false;
                dpDateOfBirth.IsEnabled = false;
                isEdit = false;
            }
        }

        private async void SaveEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (Id > 0)
            {
                using (var client = new HttpClient())
                {
                    var employee = new EmployeeRequest
                    {
                        Phone = txbPhone.Text,
                        DateOfBirth = dpDateOfBirth.SelectedDate.Value
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"https://localhost:44303/api/Employee/{Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        btnEditEmployee.Content = "Редактировать";
                        btnSaveEmployee.Visibility = Visibility.Collapsed;
                        txbPhone.IsEnabled = false;
                        dpDateOfBirth.IsEnabled = false;
                        isEdit = false;
                        MessageBox.Show("Изменения сохранены");
                    }
                }
            }
        }
    }
}
