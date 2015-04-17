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
        private int quantity;


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

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Item(int itemID, string itemName,decimal itemPrice, int quantity)
        {
            this.itemid = itemID;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.quantity = quantity;
        }
    }
}
