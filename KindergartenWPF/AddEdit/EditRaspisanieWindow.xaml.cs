using Kindergarten1;
using Kindergarten1.DataBases;
using System;
using System.Windows;

namespace KindergartenWPF
{
    public partial class EditRaspisanieWindow : Window
    {
        public raspisanie CurrentRaspisanie { get; set; }

        public EditRaspisanieWindow(raspisanie raspisanie)
        {
            InitializeComponent();
            CurrentRaspisanie = raspisanie;
            DataContext = CurrentRaspisanie;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(txtDay.Text) ||
                string.IsNullOrWhiteSpace(txtTime.Text) ||
                string.IsNullOrWhiteSpace(txtIdKrygok.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Пытаемся преобразовать время и ID кружка в числа
            if (!TimeSpan.TryParse(txtTime.Text, out TimeSpan time) ||
                !int.TryParse(txtIdKrygok.Text, out int idKrygok))
            {
                MessageBox.Show("Время должно быть в формате hh:mm, а ID кружка должен быть числом.");
                return;
            }

            // Обновляем данные расписания
            CurrentRaspisanie.Day = txtDay.Text;
            CurrentRaspisanie.Time = time;
            CurrentRaspisanie.Id_krygok = idKrygok;

            // Закрываем окно с результатом "true"
            DialogResult = true;
            Close();
        }
    }
}