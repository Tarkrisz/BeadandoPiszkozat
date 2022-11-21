using BeadandoPiszkozat.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
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
    public partial class CarsView : UserControl
    {
        CarViewModel _carViewModel;
        public CarsView()
        {
            InitializeComponent();
            _carViewModel = new CarViewModel();
            DataContext = _carViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-NH9MBOU; Initial Catalog=ProbaLoginDB; Integrated Security=true;"); 
            SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-VQ5POJE; Initial Catalog=ProbaLoginDB; Integrated Security=true;");
            try
            {
                if (sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

                string query = "SELECT ID FROM Cars ORDER BY ID DESC";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                int ID = 0;
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        ID = Convert.ToInt32(reader["ID"]);
                    }
                }

                query = "INSERT INTO cars (ID, Brand, Model, Fuel, MaxPassenger, NumberOfDoors, AvailableType, Price)" +
                    "VALUES (@ID, @Brand, @Model, @Fuel, @MaxPassenger, @NumberOfDoors, @AvailableType, @Price)";

                sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@ID", ID + 1);
                sqlCmd.Parameters.AddWithValue("@Brand", txtBxBrand.Text);
                sqlCmd.Parameters.AddWithValue("@Model", txtBxModel.Text);
                sqlCmd.Parameters.AddWithValue("@Fuel", txtBxFuel.Text);
                sqlCmd.Parameters.AddWithValue("@MaxPassenger", txtBxMaxPassanger.Text);
                sqlCmd.Parameters.AddWithValue("@NumberOfDoors", txtBxNumberOfDoors.Text);
                sqlCmd.Parameters.AddWithValue("@AvailableType", txtBxAvailableType.Text);
                sqlCmd.Parameters.AddWithValue("@Price", txtBxPrice.Text);
                sqlCmd.ExecuteNonQuery();
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
