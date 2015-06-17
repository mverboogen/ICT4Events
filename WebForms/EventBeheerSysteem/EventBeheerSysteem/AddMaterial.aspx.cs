using System;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class AddMaterial : System.Web.UI.Page
    {
        
        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();

        private List<Categorie> categorieList = new List<Categorie>();

        private Event selEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["EventID"] != null)
            {
                selEvent = dbHandler.GetEventByID(Convert.ToInt32(Request.QueryString["EventID"]));

                if (selEvent != null)
                {
                    categorieList = dbHandler.GetAllCategories();

                    if (!IsPostBack)
                    {
                        FillTable();
                    }
                }
            }
            else
            {
                Response.Redirect("404.aspx");
            }
        }

        /// <summary>
        /// Fills the DropDownList with all the categories
        /// </summary>
        private void FillTable()
        {
            materiaalCategorieDDL.Items.Clear();
            int i = 0;

            foreach(Categorie cat in categorieList)
            {
                materiaalCategorieDDL.Items.Add(cat.Name);
                materiaalCategorieDDL.Items[i].Value = cat.ID.ToString();

                i++;
            }
        }

        /// <summary>
        /// Saves the new item with a database handler methode
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Arguments</param>
        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            if(materialBrandTb.Text != "" && materialSerieTb.Text != "" && materialPriceTb.Text != "")
            {
                try
                {
                    string brand = materialBrandTb.Text;
                    string serie = materialSerieTb.Text;
                    decimal price = Convert.ToDecimal(materialPriceTb.Text.Replace('.', ','));
                    int catID = Convert.ToInt32(materiaalCategorieDDL.Items[materiaalCategorieDDL.SelectedIndex].Value);

                    int amount = Convert.ToInt32(materialAmountTb.Text);

                    Item item = new Item(brand, serie, price, catID);

                    if(dbHandler.AddMaterial(item, amount))
                    {
                        Response.Redirect("EventMaterials.aspx?EventID=" + selEvent.ID);
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        protected void addCategorie_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("AddCategorie.aspx?EventID=" + selEvent.ID);
        }
    }
}