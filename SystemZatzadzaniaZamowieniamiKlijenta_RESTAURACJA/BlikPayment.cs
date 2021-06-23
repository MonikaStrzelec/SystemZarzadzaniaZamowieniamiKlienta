using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public partial class blikPayment : Form
    {
        public blikPayment()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {}

        private void blikPayment_Load(object sender, EventArgs e)
        {
            var random = new Random();
            int liczba = random.Next(100000, 999999);
            label3.Text = liczba.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value.ToString() == label3.Text)
            {
                MessageBox.Show("Płatność została zatwierdzona");
                this.Close();
                OrderStatusTrue openForm = new OrderStatusTrue();
                openForm.ShowDialog();
            } else
            {
                MessageBox.Show("Wprowadziełeś niepoprawny kod blik");
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
