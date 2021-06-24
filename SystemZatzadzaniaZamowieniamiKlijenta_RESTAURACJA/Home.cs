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
        List<PozycjaZamowienia> orderItemList = new List<PozycjaZamowienia>();
        decimal totalPrice = 0, priceOfTheDish = 0;
        string chosenDish;


        public Home()
        {
            InitializeComponent();
            refresh();
            timerStatus();

            //Przypisanie wartości kwoty całkowitej
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                totalPrice = decimal.Parse(textBox1.Text);
            }
        }
        void refresh()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connectionString);
            cnn.Open();

            dataGridView1.Rows.Clear();
            //Wyświetlenie całej listy menu po uruchomieniu formatki 
            SqlDataAdapter sql = new SqlDataAdapter("SELECT idDanie, nazwaDania, cenaDania, skladniki FROM Danie ", cnn);
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
            OrderCart openForm = new OrderCart();
            openForm.ShowDialog();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {   //DODAWANIE do zamówienia
            Danie dish = new Danie();
            PozycjaZamowienia orderItem = new PozycjaZamowienia();
            int id, amount = 0;
            decimal priceAfterAdding = 0, priceFromTextBox =0;


            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Pobranie danych dania wybranego przez klienta
                id = (int)dataGridView1.SelectedCells[0].Value;
                chosenDish = (string)dataGridView1.SelectedCells[1].Value;
                priceOfTheDish = (decimal)dataGridView1.SelectedCells[2].Value;
                amount = (int)numericUpDown1.Value;

                dish.NazwaDania = chosenDish.ToString();
                dish.CenaDania = priceOfTheDish;
                dish.IdDanie = id;
                orderItem.IdDania = id;
                orderItem.IloscKonkretnegoDania = amount;

                listOfTheDishes.Add(dish);
                orderItemList.Add(orderItem);
                
                //Dodanie pozycji do koszyka
                dataGridView2.Rows.Add(dish.NazwaDania, dish.CenaDania, amount);

                //Pobranie ceny z textbox
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    priceFromTextBox = decimal.Parse(textBox1.Text);
                }

                //Zliczanie jednostkowej ceny całkowitej
                priceAfterAdding = dish.CenaDania * orderItem.IloscKonkretnegoDania;
                totalPrice = priceFromTextBox + priceAfterAdding;
                textBox1.Text = totalPrice.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                totalPrice = decimal.Parse(textBox1.Text);
            }
            int amount = 0, amountToDelete = 0, index = 0;

            if (dataGridView2.SelectedRows.Count > 0)
            {   //Pobranie danych dania wybranego przez klienta
                try
                {
                    chosenDish = (string)dataGridView2.SelectedCells[0].Value;
                    priceOfTheDish = (decimal)dataGridView2.SelectedCells[1].Value;
                    amount = (int)dataGridView2.SelectedCells[2].Value;
                    amountToDelete = (int)numericUpDown1.Value;

                    amount = amount - amountToDelete;

                    dataGridView2.SelectedCells[2].Value = amount;
                    decimal priceAfterDeleting = 0, newTotalPrice = 0;

                    priceAfterDeleting = priceOfTheDish * amountToDelete;

                    newTotalPrice = totalPrice - priceAfterDeleting;
                    textBox1.Text = newTotalPrice.ToString();

                    //Usunięcie wybranego dania z listy
                    for (int i = 0; i < listOfTheDishes.Count; i++)
                    {
                        index = listOfTheDishes.FindIndex(a => a.NazwaDania == chosenDish);
                        newTotalPrice = listOfTheDishes[index].CenaDania;
                        amount = orderItemList[index].IloscKonkretnegoDania;

                        listOfTheDishes.RemoveAt(index);
                        orderItemList.RemoveAt(index);
                    }

                    //Usunięcie dania z koszyka
                    try
                    {
                        int restAmount = (int)dataGridView2.SelectedCells[2].Value;
                        if (restAmount == 0)
                        {
                            dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Wybrano pustą pozycję!");
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
