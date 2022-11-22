using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeadandoPiszkozat.Model
{
	public class UsersService
	{
		private ProbaLoginDBEntities _probaLoginDBEntities;
		private int _lastId;

		public UsersService()
		{
			_probaLoginDBEntities = new ProbaLoginDBEntities();
		}

		public List<UsersDTO> getAll()
		{
			List<UsersDTO> usersDTO = new List<UsersDTO>();

			try
			{
				var users = from user in _probaLoginDBEntities.Login
						   select user;

				foreach (var item in users)
					usersDTO.Add(new UsersDTO
					{
						Id = item.Id,
						Name = item.Name,
						Password = item.Password,
						Type = item.Type
					});
			}
			catch (Exception ex)
			{

				throw ex;
			}

			return usersDTO;

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
	}
}
