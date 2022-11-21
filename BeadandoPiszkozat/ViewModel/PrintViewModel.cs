using BeadandoPiszkozat.Model;
using BeadandoPiszkozat.View;
using BeadandoPiszkozat.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadandoPiszkozat.ViewModel
{
    class PrintViewModel : BaseViewModel
    {
        public CarsDTO SelectedCar { get; set; }
        public PrintViewModel()
        {
            LoadSelectedCar();
        }

        private void LoadSelectedCar()
        {
            
        }
    }
}
