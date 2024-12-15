using Kindergarten1;
using Kindergarten1.DataBases;
using System.Windows;

namespace KindergartenWPF
{
    public partial class EditZanyatiyaWindow : Window
    {
        public Zanyatiya CurrentZanyatiya { get; set; }

        public EditZanyatiyaWindow(Zanyatiya zanyatiya)
        {
            InitializeComponent();
            CurrentZanyatiya = zanyatiya;
            DataContext = CurrentZanyatiya;
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

            // Обновляем данные занятия
            CurrentZanyatiya.Id_deti = idDeti;
            CurrentZanyatiya.Id_krygok = idKrygok;

            // Закрываем окно с результатом "true"
            DialogResult = true;
            Close();
        }
    }
}