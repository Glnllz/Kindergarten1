using Kindergarten1;
using Kindergarten1.DataBases;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KindergartenWPF.Pages
{
    public partial class MeropriyatiePage : Page
    {
        public MeropriyatiePage()
        {
            InitializeComponent();
            LoadData();
        }

        // Метод для загрузки данных в DataGrid
        private void LoadData()
        {
            var meropriyatie = data.GetContext().meropriyatie.AsQueryable();
            dataGrid.ItemsSource = meropriyatie.ToList();
        }

        // Обработчик для кнопки "Добавить"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно добавления
            var addWindow = new AddMeropriyatieWindow(data.GetContext());

            // Если окно закрылось с результатом "true", обновляем DataGrid
            if (addWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }

        // Обработчик для кнопки "Редактировать"
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный объект из DataGrid
            var selectedMeropriyatie = dataGrid.SelectedItem as meropriyatie;
            if (selectedMeropriyatie == null)
            {
                MessageBox.Show("Выберите мероприятие для редактирования.");
                return;
            }

            // Открываем окно для редактирования выбранного объекта
            var editWindow = new EditMeropriyatieWindow(selectedMeropriyatie);

            // Если окно закрылось с результатом "true", обновляем DataGrid
            if (editWindow.ShowDialog() == true)
            {
                LoadData();
            }
        }

        // Обработчик для кнопки "Удалить"
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный объект из DataGrid
            var selectedMeropriyatie = dataGrid.SelectedItem as meropriyatie;
            if (selectedMeropriyatie == null)
            {
                MessageBox.Show("Выберите мероприятие для удаления.");
                return;
            }

            // Подтверждение удаления
            if (MessageBox.Show("Вы действительно хотите удалить выбранное мероприятие?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Удаляем объект из базы данных
                data.GetContext().meropriyatie.Remove(selectedMeropriyatie);
                data.GetContext().SaveChanges();

                // Обновляем DataGrid
                LoadData();
            }
        }
    }
}