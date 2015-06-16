using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class EventMaterials : System.Web.UI.Page
    {

        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();
        DataChecker checker = DataChecker.GetInstance();

        private Event selEvent;
        private Item selItem;
        private List<Item> itemList;

        private int selectedIndex;

        protected void Page_Load(object sender, EventArgs e)
        {
            selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

            if (selEvent != null)
            {
                itemList = dbHandler.GetAllItems(selEvent.ID);

                if (!IsPostBack)
                {
                    if(itemList != null)
                    {
                        FillData();
                    }

                }
                else
                {
                    selectedIndex = materialsLb.SelectedIndex;
                    if(selectedIndex != -1)
                    {
                        selItem = itemList[selectedIndex];
                    }
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        private void FillData()
        {
            title.InnerText = selEvent.Name + " - Materialen";

            foreach(Item item in itemList)
            {
                materialsLb.Items.Add(item.Name);
            }
        }

        private void FillDetails()
        {
            materialRenterLb.Items.Clear();

            Item i = selItem;

            materialBrandTb.Text = i.Brand;
            materialSerieTb.Text = i.Serie;
            materialTypeNumberTb.Text = i.TypeNumber.ToString();
            materialPriceTb.Text = i.Price.ToString();
            materialItemCountTb.Text = i.Available + " / " + i.Amount;

            foreach(Booker b in i.RenterList)
            {
                materialRenterLb.Items.Add(b.Name);
            }
        }

        protected void addMaterial_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("addMaterial.aspx?EventID=" + selEvent.ID);
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            if(materialsLb.SelectedIndex != -1)
            {
                Item newI = new Item();
                try
                {
                    newI.ID = selItem.ID;
                    newI.Brand = materialBrandTb.Text;
                    newI.Serie = materialSerieTb.Text;
                    newI.Price = Convert.ToDecimal(materialPriceTb.Text.Replace('.', ','));

                    if (checker.ItemChanged(selItem, newI))
                    {
                        if (dbHandler.UpdateItem(newI))
                        {
                            Response.Redirect("EventMaterial.aspx?EventID=" + selEvent.ID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        protected void materialsLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = materialsLb.SelectedIndex;

            if (selectedIndex != -1)
            {
                selItem = itemList[selectedIndex];
            }

            FillDetails();
        }

        protected void addRenter_Click(object sender, EventArgs e)
        {
            if(materialsLb.SelectedIndex != -1)
            {
                if (selItem.Available > 0)
                {
                    Response.Redirect("AddRenterToItem.aspx?EventID=" + selEvent.ID + "&ItemID=" + selItem.ID);
                }
            }
        }
    }
}