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
    public partial class OrderCart : Form
    {
        List<Klient> clientList = new List<Klient>();
        List<Adresy> customerAddressList = new List<Adresy>();
        decimal totalPrice = 0;
        public OrderCart(List<Danie> listOfTheDishes, List<PozycjaZamowienia> orderItemList, decimal totalPrice)
        {
            InitializeComponent();
            int id = 0, idRow = 0;
            textBox1.Text = totalPrice.ToString();
            foreach (Danie d in listOfTheDishes)
            {
                dataGridView1.Rows.Add(d.NazwaDania, d.CenaDania);
                id = d.IdDanie;
                foreach (PozycjaZamowienia o in orderItemList)
                {
                    if (o.IdDania == id)
                    {
                        idRow = id - 1;
                        dataGridView1.Rows[idRow].Cells[2].Value = o.IloscKonkretnegoDania;
                    }
                }
            }
        }

        public static string validationTextNoSpecialCharacters(TextBox textValidation)
        {
            var hasSpecialChar = new Regex(@"[\| !#$%&/()=?»«@£§€{}.-;'<>_,]+"); //Napisy które nie mogą mieć dziwnych znaków
            if (hasSpecialChar.IsMatch(textValidation.Text))
            {
                MessageBox.Show("Wpisz poprawne dane, nie mogą zawierać znaków specjalnych", "Niepoprawne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return textValidation.Text;
        }
        public static string validationTextWithoutTheNumber(TextBox textValidation)
        {
            var hasNumber = new Regex(@"[0-9]+"); //Napisy które nie mogą mieć liczb
            if (hasNumber.IsMatch(textValidation.Text))
            {
                MessageBox.Show("Wpisz poprawne dane! Imię, nazwisko nie mogą zawierać liczb", "Niepoprawne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return textValidation.Text;
        }

        private void label14_Click(object sender, EventArgs e)
        { }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //WALIDACJA adres
                if (string.IsNullOrWhiteSpace(userAddressStreet.Text))
                {
                    MessageBox.Show("Musisz wpisać adres");
                }
                else
                {
                    if (userAddressStreet.Text.Length < 3)
                    {
                        MessageBox.Show("Sprawdź swój adres, jest za krótki");
                    }
                    else if (userAddressStreet.MaxLength > 50)
                    {
                        MessageBox.Show("Sprawdź swój adres, jest za długi");
                    }
                    else
                    {
                        validationTextNoSpecialCharacters(userAddressStreet);
                    }
                }
                //WALIDACJA numer ulicy
                if (string.IsNullOrWhiteSpace(userAddressStreetNumber.Text))
                {
                    MessageBox.Show("Musisz wpisać numer ulicy");
                }
                else if (userAddressStreetNumber.MaxLength < 7)
                {
                    MessageBox.Show("Sprawdź swój numer ulicy, chyba jest za długi");
                }
                else
                {
                    validationTextNoSpecialCharacters(userAddressStreetNumber);
                }


                //WALIDACJA kod pocztowy
                if (string.IsNullOrWhiteSpace(userAddressPostalCode.Text))
                {
                    MessageBox.Show("Musisz wpisać kod pocztowy");
                }
                else if (userAddressPostalCode.Text.Length > 5 && userAddressPostalCode.MaxLength <= 7)
                {
                    MessageBox.Show("Czy na pewno wprowadziłeś poprawny kod pocztowy?");
                }
                else
                {
                    validationTextNoSpecialCharacters(userAddressPostalCode);
                }


                //WALIDACJA miasto
                if (string.IsNullOrWhiteSpace(userAddressCity.Text))
                {
                    MessageBox.Show("Musisz wpisać miasto");
                    userAddressCity.Focus();
                    return;
                }
                else
                {
                    string city = "Łódź";
                    string city2 = "lodz";
                    if (!(userAddressCity.Text.Equals(city) || userAddressCity.Text.Equals(city2)) == true)
                    {
                        MessageBox.Show("Przykro nam ale nie obsługujemy dostawy po za Łodzią :( ");
                        this.Close();
                        Home openForm2 = new Home();
                        openForm2.ShowDialog();
                    }
                }


                //WALIDACJA imię
                if (string.IsNullOrWhiteSpace(userName.Text))
                {
                    MessageBox.Show("Musisz wpisać swoje imię");
                }
                else if (userName.Text.Length > 5 && userName.MaxLength <= 20)
                {
                    MessageBox.Show("Czy na pewno wpisałeś poprawnie swoje imię?");
                }
                else
                {
                    validationTextNoSpecialCharacters(userName);
                    validationTextWithoutTheNumber(userName);
                }


                //WALIDACJA nazwisko
                if (string.IsNullOrWhiteSpace(userFamilyName.Text))
                {
                    MessageBox.Show("Musisz wpisać swoje nazwisko");
                }
                else if (userFamilyName.Text.Length > 5 && userFamilyName.MaxLength <= 20)
                {
                    MessageBox.Show("Czy na pewno wpisałeś poprawnie nazwisko?");
                }
                else
                {
                    validationTextNoSpecialCharacters(userFamilyName);
                    validationTextWithoutTheNumber(userFamilyName);
                }


                //WALIDACJA e-mail
                if (string.IsNullOrWhiteSpace(userEmail.Text))
                {
                    MessageBox.Show("Musisz wpisać e-mail");
                }
                else if (userEmail.Text.Length > 5)
                {

                    if (!this.userEmail.Text.Contains('@') || !this.userEmail.Text.Contains('.'))
                    {
                        MessageBox.Show("Wprowadź poprawny adres email", "Niepoprawny adres email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                                       
                }
               


                //WALIDACJA numer telefonu
                if (string.IsNullOrWhiteSpace(numericuserPhoneNumber.Text))
                {
                    MessageBox.Show("Musisz wpisać numer telefonu");
                    if (userAddressPostalCode.Text.Length > 7 && userAddressPostalCode.MaxLength <= 9)
                    {
                        MessageBox.Show("Czy na pewno wprowadziłeś poprawny numer telefonu?");
                    }
                    return;
                }

                //ZAPISANIE DANYCH użytkownika
                Klient customer = new Klient();
                Adresy addressCustomer = new Adresy();
                int id = 0;

                customer.Imie = userName.Text;
                customer.Nazwisko = userFamilyName.Text;
                customer.Email = userEmail.Text;
                customer.Nrtelefonu = (int)numericuserPhoneNumber.Value;

                customer.IdKlient = id;
                addressCustomer.IdKlient = id;

                addressCustomer.Ulica = userAddressStreet.Text;
                addressCustomer.NumerDomu = userAddressStreetNumber.Text;
                addressCustomer.NumerMieszkania = userAddressApartmentNumber.Text;
                addressCustomer.KodPocztowy = userAddressPostalCode.Text;
                addressCustomer.Miasto = userAddressCity.Text;

                clientList.Add(customer);
                customerAddressList.Add(addressCustomer);


                ////DODANIE DO BAZY DANYCH
                //string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
                //SqlConnection cnn = new SqlConnection(connectionString);
                //cnn.Open();
                ////dodawanie do bazy
                //SqlDataAdapter sqlKlient = new SqlDataAdapter("INSERT INTO Klient (idKlient, imie, nazwisko, email, nrtelefonu) VALUES(@id, @imie, @nazwisko, @email, @nrtelefonu)", cnn);
                //string sqlKlient2 = "SELECT COUNT(*), MAX([id]) FROM Klient";
                //SqlCommand cmd1 = new SqlCommand(sqlKlient2, cnn);
                //SqlDataReader dataReader = cmd1.ExecuteReader();
                //int output1 = 0;
                //while (dataReader.Read())
                //{
                //    if ((int)dataReader.GetValue(0) != 0)
                //    {
                //        output1 = Convert.ToInt32(dataReader.GetValue(1)) + 1;
                //    }
                //}
                //cmd1.Cancel();
                //dataReader.Close();

                //SqlCommand cmd = new SqlCommand(sqlKlient.ToString(), cnn);
                //cmd.Parameters.Add("@idKlient", SqlDbType.Int);
                //cmd.Parameters["@idKlient"].Value = output1;
                //cmd.Parameters.Add("@imie", SqlDbType.NChar);
                //cmd.Parameters["@status"].Value = customer.Imie;
                //cmd.Parameters.Add("@nazwisko", SqlDbType.NChar);
                //cmd.Parameters["@nazwisko"].Value = customer.Nazwisko;
                //cmd.Parameters.Add("@email", SqlDbType.NChar);
                //cmd.Parameters["@email"].Value = customer.Email;
                //cmd.Parameters.Add("@nrtelefonu", SqlDbType.NChar);
                //cmd.Parameters["@nrtelefonu"].Value = customer.Nrtelefonu;
                //cmd.ExecuteNonQuery();
                //cmd.Dispose();

                //foreach (Adresy adresy in customerAddressList)
                //{
                //    string connectionString2 = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
                //    SqlConnection cnn2 = new SqlConnection(connectionString);
                //    cnn2.Open();
                //    //dodawanie do bazy
                //    SqlDataAdapter sqlAdresy = new SqlDataAdapter("INSERT INTO Adresy (idAdresy, idKlient, ulica, numerDomu, numerMieszkania, kodPocztowy, miasto) VALUES (NULL, imie, nazwisko, email, nrtelefonu)", cnn2);
                //    string sqlAdresy2 = "SELECT COUNT(*), MAX([id]) FROM Adresy";
                //    cmd1 = new SqlCommand(sqlAdresy2, cnn2);
                //    dataReader = cmd1.ExecuteReader();
                //    int output2 = 0;
                //    while (dataReader.Read())
                //    {
                //        if ((int)dataReader.GetValue(0) != 0)
                //        {
                //            output2 = Convert.ToInt32(dataReader.GetValue(1)) + 1;
                //        }
                //    }
                //    cmd1.Cancel();
                //    dataReader.Close();

                //    SqlCommand cmd3 = new SqlCommand(sqlAdresy.ToString(), cnn);
                //    cmd3.Parameters.Add("@idAdresy", SqlDbType.Int);
                //    cmd3.Parameters["@idAdresy"].Value = output2;

                //    cmd3.Parameters.Add("idKlient", SqlDbType.Int);
                //    cmd3.Parameters["@idKlient"].Value = output1;

                //    cmd3.Parameters.Add("@ulica", SqlDbType.VarChar);
                //    cmd3.Parameters["@ulica"].Value = addressCustomer.Ulica;

                //    cmd3.Parameters.Add("@numerDomu", SqlDbType.VarChar);
                //    cmd3.Parameters["@numerDomu"].Value = addressCustomer.NumerDomu;

                //    cmd3.Parameters.Add("@numerMieszkania", SqlDbType.VarChar);
                //    cmd3.Parameters["@numerMieszkania"].Value = addressCustomer.NumerMieszkania;

                //    cmd3.Parameters.Add("@id_Seat", SqlDbType.VarChar);
                //    cmd3.Parameters["@id_Seat"].Value = addressCustomer.KodPocztowy;

                //    cmd3.Parameters.Add("@kodPocztowy", SqlDbType.VarChar);
                //    cmd3.Parameters["@kodPocztowy"].Value = addressCustomer.Miasto;
                //    cmd3.ExecuteNonQuery();
                //    cmd3.Dispose();
                //    cnn.Close();
                //}

                //wywołanie WYBORU SPOSOBU ZAPŁATY
                DialogResult result = MessageBox.Show("Czy na pewno wprowadziłeś poprawne dane?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ChoosingMethodPayment openForm = new ChoosingMethodPayment(clientList, customerAddressList);
                    //ChoosingMethodPayment openForm = new ChoosingMethodPayment();
                    openForm.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   //wywołanie STRONY GŁOWNEJ
            Home openForm = new Home();
            openForm.ShowDialog();
        }

        private void userAddressStreet_TextChanged(object sender, EventArgs e)
        { }

        private void userAddressApartmentNumber_TextChanged(object sender, EventArgs e)
        { }

        private void userAddressPostalCode_TextChanged(object sender, EventArgs e)
        { }
    }
}
