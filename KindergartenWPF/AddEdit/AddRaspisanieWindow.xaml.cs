using Kindergarten1;
using Kindergarten1.DataBases;
using System;
using System.Windows;

namespace KindergartenWPF
{
    public partial class AddRaspisanieWindow : Window
    {
        private DSADEntities _context;

        public AddRaspisanieWindow(DSADEntities context)
        {
            InitializeComponent();
            _context = context;
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
                MessageBox.Show("Время должно быть в формате HH:mm, а ID кружка должен быть числом.");
                return;
            }

            // Создаем новый объект raspisanie
            var newRaspisanie = new raspisanie
            {
                Day = txtDay.Text,
                Time = time,
                Id_krygok = idKrygok
            };

            // Добавляем объект в контекст базы данных
            _context.raspisanie.Add(newRaspisanie);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Закрываем окно
            DialogResult = true;
            Close();
        }
    }
}