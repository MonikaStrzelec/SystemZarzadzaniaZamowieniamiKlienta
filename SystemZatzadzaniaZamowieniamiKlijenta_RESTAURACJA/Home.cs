using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public partial class Home : Form
    {

        
        public Home()
        {
            InitializeComponent();
            refresh();
          
            
        }
        void refresh()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            
            dataGridView1.Rows.Clear();
            SqlDataAdapter sql = new SqlDataAdapter("SELECT * FROM Klient ", cnn);
            DataTable klienci = new DataTable();
            sql.Fill(klienci);
            dataGridView1.DataSource = klienci;
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Nie znaleziono klientów!!");
            }
        }
            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        { //wywołanie KOSZYKA ZAMÓWIEŃ
            OrderCart openForm = new OrderCart();
            openForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        { //wywołanie KONTAKTÓW do restauracji
            RestaurantContactDetails openForm = new RestaurantContactDetails();
            openForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //wywołanie AKTUALNYCH PROMOCJI
            Sale openForm = new Sale();
            openForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
