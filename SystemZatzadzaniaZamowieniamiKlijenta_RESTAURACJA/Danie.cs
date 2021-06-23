using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    class Danie
    {
        int idDanie, idTypDania;
        string nazwaDania, skladniki;
        decimal cenaDania;

        public int IdDanie
        {
            get
            {
                return idDanie;
            }

            set
            {
                idDanie = value;
            }
        }

        public int IdTypDania
        {
            get
            {
                return idTypDania;
            }

            set
            {
                idTypDania = value;
            }
        }

        public string NazwaDania
        {
            get
            {
                return nazwaDania;
            }

            set
            {
                nazwaDania = value;
            }
        }

        public string Skladniki
        {
            get
            {
                return skladniki;
            }

            set
            {
                skladniki = value;
            }
        }

        public decimal CenaDania
        {
            get
            {
                return cenaDania;
            }

            set
            {
                cenaDania = value;
            }
        }
    }
}
