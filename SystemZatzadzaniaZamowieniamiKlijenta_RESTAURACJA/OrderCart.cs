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
            var hasSpecialChar = new Regex(@"[\| !#$%&/(:(?»«@£§€{}.-;'<>_,]+"); //Napisy które nie mogą mieć dziwnych znaków
            if (hasSpecialChar.IsMatch(textValidation.Text))
            {
                MessageBox.Show("Wpisz poprawne dane!", "Niepoprawne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return textValidation.Text;
        }
        public static string validationTextWithoutTheNumber(TextBox textValidation)
        {
            var hasNumber = new Regex(@"[0-9]+"); //Napisy które nie mogą mieć liczb
            if (hasNumber.IsMatch(textValidation.Text))
            {
                MessageBox.Show("Wpisz poprawne dane!", "Niepoprawne dane", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return textValidation.Text;
        }

        private void label14_Click(object sender, EventArgs e)
        {}

        private void button5_Click(object sender, EventArgs e)
        {   //WALIDACJA adres
            if (string.IsNullOrWhiteSpace(userAddressStreet.Text))
            {
                MessageBox.Show("Musisz wpisać adres");
                if (userAddressStreet.Text.Length < 4)
                {
                    MessageBox.Show("Sprawdź swój adres, jest za krótki");
                } else
                {
                    if (userAddressStreet.MaxLength > 50)
                    {
                        MessageBox.Show("Sprawdź swój adres, jest za długi");
                    }
                }
                return;
            } else
            {
                validationTextNoSpecialCharacters(userAddressStreet);
                validationTextWithoutTheNumber(userAddressStreet);
            }


            //WALIDACJA numer ulicy
            if (string.IsNullOrWhiteSpace(userAddressStreetNumber.Text))
            {
                MessageBox.Show("Musisz wpisać numer ulicy");
                if (userAddressStreetNumber.MaxLength > 7)
                {
                    MessageBox.Show("Sprawdź swój numer ulicy, chyba jest za długi");
                }
                return;
            }
            else
            {
                validationTextNoSpecialCharacters(userAddressStreetNumber);
            }

            //WALIDACJA kod pocztowy
            if (string.IsNullOrWhiteSpace(userAddressPostalCode.Text))
            {
                MessageBox.Show("Musisz wpisać kod pocztowy");
                //userAddressPostalCode.Focus();
                if (userAddressPostalCode.Text.Length > 5 && userAddressPostalCode.MaxLength <= 7)
                {
                    MessageBox.Show("Czy na pewno wprowadziłeś poprawny kod pocztowy?");
                }
                return;
            }
            else
            {
                validationTextNoSpecialCharacters(userAddressStreet);
                validationTextWithoutTheNumber(userAddressStreet);
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
                //userAddressPostalCode.Focus();
                if (userAddressPostalCode.Text.Length > 5 && userAddressPostalCode.MaxLength <= 20)
                {
                    MessageBox.Show("Czy na pewno wpisałeś poprawnie swoje imię?");
                }
                else
                {
                    validationTextNoSpecialCharacters(userName);
                    validationTextWithoutTheNumber(userName);
                }
            }

            //WALIDACJA nazwisko
            if (string.IsNullOrWhiteSpace(userFamilyName.Text))
            {
                MessageBox.Show("Musisz wpisać swoje nazwisko");
                //userAddressPostalCode.Focus();
                if (userAddressPostalCode.Text.Length > 5 && userAddressPostalCode.MaxLength <= 20)
                {
                    MessageBox.Show("Czy na pewno wpisałeś poprawnie nazwisko?");
                }
                else
                {
                    validationTextNoSpecialCharacters(userFamilyName);
                    validationTextWithoutTheNumber(userFamilyName);
                }
            }

            //WALIDACJA e-mail
            if (string.IsNullOrWhiteSpace(userEmail.Text))
            {
                MessageBox.Show("Musisz wpisać e-mail");
                //userAddressPostalCode.Focus();
                if (userAddressPostalCode.Text.Length > 5 && userAddressPostalCode.MaxLength <= 7)
                {
                    MessageBox.Show("Czy na pewno wprowadziłeś poprawny kod pocztowy?");
                }
            } else
            {
                if (!this.userEmail.Text.Contains('@') || !this.userEmail.Text.Contains('.'))
                {
                    MessageBox.Show("Wprowadź poprawny adres email", "Niepoprawny adres email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            //WALIDACJA numer telefonu
            if (string.IsNullOrWhiteSpace(numericuserPhoneNumber.Text))
            {
                MessageBox.Show("Musisz wpisać numer telefonu");
                //userAddressPostalCode.Focus();
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

            //wywołanie WYBORU SPOSOBU ZAPŁATY
            ChoosingMethodPayment openForm = new ChoosingMethodPayment();
            openForm.ShowDialog();

        }

        private void button1_Click(object sender, EventArgs e)
        {   //wywołanie STRONY GŁOWNEJ
            Home openForm = new Home();
            openForm.ShowDialog();
        }

        private void userAddressStreet_TextChanged(object sender, EventArgs e)
        {}

        private void userAddressApartmentNumber_TextChanged(object sender, EventArgs e)
        {}

        private void userAddressPostalCode_TextChanged(object sender, EventArgs e)
        {}
    }
}
