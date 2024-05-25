using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text;
using RoadsOfRussia.Views.Pages;
using System.Windows;
using System.Windows.Threading;
using System;

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

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(30); // Интервал 30 секунд
            _timer.Tick += SendNotifiDateOfBirth; // Подписка на событие Tick
            _timer.Start(); // Запуск таймера

            mainFrame.Navigate(new EmployeeDirectory());
            
        }

        private void SendNotifiDateOfBirth(object sender, EventArgs e)
        {
        }

        private void pageEmployee_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new EmployeeDirectory());
        }

        private void ResumeSelection_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new ResumeSelectionPage());
        }

        private void AbsenceSelection_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new TemporaryAbsencePage());
        }

        private void CalendarTraining_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(new EmployeeEventsCalendarPage());
        }
    }
}
