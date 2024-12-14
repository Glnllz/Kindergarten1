using Kindergarten1;
using Kindergarten1.DataBases;
using System.Windows;

namespace KindergartenWPF
{
    public partial class AddKrygokWindow : Window
    {
        private DSADEntities _context;

        public AddKrygokWindow(DSADEntities context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(txtNazvanie.Text) ||
                string.IsNullOrWhiteSpace(txtKolvoMest.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Пытаемся преобразовать количество мест в целое число
            if (!int.TryParse(txtKolvoMest.Text, out int kolvoMest))
            {
                MessageBox.Show("Количество мест должно быть числом.");
                return;
            }

            // Создаем новый объект krygok
            var newKrygok = new krygok
            {
                Nazvanie = txtNazvanie.Text,
                kolvo_mest = kolvoMest
            };

            // Добавляем объект в контекст базы данных
            _context.krygok.Add(newKrygok);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Закрываем окно
            DialogResult = true;
            Close();
        }
    }
}