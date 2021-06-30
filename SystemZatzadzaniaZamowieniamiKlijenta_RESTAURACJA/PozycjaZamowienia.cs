using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public class PozycjaZamowienia
    {
        int idPozycjaZamowienia, idZamowienie, idDania, idKlient, iloscKonkretnegoDania;

        public int IdPozycjaZamowienia
        {
            get
            {
                return idPozycjaZamowienia;
            }

            set
            {
                idPozycjaZamowienia = value;
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
