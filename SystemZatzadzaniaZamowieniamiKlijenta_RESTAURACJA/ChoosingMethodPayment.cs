using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public partial class ChoosingMethodPayment : Form
    {
        private List<Klient> clientListOK;
        private List<Adresy> customerAddressListOK;
        List<Danie> listOfTheDishes = new List<Danie>();
        List<PozycjaZamowienia> orderItemList = new List<PozycjaZamowienia>();
        decimal totalPrice = 0;

        static string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        public ChoosingMethodPayment(List<Klient> clientList, List<Adresy> customerAddressList, List<Danie> listOfTheDishes, List<PozycjaZamowienia> orderItemList, decimal totalPrice)
        {
            InitializeComponent();
            clientListOK = clientList;
            customerAddressListOK = customerAddressList;
        }

        private void button1_Click(object sender, EventArgs e)
        {   //DODAWANIE klienta
            foreach (Klient client in clientListOK)
            {   //DODANIE DO BAZY DANYCH
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


                foreach (Adresy adresy in customerAddressListOK)
                {   //DODAWANIE adresu
                    cnn.Open();
                    //dodawanie do bazy
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


                //Zamowienie zamowienie;
                cnn.Open();
                //dodawanie do bazy
                string sqlZamowienie = "INSERT INTO Zamowienie (idZamowienie, dataZamowienia, statusZamowienia, opcjePlatnosci, idPromocja, czasDostawy, kosztCalkowity, kosztDostawy, uwagi) VALUES (@idZamowienie, @dataZamowienia, @statusZamowienia, @opcjePlatnosci, @idPromocja, @czasDostawy, @kosztCalkowity, @kosztDostawy, @uwagi)";
                string sqlZamowienie2 = "SELECT COUNT(*), MAX([idAdres]) FROM Zamowienie";
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
                var today = DateTime.Now.Date;
                DateTime otherDate = DateTime.Now.AddMinutes(50);
                decimal dostawa;
                int promocja;

                if(totalPrice > 200)
                {
                    dostawa = 7;
                    promocja = 1;
                } else
                {
                    promocja = 2;
                    dostawa = 0;
                }

                SqlCommand cmd6 = new SqlCommand(sqlZamowienie, cnn);
                cmd6.Parameters.Add("@idZamowienie", SqlDbType.Int);
                cmd6.Parameters["@idZamowienie"].Value = output4;

                cmd6.Parameters.Add("@dataZamowienia", SqlDbType.DateTime);
                cmd6.Parameters["@dataZamowienia"].Value = today;

                cmd6.Parameters.Add("@statusZamowienia", SqlDbType.VarChar);
                cmd6.Parameters["@statusZamowienia"].Value = "Zamówienie czeka na potwierdzenie";

                cmd6.Parameters.Add("@opcjePlatnosci", SqlDbType.VarChar);
                cmd6.Parameters["@opcjePlatnosci"].Value = label2.Text;

                cmd6.Parameters.Add("@idPromocja", SqlDbType.VarChar);
                cmd6.Parameters["@idPromocja"].Value = promocja;

                cmd6.Parameters.Add("@czasDostawy", SqlDbType.DateTime);
                cmd6.Parameters["@czasDostawy"].Value = otherDate;

                cmd6.Parameters.Add("@kosztCalkowity", SqlDbType.Money);
                cmd6.Parameters["@kosztCalkowity"].Value = totalPrice;

                cmd6.Parameters.Add("@kosztDostawy", SqlDbType.Money);
                cmd6.Parameters["@kosztDostawy"].Value = dostawa;

                cmd6.Parameters.Add("@uwagi", SqlDbType.VarChar);
                cmd6.Parameters["@uwagi"].Value = " "; //potem poprawić

                cmd6.ExecuteNonQuery();
                cmd6.Dispose();
                cnn.Close();


                //foreach (PozycjaZamowienia pozycjaZamowienia in orderItemList)
                //{   //DODAWANIE zamówienia
                //    cnn.Open();
                //    //dodawanie do bazy
                //    string sqlPozycjaZamowienia = "INSERT INTO PromocjeZamowienia (idPromocjeZamowienia, idZamowienie, idDania, idKlient, iloscKonkretnegoDania) VALUES (@idPromocjeZamowienia, @idZamowienie, @idDania, @idKlient, @iloscKonkretnegoDania)";

                //    string sqlPozycjaZamowienia2 = "SELECT COUNT(*), MAX([idAdres]) FROM PromocjeZamowienia";
                //    SqlCommand cmd4 = new SqlCommand(sqlPozycjaZamowienia2, cnn);
                //    SqlDataReader dataReader2 = cmd4.ExecuteReader();
                //    int output3 = 0;
                //    while (dataReader2.Read())
                //    {
                //        if ((int)dataReader2.GetValue(0) != 0)
                //        {
                //            output3 = Convert.ToInt32(dataReader2.GetValue(1)) + 1;
                //        }
                //    }
                //    cmd4.Cancel();
                //    dataReader2.Close();

                //    SqlCommand cmd3 = new SqlCommand(sqlPozycjaZamowienia, cnn);
                //    cmd3.Parameters.Add("@idPromocjeZamowienia", SqlDbType.Int);
                //    cmd3.Parameters["@idPromocjeZamowienia"].Value = output3;

                //    cmd3.Parameters.Add("@idZamowienie", SqlDbType.Int);
                //    cmd3.Parameters["@idZamowienie"].Value = output1;

                //    cmd3.Parameters.Add("@idDania", SqlDbType.VarChar);
                //    cmd3.Parameters["@idDania"].Value = listOfTheDishes.idDania;

                //    cmd3.Parameters.Add("@idKlient", SqlDbType.VarChar);
                //    cmd3.Parameters["@idKlient"].Value = output1;

                //    cmd3.Parameters.Add("@iloscKonkretnegoDania", SqlDbType.VarChar);
                //    cmd3.Parameters["@iloscKonkretnegoDania"].Value = adresy.iloscKonkretnegoDania;
                //    cmd3.ExecuteNonQuery();
                //    cmd3.Dispose();
                //    cnn.Close();
                //}



                if (radioButton1.Checked)
                {   //Blik
                    blikPayment openForm = new blikPayment();
                    openForm.ShowDialog();
                }
                else if (radioButton2.Checked)
                {   //GOTÓWKA
                    OrderStatusTrue openForm = new OrderStatusTrue();
                    openForm.ShowDialog();
                }
                else if (radioButton3.Checked)
                {   //KARTA PLATNICZA
                    cashPayment openForm = new cashPayment();
                    openForm.ShowDialog();
                }
                else
                {   //brak zaznaczonej płatności
                    DialogResult result = MessageBox.Show("Musisz wybrać petodę płatności!", "Confirmation", MessageBoxButtons.YesNo);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {   //wywołanie STRONY GŁOWNEJ
            Home openForm = new Home();
            openForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {   //REZYGNACJA z zamówienia
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zrezygnować z zamówienia?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Płatność anulowana.");
                //ZEROWANIE KOSZYKA?
                this.Hide();
                Home openForm = new Home();
                openForm.ShowDialog();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        { }

        private void ChoosingMethodPayment_Load(object sender, EventArgs e)
        { }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {   //BLIK
            label2.Text = "Sposób płatności: Płatność BLIK";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {   //GOTOWKA
            label2.Text = "Sposób płatności: Płatność gotówką";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {   //KARTA PLATNICZA
            label2.Text = "Sposób płatności: Kartą płatniczą";
        }
    }
}
