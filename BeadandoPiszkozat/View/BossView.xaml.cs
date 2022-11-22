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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeadandoPiszkozat.View
{
	/// <summary>
	/// Interaction logic for BossView.xaml
	/// </summary>
	public partial class BossView : UserControl
	{
		UsersViewModel _usersViewModel;
		public BossView()
		{
			InitializeComponent();
			_usersViewModel = new UsersViewModel();
			DataContext = _usersViewModel;
		}
	}
}
