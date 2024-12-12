using Kindergarten1.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace KindergartenWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для DetiPage.xaml
    /// </summary>
    public partial class DetiPage : Page
    {
        public DetiPage()
        {
            InitializeComponent();
            var deti = data.GetContext().Deti.AsQueryable();
            dataGrid.ItemsSource = deti.ToList();
        }
    }
}
