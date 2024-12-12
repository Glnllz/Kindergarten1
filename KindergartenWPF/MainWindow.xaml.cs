using Kindergarten1.DataBases;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KindergartenWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private data _db;
        public MainWindow()
        {
            InitializeComponent();
            _db = new data();
        }
    
        private void OnLoginButtonClick(object sender, RoutedEventArgs e)

        {
            string enteredPassword = passwordBox.Password;

            try
            {
                // Получаем пользователя из базы данных
                var user = data.GetUser().FirstOrDefault(u => u.login == "admin");

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }

                if (user.password == enteredPassword)
                {
                    MessageBox.Show("Вход выполнен успешно!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    AdminWindow mainAdminWindow = new AdminWindow();
                    mainAdminWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                    errorText.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            // Закрываем окно
            this.Close();
        }
    }
}
