using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public class Adresy
    {
        int idAdres, idKlient;
        string ulica, numerDomu, numerMieszkania, kodPocztowy, miasto;


        public int IdAdres
        {
            get { return idAdres; } 
            set { idAdres = value; }
        }
        public int IdKlient
        {
            get { return idKlient; } 
            set { idKlient = value; }
        }

        public string Ulica
        {
            get { return ulica; }
            set { ulica = value; }
        }
        public string NumerDomu
        {
            get { return numerDomu; }
            set { numerDomu = value; }
        }
        public string NumerMieszkania
        {
            get { return numerMieszkania; }
            set { numerMieszkania = value; }
        }
        public string KodPocztowy
        {
            get { return kodPocztowy; }
            set { kodPocztowy = value; }
        }
        public string Miasto
        {
            get { return miasto; }
            set { miasto = value; }
        }
    }
}
