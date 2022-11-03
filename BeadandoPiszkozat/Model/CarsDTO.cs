using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadandoPiszkozat.Model
{
	public class CarsDTO
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string Fuel { get; set; }
		public string MaxPassenger { get; set; }
		public string NumberOfDoors { get; set; }
		public string AvailableType { get; set; }
		public string Price { get; set; }
	}
}
