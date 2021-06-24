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
            int idRow = 0;
            textBox1.Text = totalPrice.ToString();
            foreach (Danie d in listOfTheDishes)
            {
                dataGridView1.Rows.Add(d.NazwaDania, d.CenaDania);
              
                foreach (PozycjaZamowienia o in orderItemList)
                {
                    if (o.IdDania == d.IdDanie)
                    {

                        idRow++;
                        try
                        {                            
                            dataGridView1.Rows[idRow-1].Cells[2].Value = o.IloscKonkretnegoDania;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
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
                    return;
                }
                else
                {
                    if (userAddressStreet.Text.Length < 3)
                    {
                        MessageBox.Show("Sprawdź swój adres, jest za krótki");
                        return;
                    }
                    if (userAddressStreet.MaxLength > 50)
                    {
                        MessageBox.Show("Sprawdź swój adres, jest za długi");
                        return;
                    }
                }

                //WALIDACJA numer ulicy
                if (string.IsNullOrWhiteSpace(userAddressStreetNumber.Text))
                {
                    MessageBox.Show("Musisz wpisać numer ulicy");
                    return;
                }
                if (userAddressStreetNumber.MaxLength < 7)
                {
                    MessageBox.Show("Sprawdź swój numer ulicy, chyba jest za długi");
                    return;
                }
                else
                {
                    //validationTextNoSpecialCharacters(userAddressStreetNumber);
                    //MessageBox.Show("validationTextNoSpecialCharacters numer domu");
                    //return;
                }


                //WALIDACJA kod pocztowy
                if (string.IsNullOrWhiteSpace(userAddressPostalCode.Text))
                {
                    MessageBox.Show("Musisz wpisać kod pocztowy");
                }
                else
                {
                    //validationTextNoSpecialCharacters(userAddressPostalCode);
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
                    return;
                }
                if (userName.Text.Length > 5 && userName.MaxLength <= 20)
                {
                    MessageBox.Show("Czy na pewno wpisałeś poprawnie swoje imię?");
                    return;
                }


                //WALIDACJA nazwisko
                if (string.IsNullOrWhiteSpace(userFamilyName.Text))
                {
                    MessageBox.Show("Musisz wpisać swoje nazwisko");
                    return;
                }
                else if (userFamilyName.Text.Length > 5 && userFamilyName.MaxLength <= 20)
                {
                    MessageBox.Show("Czy na pewno wpisałeś poprawnie nazwisko?");
                    return;
                }


                //WALIDACJA e-mail
                if (string.IsNullOrWhiteSpace(userEmail.Text))
                {
                    MessageBox.Show("Musisz wpisać e-mail");
                    return;
                }
                else if (!this.userEmail.Text.Contains('@') || !this.userEmail.Text.Contains('.'))
                {
                    MessageBox.Show("Wprowadź poprawny adres email");
                    return;
                }



                //WALIDACJA numer telefonu
                if (numericuserPhoneNumber.Value == 0)
                {
                    MessageBox.Show("Musisz wpisać numer telefonu");
                    return;
                }
                else if (numericuserPhoneNumber.Value <= 10)
                {
                    MessageBox.Show("Czy na pewno wprowadziłeś poprawny numer telefonu?");
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

                if (!(string.IsNullOrWhiteSpace(userName.Text)) ||
                    !(string.IsNullOrWhiteSpace(userFamilyName.Text)) ||
                    !(string.IsNullOrWhiteSpace(userEmail.Text)) ||
                    !(string.IsNullOrWhiteSpace(numericuserPhoneNumber.Value.ToString())) ||
                    !(string.IsNullOrWhiteSpace(userAddressStreet.Text)) ||
                    !(string.IsNullOrWhiteSpace(userAddressStreetNumber.Text)) ||
                    !(string.IsNullOrWhiteSpace(userAddressPostalCode.Text)) ||
                    !(string.IsNullOrWhiteSpace(userAddressCity.Text)))
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
        {   
            //Pytanie o rezygnacje i powrót do Strony głównej
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zrezygnować z zamówienia?", "Potwierdzenie", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Home openForm = new Home();
                openForm.ShowDialog();
            }
        }

        private void userAddressStreet_TextChanged(object sender, EventArgs e)
        { }

        private void userAddressApartmentNumber_TextChanged(object sender, EventArgs e)
        { }

        private void userAddressPostalCode_TextChanged(object sender, EventArgs e)
        { }
    }
}
