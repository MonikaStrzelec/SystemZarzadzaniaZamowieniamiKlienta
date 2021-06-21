﻿using System;
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
        public ChoosingMethodPayment()
        {
            InitializeComponent();

            if (radioButton1.Checked)
            {//GOTOWKA
                label2.Text = "Sposób płatności: Płatność gotówką";
            }
            else if (radioButton2.Checked)
            {//BLIK
                label2.Text = "Sposób płatności: BLIK";
            }
            else if (radioButton3.Checked)
            {//KARTA PLATNICZA
                label2.Text = "Sposób płatności: Kartą płatniczą";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //wywołanie STRONY GŁOWNEJ
            Home openForm = new Home();
            openForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //REZYGNACJA z zamówienia
            DialogResult result = MessageBox.Show("Czy na pewno chcesz zrezygnować z zamówienie?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Płatność anulowana.");
                this.Hide();
                Home openForm = new Home();
                openForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {//GOTOWKA
                cashPayment openForm = new cashPayment();
                openForm.ShowDialog();
            }
            else if (radioButton2.Checked)
            {//BLIK
                blikPayment openForm = new blikPayment();
                openForm.ShowDialog();
            }
            else if (radioButton3.Checked)
            {//KARTA PLATNICZA

            }
            else
            {//brak zaznaczonej płatności
                DialogResult result = MessageBox.Show("Musisz wybrać petodę płatności!", "Confirmation", MessageBoxButtons.YesNo);
            }
        }
    }
}
