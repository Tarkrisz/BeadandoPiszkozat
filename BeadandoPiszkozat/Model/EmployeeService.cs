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
	}
}
