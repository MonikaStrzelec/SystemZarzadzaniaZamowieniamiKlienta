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
        List<Klient> clientListOK;
        List<Adresy> customerAddressListOK;
        List<Zamowienie> orderListOK;
        List<PozycjaZamowienia> orderItemListOK;
        List<Danie> listOfTheDishesOk;
      

        static string connectionString = ConfigurationManager.ConnectionStrings["Restaurant"].ConnectionString;
        SqlConnection cnn = new SqlConnection(connectionString);
        public ChoosingMethodPayment(List<Klient> clientList, List<Adresy> customerAddressList, List<Danie> listOfTheDishes, List<PozycjaZamowienia> orderItemList, List<Zamowienie> orderList)
        {
            InitializeComponent();
            clientListOK = clientList;
            customerAddressListOK = customerAddressList;
            orderListOK = orderList;
            orderItemListOK = orderItemList;
            listOfTheDishesOk = listOfTheDishes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

                foreach (Zamowienie order in orderListOK)
                {
                    if (radioButton1.Checked)
                    {   //Blik
                        
                        order.OpcjePlatnosci = "Blik";
                        blikPayment openForm = new blikPayment(clientListOK,customerAddressListOK,orderItemListOK,orderListOK,listOfTheDishesOk);
                        openForm.ShowDialog();
                }
                else if (radioButton2.Checked)
                    {   //GOTÓWKA
                        order.OpcjePlatnosci = "Gotówka";
                        OrderStatusTrue openForm = new OrderStatusTrue(clientListOK, customerAddressListOK, orderItemListOK, orderListOK, listOfTheDishesOk);
                        openForm.ShowDialog();

                       
                    }
                    else if (radioButton3.Checked)
                    {   //KARTA PLATNICZA

                        order.OpcjePlatnosci = "Karta płatnicza";
                   
                        cashPayment openForm = new cashPayment(clientListOK, customerAddressListOK, orderItemListOK, orderListOK, listOfTheDishesOk);
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
