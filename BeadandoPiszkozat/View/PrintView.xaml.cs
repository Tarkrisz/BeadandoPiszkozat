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
            if (SelectedCar.AvailableType == "Eladó")
            {
                txtBxTitle.Text = "Eladási szerződés";

                txtBxData_Car.Text = $"1. Jármű adatai:\n" + 
                    $"Típus: {SelectedCar.Brand}\n" + 
                    $"Model: {SelectedCar.Model}\n" + 
                    $"Szállítható személyek száma: {SelectedCar.MaxPassenger}\n" + 
                    $"Ajtók száma: {SelectedCar.NumberOfDoors}\n" + 
                    $"Ár: {SelectedCar.Price}\n";

                txtBxData_Person.Text = $"2. Vevő adatai:\n" + 
                    $"Név:\n" + 
                    $"Születési hely, idő:\n" + 
                    $"Anyja neve:\n" + 
                    $"Lakcíme:\n" + 
                    $"Állampolgársága:\n";
            }
            else if (SelectedCar.AvailableType == "Kölcsönözhető")
            {
                txtBxTitle.Text = "Kölcsönzési szerződés";

                txtBxData_Car.Text = $"1. Jármű adatai:\n" +
                    $"Típus: {SelectedCar.Brand}\n" +
                    $"Model: {SelectedCar.Model}\n" +
                    $"Szállítható személyek száma: {SelectedCar.MaxPassenger}\n" +
                    $"Ajtók száma: {SelectedCar.NumberOfDoors}\n" +
                    $"Ár: {SelectedCar.Price}\n";

                txtBxData_Person.Text = $"2. Kölcsönző adatai:\n" +
                    $"Név:\n" +
                    $"Születési hely, idő:\n" +
                    $"Anyja neve:\n" +
                    $"Lakcíme:\n" +
                    $"Állampolgársága:\n" +
                    $"Kölcsönzési idő:\n";
            }
            else
            {
                txtBxData_Car.Text = "Error. Not recognized type.";
                txtBxData_Person.Text = "";
            }
        }
    }
}
