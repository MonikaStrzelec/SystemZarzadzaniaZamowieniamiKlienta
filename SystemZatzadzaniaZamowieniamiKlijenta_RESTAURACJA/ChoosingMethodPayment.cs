using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public partial class ChoosingMethodPayment : Form
    {
        //public ChoosingMethodPayment(List<Klient> clientList, List<Adresy> customerAddressList)
        //{
        //    InitializeComponent();
        //}
        public ChoosingMethodPayment()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {   //wywołanie STRONY GŁOWNEJ
            Home openForm = new Home();
            openForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {   //REZYGNACJA z zamówienia
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zrezygnować z zamówienie?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Płatność anulowana.");
                //ZEROWANIE KOSZYKA?
                this.Hide();
                Home openForm = new Home();
                openForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {//Blik
                blikPayment openForm = new blikPayment();
                openForm.ShowDialog();
            }
            else if (radioButton2.Checked)
            {//GOTÓWKA
                OrderStatusTrue openForm = new OrderStatusTrue();
                openForm.ShowDialog();
            }
            else if (radioButton3.Checked)
            {//KARTA PLATNICZA
                cashPayment openForm = new cashPayment();
                openForm.ShowDialog();
            }
            else
            {//brak zaznaczonej płatności
                DialogResult result = MessageBox.Show("Musisz wybrać petodę płatności!", "Confirmation", MessageBoxButtons.YesNo);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ChoosingMethodPayment_Load(object sender, EventArgs e)
        {

        }

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
