using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadandoPiszkozat.Model
{
	public class EmployeeService
	{

		private ProbaLoginDBEntities _probaLoginDBEntities;
		private int _lastId;
		public EmployeeService()
		{
			_probaLoginDBEntities = new ProbaLoginDBEntities();
		}
		public List<EmployeeDTO> getAll()
		{
			List<EmployeeDTO> employeeDTO = new List<EmployeeDTO>();

			try
			{
				var cars = from car in _probaLoginDBEntities.Employee
						   select car;

				foreach (var item in cars)
					employeeDTO.Add(new EmployeeDTO
					{
						ID = item.ID,
						FirstName = item.FirstName,
						LastName = item.LastName,
						DateOfBirht = item.DateOfBirht,
						Gender = item.Gender,
						Position = item.Position,
						Salary= item.Salary,
						CityOfWork = item.CityOfWork
					});
			}
			catch (Exception ex)
			{

				throw ex;
			}

			return employeeDTO;

		}

		void lastId()
		{

			using (var db = new ProbaLoginDBEntities())
			{
				var querry = from n in db.Employee
							 where n.ID >= 0
							 select n;

				foreach (var item in querry)
				{
					_lastId = item.ID;
				}

			}
		}

		public bool addEmployee(EmployeeDTO newEmployee)
		{

			lastId();
			bool isAdded = false;
			try
			{
				var _employee = new Employee();
				_employee.ID = _lastId + 1;
				_employee.FirstName = newEmployee.FirstName;
				_employee.LastName = newEmployee.LastName;
				_employee.DateOfBirht = newEmployee.DateOfBirht;
				_employee.Gender = newEmployee.Gender;
				_employee.Position = newEmployee.Position;
				_employee.Salary = newEmployee.Salary;
				_employee.CityOfWork = newEmployee.CityOfWork;

				_probaLoginDBEntities.Employee.Add(_employee);
				var numberOfRowsAffected = _probaLoginDBEntities.SaveChanges();
				isAdded = numberOfRowsAffected > 0;
			}
			catch (Exception)
			{

				throw;
			}
			return isAdded;
		}

		public bool deleteEmployee(int id)
		{
			bool isDeleted = false;
			try
			{
				var _employee = _probaLoginDBEntities.Employee.Find(id);
				_probaLoginDBEntities.Employee.Remove(_employee);
				var numberOfRowsAffected = _probaLoginDBEntities.SaveChanges();
				isDeleted = numberOfRowsAffected > 0;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return isDeleted;
		}

		public bool update(EmployeeDTO employeeUpdate)
		{
			bool isUpdated = false;
			try
			{
				var _employee = _probaLoginDBEntities.Employee.Find(employeeUpdate.ID);
				_employee.FirstName = employeeUpdate.FirstName;
				_employee.LastName = employeeUpdate.LastName;
				_employee.DateOfBirht = employeeUpdate.DateOfBirht;
				_employee.Gender = employeeUpdate.Gender;
				_employee.Position = employeeUpdate.Position;
				_employee.Salary = employeeUpdate.Salary;
				_employee.CityOfWork = employeeUpdate.CityOfWork;

				var numberOfRowsAffected = _probaLoginDBEntities.SaveChanges();
				isUpdated = numberOfRowsAffected > 0;

			}
			catch (Exception ex)
			{

				throw ex;
			}

			return isUpdated;
		}
	}
}
