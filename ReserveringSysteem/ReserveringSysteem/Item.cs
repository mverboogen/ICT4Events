using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveringSysteem
{
    class Item
    {
        private int itemid;
        private string itemName;
        private decimal itemPrice;



        public int ItemID
        {
            get{return itemid;}
            set {itemid = value;}
        }

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public decimal ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        public Item(int itemID, string itemName,decimal itemPrice)
        {
            this.itemid = itemID;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
        }
    }
}
