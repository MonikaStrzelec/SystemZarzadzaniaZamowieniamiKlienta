using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public partial class OrderCart : Form
    {
        public OrderCart()
        {
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //WALIDACJA adres
            if (string.IsNullOrWhiteSpace(userAddressStreet.Text))
            {
                MessageBox.Show("Musisz wpisać adres");
                if (userAddressStreet.Text.Length < 4)
                {
                    MessageBox.Show("Sprawdź swój adres, jest za krótki");
                } else
                {
                    if (userAddressStreet.Text.Length > 50)
                    {
                        MessageBox.Show("Sprawdź swój adres, jest za długi");
                    }
                }
                return;
            }

            //WALIDACJA numer ulicy
            if (string.IsNullOrWhiteSpace(userAddressStreetNumber.Text))
            {
                MessageBox.Show("Musisz wpisać numer ulicy");
                if (userAddressStreetNumber.Text.Length > 7)
                {
                    MessageBox.Show("Sprawdź swój numer ulicy, chyba jest za długi");
                }
                return;
            }

            //WALIDACJA kod pocztowy
            if (string.IsNullOrWhiteSpace(userAddressPostalCode.Text))
            {
                MessageBox.Show("Musisz wpisać kod pocztowy");
                //userAddressPostalCode.Focus();
                if (userAddressPostalCode.Text.Length > 5 && userAddressPostalCode.Text.Length <= 7)
                {
                    MessageBox.Show("Czy na pewno wprowadziłeś poprawny kod pocztowy?");
                }
                return;
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
                    Home openForm = new Home();
                    openForm.ShowDialog();
                }
                else
                {//wywołanie WYBORU SPOSOBU ZAPŁATY
                    ChoosingMethodPayment openForm = new ChoosingMethodPayment();
                    openForm.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //wywołanie STRONY GŁOWNEJ
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
