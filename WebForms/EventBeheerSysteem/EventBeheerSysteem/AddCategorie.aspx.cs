using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventBeheerSysteem
{
    public partial class AddCategorie : System.Web.UI.Page
    {
        List<Categorie> categorieList = new List<Categorie>();

        DatabaseHandler dbHandler = DatabaseHandler.GetInstance();

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
                        FillData();
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
            categorieSubCategorieDDL.Items.Clear();

            int i = 1;

            categorieSubCategorieDDL.Items.Add("Geen");
            categorieSubCategorieDDL.Items[0].Value = "0";

            foreach(Categorie c in categorieList)
            {
                categorieSubCategorieDDL.Items.Add(c.Name);
                categorieSubCategorieDDL.Items[i].Value = c.ID.ToString();

                i++;
            }
        }

        protected void saveBtn_OnClick(object sender, EventArgs e)
        {
            Categorie cat = new Categorie();
            cat.Name = categorieNameTb.Text;
            if(categorieSubCategorieDDL.SelectedIndex != -1 && categorieSubCategorieDDL.SelectedIndex != 0)
            {
                cat.SubID = Convert.ToInt32(categorieSubCategorieDDL.Items[categorieSubCategorieDDL.SelectedIndex].Value);
            }

            if(dbHandler.AddCategorie(cat))
            {
                Response.Redirect("AddMaterial.aspx");
            }
        }
    }
}