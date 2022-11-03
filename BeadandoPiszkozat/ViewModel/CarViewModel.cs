using BeadandoPiszkozat.Model;
using BeadandoPiszkozat.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadandoPiszkozat.ViewModel
{
	public class CarViewModel : BaseViewModel
	{
		public ObservableCollection<CarsDTO> Cars { get; set; }
		public CarsDTO CurrentCar { get; set; }

		private CarService CarService;
		public CarViewModel()
		{
			CarService = new CarService();
			LoadCars();
			CurrentCar = new CarsDTO();
		}

		private void LoadCars()
		{
			Cars = new ObservableCollection<CarsDTO>(CarService.getAll());
		}
	}
}
