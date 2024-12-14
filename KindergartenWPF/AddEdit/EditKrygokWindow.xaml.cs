using Kindergarten1;
using Kindergarten1.DataBases;
using System.Windows;

namespace KindergartenWPF
{
    public partial class EditKrygokWindow : Window
    {
        public krygok CurrentKrygok { get; set; }

        public EditKrygokWindow(krygok krygok)
        {
            InitializeComponent();
            CurrentKrygok = krygok;
            DataContext = CurrentKrygok;
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

            // Обновляем данные кружка
            CurrentKrygok.Nazvanie = txtNazvanie.Text;
            CurrentKrygok.kolvo_mest = kolvoMest;

            // Закрываем окно с результатом "true"
            DialogResult = true;
            Close();
        }
    }
}