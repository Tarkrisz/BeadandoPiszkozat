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
	public class EmployeeViewModel : BaseViewModel
	{
		public ObservableCollection<EmployeeDTO> employee { get; set; }
		public EmployeeDTO currentEmploye;
		public EmployeeService _employeeService;
		public EmployeeViewModel()
		{
			_employeeService = new EmployeeService();
			LoadEmployee();
		}

		private void LoadEmployee()
		{
			employee = new ObservableCollection<EmployeeDTO>(_employeeService.getAll());
		}
	}
}
