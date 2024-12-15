using Kindergarten1;
using Kindergarten1.DataBases;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KindergartenWPF.Pages
{
    public partial class ZanyatiyaPage : Page
    {
        public ZanyatiyaPage()
        {
            InitializeComponent();
            LoadData();
        }

        // Метод для загрузки данных в DataGrid
        private void LoadData()
        {
            var zanyatiya = data.GetContext().Zanyatiya.AsQueryable();
            dataGrid.ItemsSource = zanyatiya.ToList();
        }

        // Обработчик для кнопки "Добавить"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно добавления
            var addWindow = new AddZanyatiyaWindow(data.GetContext());

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
            var selectedZanyatiya = dataGrid.SelectedItem as Zanyatiya;
            if (selectedZanyatiya == null)
            {
                MessageBox.Show("Выберите занятие для редактирования.");
                return;
            }

            // Открываем окно для редактирования выбранного объекта
            var editWindow = new EditZanyatiyaWindow(selectedZanyatiya);

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
            var selectedZanyatiya = dataGrid.SelectedItem as Zanyatiya;
            if (selectedZanyatiya == null)
            {
                MessageBox.Show("Выберите занятие для удаления.");
                return;
            }

            // Подтверждение удаления
            if (MessageBox.Show("Вы действительно хотите удалить выбранное занятие?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Удаляем объект из базы данных
                data.GetContext().Zanyatiya.Remove(selectedZanyatiya);
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

            var zanyatiya = data.GetContext().Zanyatiya.AsQueryable();

            switch (sortType)
            {
                case "None":
                    dataGrid.ItemsSource = zanyatiya.ToList(); // Без сортировки
                    break;
                case "AscDeti":
                    dataGrid.ItemsSource = zanyatiya.OrderBy(z => z.Id_deti).ToList(); // По ID Ребенка (возрастание)
                    break;
                case "DescDeti":
                    dataGrid.ItemsSource = zanyatiya.OrderByDescending(z => z.Id_deti).ToList(); // По ID Ребенка (убывание)
                    break;
                case "AscKrygok":
                    dataGrid.ItemsSource = zanyatiya.OrderBy(z => z.Id_krygok).ToList(); // По ID Кружка (возрастание)
                    break;
                case "DescKrygok":
                    dataGrid.ItemsSource = zanyatiya.OrderByDescending(z => z.Id_krygok).ToList(); // По ID Кружка (убывание)
                    break;
            }
        }
    }
}