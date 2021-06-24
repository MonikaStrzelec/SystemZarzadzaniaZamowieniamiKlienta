using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    class Promocja
    {
        int idPromocja;
        string nazwaPromocji, opisPromocji;
       


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


        public string NazwaPromocji
        {
            get
            {
                return nazwaPromocji;
            }

            set
            {
                nazwaPromocji = value;
            }
        }

        public string OpisPromocji
        {
            get
            {
                return opisPromocji;
            }

            set
            {
                opisPromocji = value;
            }
        }

    }
}
