using BeadandoPiszkozat.Model;
using BeadandoPiszkozat.View;
using BeadandoPiszkozat.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeadandoPiszkozat.ViewModel
{
	public class LoginViewModel : BaseViewModel
	{
		private string _loginName;
		private string _password;

		public string _type;
		public string LoginName
		{
			get { return _loginName; }
			set { _loginName = value; }
		}
		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}
		public RelayCommand EnterLogin { get; }
		public LoginViewModel()
		{
			EnterLogin = new RelayCommand(Mehet);
		}

		private void GetType()
		{
			try
			{
				using (var db = new ProbaLoginDBEntities())
				{
					var querry = from n in db.Login
								 where n.Name.Equals(_loginName)
								 select n;

					foreach (var item in querry)
					{
						_type = item.Type;
					}
				}
			}
			catch (Exception)
			{

				throw;
			}

		}
		void Mehet()
		{
			SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-NH9MBOU; Initial Catalog=ProbaLoginDB; Integrated Security=true;");
			try
			{
				if (sqlCon.State == System.Data.ConnectionState.Closed)
				{
					sqlCon.Open();
				}
				string query = "SELECT COUNT(1) FROM Login WHERE Name=@Username AND Password=@Password";
				SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
				sqlCmd.CommandType = System.Data.CommandType.Text;
				sqlCmd.Parameters.AddWithValue("@Username", _loginName);
				sqlCmd.Parameters.AddWithValue("@Password", _password);
				int counts = Convert.ToInt32(sqlCmd.ExecuteScalar());
				if (counts == 1)
				{
					GetType();
					Main m = new Main();
					m.Show();
					var asd = Application.Current.MainWindow;
					asd.Close();
				}
				else
					MessageBox.Show("Hibás név vagy jelszó.");
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
			finally
			{
				sqlCon.Close();
			}
		}
	}
}
