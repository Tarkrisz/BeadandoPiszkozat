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
		public EmployeeDTO currentEmploye { get; set; }
		public EmployeeService _employeeService;
		public RelayCommand SaveCommand { get; }

		public EmployeeViewModel()
		{
			_employeeService = new EmployeeService();
			LoadEmployee();
			currentEmploye = new EmployeeDTO();
			SaveCommand = new RelayCommand(save);
		}

		private void LoadEmployee()
		{
			employee = new ObservableCollection<EmployeeDTO>(_employeeService.getAll());
		}

		private void save()
		{
			try
			{
				bool isSaved = _employeeService.addEmployee(currentEmploye);
				LoadEmployee();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
	}
}
