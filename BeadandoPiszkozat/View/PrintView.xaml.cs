using BeadandoPiszkozat.Model;
using BeadandoPiszkozat.ViewModel;
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
using System.Windows.Shapes;

namespace BeadandoPiszkozat.View
{
    public partial class PrintView : Window
    {
        PrintViewModel _printViewModel;
        public string model;
        public PrintView(CarsDTO SelectedCar)
        {
            InitializeComponent();
            _printViewModel = new PrintViewModel();
            DataContext = _printViewModel;
            txtBxTitle.Text = SelectedCar.Brand + "|" + SelectedCar.Fuel + "|" + SelectedCar.MaxPassenger;
        }
    }
}
