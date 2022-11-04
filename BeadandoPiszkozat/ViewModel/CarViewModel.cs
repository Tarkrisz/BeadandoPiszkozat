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
		int _id;
		string _brand;
		string _model;
		string _fuel;
		string _maxPassenger;
		string _numberOfDoors;
		string _availableType;
		string _price;
		public int IdofCars {
			get { return _id; }
			set { _id = value; }
		}
		public string Brand {
			get { return _brand; }
			set { _brand = value; }
		}
		public string Model {
			get { return _model; }
			set { _model = value; }
		}
		public string Fuel {
			get { return _fuel; }
			set { _fuel = value; }
		}
		public string MaxPassenger {
			get { return _maxPassenger; }
			set { _maxPassenger = value; }
		}
		public string NumberOfDoors {
			get { return _numberOfDoors; }
			set { _numberOfDoors = value; }
		}
		public string AvailableType {
			get { return _availableType; }
			set { _availableType = value; }
		}
		public string Price {
			get { return _price; }
			set { _price = value; }
		}
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
