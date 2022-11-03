using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadandoPiszkozat.Model
{
	public class CarService
	{
		private ProbaLoginDBEntities _probaLoginDBEntities;
		public CarService()
		{
			_probaLoginDBEntities = new ProbaLoginDBEntities();
		}

		public List<CarsDTO> getAll()
		{
			List<CarsDTO> carsDTOs = new List<CarsDTO>();

			try
			{
				var cars = from car in _probaLoginDBEntities.Cars
						   select car;

				foreach (var item in cars)
					carsDTOs.Add(new CarsDTO
					{
						Id = item.ID,
						Brand = item.Brand,
						Model = item.Model,
						Fuel = item.Fuel,
						MaxPassenger = item.MaxPassenger,
						NumberOfDoors = item.NumberOfDoors,
						AvailableType = item.AvailableType,
						Price = item.Price
					});
			}
			catch (Exception ex)
			{

				throw ex;
			}

			return carsDTOs;

		}
	}
}
