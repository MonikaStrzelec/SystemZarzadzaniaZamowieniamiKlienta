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
        public ChoosingMethodPayment()
        {
            InitializeComponent();
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
            {//Blik
                blikPayment openForm = new blikPayment();
                openForm.ShowDialog();
            }
            else if (radioButton2.Checked)
            {//GOTÓWKA
                OrderStatus openForm = new OrderStatus();
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
                label2.Text = "";

                if (radioButton1.Checked == true)
                {//GOTOWKA
                    label2.Text = "Sposób płatności: Płatność BLIK";
                }
                if (radioButton2.Checked == true)
                {//BLIK
                    label2.Text = "Sposób płatności: Płatność gotówką";
                }
                if(radioButton3.Checked == true)
                {//KARTA PLATNICZA
                    label2.Text = "Sposób płatności: Kartą płatniczą";
                }

        }
        //public void CreateMyLabel0()
        //{
        //    Label label10 = new Label();
        //    Image image1 = Image.FromFile("D:\\INFORMATYKA\\sem 6\\projektRestauracja\\ikony\\gotowka.jpg");
        //    label10.Size = new Size(image1.Width, image1.Height);
        //    label10.Image = image1;
        //}
    }
}
