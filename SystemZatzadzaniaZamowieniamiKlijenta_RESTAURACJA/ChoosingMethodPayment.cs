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
        private List<Zamowienie> orderListOK;
        List<Danie> listOfTheDishes = new List<Danie>();
        List<PozycjaZamowienia> orderItemList = new List<PozycjaZamowienia>();
        decimal totalPrice = 0, delivery =0;
        int specialOffer = 0;
        DateTime today = DateTime.Now.Date;
        string paymentMethod;

        static string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        public ChoosingMethodPayment(List<Klient> clientList, List<Adresy> customerAddressList, List<Danie> listOfTheDishes, List<PozycjaZamowienia> orderItemList, List<Zamowienie> orderList)
        {
            InitializeComponent();
            clientListOK = clientList;
            customerAddressListOK = customerAddressList;
            orderListOK = orderList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DODANIE KLIENTA DO BAZY DANYCH
            foreach (Klient client in clientListOK)
            {   string sqlKlient = "INSERT INTO Klient (idKlient, imie, nazwisko, email, nrtelefonu) VALUES ( @idKlient, @imie, @nazwisko, @email, @nrtelefonu)";
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
                    foreach(Zamowienie order in orderListOK)
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

                        /*if(order.KosztDostawy == 0)
                        {
                            specialOffer = 1;
                        }
                        else if (today.DayOfWeek.ToString() == "Monday")
                        {
                            specialOffer = 2;
                        } */

                        SqlCommand cmd6 = new SqlCommand(sqlZamowienie, cnn);
                        cmd6.Parameters.Add("@idZamowienie", SqlDbType.Int);
                        cmd6.Parameters["@idZamowienie"].Value = output4;

                        cmd6.Parameters.Add("@dataZamowienia", SqlDbType.DateTime);
                        cmd6.Parameters["@dataZamowienia"].Value = today;

                        cmd6.Parameters.Add("@statusZamowienia", SqlDbType.VarChar);
                        cmd6.Parameters["@statusZamowienia"].Value = "dostarczone";

                        cmd6.Parameters.Add("@opcjePlatnosci", SqlDbType.VarChar);
                        cmd6.Parameters["@opcjePlatnosci"].Value = "gotówka";

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
                    
                    

                }


                if (radioButton1.Checked)
                {   //Blik
                    //blikPayment openForm = new blikPayment();
                    //openForm.ShowDialog();

                    paymentMethod = "Blik";
                }
                else if (radioButton2.Checked)
                {   //GOTÓWKA
                    //OrderStatusTrue openForm = new OrderStatusTrue();
                    //openForm.ShowDialog();

                    paymentMethod = "Gotówka";
                }
                else if (radioButton3.Checked)
                {   //KARTA PLATNICZA

                    //cashPayment openForm = new cashPayment();
                    //openForm.ShowDialog();

                    paymentMethod = "Karta płatnicza";
                }
                else
                {   //brak zaznaczonej płatności
                    DialogResult result = MessageBox.Show("Musisz wybrać petodę płatności!", "Confirmation", MessageBoxButtons.YesNo);
                }
                //SqlCommand cmd6 = new SqlCommand(sqlZamowienie, cnn);
                //cmd6.Parameters.Add("@idZamowienie", SqlDbType.Int);
                //cmd6.Parameters["@idZamowienie"].Value = output4;

                //cmd6.Parameters.Add("@dataZamowienia", SqlDbType.DateTime);
                //cmd6.Parameters["@dataZamowienia"].Value = DateTime.Now.Date;

                //cmd6.Parameters.Add("@statusZamowienia", SqlDbType.VarChar);
                //cmd6.Parameters["@statusZamowienia"].Value = "Zamówienie czeka na potwierdzenie";

                //cmd6.Parameters.Add("@opcjePlatnosci", SqlDbType.VarChar);
                //cmd6.Parameters["@opcjePlatnosci"].Value = label2.Text;

                //cmd6.Parameters.Add("@idPromocja", SqlDbType.VarChar);
                //cmd6.Parameters["@idPromocja"].Value = promocja;

                //cmd6.Parameters.Add("@czasDostawy", SqlDbType.DateTime);
                //cmd6.Parameters["@czasDostawy"].Value = DateTime.Now.AddMinutes(Convert.ToDouble(client.CzasDostawy));

                //cmd6.Parameters.Add("@kosztCalkowity", SqlDbType.Money);
                //cmd6.Parameters["@kosztCalkowity"].Value = totalPrice;

                //cmd6.Parameters.Add("@kosztDostawy", SqlDbType.Money);
                //cmd6.Parameters["@kosztDostawy"].Value = dostawa;

                //cmd6.Parameters.Add("@uwagi", SqlDbType.VarChar);
                //cmd6.Parameters["@uwagi"].Value = client.Komentarz; //potem poprawić

                //cmd6.ExecuteNonQuery();
                //cmd6.Dispose();
                //cnn.Close();


                //foreach (PozycjaZamowienia pozycjaZamowienia in orderItemList)
                //{   //DODAWANIE promocji zamówienia
                //    cnn.Open();
                //    //dodawanie do bazy
                //    string sqlPozycjaZamowienia = "INSERT INTO PozycjeZamowienia (idPozycjeZamowienia, idZamowienie, idDania, idKlient, iloscKonkretnegoDania) VALUES (@idPozycjeZamowienia, @idZamowienie, @idDania, @idKlient, @iloscKonkretnegoDania)";

                //    string sqlPozycjaZamowienia2 = "SELECT COUNT(*), MAX([idAdres]) FROM PozycjeZamowienia";
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

                //    foreach (Danie danie in listOfTheDishes)
                //    {



                //        SqlCommand cmd3 = new SqlCommand(sqlPozycjaZamowienia, cnn);
                //    cmd3.Parameters.Add("@idPozycjeZamowienia", SqlDbType.Int);
                //    cmd3.Parameters["@idPozycjeZamowienia"].Value = output3;

                //    cmd3.Parameters.Add("@idZamowienie", SqlDbType.Int);
                //    cmd3.Parameters["@idZamowienie"].Value = output4;

                //    cmd3.Parameters.Add("@idDania", SqlDbType.VarChar);
                //        cmd3.Parameters["@idDania"].Value = pozycjaZamowienia.IdDania; //jak byś mogła pobrać

                //    cmd3.Parameters.Add("@idKlient", SqlDbType.VarChar);
                //    cmd3.Parameters["@idKlient"].Value = output1;

                //    cmd3.Parameters.Add("@iloscKonkretnegoDania", SqlDbType.VarChar);
                //        cmd3.Parameters["@iloscKonkretnegoDania"].Value = pozycjaZamowienia.IloscKonkretnegoDania; // jak byś mogła pobrać
                //    cmd3.ExecuteNonQuery();
                //    cmd3.Dispose();
                //    cnn.Close();
                //    }
                //}




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
