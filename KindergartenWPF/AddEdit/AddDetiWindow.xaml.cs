using Kindergarten1;
using Kindergarten1.DataBases;
using System.Windows;

namespace KindergartenWPF
{
    public partial class AddDetiWindow : Window
    {
        // Ссылка на контекст базы данных
        private DSADEntities _context;

        public AddDetiWindow(DSADEntities context)
        {
            InitializeComponent();
            _context = context;
        }

        // Обработчик кнопки "Сохранить"
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что введенные данные корректны
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtGroup.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Пытаемся преобразовать Id_gruppa в целое число
            if (!int.TryParse(txtGroup.Text, out int groupId))
            {
                MessageBox.Show("Поле 'Группа' должно быть числом.");
                return;
            }

            // Создаем новый объект Deti
            var newDeti = new Deti
            {
                FName = txtFName.Text,
                LName = txtLName.Text,
                Phone_roditelya = txtPhone.Text,
                Id_gruppa = groupId // Используем преобразованное целое число
            };

            // Добавляем объект в контекст базы данных
            _context.Deti.Add(newDeti);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Закрываем окно
            DialogResult = true;
            Close();
        }
    }
}