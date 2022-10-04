using System.Windows;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MySQLWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["localMySql"].ConnectionString);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select id_book, name, author,isbn from book", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tbResult.Text += reader.GetString(0) + " , " + reader.GetString(1) + " , " + reader.GetString(2) + "\n";
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally {
                conn.Close();
            }
        }
    }
}
