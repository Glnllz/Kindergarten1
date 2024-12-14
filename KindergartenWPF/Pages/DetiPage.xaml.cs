using Kindergarten1;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KindergartenWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для DetiPage.xaml
    /// </summary>
    public partial class DetiPage : Page
    {
        public DetiPage()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            var deti = data.GetContext().Deti.AsQueryable();
            dataGrid.ItemsSource = deti.ToList();
        }

        // Обработчик для кнопки "Добавить"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Создаем новый объект Deti
            var newDeti = new Deti();

            // Открываем окно для редактирования нового объекта
            OpenEditWindow(newDeti);
        }

        // Обработчик для кнопки "Редактировать"
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный объект из DataGrid
            var selectedDeti = dataGrid.SelectedItem as Deti;
            if (selectedDeti == null)
            {
                MessageBox.Show("Выберите ребенка для редактирования.");
                return;
            }

            // Открываем окно для редактирования выбранного объекта
            OpenEditWindow(selectedDeti);
        }

        // Обработчик для кнопки "Удалить"
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный объект из DataGrid
            var selectedDeti = dataGrid.SelectedItem as Deti;
            if (selectedDeti == null)
            {
                MessageBox.Show("Выберите ребенка для удаления.");
                return;
            }

            // Подтверждение удаления
            if (MessageBox.Show("Вы действительно хотите удалить выбранного ребенка?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Удаляем объект из базы данных
                data.GetContext().Deti.Remove(selectedDeti);
                data.GetContext().SaveChanges();

                // Обновляем DataGrid
                LoadData();
            }
        }

        // Метод для открытия окна редактирования
        private void OpenEditWindow(Deti deti)
        {
            // Создаем окно редактирования (например, EditDetiWindow)
            //var editWindow = new EditDetiWindow(deti);

            //// Показываем окно и обновляем DataGrid после закрытия
            //if (editWindow.ShowDialog() == true)
            //{
            //    data.GetContext().SaveChanges();
            //    LoadData();
            //}
        }
    }
}
