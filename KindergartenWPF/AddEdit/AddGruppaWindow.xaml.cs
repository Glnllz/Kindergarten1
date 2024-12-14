using Kindergarten1;
using Kindergarten1.DataBases;
using System.Windows;

namespace KindergartenWPF
{
    public partial class AddGruppaWindow : Window
    {
        private DSADEntities _context;

        public AddGruppaWindow(DSADEntities context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtCount.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Пытаемся преобразовать возраст и количество детей в целые числа
            if (!int.TryParse(txtCount.Text, out int count))
            {
                MessageBox.Show("количество детей должно быть числом.");
                return;
            }

            // Создаем новый объект Gruppa
            var newGruppa = new Gryppa
            {
                Nazvanie = txtName.Text,
                kolvo = count
            };

            // Добавляем объект в контекст базы данных
            _context.Gryppa.Add(newGruppa);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Закрываем окно
            DialogResult = true;
            Close();
        }
    }
}