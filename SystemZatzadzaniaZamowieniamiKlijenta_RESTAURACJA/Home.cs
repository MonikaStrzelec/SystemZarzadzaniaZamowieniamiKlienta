using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public partial class Home : Form
    {
        

        public Home()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        { //wywołanie KOSZYKA ZAMÓWIEŃ
            OrderCart openForm = new OrderCart();
            openForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        { //wywołanie KONTAKTÓW do restauracji
            RestaurantContactDetails openForm = new RestaurantContactDetails();
            openForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //wywołanie AKTUALNYCH PROMOCJI
            Sale openForm = new Sale();
            openForm.ShowDialog();
        }
    }
}
