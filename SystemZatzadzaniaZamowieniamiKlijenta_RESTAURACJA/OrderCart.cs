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


        public OrderCart()
        {
            InitializeComponent();
        }

        public static string validationTextNoSpecialCharacters(TextBox textValidation)
        {
            var hasSpecialChar = new Regex(@"[\| !#$%&/(:(?»«@£§€{}.-;'<>_,]+"); //Napisy które nie mogą mieć dziwnych znaków
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
        {}

        private void button5_Click(object sender, EventArgs e)
        {

            //WALIDACJA adres
            if (string.IsNullOrWhiteSpace(userAddressStreet.Text))
            {
                MessageBox.Show("Musisz wpisać adres");
            } else
            {
                if (userAddressStreet.Text.Length < 3)
                {
                    MessageBox.Show("Sprawdź swój adres, jest za krótki");
                } else if (userAddressStreet.MaxLength > 50)
                {
                    MessageBox.Show("Sprawdź swój adres, jest za długi");
                } else
                {
                    validationTextNoSpecialCharacters(userAddressStreet);
                }
            }
            

            //WALIDACJA numer ulicy
            if (string.IsNullOrWhiteSpace(userAddressStreetNumber.Text))
            {
                MessageBox.Show("Musisz wpisać numer ulicy");
            } else if (userAddressStreetNumber.MaxLength < 7)
            { 
                MessageBox.Show("Sprawdź swój numer ulicy, chyba jest za długi"); 
            } else
            {
                validationTextNoSpecialCharacters(userAddressStreetNumber);
            }


            //WALIDACJA kod pocztowy
            if (string.IsNullOrWhiteSpace(userAddressPostalCode.Text))
            {
                MessageBox.Show("Musisz wpisać kod pocztowy");
            } else if (userAddressPostalCode.Text.Length > 5 && userAddressPostalCode.MaxLength <= 7)
            {
                MessageBox.Show("Czy na pewno wprowadziłeś poprawny kod pocztowy?");
            } else
            {
                validationTextNoSpecialCharacters(userAddressPostalCode);
            }


            //WALIDACJA miasto
            if (string.IsNullOrWhiteSpace(userAddressCity.Text))
            {
                MessageBox.Show("Musisz wpisać miasto");
                userAddressCity.Focus();
                return;
            } else
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
            } else if (userName.Text.Length > 5 && userName.MaxLength <= 20)
            { 
                MessageBox.Show("Czy na pewno wpisałeś poprawnie swoje imię?");
            } else
            {
                validationTextNoSpecialCharacters(userName);
                validationTextWithoutTheNumber(userName);
            }


            //WALIDACJA nazwisko
            if (string.IsNullOrWhiteSpace(userFamilyName.Text))
            {
                MessageBox.Show("Musisz wpisać swoje nazwisko");
            } else if (userFamilyName.Text.Length > 5 && userFamilyName.MaxLength <= 20)
            {
                MessageBox.Show("Czy na pewno wpisałeś poprawnie nazwisko?");
            } else
            {
                validationTextNoSpecialCharacters(userFamilyName);
                validationTextWithoutTheNumber(userFamilyName);
            }


            //WALIDACJA e-mail
            if (string.IsNullOrWhiteSpace(userEmail.Text))
            {
                MessageBox.Show("Musisz wpisać e-mail");
            } else if (userEmail.Text.Length > 5)
            {
                MessageBox.Show("Czy na pewno wprowadziłeś poprawny email?");
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
