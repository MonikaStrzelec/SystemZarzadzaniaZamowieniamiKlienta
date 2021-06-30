using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public class Zamowienie
    {
        int idZamowienie, idPromocja;
        DateTime dataZamowienia, czasDostawy;
        string statusZamowienia, opcjePlatnosci, uwagi;       
        decimal kosztCalkowity, kosztDostawy;

        public int IdZamowienie
        {
            get
            {
                return idZamowienie;
            }

            set
            {
                idZamowienie = value;
            }
        }

        public int IdPromocja
        {
            get
            {
                return idPromocja;
            }

            set
            {
                idPromocja = value;
            }
        }

        public string StatusZamowienia
        {
            get
            {
                return statusZamowienia;
            }

            set
            {
                statusZamowienia = value;
            }
        }

        public string OpcjePlatnosci
        {
            get
            {
                return opcjePlatnosci;
            }

            set
            {
                opcjePlatnosci = value;
            }
        }

        public string Uwagi
        {
            get
            {
                return uwagi;
            }

            set
            {
                uwagi = value;
            }
        }

        public decimal KosztCalkowity
        {
            get
            {
                return kosztCalkowity;
            }

            set
            {
                kosztCalkowity = value;
            }
        }

        public decimal KosztDostawy
        {
            get
            {
                return kosztDostawy;
            }

            set
            {
                kosztDostawy = value;
            }
        }

        public DateTime DataZamowienia
        {
            get
            {
                return dataZamowienia;
            }

            set
            {
                dataZamowienia = value;
            }
        }

        public DateTime CzasDostawy
        {
            get
            {
                return czasDostawy;
            }

            set
            {
                czasDostawy = value;
            }
        }
    }
}
