using Kindergarten1;
using Kindergarten1.DataBases;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KindergartenWPF.Pages
{
    public partial class GryppaPage : Page
    {
        public GryppaPage()
        {
            InitializeComponent();
            LoadData();
        }

        // Метод для загрузки данных в DataGrid
        private void LoadData()
        {
            var groups = data.GetContext().Gryppa.AsQueryable();
            dataGrid.ItemsSource = groups.ToList();
        }

        // Обработчик для кнопки "Добавить"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно добавления
            var addWindow = new AddGruppaWindow(data.GetContext());

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
            var selectedGryppa = dataGrid.SelectedItem as Gryppa;
            if (selectedGryppa == null)
            {
                MessageBox.Show("Выберите группу для редактирования.");
                return;
            }

            // Открываем окно для редактирования выбранного объекта
            OpenEditWindow(selectedGryppa);
        }

        // Обработчик для кнопки "Удалить"
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный объект из DataGrid
            var selectedGruppa = dataGrid.SelectedItem as Gryppa;
            if (selectedGruppa == null)
            {
                MessageBox.Show("Выберите группу для удаления.");
                return;
            }

            // Подтверждение удаления
            if (MessageBox.Show("Вы действительно хотите удалить выбранную группу?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Удаляем объект из базы данных
                data.GetContext().Gryppa.Remove(selectedGruppa);
                data.GetContext().SaveChanges();

                // Обновляем DataGrid
                LoadData();
            }
        }

        // Метод для открытия окна редактирования
        private void OpenEditWindow(Gryppa gruppa)
        {
            // Создаем окно редактирования (например, EditGruppaWindow)
            var editWindow = new EditGruppaWindow(gruppa);

            // Показываем окно и обновляем DataGrid после закрытия
            if (editWindow.ShowDialog() == true)
            {
                data.GetContext().SaveChanges();
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
                    dataGrid.ItemsSource = data.GetContext().Gryppa.OrderBy(g => g.Nazvanie).ToList(); // По названию (А-Я)
                    break;
                case "ZA":
                    dataGrid.ItemsSource = data.GetContext().Gryppa.OrderByDescending(g => g.Nazvanie).ToList(); // По названию (Я-А)
                    break;
                case "Asc":
                    dataGrid.ItemsSource = data.GetContext().Gryppa.OrderBy(g => g.kolvo).ToList(); // По количеству детей (возрастание)
                    break;
                case "Desc":
                    dataGrid.ItemsSource = data.GetContext().Gryppa.OrderByDescending(g => g.kolvo).ToList(); // По количеству детей (убывание)
                    break;
            }
        }
    }
}