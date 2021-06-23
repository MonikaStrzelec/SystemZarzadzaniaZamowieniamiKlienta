using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public partial class OrderStatusTrue : Form
    {
        int timeLeft; //zmienna śledząca pozostały czas

        public OrderStatusTrue()
        {
            InitializeComponent();
            StartTimer();
        }

        public void StartTimer()
        {   // Uruchom timer.
            timeLeft = 3000; //50 minut: 60=1min
            timeLabel.Text = timeLeft / 60 + " : " + ((timeLeft % 60) >= 10 ? (timeLeft % 60).ToString() : "0" + (timeLeft % 60));
            timer1.Start();
        }
        private void OrderStatus_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {   //wyświetla aktualny czas
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft / 60 + " : " + ((timeLeft % 60) >= 10 ? (timeLeft % 60).ToString() : "0" + (timeLeft % 60));
            }
            else
            {   // Jeśli użytkownikowi zabrakło czasu, zatrzymaj minutnik, pokaż
                timer1.Stop();
                timeLabel.Text = "Czas na dostawę minął!";
                MessageBox.Show("Jeśli nie dostałes swojego jedzenia to Przepraszamy!.", "Możesz skontaktować się z restauracja by dowiedzieć się za ile dotrze jedzenie!");
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {   //dostawa dostarczona
            timer1.Stop();
            MessageBox.Show("SMACZNEGO!", "Zapraszamy ponownie!");
            Home openForm = new Home();
            openForm.ShowDialog();
        }
    }
}
