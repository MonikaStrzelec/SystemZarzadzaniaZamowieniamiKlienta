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

        List<Klient> clientListOK;
        List<Adresy> customerAddressListOK;
        List<Zamowienie> orderListOK;
        List<PozycjaZamowienia> orderItemListOK;
        List<Danie> listOfTheDishesOk;

        static string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);

        decimal totalPrice = 0, delivery = 0;
        int specialOffer = 0;
        DateTime today = DateTime.Now.Date;
        string paymentMethod;
        public OrderStatusTrue(List<Klient> clientList, List<Adresy> customerAddressList, List<PozycjaZamowienia> orderItemList, List<Zamowienie> orderList, List<Danie> listOfTheDishes)
        {
            InitializeComponent();
            StartTimer();
            statusText.Text = "";

            clientListOK = clientList;
            customerAddressListOK = customerAddressList;
            orderListOK = orderList;
            orderItemListOK = orderItemList;
            listOfTheDishesOk = listOfTheDishes;
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

            //DODANIE KLIENTA DO BAZY DANYCH
            foreach (Klient client in clientListOK)
            {
                string sqlKlient = "INSERT INTO Klient (idKlient, imie, nazwisko, email, nrtelefonu) VALUES ( @idKlient, @imie, @nazwisko, @email, @nrtelefonu)";
                string sqlKlient2 = "SELECT COUNT(*), MAX([idKlient]) FROM Klient";
                cnn.Open();
                SqlCommand cmd1 = new SqlCommand(sqlKlient2, cnn);
                SqlDataReader dataReader = cmd1.ExecuteReader(); //uruchamianie zapytania
                int output1 = 0;
                while (dataReader.Read())
                {
                    if ((int)dataReader.GetValue(0) != 0)
                    {
                        output1 = Convert.ToInt32(dataReader.GetValue(1)) + 1;
                    }
                }
                cmd1.Cancel();
                dataReader.Close();

                SqlCommand cmd = new SqlCommand(sqlKlient, cnn);
                cmd.Parameters.Add("@idKlient", SqlDbType.Int);
                cmd.Parameters["@idKlient"].Value = output1;

                cmd.Parameters.Add("@imie", SqlDbType.NChar);
                cmd.Parameters["@imie"].Value = client.Imie;

                cmd.Parameters.Add("@nazwisko", SqlDbType.NChar);
                cmd.Parameters["@nazwisko"].Value = client.Nazwisko;

                cmd.Parameters.Add("@email", SqlDbType.NChar);
                cmd.Parameters["@email"].Value = client.Email;

                cmd.Parameters.Add("@nrtelefonu", SqlDbType.NChar);
                cmd.Parameters["@nrtelefonu"].Value = client.Nrtelefonu;

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Close();

                //DODANIE ADRESU DO BAZY DANYCH
                foreach (Adresy adresy in customerAddressListOK)
                {
                    cnn.Open();

                    string sqlAdresy = "INSERT INTO Adresy (idAdres, idKlient, ulica, numerDomu, numerMieszkania, kodPocztowy, miasto) VALUES (@idAdres, @idKlient, @ulica, @numerDomu, @numerMieszkania, @kodPocztowy, @miasto)";
                    string sqlAdresy2 = "SELECT COUNT(*), MAX([idAdres]) FROM Adresy";
                    SqlCommand cmd4 = new SqlCommand(sqlAdresy2, cnn);
                    SqlDataReader dataReader2 = cmd4.ExecuteReader();
                    int output2 = 0;
                    while (dataReader2.Read())
                    {
                        if ((int)dataReader2.GetValue(0) != 0)
                        {
                            output2 = Convert.ToInt32(dataReader2.GetValue(1)) + 1;
                        }
                    }
                    cmd4.Cancel();
                    dataReader2.Close();

                    SqlCommand cmd3 = new SqlCommand(sqlAdresy, cnn);
                    cmd3.Parameters.Add("@idAdres", SqlDbType.Int);
                    cmd3.Parameters["@idAdres"].Value = output2;

                    cmd3.Parameters.Add("@idKlient", SqlDbType.Int);
                    cmd3.Parameters["@idKlient"].Value = output1;

                    cmd3.Parameters.Add("@ulica", SqlDbType.VarChar);
                    cmd3.Parameters["@ulica"].Value = adresy.Ulica;

                    cmd3.Parameters.Add("@numerDomu", SqlDbType.VarChar);
                    cmd3.Parameters["@numerDomu"].Value = adresy.NumerDomu;

                    cmd3.Parameters.Add("@numerMieszkania", SqlDbType.VarChar);
                    cmd3.Parameters["@numerMieszkania"].Value = adresy.NumerMieszkania;

                    cmd3.Parameters.Add("@kodPocztowy", SqlDbType.VarChar);
                    cmd3.Parameters["@kodPocztowy"].Value = adresy.KodPocztowy;

                    cmd3.Parameters.Add("@miasto", SqlDbType.VarChar);
                    cmd3.Parameters["@miasto"].Value = adresy.Miasto;
                    cmd3.ExecuteNonQuery();
                    cmd3.Dispose();
                    cnn.Close();
                }


                //DODANIE ZAMÓWIENIA DO BAZY
                ////Zamowienie zamowienie;           


                foreach (Klient clientDetails in clientListOK)
                {
                    foreach (Zamowienie order in orderListOK)
                    {
                        cnn.Open();

                        string sqlZamowienie = "INSERT INTO Zamowienie (idZamowienie, dataZamowienia, statusZamowienia, opcjePlatnosci, idPromocja, czasDostawy, kosztCalkowity, kosztDostawy, uwagi) VALUES (@idZamowienie, @dataZamowienia, @statusZamowienia, @opcjePlatnosci, @idPromocja, @czasDostawy, @kosztCalkowity, @kosztDostawy, @uwagi)";
                        string sqlZamowienie2 = "SELECT COUNT(*), MAX([idZamowienie]) FROM Zamowienie";
                        SqlCommand cmd5 = new SqlCommand(sqlZamowienie2, cnn);
                        SqlDataReader dataReader3 = cmd5.ExecuteReader();
                        int output4 = 0;
                        while (dataReader3.Read())
                        {
                            if ((int)dataReader3.GetValue(0) != 0)
                            {
                                output4 = Convert.ToInt32(dataReader3.GetValue(1)) + 1;
                            }
                        }
                        cmd5.Cancel();
                        dataReader3.Close();

                        if (order.KosztDostawy == 0)
                        {
                            specialOffer = 1;
                        }
                        else if (today.DayOfWeek.ToString() == "Monday")
                        {
                            specialOffer = 2;
                        }

                        SqlCommand cmd6 = new SqlCommand(sqlZamowienie, cnn);
                        cmd6.Parameters.Add("@idZamowienie", SqlDbType.Int);
                        cmd6.Parameters["@idZamowienie"].Value = output4;

                        cmd6.Parameters.Add("@dataZamowienia", SqlDbType.DateTime);
                        cmd6.Parameters["@dataZamowienia"].Value = today;

                        cmd6.Parameters.Add("@statusZamowienia", SqlDbType.VarChar);
                        cmd6.Parameters["@statusZamowienia"].Value = "dostarczone";

                        cmd6.Parameters.Add("@opcjePlatnosci", SqlDbType.VarChar);
                        cmd6.Parameters["@opcjePlatnosci"].Value = order.OpcjePlatnosci;

                        cmd6.Parameters.Add("@idPromocja", SqlDbType.Int);
                        cmd6.Parameters["@idPromocja"].Value = specialOffer;

                        cmd6.Parameters.Add("@czasDostawy", SqlDbType.DateTime);
                        cmd6.Parameters["@czasDostawy"].Value = clientDetails.CzasDostawy;

                        cmd6.Parameters.Add("@kosztCalkowity", SqlDbType.Money);
                        cmd6.Parameters["@kosztCalkowity"].Value = order.KosztCalkowity;

                        cmd6.Parameters.Add("@kosztDostawy", SqlDbType.Money);
                        cmd6.Parameters["@kosztDostawy"].Value = order.KosztDostawy;

                        cmd6.Parameters.Add("@uwagi", SqlDbType.VarChar);
                        cmd6.Parameters["@uwagi"].Value = clientDetails.Komentarz;
                        cmd6.ExecuteNonQuery();
                        cmd6.Dispose();

                      

                        cnn.Close();
                    }


                    //DODAWANIE POZYCJI ZAMOWIENIA DO BAZY
                    foreach (PozycjaZamowienia orderItem in orderItemListOK)
                    {
                        cnn.Open();
                        string sqlPozycjaZamowienia = "INSERT INTO PozycjaZamowienia (idPozycjaZamowienia, idZamowienie, idDania, idKlient,iloscKonkretnegoDania) VALUES (@idPozycjaZamowienia, @idZamowienie, @idDania, @idKlient, @iloscKonkretnegoDania)";
                        string sqlPozycjaZamowienia2 = "SELECT COUNT(*), MAX([idPozycjaZamowienia]) FROM PozycjaZamowienia";
                        string sqlGetId = "SELECT COUNT(*), MAX([idZamowienie]) FROM Zamowienie";
                        SqlCommand cmd7 = new SqlCommand(sqlPozycjaZamowienia2, cnn);
                        SqlDataReader dataReader4 = cmd7.ExecuteReader();
                        int output5 = 0, output6=0;
                        while (dataReader4.Read())
                        {
                            if ((int)dataReader4.GetValue(0) != 0)
                            {
                                output5 = Convert.ToInt32(dataReader4.GetValue(1)) + 1;
                            }
                        }
                        cmd7.Cancel();
                        dataReader4.Close();

                        SqlCommand cmd9 = new SqlCommand(sqlGetId, cnn);
                        SqlDataReader dataReader6 = cmd9.ExecuteReader();

                        {
                            if ((int)dataReader6.GetValue(0) != 0)
                            {
                                output6 = Convert.ToInt32(dataReader6.GetValue(1)) + 1;
                            }
                        }
                        cmd9.Cancel();
                        dataReader6.Close();


                        SqlCommand cmd8 = new SqlCommand(sqlPozycjaZamowienia, cnn);

                        cmd8.Parameters.Add("@idPozycjaZamowienia", SqlDbType.Int);
                        cmd8.Parameters["@idPozycjaZamowienia"].Value = output5;

                        cmd8.Parameters.Add("@idZamowienie", SqlDbType.Int);
                        cmd8.Parameters["@idZamowienie"].Value = output6;

                        cmd8.Parameters.Add("@idDania", SqlDbType.Int);
                        cmd8.Parameters["@idDania"].Value = orderItem.IdDania;

                        cmd8.Parameters.Add("@idKlient", SqlDbType.Int);
                        cmd8.Parameters["@idKlient"].Value = output6;

                        cmd8.Parameters.Add("@iloscKonkretnegoDania", SqlDbType.Int);
                        cmd8.Parameters["@iloscKonkretnegoDania"].Value = orderItem.IloscKonkretnegoDania;

                        cmd8.ExecuteNonQuery();
                        cmd8.Dispose();
                        cnn.Close();
                    }


                }
            }

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
