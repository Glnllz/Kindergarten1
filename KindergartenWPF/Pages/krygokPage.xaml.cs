﻿using Kindergarten1;
using Kindergarten1.DataBases;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KindergartenWPF.Pages
{
    public partial class krygokPage : Page
    {
        public krygokPage()
        {
            InitializeComponent();
            LoadData();
        }

        // Метод для загрузки данных в DataGrid
        private void LoadData()
        {
            var krygok = data.GetContext().krygok.AsQueryable();
            dataGrid.ItemsSource = krygok.ToList();
        }

        // Обработчик для кнопки "Добавить"
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Открываем окно добавления
            var addWindow = new AddKrygokWindow(data.GetContext());

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
            var selectedKrygok = dataGrid.SelectedItem as krygok;
            if (selectedKrygok == null)
            {
                MessageBox.Show("Выберите кружок для редактирования.");
                return;
            }

            // Открываем окно для редактирования выбранного объекта
            var editWindow = new EditKrygokWindow(selectedKrygok);

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
            var selectedKrygok = dataGrid.SelectedItem as krygok;
            if (selectedKrygok == null)
            {
                MessageBox.Show("Выберите кружок для удаления.");
                return;
            }

            // Подтверждение удаления
            if (MessageBox.Show("Вы действительно хотите удалить выбранный кружок?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Удаляем объект из базы данных
                data.GetContext().krygok.Remove(selectedKrygok);
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
                    dataGrid.ItemsSource = data.GetContext().krygok.OrderBy(k => k.Nazvanie).ToList(); // По названию (А-Я)
                    break;
                case "ZA":
                    dataGrid.ItemsSource = data.GetContext().krygok.OrderByDescending(k => k.Nazvanie).ToList(); // По названию (Я-А)
                    break;
                case "Asc":
                    dataGrid.ItemsSource = data.GetContext().krygok.OrderBy(k => k.kolvo_mest).ToList(); // По количеству мест (возрастание)
                    break;
                case "Desc":
                    dataGrid.ItemsSource = data.GetContext().krygok.OrderByDescending(k => k.kolvo_mest).ToList(); // По количеству мест (убывание)
                    break;
            }
        }
    }
}