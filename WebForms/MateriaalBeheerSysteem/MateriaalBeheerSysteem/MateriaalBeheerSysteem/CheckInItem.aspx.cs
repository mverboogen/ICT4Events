using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MateriaalBeheerSysteem
{
    public partial class CheckInItem : System.Web.UI.Page
    {
        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();

        List<Item> itemList = new List<Item>();
        Item selItem = new Item();

        int selectedInstanceItemID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (barcodeTb.Text != "")
            {
                int reservationID = dbHandler.GetReservationByBarcode(barcodeTb.Text);
                if (reservationID != 0)
                {
                    itemList = dbHandler.GetReservedItems(reservationID);

                    if (itemList != null)
                    {
                        FillTable();
                    }
                    else
                    {
                        materialLb.Items.Clear();
                    }
                }
                else
                {
                    materialLb.Items.Clear();
                }
            }

            if (materialLb.SelectedIndex != -1)
            {
                selectedInstanceItemID = Convert.ToInt32(materialLb.SelectedValue);
            }
        }

        protected void materialLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialLb.SelectedIndex != -1)
            {
                selItem = itemList[materialLb.SelectedIndex];
                itemInstanceNameTb.Text = selItem.Name;
                iteminstanceTypeNumberTb.Text = selItem.TypeNumber.ToString();
                itemInstanceBarcodeTb.Text = selItem.Barcode;
                itemInstancePayedCb.Checked = selItem.Payed;
                if (selItem.DateOut != DateTime.MinValue)
                {
                    itemInstanceDateOutTb.Text = selItem.DateOut.ToShortDateString() + " - " + selItem.DateOut.ToShortTimeString();
                }
                else
                {
                    itemInstanceDateOutTb.Text = "";
                }
                if (selItem.DateIn != DateTime.MinValue)
                {
                    itemInstanceDateInTb.Text = selItem.DateIn.ToShortDateString() + " - " + selItem.DateIn.ToShortTimeString();
                }
                else
                {
                    itemInstanceDateInTb.Text = "";
                }
            }
        }

        protected void checkInBtn_Click(object sender, EventArgs e)
        {
            if(itemInstanceDateOutTb.Text != "")
            {
                if (dbHandler.UpdateItemCheckIn(selectedInstanceItemID))
                {
                    itemInstanceDateInTb.Text = DateTime.Now.ToShortDateString() + " - " + DateTime.Now.ToShortTimeString();
                    selItem.DateIn = DateTime.Now;
                }
            }
            
        }

        protected void PayBtn_Click(object sender, EventArgs e)
        {
            if (dbHandler.UpdateItemPayed(selectedInstanceItemID, 1))
            {
                itemInstancePayedCb.Checked = true;
                selItem.Payed = true;
            }
        }

        protected void checkBarcode_Click(object sender, EventArgs e)
        {
            materialLb.SelectedIndex = -1;
            itemInstanceBarcodeTb.Text = "";
            itemInstanceDateInTb.Text = "";
            itemInstanceDateOutTb.Text = "";
            itemInstanceNameTb.Text = "";
            iteminstanceTypeNumberTb.Text = "";
            itemInstancePayedCb.Checked = false;
        }

        private void FillTable()
        {
            if (materialLb.SelectedIndex == -1)
            {
                materialLb.Items.Clear();

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