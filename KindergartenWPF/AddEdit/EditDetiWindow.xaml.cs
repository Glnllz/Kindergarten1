using Kindergarten1;
using Kindergarten1.DataBases;
using System.Windows;

namespace KindergartenWPF
{
    public partial class EditDetiWindow : Window
    {
        public Deti CurrentDeti { get; set; }

        public EditDetiWindow(Deti deti)
        {
            InitializeComponent();
            CurrentDeti = deti;
            DataContext = CurrentDeti;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Сохраняем изменения
            DialogResult = true;
            Close();
        }
    }
}