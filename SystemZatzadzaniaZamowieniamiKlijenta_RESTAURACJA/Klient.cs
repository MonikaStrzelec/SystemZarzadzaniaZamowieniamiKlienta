using System;
using System.Collections.Generic;
using System.Text;

namespace SystemZatzadzaniaZamowieniamiKlijenta_RESTAURACJA
{
    public class Klient
    {
        int idKlient, nrtelefonu;
        string imie, nazwisko, email, komentarz;
        DateTime czasDostawy;

        public int IdKlient
        {
            get { return idKlient; }
            set { idKlient = value; }
        }

        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Nrtelefonu
        {
            get { return nrtelefonu; }
            set { nrtelefonu = value; }
        }
        public string Komentarz
        {
            get { return komentarz; }
            set { komentarz = value; }
        }
        public DateTime CzasDostawy
        {
            get { return czasDostawy; }
            set { czasDostawy = value; }
        }
    }
}