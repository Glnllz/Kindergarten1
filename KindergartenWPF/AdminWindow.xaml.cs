using Kindergarten1.DataBases;
using KindergartenWPF.Pages;
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

namespace KindergartenWPF
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        
        private void btnDeti_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DetiPage());
        }

        private void btnZanyatiya_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ZanyatiyaPage());
        }

        private void btnGruppa_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GryppaPage());
        }

        private void btnKruzhok_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new krygokPage());
        }

        private void btnMeropriyatie_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MeropriyatiePage());
        }

        private void btnRaspisanie_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RaspisaniePage());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
    }
}

