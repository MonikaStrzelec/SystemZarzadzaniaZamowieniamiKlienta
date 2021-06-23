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
        public cashPayment()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OrderStatus openForm = new OrderStatus();
            openForm.ShowDialog();
        }
    }
}