using Kindergarten1;
using Kindergarten1.DataBases;
using System;
using System.Windows;

namespace KindergartenWPF
{
    public partial class EditMeropriyatieWindow : Window
    {
        public meropriyatie CurrentMeropriyatie { get; set; }

        public EditMeropriyatieWindow(meropriyatie meropriyatie)
        {
            InitializeComponent();
            CurrentMeropriyatie = meropriyatie;
            DataContext = CurrentMeropriyatie;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(txtNazvanie.Text) ||
                dpDate.SelectedDate == null ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtIdKrygok.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Пытаемся преобразовать цену и ID кружка в числа
            if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                !int.TryParse(txtIdKrygok.Text, out int idKrygok))
            {
                MessageBox.Show("Цена и ID кружка должны быть числами.");
                return;
            }

            // Обновляем данные мероприятия
            CurrentMeropriyatie.Nazvanie = txtNazvanie.Text;
            CurrentMeropriyatie.Date = dpDate.SelectedDate.Value;
            CurrentMeropriyatie.price = price;
            CurrentMeropriyatie.Id_krygok = idKrygok;

            // Закрываем окно с результатом "true"
            DialogResult = true;
            Close();
        }
    }
}