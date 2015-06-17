using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MateriaalBeheerSysteem
{
    public partial class CheckOutItem : System.Web.UI.Page
    {
        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();

        List<Item> itemList = new List<Item>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void materialLb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            
        }

        protected void checkBarcode_Click(object sender, EventArgs e)
        {
            if (barcodeTb.Text != "")
            {
                int reservationID = dbHandler.GetReservationByBarcode(barcodeTb.Text);
                if (reservationID != 0)
                {
                    itemList = dbHandler.GetReservedItems(reservationID);

                    int i = 0;

                    foreach (Item item in itemList)
                    {
                        materialLb.Items.Add(item.Name);
                        materialLb.Items[i].Value = item.InstanceNumber.ToString();

                        i++;
                    }
                }
            }
        }
    }
}