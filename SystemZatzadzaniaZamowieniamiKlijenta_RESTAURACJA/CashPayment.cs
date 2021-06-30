using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    
    public partial class cashPayment : Form
    {
        List<Klient> clientListOK;
        List<Adresy> customerAddressListOK;
        List<Zamowienie> orderListOK;
        List<PozycjaZamowienia> orderItemListOK;
        List<Danie> listOfTheDishesOk;
        public cashPayment(List<Klient> clientList, List<Adresy> customerAddressList, List<PozycjaZamowienia> orderItemList, List<Zamowienie> orderList, List<Danie> listOfTheDishes)
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderStatusTrue openForm = new OrderStatusTrue(clientListOK, customerAddressListOK, orderItemListOK, orderListOK, listOfTheDishesOk);
            openForm.ShowDialog();
        }
    }
}