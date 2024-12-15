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

        // Обработчик для выбора сортировки в ComboBox
        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = cbSort.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;

            var sortType = selectedItem.Tag.ToString();

            switch (sortType)
            {
                case "None":
                    LoadData(); // Без сортировки
                    break;
                case "AZ":
                    dataGrid.ItemsSource = data.GetContext().meropriyatie.OrderBy(m => m.Nazvanie).ToList(); // По названию (А-Я)
                    break;
                case "ZA":
                    dataGrid.ItemsSource = data.GetContext().meropriyatie.OrderByDescending(m => m.Nazvanie).ToList(); // По названию (Я-А)
                    break;
                case "Oldest":
                    dataGrid.ItemsSource = data.GetContext().meropriyatie.OrderBy(m => m.Date).ToList(); // По дате (сначала старые)
                    break;
                case "Newest":
                    dataGrid.ItemsSource = data.GetContext().meropriyatie.OrderByDescending(m => m.Date).ToList(); // По дате (сначала новые)
                    break;
                case "Asc":
                    dataGrid.ItemsSource = data.GetContext().meropriyatie.OrderBy(m => m.price).ToList(); // По цене (возрастание)
                    break;
                case "Desc":
                    dataGrid.ItemsSource = data.GetContext().meropriyatie.OrderByDescending(m => m.price).ToList(); // По цене (убывание)
                    break;
            }
        }
    }
}