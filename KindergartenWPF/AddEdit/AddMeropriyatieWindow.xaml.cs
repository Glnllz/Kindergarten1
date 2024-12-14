using Kindergarten1;
using Kindergarten1.DataBases;
using System;
using System.Windows;

namespace KindergartenWPF
{
    public partial class AddMeropriyatieWindow : Window
    {
        private DSADEntities _context;

        public AddMeropriyatieWindow(DSADEntities context)
        {
            InitializeComponent();
            _context = context;
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

            // Создаем новый объект meropriyatie
            var newMeropriyatie = new meropriyatie
            {
                Nazvanie = txtNazvanie.Text,
                Date = dpDate.SelectedDate.Value,
                price = price,
                Id_krygok = idKrygok
            };

            // Добавляем объект в контекст базы данных
            _context.meropriyatie.Add(newMeropriyatie);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Закрываем окно
            DialogResult = true;
            Close();
        }
    }
}