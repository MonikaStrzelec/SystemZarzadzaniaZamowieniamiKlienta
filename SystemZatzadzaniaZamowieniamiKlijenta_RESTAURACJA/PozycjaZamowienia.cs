using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    class PozycjaZamowienia
    {
        int idPromocjeZamowienia, idZamowienie, idDania, idKlient, iloscKonkretnegoDania;

        public int IdPromocjeZamowienia
        {
            get
            {
                return idPromocjeZamowienia;
            }

            set
            {
                idPromocjeZamowienia = value;
            }
        }

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

        public int IdDania
        {
            get
            {
                return idDania;
            }

            set
            {
                idDania = value;
            }
        }

        public int IdKlient
        {
            get
            {
                return idKlient;
            }

            set
            {
                idKlient = value;
            }
        }
        public int IloscKonkretnegoDania
        {
            get
            {
                return iloscKonkretnegoDania;
            }

            set
            {
                iloscKonkretnegoDania = value;
            }
        }



    }
}
