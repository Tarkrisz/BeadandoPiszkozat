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

        public int IdofCars
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string Fuel
        {
            get { return _fuel; }
            set { _fuel = value; }
        }
        public string MaxPassenger
        {
            get { return _maxPassenger; }
            set { _maxPassenger = value; }
        }
        public string NumberOfDoors
        {
            get { return _numberOfDoors; }
            set { _numberOfDoors = value; }
        }
        public string AvailableType
        {
            get { return _availableType; }
            set { _availableType = value; }
        }
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public ObservableCollection<CarsDTO> Cars { get; set; }

        public CarsDTO CurrentCar { get; set; }

        public ObservableCollection<CarsDTO> Selected_Row { get; set; } //Viewban selected row a datagridből

        private CarService CarService;
        public string Message { get; set; }
        public RelayCommand SaveCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SearchCommand { get; }
        public CarViewModel()
        {
            CarService = new CarService();
            LoadCars();
            CurrentCar = new CarsDTO();
            SaveCommand = new RelayCommand(save);
            UpdateCommand = new RelayCommand(update);
            DeleteCommand = new RelayCommand(delete);
            SearchCommand = new RelayCommand(search);
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

        private void search()
        {
            try
            {
                CarsDTO cars = CarService.search(CurrentCar.Id);
                if (cars != null)
                {
                    CurrentCar.Brand = cars.Brand;
                    CurrentCar.Model = cars.Model;
                    CurrentCar.Fuel = cars.Fuel;
                    CurrentCar.MaxPassenger = cars.MaxPassenger;
                    CurrentCar.NumberOfDoors = cars.NumberOfDoors;
                    CurrentCar.AvailableType = cars.AvailableType;
                    CurrentCar.Price = cars.Price;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
