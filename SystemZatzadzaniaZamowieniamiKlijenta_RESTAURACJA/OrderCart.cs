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
            if (string.IsNullOrWhiteSpace(userAddressStreet.Text))
            {
                MessageBox.Show("Musisz wpisać adres");
                userAddressStreet.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(userAddressPostalCode.Text))
            {
                MessageBox.Show("Musisz wpisać kod pocztowy");
                userAddressPostalCode.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(userAddressCity.Text))
            {
                MessageBox.Show("Musisz wpisać miasto");
                userAddressCity.Focus();
                return;
            }
            else
            {
                String city = "Łódź";
                if (userAddressCity.Text != city)
                {
                    MessageBox.Show("Przykro nam ale nie obsługujemy dostawy po za Łodzią :( ");
                    Home openForm = new Home();
                    openForm.ShowDialog();
                }
                else
                {
                    //wywołanie WYBORU SPOSOBU ZAPŁATY
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
        {
            if (((TextBox)sender).Text.Length < 4)
            {
                MessageBox.Show("Sprawdź swój adres, jest za krótki");
            }
            if (((TextBox)sender).Text.Length > 50)
            {
                MessageBox.Show("Sprawdź swój adres, jest za długi");
            }
        }

        private void userAddressApartmentNumber_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length > 5)
            {
                MessageBox.Show("Czy numer mieszkania nie jest za długi?");
            }
        }

        private void userAddressPostalCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
