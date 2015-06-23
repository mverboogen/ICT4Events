using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace ReserveringSysteem
{
    public partial class Index : Page
    {
        private DatabaseHandler handler = DatabaseHandler.GetInstance();
        private HashGenerator hashGenerator = new HashGenerator();
        private AdHandlerAm handleram = new AdHandlerAm();

        private List<Account> accounts
        {
            get
            {
                object obj3 = Session["AccountList"];
                if (obj3 == null)
                {
                    obj3 = Session["AccountList"] = new List<Account>();
                }
                return (List<Account>) obj3;
            }

            set { Session["AccountList"] = value; }
        }

        private List<Item> ReserveerItems
        {
            get
            {
                object obj1 = Session["ItemList"];
                if (obj1 == null)
                {
                    obj1 = Session["ItemList"] = new List<Item>();
                }
                return (List<Item>) obj1;
            }

            set { Session["ItemList"] = value; }
        }

        private List<Campsite> ReserveerCampsites
        {
            get
            {
                object obj2 = Session["CampsiteList"];
                if (obj2 == null)
                {
                    obj2 = Session["CampsiteList"] = new List<Campsite>();
                }
                return (List<Campsite>) obj2;
            }

            set { Session["CampsiteList"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                handler.GetAllCampsites();
                handler.GetAllItems();
                RefreshListbox();
            }
        }

        /// <summary>
        ///     Confirms reservation, sends all data to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btBevestigen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbVoornaam.Text) || string.IsNullOrWhiteSpace(tbAchternaam.Text))
            {
                lblReservationConfirm.Text =
                    "Waarschuwing: Controleer of alle informatie van de reserveerder correct is ingevuld";
            }
            else
            {
                DateTime startEvent = new DateTime(2015, 06, 01);
                DateTime endEvent = new DateTime(2015, 06, 30);

                string dateIn = cBeginDate.SelectedDate.ToString("dd/MM/yy");
                string dateOut = cEndDate.SelectedDate.ToString("dd/MM/yy");

                DateTime startRes = cBeginDate.SelectedDate;
                DateTime endRes = cEndDate.SelectedDate;

                if (cBeginDate.SelectedDate > cEndDate.SelectedDate || startRes < startEvent || startRes > endEvent ||
                    endRes < startEvent || endRes > endEvent)
                {
                    lblReservationConfirm.Text = "Waarschuwing: Controleer de data";
                }
                else
                {
                    string voornaam = tbVoornaam.Text;
                    string tussenvoegsel = tbTussenvoegsel.Text;
                    string achternaam = tbAchternaam.Text;
                    string straat = tbStraat.Text;
                    string huisNr = tbHuisNr.Text;
                    string woonplaats = tbWoonplaats.Text;
                    string bankNr = tbBankNr.Text;

                    handler.AddPerson(voornaam, tussenvoegsel, achternaam, straat, huisNr, woonplaats, bankNr);

                    handler.AddReservering(dateIn, dateOut);

                    foreach (Account a in accounts)
                    {
                        
                        handler.AddPolsbandje();
                        handler.AddAccount(a.Username, a.Email, a.Hash);
                        handler.AddReserveringPolsbandje();

                        handleram.CreateUser(a.Username, "password");

                        SendEmail(a.Username, a.Email, a.Hash);     
                    }

                    foreach (Campsite c in ReserveerCampsites)
                    {
                        handler.AddPlekReservering(c.Id);
                    }

                    foreach (Item i in ReserveerItems)
                    {
                        handler.AddVerhuur(i.Id, dateIn, dateOut);
                    }

                    Response.Redirect("~/Pages/ReservationConfirm.aspx");
                }
            }
        }

        /// <summary>
        ///     Add a account to the visitor list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btToevoegen_Click(object sender, EventArgs e)
        {
            string gebruikersnaam = tbGebruikersnaam.Text;
            string email = tbEmail.Text;

            if (string.IsNullOrWhiteSpace(tbGebruikersnaam.Text) || string.IsNullOrWhiteSpace(tbEmail.Text))
            {
                lblAccountConfirm.Text = "Niet alle informatie is correct ingevuld";
            }
            else
            {
                string hash = hashGenerator.GenerateToken(32);
                Account account = new Account(gebruikersnaam, email, hash);

                accounts.Add(account);

                lblAccountConfirm.Text = "Account toegevoegd";
            }

            gvAccounts.DataSource = accounts;
            gvAccounts.DataBind();
        }

        /// <summary>
        ///     Fils all listboxes
        /// </summary>
        public void RefreshListbox()
        {
            lbCampsites.Items.Clear();
            lbItems.Items.Clear();
            lbResCampsites.Items.Clear();
            lbResItems.Items.Clear();

            foreach (Campsite c in handler.CampsiteList)
            {
                lbCampsites.Items.Add(c.ToString());
            }

            foreach (Item i in handler.ItemList)
            {
                lbItems.Items.Add(i.ToString());
            }

            foreach (Campsite c in ReserveerCampsites)
            {
                lbResCampsites.Items.Add(c.ToString());
            }

            foreach (Item i in ReserveerItems)
            {
                lbResItems.Items.Add(i.ToString());
            }
        }

        /// <summary>
        ///     Calls method to add a campsite to the list of reserved campsites
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btAddCampsite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCampsiteID.Text))
            {
                lblCampsiteConfirm.Text = "Er is geen campsite ingevuld";
            }
            else
            {
                if (Regex.IsMatch(tbCampsiteID.Text, "[^0-9]"))
                {
                    lblCampsiteConfirm.Text = "Vul een getal in";
                }
                else
                {
                    int campId = Convert.ToInt32(tbCampsiteID.Text);

                    Campsite id = AddCampsite(campId);
                }
            }
            RefreshListbox();
        }

        /// <summary>
        ///     Calls method to add a item to the list of reserved items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btAddItems_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbItemID.Text))
            {
                lblItemConfirm.Text = "Er is geen item ingevuld";
            }
            else
            {
                if (Regex.IsMatch(tbItemID.Text, "[^0-9]"))
                {
                    lblItemConfirm.Text = "Vul een getal in";
                }
                else
                {
                    int itemID = Convert.ToInt32(tbItemID.Text);

                    Item id = AddItem(itemID);
                }
            }
            RefreshListbox();
        }

        /// <summary>
        ///     Calls method to add item to the list of reserved items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btRemoveItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbItemID.Text))
            {
                lblItemConfirm.Text = "Er is geen item ingevuld";
            }
            else
            {
                if (Regex.IsMatch(tbItemID.Text, "[^0-9]"))
                {
                    lblItemConfirm.Text = "Vul een getal in";
                }
                else
                {
                    Item removeI = FindReservedItem(Convert.ToInt32(tbItemID.Text));
                    RemoveItem(removeI);
                }
            }
        }

        /// <summary>
        ///     Calls method to remove a campsite from the list of reserved campsites
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btRemoveCampsite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCampsiteID.Text))
            {
                lblCampsiteConfirm.Text = "Er is geen campsite ingevuld";
            }
            else
            {
                if (Regex.IsMatch(tbCampsiteID.Text, "[^0-9]"))
                {
                    lblCampsiteConfirm.Text = "Vul een getal in";
                }
                else
                {
                    Campsite removeCS = FindReservedCampsite(Convert.ToInt32(tbCampsiteID.Text));
                    RemoveCampsite(removeCS);
                }
            }
        }

        /// <summary>
        ///     Checks if the campsite exists in the list of available campsites
        /// </summary>
        /// <param name="campID"></param>
        /// <returns></returns>
        private Campsite FindCampsite(int campID)
        {
            foreach (Campsite campsite in ReserveerCampsites)
            {
                if (campsite.Id == campID)
                {
                    return campsite;
                }
            }
            lblCampsiteConfirm.Text = "Dit nummer bestaat niet";
            return null;
        }

        /// <summary>
        ///     Checks if the campsite exists in the list of reserved campsites
        /// </summary>
        /// <param name="campID"></param>
        /// <returns></returns>
        private Campsite FindReservedCampsite(int campID)
        {
            foreach (Campsite c in ReserveerCampsites)
            {
                if (c.Id == campID)
                {
                    lblCampsiteConfirm.Text = "Campsite verwijderd";
                    return c;
                }
            }
            lblCampsiteConfirm.Text = "Dit nummer bestaat niet";
            return null;
        }

        /// <summary>
        ///     Adds a campsite to the list of reserved campsites
        /// </summary>
        /// <param name="campID"></param>
        /// <returns></returns>
        private Campsite AddCampsite(int campID)
        {
            foreach (Campsite c in handler.CampsiteList)
            {
                if (c.Id == campID)
                {
                    Campsite cs = new Campsite(campID);

                    ReserveerCampsites.Add(cs);

                    lblCampsiteConfirm.Text = "Campsite toegevoegd";
                    return c;
                }
            }
            lblCampsiteConfirm.Text = "Dit nummer bestaat niet";
            return null;
        }

        /// <summary>
        ///     Removes a campsite from the list of reserved campsites
        /// </summary>
        /// <param name="c"></param>
        private void RemoveCampsite(Campsite c)
        {
            ReserveerCampsites.Remove(c);
            RefreshListbox();
        }

        /// <summary>
        ///     Checks if the item exists in the list of available campsites
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        private Item FindItem(int itemID)
        {
            foreach (Item item in handler.ItemList)
            {
                if (item.Id == itemID)
                {
                    return item;
                }
            }
            lblItemConfirm.Text = "Dit nummer bestaat niet";
            return null;
        }

        /// <summary>
        ///     Add a item to the list of reserved items
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        private Item AddItem(int itemID)
        {
            foreach (Item i in handler.ItemList)
            {
                if (i.Id == itemID)
                {
                    Item item = new Item(itemID);

                    ReserveerItems.Add(item);

                    lblItemConfirm.Text = "Item toegevoegd";
                    return i;
                }
            }
            lblItemConfirm.Text = "Dit nummer bestaat niet";
            return null;
        }

        /// <summary>
        ///     Checks if the item is in the list of reserved items
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        private Item FindReservedItem(int itemID)
        {
            foreach (Item i in ReserveerItems)
            {
                if (i.Id == itemID)
                {
                    lblItemConfirm.Text = "Item verwijderd";
                    return i;
                }
            }
            lblItemConfirm.Text = "Dit nummer bestaat niet";
            return null;
        }

        /// <summary>
        ///     Removes a item from the list of reserved items
        /// </summary>
        /// <param name="i"></param>
        private void RemoveItem(Item i)
        {
            ReserveerItems.Remove(i);
            RefreshListbox();
        }

        /// <summary>
        ///     Sends a email with username and hash to activate account to every account in reservation
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="hash"></param>
        private void SendEmail(string username, string email, string hash)
        {
            SmtpClient client = new SmtpClient("smtp.bedrijfs86.com");
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress("ticketmaster@bedrijfs86.com");

            Message.To.Add(email);
            Message.Body = "Hartelijk dank voor het reserveren," + Environment.NewLine + Environment.NewLine +
                           "Uw gebruikersnaam is:" + Environment.NewLine + username + Environment.NewLine +
                           Environment.NewLine + "Uw activatie code is:" + Environment.NewLine + hash +
                           Environment.NewLine + Environment.NewLine +
                           "Om uw account te activeren gaat u naar www.bedrijfs86.com/rs/pages/activation.aspx" + Environment.NewLine +
                           Environment.NewLine + "Ict4Events groep D";
            Message.Subject = "Activering account";
            client.Credentials = new NetworkCredential("ticketmaster@bedfijs86.com", "password");
            client.Port = Convert.ToInt32(25);
            client.EnableSsl = false;
            client.Send(Message);
        }
    }
}