using Kindergarten1;
using Kindergarten1.DataBases;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KindergartenWPF.Pages
{
    public partial class RaspisaniePage : Page
    {
        public RaspisaniePage()
        {
            InitializeComponent();
            LoadData();
        }

        // Метод для загрузки данных в DataGrid
        private void LoadData()
        {
            ApplyFilter();
        }

        // Обработчик для кнопки "Добавить"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно добавления
            var addWindow = new AddRaspisanieWindow(data.GetContext());

            // Если окно закрылось с результатом "true", обновляем DataGrid
            if (addWindow.ShowDialog() == true)
            {
                ApplyFilter();
            }
        }

        // Обработчик для кнопки "Редактировать"
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный объект из DataGrid
            var selectedRaspisanie = dataGrid.SelectedItem as raspisanie;
            if (selectedRaspisanie == null)
            {
                MessageBox.Show("Выберите расписание для редактирования.");
                return;
            }

            // Открываем окно для редактирования выбранного объекта
            var editWindow = new EditRaspisanieWindow(selectedRaspisanie);

            // Если окно закрылось с результатом "true", обновляем DataGrid
            if (editWindow.ShowDialog() == true)
            {
                ApplyFilter();
            }
        }

        // Обработчик для кнопки "Удалить"
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный объект из DataGrid
            var selectedRaspisanie = dataGrid.SelectedItem as raspisanie;
            if (selectedRaspisanie == null)
            {
                MessageBox.Show("Выберите расписание для удаления.");
                return;
            }

            // Подтверждение удаления
            if (MessageBox.Show("Вы действительно хотите удалить выбранное расписание?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Удаляем объект из базы данных
                data.GetContext().raspisanie.Remove(selectedRaspisanie);
                data.GetContext().SaveChanges();

                // Обновляем DataGrid
                ApplyFilter();
            }
        }

        // Обработчик для выбора сортировки в ComboBox
        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        // Обработчик для изменения выбора поля фильтрации
        private void cbFilterField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        // Обработчик для изменения текста фильтра
        private void tbFilterValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        // Метод для применения фильтра
        private void ApplyFilter()
        {
            var filterField = (cbFilterField.SelectedItem as ComboBoxItem)?.Tag.ToString();
            var filterValue = tbFilterValue.Text.Trim().ToLower();

            var raspisanie = data.GetContext().raspisanie.AsQueryable();

            // Фильтрация по выбранному полю
            if (!string.IsNullOrEmpty(filterValue))
            {
                switch (filterField)
                {
                    case "Day":
                        raspisanie = raspisanie.Where(r => r.Day.ToLower().Contains(filterValue));
                        break;
                    case "Time":
                        raspisanie = raspisanie.Where(r => r.Time.ToString().ToLower().Contains(filterValue));
                        break;
                    case "Id_krygok":
                        if (int.TryParse(filterValue, out int idKrugok))
                        {
                            raspisanie = raspisanie.Where(r => r.Id_krygok == idKrugok);
                        }
                        break;
                }
            }

            // Применение сортировки
            var selectedItem = cbSort.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                var sortType = selectedItem.Tag.ToString();
                switch (sortType)
                {
                    case "AZ":
                        raspisanie = raspisanie.OrderBy(r => r.Day);
                        break;
                    case "ZA":
                        raspisanie = raspisanie.OrderByDescending(r => r.Day);
                        break;
                    case "Early":
                        raspisanie = raspisanie.OrderBy(r => r.Time);
                        break;
                    case "Late":
                        raspisanie = raspisanie.OrderByDescending(r => r.Time);
                        break;
                }
            }

            // Обновление DataGrid
            dataGrid.ItemsSource = raspisanie.ToList();
        }
    }
}