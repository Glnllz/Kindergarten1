using Kindergarten1;
using Kindergarten1.DataBases;
using System.Windows;

namespace KindergartenWPF
{
    public partial class AddZanyatiyaWindow : Window
    {
        private DSADEntities _context;

        public AddZanyatiyaWindow(DSADEntities context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(txtIdDeti.Text) ||
                string.IsNullOrWhiteSpace(txtIdKrygok.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Пытаемся преобразовать ID ребенка и ID кружка в числа
            if (!int.TryParse(txtIdDeti.Text, out int idDeti) ||
                !int.TryParse(txtIdKrygok.Text, out int idKrygok))
            {
                MessageBox.Show("ID ребенка и ID кружка должны быть числами.");
                return;
            }

            // Создаем новый объект Zanyatiya
            var newZanyatiya = new Zanyatiya
            {
                Id_deti = idDeti,
                Id_krygok = idKrygok
            };

            // Добавляем объект в контекст базы данных
            _context.Zanyatiya.Add(newZanyatiya);

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            // Закрываем окно
            DialogResult = true;
            Close();
        }
    }
}