using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public partial class OrderStatus : Form
    {
        int timeLeft; //zmienna śledząca pozostały czas

        public OrderStatus()
        {
            InitializeComponent();
        }

        private void OrderStatus_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {   //wyświetla aktualny czas
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " sekund";
            }
            else
            {
                // Jeśli użytkownikowi zabrakło czasu, zatrzymaj minutnik, pokaż
                timer1.Stop();
                timeLabel.Text = "Czas minął!";
                MessageBox.Show("Jeśli nie dostałes swojego jedzenia to Przepraszamy!.", "Możesz skontaktować się z restauracja by dowiedzieć się za ile dotrze jedzenie!");
                startButton.Enabled = true;
            }
        }
        public void StartTheQuiz()
        {
            // Uruchom timer.
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
    }
}
