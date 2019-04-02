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
using MySql.Data.MySqlClient;
using System.Data;

namespace WorldSkils
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            load_data();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid data = sender as DataGrid;
            DataRowView rowView = data.SelectedItem as DataRowView;
            if (rowView != null)
            {
                name.Text = rowView["name"].ToString();
                login.Text = rowView["login"].ToString();
                email.Text = rowView["email"].ToString();
                last_name.Text = rowView["last_name"].ToString();
                Id = rowView["id"].ToString();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
        private string Id { get; set; }
        private void load_data() {
            using(MySqlConnection link = new MySqlConnection("server=localhost;user=root;database=pod;password="))
            {
                link.Open();
                var df = "select * from user u join info_user i on u.id=i.id_user ";
                DataTable data = new DataTable();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(df, link);
                dataAdapter.Fill(data);
                data_row.ItemsSource = data.DefaultView;
            }
        }
    }
}
