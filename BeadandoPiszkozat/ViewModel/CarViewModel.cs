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
		public string Message { get; set; }
		public RelayCommand SaveCommand { get; }
		public RelayCommand UpdateCommand { get; }
		public RelayCommand DeleteCommand { get; }
		public RelayCommand PrintCommand { get;  }
		public CarViewModel()
		{
			CarService = new CarService();
			LoadCars();
			CurrentCar = new CarsDTO();
			SaveCommand = new RelayCommand(save);
			UpdateCommand = new RelayCommand(update);
			DeleteCommand = new RelayCommand(delete);
		}

		private void LoadCars()
		{
			Cars = new ObservableCollection<CarsDTO>(CarService.getAll());
		}

		private void save()
		{
			try
			{
				bool isSaved = CarService.add(CurrentCar);
				LoadCars();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}


		private void update()
		{
			try
			{
				var isUpdated = CarService.update(CurrentCar);
				LoadCars();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		private void delete()
		{
			try
			{
				var isDeleted = CarService.delete(CurrentCar.Id);
				LoadCars();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
