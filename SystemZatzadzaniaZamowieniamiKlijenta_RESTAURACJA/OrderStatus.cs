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
    public partial class OrderStatusTrue : Form
    {
        int timeLeft; //zmienna śledząca pozostały czas
        string[] arrayDeliveryStatus = new string[] {"Zamówienie czeka na potwierdzenie", "Restauracja przyjeła zamówienie",
                "Danie w realizacji", "Jedzenie czeka na dostawcę jedzenia", "Jedzenie jest w drodze do ciebie"};

        public OrderStatusTrue()
        {
            InitializeComponent();
            StartTimer();
        }

        public void StartTimer()
        {   // Uruchom timer.
            timeLeft = 3000; //50 minut: 60=1min
            timeLabel.Text = timeLeft / 60 + " : " + ((timeLeft % 60) >= 10 ? (timeLeft % 60).ToString() : "0" + (timeLeft % 60));
            timer1.Start();

        }
        private void OrderStatus_Load(object sender, EventArgs e)
        {
            statusText.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {   //wyświetla aktualny czas
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft / 60 + " : " + ((timeLeft % 60) >= 10 ? (timeLeft % 60).ToString() : "0" + (timeLeft % 60));
                viewDeliveryStatus();
            }
            else
            {   // Jeśli użytkownikowi zabrakło czasu, zatrzymaj minutnik, pokaż
                timer1.Stop();
                timeLabel.Text = "Czas na dostawę minął!";
                MessageBox.Show("Jeśli nie dostałes swojego jedzenia to Przepraszamy!.", "Możesz skontaktować się z restauracja by dowiedzieć się za ile dotrze jedzenie!");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {   //dostawa dostarczona
            timer1.Stop();
            MessageBox.Show("SMACZNEGO!", "Zapraszamy ponownie!");
            Home openForm = new Home();
            openForm.ShowDialog();
        }

        public void viewDeliveryStatus()
        {   // wyświetlanie STATUSU DOSTAWY: zależne od timera

            //string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
            //SqlConnection cnn = new SqlConnection(connectionString);
            //cnn.Open();
            ////wyświetlenie całej listy MENU
            //SqlDataAdapter sql = new SqlDataAdapter("SELECT idDanie,nazwaDania, cenaDania, skladniki FROM Danie ", cnn);
            //DataTable dishes = new DataTable();
            //sql.Fill(dishes);
            ////dataGridView1.DataSource = dishes;

            ////if (dataGridView1.Rows.Count == 1 && dataGridView1.Rows != null)
            ////{
            ////    MessageBox.Show("Aktualnie nie posiadamy żadnych dań w ofercie!");
            ////}
            ////dataGridView1.ClearSelection();
            //cnn.Close();

            if (timeLeft >= 0 && timeLeft < 1000)
            {
                statusText.Text = arrayDeliveryStatus[4];
            }
            else if (timeLeft >= 1001 && timeLeft < 2000)
            {
                statusText.Text = arrayDeliveryStatus[3];
            }
            else if (timeLeft >= 2001 && timeLeft < 2970)
            {
                statusText.Text = arrayDeliveryStatus[2];
            }
            else if (timeLeft >= 2711 && timeLeft < 2989)
            {
                statusText.Text = arrayDeliveryStatus[1];
            }
            else if (timeLeft >= 2990 && timeLeft < 3001)
            {
                statusText.Text = arrayDeliveryStatus[0];
            }
            statusText.Refresh();
        }

        private void statusText_Click(object sender, EventArgs e)
        {}
    }
}
