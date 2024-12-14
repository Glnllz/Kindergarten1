using Kindergarten1;
using Kindergarten1.DataBases;
using System.Windows;

namespace KindergartenWPF
{
    public partial class EditGruppaWindow : Window
    {
        // Текущая редактируемая группа
        public Gryppa CurrentGruppa { get; set; }

        public EditGruppaWindow(Gryppa gruppa)
        {
            InitializeComponent();

            // Устанавливаем текущую группу и привязываем данные
            CurrentGruppa = gruppa;
            DataContext = CurrentGruppa;
        }

        // Обработчик кнопки "Сохранить"
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
            if ( !int.TryParse(txtCount.Text, out int count))
            {
                MessageBox.Show("количество детей должно быть числом.");
                return;
            }

            // Обновляем данные группы
            CurrentGruppa.Nazvanie = txtName.Text;
            CurrentGruppa.kolvo = count; // Используем переменную count

            // Закрываем окно с результатом "true"
            DialogResult = true;
            Close();
        }
    }
}