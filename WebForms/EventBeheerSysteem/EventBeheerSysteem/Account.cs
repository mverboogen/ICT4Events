using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBeheerSysteem
{
    public class Account
    {

        private int id;
        private int barcodeID;
        private string barcode;
        private string gebruikersnaam;
        private string email;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int BarcodeID
        {
            get { return barcodeID; }
            set { barcodeID = value; }
        }

        public string Barcode
        {
            get { return barcode; }
            set { barcode = value; }
        }

        public string Gebruikersnaam
        {
            get { return gebruikersnaam; }
            set { gebruikersnaam = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}