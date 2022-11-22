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
	public class UsersViewModel : BaseViewModel
	{
		public ObservableCollection<UsersDTO> Users { get; set; }
		private UsersService _userService;
		public UsersViewModel()
		{
			_userService = new UsersService();
			LoadUsers();
		}

		private void LoadUsers()
		{
			Users = new ObservableCollection<UsersDTO>(_userService.getAll());
		}
	}
}
