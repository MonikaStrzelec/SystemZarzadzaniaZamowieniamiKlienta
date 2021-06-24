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
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
            refresh();
        }
            void refresh()
            {
            void refresh()
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connectionString);
                cnn.Open();
                dataGridView1.Rows.Clear();
                //Wyświetlenie promocji
                SqlDataAdapter sql = new SqlDataAdapter("SELECT nazwaPromocji, opisPromocji FROM Promocja ", cnn);
                DataTable sale = new DataTable();
                sql.Fill(sale);
                dataGridView1.DataSource = sale;

                //Ustawienie szerokości                
                dataGridView1.Columns[0].Width = 140;
                dataGridView1.Columns[1].Width = 370;

                if (dataGridView1.Rows.Count == 1 && dataGridView1.Rows != null)
                {
                    MessageBox.Show("Aktualnie nie posiadamy żadnych promocji");
                    this.Hide();
                }
                dataGridView1.ClearSelection();
                cnn.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Sale_Load(object sender, EventArgs e)
        {

        }
    }
}
