using BeadandoPiszkozat.ViewModel;
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
		private int _lastId;

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

		void lastId()
		{

			using (var db = new ProbaLoginDBEntities())
			{
				var querry = from n in db.Cars
							 where n.ID >= 0
							 select n;

				foreach (var item in querry)
				{
					_lastId = item.ID;
				}
				
			}
		}

		public bool add(CarsDTO newCar)
		{
			lastId();
			bool isAdded = false;
			try
			{
				var car = new Cars();
				car.ID = _lastId + 1;
				car.Brand = newCar.Brand;
				car.Model = newCar.Model;
				car.Fuel = newCar.Fuel;
				car.MaxPassenger = newCar.MaxPassenger;
				car.NumberOfDoors = newCar.NumberOfDoors;
				car.AvailableType = newCar.AvailableType;
				car.Price = newCar.Price;

				_probaLoginDBEntities.Cars.Add(car);
				var numberOfRowsAffected = _probaLoginDBEntities.SaveChanges();
				isAdded = numberOfRowsAffected > 0;

			}
			catch (Exception ex)
			{

				throw ex;
			}
			return isAdded;
		}

		public bool update(CarsDTO carUpdate)
		{
			bool isUpdated = false;
			try
			{
				var car = _probaLoginDBEntities.Cars.Find(carUpdate.Id);
				car.Brand = carUpdate.Brand;
				car.Model = carUpdate.Model;
				car.Fuel = carUpdate.Fuel;
				car.MaxPassenger = carUpdate.MaxPassenger;
				car.NumberOfDoors = carUpdate.NumberOfDoors;
				car.AvailableType = carUpdate.AvailableType;
				car.Price = carUpdate.Price;
				var numberOfRowsAffected = _probaLoginDBEntities.SaveChanges();
				isUpdated = numberOfRowsAffected > 0;

			}
			catch (Exception ex)
			{

				throw ex;
			}

			return isUpdated;
		}

		public bool delete(int id)
		{
			bool isDeleted = false;
			try
			{
				var car = _probaLoginDBEntities.Cars.Find(id);
				_probaLoginDBEntities.Cars.Remove(car);
				var numberOfRowsAffected = _probaLoginDBEntities.SaveChanges();
				isDeleted = numberOfRowsAffected > 0;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return isDeleted;
		}
		
	}
}
