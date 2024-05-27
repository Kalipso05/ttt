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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txbLogin.Text != "" && txbPass.Text != "")
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:44303/api/Employee");
                    var content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<EmployeeModel>>(content);

                    var user = data.Where(p => p.Login == txbLogin.Text).FirstOrDefault();

                    if (user != null)
                    {
                        if (user.Password == txbPass.Text)
                        {
                            var win = new MainWindow();
                            win.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Пароль неверный!");
                        }

                    }
                    else
                        MessageBox.Show("Пользователь ненайден!");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
