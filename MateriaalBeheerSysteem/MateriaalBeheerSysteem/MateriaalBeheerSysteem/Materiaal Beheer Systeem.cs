using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriaalBeheerSysteem
{
    public partial class Form1 : Form
    {

        private int eventID = 1;

        private ItemManager itemManager = new ItemManager();
        private VisitorManager visitorManager = new VisitorManager();
        private ReservationManager reservationManager = new ReservationManager();
        private CampSiteManager campsiteManager = new CampSiteManager();

        private DatabaseManager databaseHandler = new DatabaseManager();

        private Item selectedItem;

        public Form1()
        {
            InitializeComponent();
            RetrieveData();
            ClearDetails();
            FillData();
        }

        private void ClearDetails()
        {
            tbName.Clear();
            tbPrice.Clear();
            tbDailyRent.Clear();
            tbAvailible.Clear();

            lboxMaterialRenters.Items.Clear();
        }

        private void RetrieveData()
        {
            itemManager.itemList = databaseHandler.GetAllItems(eventID);
            reservationManager.reservationList = databaseHandler.GetAllReservations(eventID);
            visitorManager.visitorList = databaseHandler.GetAllVisitors(eventID);
            campsiteManager.campSiteList = databaseHandler.GetAllCampSites(eventID);

            foreach (Reservation reservation in reservationManager.reservationList)
            {

                reservation.Booker = databaseHandler.GetBooker(eventID, reservation.ID);
                reservation.BookerID = reservation.Booker.ID;

                if (reservation.ReservedItemID != null)
                {
                    List<int> itemIDs = databaseHandler.GetReserverdItems(eventID, reservation.ID);
                    foreach (int itemID in itemIDs)
                    {
                        foreach (Item item in itemManager.itemList)
                        {
                            if (itemID == item.ID)
                            {
                                reservation.ItemList.Add(item);
                                item.itemReservation = reservation;
                                item.ReservationID = reservation.ID;
                                break;
                            }
                        }
                    }
                }

                foreach (CampSite campSite in campsiteManager.campSiteList)
                {
                    if (campSite.ReservationID == reservation.ID)
                    {
                        reservation.CampSiteList.Add(campSite);
                        campSite.CampSiteReservation = reservation;
                        campSite.ReservationID = reservation.ID;
                    }
                }

                foreach (Visitor visitor in visitorManager.visitorList)
                {
                    if (reservation.ID == visitor.ReservationID)
                    {
                        visitor.VisitorReservation = reservation;
                        visitor.VisitorBooker = reservation.Booker;
                        reservation.AddVisitor(visitor);
                    }
                }
            }
        }

        private void FillData()
        {
            lboxMaterials.Items.Clear();
            foreach (Item item in itemManager.itemList)
            {
                bool exsists = false;
                for (int i = 0; i < lboxMaterials.Items.Count; i++)
                {
                    if (lboxMaterials.Items[i].ToString() == item.Name)
                    {
                        exsists = true;
                    }
                }
                if (!exsists)
                {
                    lboxMaterials.Items.Add(item);
                }
            }
        }

        private void lboxMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxMaterials.SelectedIndex != -1)
            {
                ClearDetails();
                selectedItem = lboxMaterials.SelectedItem as Item;
                if (selectedItem != null)
                {
                    tbName.Text = selectedItem.Name;
                    tbDailyRent.Text = selectedItem.Price.ToString("N2");
                    tbPrice.Text = selectedItem.NewPrice.ToString("N2");

                    int availible = databaseHandler.GetItemAmount(eventID, selectedItem.Name);
                    int used = databaseHandler.GetAviableItemAmount(eventID, selectedItem.Name);

                    tbAvailible.Text = Convert.ToString(availible - used) + " / " + availible.ToString();

                    foreach (Item item in itemManager.itemList)
                    {
                        if (item.Name == selectedItem.Name)
                        {
                            if (item.itemReservation != null)
                            {
                                lboxMaterialRenters.Items.Add(item.itemReservation);
                            }
                        }
                    }
                }
            }
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            using (var form = new AddItem())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < form.amount; i++)
                    {
                        int id = databaseHandler.GetnewItemID(eventID);

                        Item newItem = new Item(id, form.name, form.rentPrice, form.price);
                        itemManager.AddItem(newItem);
                        databaseHandler.AddItem(eventID, form.name, form.rentPrice, form.price);
                        FillData();
                        ClearDetails();
                    }
                }
            }
        }

        private void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            List<Item> selectedItemsList = new List<Item>();
            bool failed = false;

            foreach (Item item in itemManager.itemList)
            {
                if (item.Name == selectedItem.Name)
                {
                    selectedItemsList.Add(item);
                }
            }

            foreach (Reservation reservation in reservationManager.reservationList)
            {
                foreach (Item reservationItem in reservation.ItemList)
                {
                    foreach (Item item in selectedItemsList)
                    {
                        if (item.ID == reservationItem.ID)
                        {
                            failed = true;
                            break;
                        }
                    }
                }
            }

            if (!failed)
            {
                databaseHandler.DeleteItem(eventID, selectedItem.Name);
                foreach (Item item in selectedItemsList)
                {
                    itemManager.RemoveItem(item);
                }

                ClearDetails();
                FillData();

            }
            else
            {
                MessageBox.Show("Cannot delete item. Item has already been reserved. Remove reservations before removing item");
            }
        }

        private void btnAddRenter_Click(object sender, EventArgs e)
        {
            if (lboxMaterials.SelectedIndex != -1)
            {
                using (var form = new AddItemToReservation(databaseHandler.GetItemAmount(eventID, selectedItem.Name), reservationManager.reservationList))
                {

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        for (int i = 0; i < form.amount; i++)
                        {
                            if (form.selectedReservation.ReservedItemID == 0)
                            {
                                form.selectedReservation.ReservedItemID = databaseHandler.GetNewItemReservationID(eventID);
                                databaseHandler.AddItemReservationID(eventID, form.selectedReservation.ID, form.selectedReservation.ReservedItemID);
                            }

                            databaseHandler.AddItemToReservation(eventID, form.selectedReservation.ReservedItemID, selectedItem.Name);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecteer een item eerst");
            }
        }

        private void btnDeleteRenter_Click(object sender, EventArgs e)
        {
            if (lboxMaterialRenters.SelectedIndex != -1)
            {
                Reservation reservation = lboxMaterialRenters.SelectedItem as Reservation;
                if (reservation != null)
                {
                    foreach (Item item in reservation.ItemList)
                    {
                        if (item.Name == selectedItem.Name)
                        {
                            item.ReservationID = null;
                            item.itemReservation = null;
                            reservation.ItemList.Remove(item);

                            databaseHandler.DeleteItemReservation(item.ID);
                            ClearDetails();
                            FillData();
                            break;
                        }
                    }
                }
            }
        }
    }
}
