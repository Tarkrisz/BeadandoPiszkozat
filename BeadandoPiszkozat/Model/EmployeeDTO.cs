using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadandoPiszkozat.Model
{
	public class EmployeeDTO
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirht { get; set; }
		public string Gender { get; set; }
		public string Position { get; set; }
		public string Salary { get; set; }
		public string CityOfWork { get; set; }
	}
}
