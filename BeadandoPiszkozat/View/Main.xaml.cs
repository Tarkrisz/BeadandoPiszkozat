using BeadandoPiszkozat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BeadandoPiszkozat.View
{
	/// <summary>
	/// Interaction logic for Main.xaml
	/// </summary>
	public partial class Main : Window
	{
		public CarsView _carView;
		public BossView _bossView;
		public EmployeeView _employeeView;
		public CarViewModel _carViewModel;
		public Main()
		{
			InitializeComponent();
			Customer();
			_carView = new CarsView();
			_bossView = new BossView();
			_employeeView = new EmployeeView();
		}
		void Customer()
		{
			if (LoginViewModel._type == "Employee")
			{
				bttnDatas.Visibility = Visibility.Hidden;
				bttnAdmin.Visibility = Visibility.Hidden;
			}
			else if (LoginViewModel._type == "Boss")
			{
				bttnAdmin.Visibility = Visibility.Hidden;
			}

		}

		private void bttnMain_Click(object sender, RoutedEventArgs e)
		{
			Mnwfrm.Content = _carView;
			_carViewModel = new CarViewModel();
			DataContext = _carViewModel;
		}

		private void bttnDatas_Click(object sender, RoutedEventArgs e)
		{
			Mnwfrm.Content = _employeeView;
		}

		private void bttnAdmin_Click(object sender, RoutedEventArgs e)
		{
			Mnwfrm.Content = _bossView;
		}
	}
}
