using RoadsOfRussia.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для TrainingCardWindow.xaml
    /// </summary>
    public partial class TrainingCardWindow : Window
    {
        public string Email {  get; set; }
        public string Name {  get; set; }
        EmployeeModel employeyModel {  get; set; }
        public TrainingCardWindow(EventModel eventModel, bool isActive = false, string email = "", string name = null)
        {
            InitializeComponent();
            Name = name;
            Email = email;
            txbNameEvent.Text = $"Название мероприятия: {eventModel.NameEvent}";
            txbTypeEvent.Text = $"Тип мероприятия: {eventModel.TypeEvent}";
            txbStatusEvent.Text = $"Статус мероприятия: {eventModel.StatusEvent}";
            txbDateStartEvent.Text = $"Дата начала мероприятия: {eventModel.DateTimeEvent.ToString()}";
            txbDescEvent.Text = $"Описание мероприятия: {eventModel.Description}";
            if(isActive )
            {
                btnSubscribeDateOfBirth.Visibility = Visibility.Visible;
            }
        }

        private async void btnSubscribeDateOfBirth_Click(object sender, RoutedEventArgs e)
        {
            await NotifyViewModel.SendEmailAsync(Email, "День рождения", $"Сегодня у {Name} День рождения. Незабудьте его поздравить");
            btnSubscribeDateOfBirth.Visibility = Visibility.Collapsed;
        }
    }
}
