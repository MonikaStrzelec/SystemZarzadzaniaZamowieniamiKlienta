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
        List<Danie> listOfTheDishes = new List<Danie>();
        List<PozycjaZamowienia> orderList = new List<PozycjaZamowienia>();
        public Home()
        {
            InitializeComponent();
            refresh();
            timerStatus();
        }
        void refresh()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            dataGridView1.Rows.Clear();
            //Wyświetlenie całej listy menu po uruchomieniu formatki 
            SqlDataAdapter sql = new SqlDataAdapter("SELECT nazwaDania, cenaDania, skladniki FROM Danie ", cnn);
            DataTable dishes = new DataTable();
            sql.Fill(dishes);
            dataGridView1.DataSource = dishes;
            if (dataGridView1.Rows.Count == 1 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Aktualnie nie posiadamy żadnych dań w ofercie!");
            }

            dataGridView1.ClearSelection();
            cnn.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        void timerStatus()
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 12 && hour < 21)
            {   //Otwarte od 12:00am do 8:59pm
                LabelStatus.Text = "Restauracja OTWARTA";
            }
            else
            {   //Zamknięte 5:00pm through 9:59am
                LabelStatus.Text = "restauracja ZAMKNIĘTA";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 12 && hour < 21)
            {   //wywołanie KOSZYKA ZAMÓWIEŃ
                OrderCart openForm = new OrderCart();
                //wrzucamy tu listę
                openForm.ShowDialog();
            }else
            {
                MessageBox.Show("Przykro nam ale restauracja jest zamknięta! Zapraszamy codziennie w godzinach: 12-21");
            }
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
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            //wyświetlenie całej listy MENU
            SqlDataAdapter sql = new SqlDataAdapter("SELECT nazwaDania, cenaDania, skladniki FROM Danie ", cnn);
            DataTable dishes = new DataTable();
            sql.Fill(dishes);
            dataGridView1.DataSource = dishes;

            if (dataGridView1.Rows.Count == 1 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Aktualnie nie posiadamy żadnych dań w ofercie!");
            }
            dataGridView1.ClearSelection();
            cnn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OrderStatusTrue openForm = new OrderStatusTrue();
            openForm.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {   //DODAWANIE do zamówienia
            Danie dish = new Danie();
            string chosenDish;
            decimal priceOfTheDish, totalPrice = 0, orderPrice = 0;
            int amount = 0;

            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                totalPrice = decimal.Parse(textBox1.Text);
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Pobranie danych dania wybranego przez klienta
                chosenDish = (string)dataGridView1.SelectedCells[0].Value;
                priceOfTheDish = (decimal)dataGridView1.SelectedCells[1].Value;
                amount = (int)numericUpDown1.Value;

                dish.NazwaDania = chosenDish.ToString();
                dish.CenaDania = priceOfTheDish;
                //dataGridView2.Rows[0].Cells[0].Value = dish.NazwaDania;
                listOfTheDishes.Add(dish);

                //Dodanie pozycji do koszyka
                dataGridView2.Rows.Add(dish.NazwaDania, dish.CenaDania, amount);

                //Zliczanie ceny całkowitej
                foreach (Danie d in listOfTheDishes)
                {
                    totalPrice = totalPrice + d.CenaDania * amount;

                }
                //textBox1.Text = totalPrice.ToString();

                /*for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    dataGridView2.Rows[i].Cells[1].Value = orderPrice;
                    dataGridView2.Rows[i].Cells[2].Value = amount;

                    totalPrice = dish.CenaDania * amount;

                }*/

                textBox1.Text = totalPrice.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string chosenDish;
            decimal priceOfTheDish, totalPrice = 0;
            int amount = 0, amountToDelete = 0, index = 0;
            //totalPrice = decimal.Parse(textBox1.Text);

            if (dataGridView2.SelectedRows.Count > 0)
            {
                //Pobranie danych dania wybranego przez klienta
                chosenDish = (string)dataGridView2.SelectedCells[0].Value;
                priceOfTheDish = (decimal)dataGridView2.SelectedCells[1].Value;
                amount = (int)dataGridView2.SelectedCells[2].Value;
                amountToDelete = (int)numericUpDown1.Value;
                amount = amount - amountToDelete;
                dataGridView2.SelectedCells[2].Value = amount;

                //Usunięcie wybranego dania z listy
                for (int i = 0; i < listOfTheDishes.Count; i++)
                {
                    index = listOfTheDishes.FindIndex(a => a.NazwaDania == chosenDish);
                    listOfTheDishes.RemoveAt(index);
                }

                //Całkowite usuwanie pozycji z koszyka
                if (amount == 0)
                {
                    dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                }

                //Zliczanie ceny całkowitej
                /*foreach (Danie d in listOfTheDishes)
                {
                    totalPrice = totalPrice - priceOfTheDish * amountToDelete;
                    textBox1.Text = totalPrice.ToString();
                }*/


                if (totalPrice < 0)
                {
                    textBox1.Text = "0";
                }
                else
                {
                    foreach (Danie d in listOfTheDishes)
                    {
                        totalPrice = totalPrice + d.CenaDania * amount;

                    }
                    textBox1.Text = totalPrice.ToString();
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Wyświetlenie listy przystawek
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlDataAdapter sql = new SqlDataAdapter("SELECT nazwaDania, cenaDania, skladniki FROM Danie INNER JOIN TypDania ON Danie.idTypDania = TypDania.idTypDania WHERE TypDania.nazwa = 'Przystawka'", cnn);
            DataTable dishes = new DataTable();
            sql.Fill(dishes);
            dataGridView1.DataSource = dishes;
            dataGridView1.ClearSelection();
            if (dataGridView1.Rows.Count == 1 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Aktualnie nie posiadamy żadnych przystawek w ofercie!");
            }

            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();
            //Wyświetlenie listy ramenów            
            SqlDataAdapter sql = new SqlDataAdapter("SELECT nazwaDania, cenaDania, skladniki FROM Danie INNER JOIN TypDania ON Danie.idTypDania = TypDania.idTypDania WHERE TypDania.nazwa = 'Ramen'", cnn);
            DataTable dishes = new DataTable();
            sql.Fill(dishes);
            dataGridView1.DataSource = dishes;

            if (dataGridView1.Rows.Count == 1 && dataGridView1.Rows != null)
            {
                MessageBox.Show("Aktualnie nie posiadamy żadnych ramenów w ofercie!");
            }

            dataGridView1.ClearSelection();
            cnn.Close();
        }
    }
}
