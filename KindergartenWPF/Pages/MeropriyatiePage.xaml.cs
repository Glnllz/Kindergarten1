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
    /// Логика взаимодействия для MeropriyatiePage.xaml
    /// </summary>
    public partial class MeropriyatiePage : Page
    {
        public MeropriyatiePage()
        {
            InitializeComponent();
            var Meropriyatie = data.GetContext().meropriyatie.AsQueryable();
            dataGrid.ItemsSource = Meropriyatie.ToList();
        }
    }
}
