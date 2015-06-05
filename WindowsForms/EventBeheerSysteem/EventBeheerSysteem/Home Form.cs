using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventBeheerSysteem
{
    public partial class EbsHomeForm : Form
    {
        private EventManager eventManager = new EventManager();
        private Event selectedEvent;
        private Visitor selectedVisitor;
        private Item selectedItem;
        private CampSite selectedCampSite;

        public EbsHomeForm()
        {
            InitializeComponent();
            RefreshEventList();
            dgvEbsEvents.CurrentCell = null;
        }

        private void btnEbsAdd_Click(object sender, EventArgs e)
        {
            using(var form = new EbsAddEventForm())
            {
                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    string eventName = form.eventName;
                    string eventLocation = form.eventLocation;
                    DateTime beginDate = form.beginDate;
                    DateTime endDate = form.endDate;

                    eventManager.databaseHandler.AddEvent(eventName, beginDate, endDate, eventLocation);
                    eventManager.GetAllEvents();
                    RefreshEventList();
                }
            }
        }

        private void btnEbsRemove_Click(object sender, EventArgs e)
        {
            if (dgvEbsEvents.CurrentCell != null)
            {
                selectedEvent = eventManager.GetEvent(Convert.ToInt32(dgvEbsEvents.CurrentRow.Cells[0].Value.ToString()));
                eventManager.databaseHandler.UpdateDisableEvent(selectedEvent.ID);
                eventManager.GetAllEvents();
                RefreshEventList();
            }
        }

        private void btnEventTerug_Click(object sender, EventArgs e)
        {
            pnlEbsEvent.Visible = false;
            pnlEbsMain.Visible = true;

            selectedEvent = null;
            selectedVisitor = null;
            selectedItem = null;
            selectedCampSite = null;

            tabEvent.SelectTab(0);

            eventManager.GetAllEvents();
            RefreshEventList();
        }

        /// <summary>
        /// Event that will be called if the DataGridViewer is double clicked.
        /// Checks if the selected cell is not null
        /// If the selected cell is not null, proceed to next window
        /// </summary>
        private void dgvEbsEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvEbsEvents.CurrentCell != null)
            {
                pnlEbsMain.Visible = false;
                pnlEbsEvent.Visible = true;

                selectedEvent = eventManager.GetEvent(Convert.ToInt32(dgvEbsEvents.CurrentRow.Cells[0].Value.ToString()));
                selectedEvent.ReservationsOpen = eventManager.databaseHandler.GetReservationState(selectedEvent.ID);

                try
                {
                    selectedEvent.LoadData();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                FillEventDetailsTab();
                FillVisitorsTab();
                FillMaterialsTab();
                FillCampSitesTab();
            }
            
        }

        private void RefreshEventList()
        {
            dgvEbsEvents.Rows.Clear();

            foreach (Event currentEvent in eventManager.eventList)
            {
                dgvEbsEvents.Rows.Add(currentEvent.ID, currentEvent.Name, currentEvent.Location, currentEvent.BeginDate.ToString("dd/MM/yyyy"), currentEvent.EndDate.ToString("dd/MM/yyyy"));
            }
        }

        private void EbsHomeForm_Load(object sender, EventArgs e)
        {
            dgvEbsEvents.ClearSelection();
        }

        //----------------------------------------------------------------------------------------------------
        //DETAILS TAB
        //----------------------------------------------------------------------------------------------------

        /// <summary>
        /// Fills the tabel with the data from the SelectedEvent object
        /// </summary>
        private void FillEventDetailsTab()
        {
            lblEbsTabEvent.Text = selectedEvent.Name;

            tbEventDetailsName.Text = selectedEvent.Name;
            tbEventDetailsLocation.Text = selectedEvent.Location;

            dtpEventDetailsBeginDate.Value = selectedEvent.BeginDate;
            dtpEventDetailsEndDate.Value = selectedEvent.EndDate;

            cboxEventDetailsOpen.Checked = selectedEvent.ReservationsOpen;

            tbEventDetailsCounter.Text = Convert.ToString(eventManager.databaseHandler.GetVistiorAmount(selectedEvent.ID));
        }

        /// <summary>
        /// Saves all data supplied, check if the data if different.
        /// If the data is different from the saved data, data will be updated to the database
        /// </summary>
        private void btnEventDetailsSave_Click(object sender, EventArgs e)
        {
            if(selectedEvent.Name != tbEventDetailsName.Text)
            {
                if(tbEventDetailsName.Text == "")
                {
                    MessageBox.Show("Vul een geldige naam in");
                }
                else
                {
                    eventManager.databaseHandler.UpdateEventName(selectedEvent.ID, tbEventDetailsName.Text);
                    selectedEvent.Name = tbEventDetailsName.Text;
                }
            }
            if(selectedEvent.Location != tbEventDetailsLocation.Text)
            {
                if(tbEventDetailsLocation.Text == "")
                {
                    MessageBox.Show("Vul een geldige location in");
                }
                else
                {
                    eventManager.databaseHandler.UpdateEventLocation(selectedEvent.ID, tbEventDetailsLocation.Text);
                    selectedEvent.Location = tbEventDetailsLocation.Text;
                }
                
            }
            if(selectedEvent.BeginDate != dtpEventDetailsBeginDate.Value)
            {
                if(dtpEventDetailsBeginDate.Value < dtpEventDetailsEndDate.Value)
                {
                    eventManager.databaseHandler.UpdateEventBeginDate(selectedEvent.ID, dtpEventDetailsBeginDate.Value);
                    selectedEvent.BeginDate = dtpEventDetailsBeginDate.Value;
                }
                else
                {
                    MessageBox.Show("Begin Datum moet kleiner zijn dan Eind Datum");
                }
                
            }
            if(selectedEvent.EndDate != dtpEventDetailsEndDate.Value)
            {
                if(dtpEventDetailsEndDate.Value > dtpEventDetailsBeginDate.Value)
                {
                    eventManager.databaseHandler.UpdateEventEndDate(selectedEvent.ID, dtpEventDetailsEndDate.Value);
                    selectedEvent.EndDate = dtpEventDetailsEndDate.Value;
                }
                else
                {
                    MessageBox.Show("Eind Datum moet groter zijn dan Begin Datum");
                }
                
            }
            if(selectedEvent.ReservationsOpen != cboxEventDetailsOpen.Checked)
            {
                eventManager.databaseHandler.UpdateEventReservationState(selectedEvent.ID, cboxEventDetailsOpen.Checked);
                selectedEvent.ReservationsOpen = cboxEventDetailsOpen.Checked;
            }
        }

        //----------------------------------------------------------------------------------------------------
        //VISITORS TAB
        //----------------------------------------------------------------------------------------------------

        /// <summary>
        /// Clears the listbox of visitors
        /// Fills the listbox with all the visitors registered inside visitorManager.visitorList
        /// </summary>
        private void FillVisitorsTab()
        {
            lboxEventVisitorsList.Items.Clear();
            foreach(Visitor visitor in selectedEvent.visitorManager.visitorList)
            {
                lboxEventVisitorsList.Items.Add(visitor);
            }
        }

        private void FillVisitorDetailsTab()
        {
            tbEventVisitorsDetailsSurname.Text = selectedVisitor.Surname;
            tbEventVisitorsDetailsLastname.Text = selectedVisitor.Lastname;
            tbEventVisitorsDetailsRFID.Text = selectedVisitor.RFID;
            tbEventVisitorsDetailsStreet.Text = selectedVisitor.VisitorBooker.Address;
            tbEventVisitorsDetailsZipcode.Text = selectedVisitor.VisitorBooker.Zipcode;

            string campSites = "";

            foreach (CampSite campSite in selectedVisitor.VisitorReservation.CampSiteList)
            {
                campSites += campSite.Name + ", ";
            }
            if (campSites != "")
            {
                campSites = campSites.Substring(0, campSites.Length - 2);
            }

            tbEventVisitorsDetailsCampNr.Text = campSites;

            dtpEventVisitorsDetailsBookingDate.Value = selectedVisitor.VisitorReservation.ReservationDate;

            if(selectedVisitor.VisitorReservation.Payed != null)
            {
                cboxEventVisitorsDetailsPaid.Checked = selectedVisitor.VisitorReservation.Payed;
            }
            else
            {
                cboxEventVisitorsDetailsPaid.Checked = false;
            }

            if (selectedVisitor.VisitorReservation.CheckinDate != null)
            {
                cboxEventVisitorsDetailsPresent.Checked = true;
            }
            else
            {
                cboxEventVisitorsDetailsPresent.Checked = false;
            }

            lboxEventVisitorsDetailsMembers.Items.Clear();
            lboxEventVisitorsDetailsMaterials.Items.Clear();

            foreach (Visitor visitor in selectedVisitor.VisitorReservation.VisitorList)
            {
                lboxEventVisitorsDetailsMembers.Items.Add(visitor);
            }

            foreach (Item item in selectedVisitor.VisitorReservation.ItemList)
            {
                lboxEventVisitorsDetailsMaterials.Items.Add(item);
            }
        }

        /// <summary>
        /// Fills the details menu with the informatie of the selected object
        /// </summary>
        private void lboxEventVisitorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lboxEventVisitorsList.SelectedIndex != -1)
            {
                selectedVisitor = lboxEventVisitorsList.SelectedItem as Visitor;
                if(selectedVisitor != null)
                {
                    FillVisitorDetailsTab();
                }
            }
        }

        private void btnEventVisitorsDetailsAddMember_Click(object sender, EventArgs e)
        {
            if(lboxEventVisitorsList.SelectedIndex != -1)
            {
                using (var form = new AddMember())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int id = eventManager.databaseHandler.GetNewVisitorID(selectedEvent.ID);
                        Visitor newVisitor = new Visitor(id, form.surname, form.lastname, form.email, selectedVisitor.BookerID, selectedVisitor.ReservationID, "");
                        newVisitor.VisitorReservation = selectedVisitor.VisitorReservation;
                        newVisitor.VisitorBooker = selectedVisitor.VisitorBooker;
                        eventManager.databaseHandler.AddVisitor(id, selectedVisitor.ReservationID, selectedEvent.ID, form.surname, form.lastname, form.email, selectedVisitor.BookerID);
                        selectedVisitor.VisitorReservation.AddVisitor(newVisitor);

                        selectedEvent.visitorManager.AddVisitor(newVisitor);
                        FillVisitorsTab();
                        RefreshDetailMembers();
                    }
                }
            }
        }

        private void btnEventVisitorsDetailsSave_Click(object sender, EventArgs e)
        {
            if (cboxEventVisitorsDetailsPaid.Checked && !selectedVisitor.VisitorReservation.Payed)
            {
                selectedVisitor.VisitorReservation.Payed = cboxEventVisitorsDetailsPaid.Checked;
                eventManager.databaseHandler.SetReservationPayement(selectedEvent.ID, selectedVisitor.VisitorReservation.ID, cboxEventVisitorsDetailsPaid.Checked);
            }
            else if (!cboxEventVisitorsDetailsPaid.Checked && selectedVisitor.VisitorReservation.Payed)
            {
                selectedVisitor.VisitorReservation.Payed = cboxEventVisitorsDetailsPaid.Checked;
                eventManager.databaseHandler.SetReservationPayement(selectedEvent.ID, selectedVisitor.VisitorReservation.ID, cboxEventVisitorsDetailsPaid.Checked);
            }

            if (cboxEventVisitorsDetailsPresent.Checked && !selectedVisitor.VisitorReservation.Payed)
            {
                MessageBox.Show("Reservering heeft nog niet betaalt!");
            }
            else
            {
                if (cboxEventVisitorsDetailsPresent.Checked && (!selectedVisitor.VisitorReservation.CheckinDate.HasValue || selectedVisitor.VisitorReservation == null))
                {
                    selectedVisitor.VisitorReservation.CheckinDate = DateTime.Now;
                    eventManager.databaseHandler.SetReservationCheckInDate(selectedEvent.ID, selectedVisitor.VisitorReservation.ID);
                }
                else if (!cboxEventVisitorsDetailsPresent.Checked && selectedVisitor.VisitorReservation.CheckinDate.HasValue)
                {
                    selectedVisitor.VisitorReservation.CheckinDate = null;
                    eventManager.databaseHandler.RemoveReservationCheckInDate(selectedEvent.ID, selectedVisitor.ReservationID);
                }
            }
        }

        private void btnEventVisitorsDetailsDeleteMember_Click(object sender, EventArgs e)
        {
            if(lboxEventVisitorsDetailsMembers.SelectedIndex != -1)
            {
                Visitor lbVisitor = lboxEventVisitorsDetailsMembers.SelectedItem as Visitor;
                if (lbVisitor != null)
                {
                    if (lbVisitor.ID != lbVisitor.BookerID)
                    {
                        eventManager.databaseHandler.DeleteVisitor(lbVisitor.VisitorReservation.ID, lbVisitor.ID);
                        selectedEvent.visitorManager.RemoveVisitor(lbVisitor);
                        lbVisitor.VisitorReservation.VisitorList.Remove(lbVisitor);
                        FillVisitorsTab();
                        RefreshDetailMembers();
                    }
                    else
                    {
                        if (lbVisitor.VisitorReservation.VisitorList.Count == 1)
                        {
                            eventManager.databaseHandler.DeleteVisitor(lbVisitor.VisitorReservation.ID, lbVisitor.ID);
                            selectedEvent.visitorManager.RemoveVisitor(lbVisitor);
                            lbVisitor.VisitorReservation.VisitorList.Remove(lbVisitor);
                            FillVisitorsTab();
                            RefreshDetailMembers();
                        }
                        else
                        {
                            MessageBox.Show("De deelnemer is een boeker, boeker kan alleen verwijdert worden als de overige deelnemers worden verwijdert");
                        }
                    }
                }
            }
        }

        private void RefreshDetailMembers()
        {
            lboxEventVisitorsDetailsMembers.Items.Clear();

            foreach (Visitor visitor in selectedVisitor.VisitorReservation.VisitorList)
            {
                lboxEventVisitorsDetailsMembers.Items.Add(visitor);
            }
        }

        private void btnEventVisitorsDetailsRFID_Click(object sender, EventArgs e)
        {
            using (var form = new AddRFID(selectedEvent.visitorManager.visitorList))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedVisitor.RFID = form.rfidString;
                    eventManager.databaseHandler.UpdateRFID(selectedEvent.ID, selectedVisitor.ID, form.rfidString);
                    FillVisitorDetailsTab();
                }
            }
        }

        //TODO: Insert search function

        //----------------------------------------------------------------------------------------------------
        //MATERIALS TAB
        //----------------------------------------------------------------------------------------------------

        private void FillMaterialsTab()
        {
            lboxEventMaterialList.Items.Clear();
            foreach(Item item in selectedEvent.itemManager.itemList)
            {
                bool exsists = false;
                for (int i = 0; i < lboxEventMaterialList.Items.Count; i++)
                {
                    if (lboxEventMaterialList.Items[i].ToString() == item.Name)
                    {
                        exsists = true;
                    }
                }
                if(!exsists)
                {
                    lboxEventMaterialList.Items.Add(item);
                }
            }
        }

        private void FillMaterialsDetailsTab()
        {
            tbEventMaterialDetailsName.Text = selectedItem.Name;
            tbEventMaterialDetailsDailyRent.Text = selectedItem.Price.ToString("N2");
            tbEventMaterialDetailsPrice.Text = selectedItem.NewPrice.ToString("N2");

            int availible = eventManager.databaseHandler.GetItemAmount(selectedEvent.ID, selectedItem.Name);
            int used = eventManager.databaseHandler.GetAviableItemAmount(selectedEvent.ID, selectedItem.Name);

            tbEventMaterialDetailsAvailable.Text = Convert.ToString(availible - used) + " / " + availible.ToString();

            foreach (Item item in selectedEvent.itemManager.itemList)
            {
                if (item.Name == selectedItem.Name)
                {
                    if (item.itemReservation != null)
                    {
                        lboxEventMaterialDetailsRentersList.Items.Add(item.itemReservation);
                    }
                }
            }
        }

        private void ClearMaterialsDetailsTab()
        {
            tbEventMaterialDetailsName.Clear();
            tbEventMaterialDetailsPrice.Clear();
            tbEventMaterialDetailsDailyRent.Clear();
            tbEventMaterialDetailsAvailable.Clear();
            lboxEventMaterialDetailsRentersList.Items.Clear();
        }

        private void lboxEventMaterialList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lboxEventMaterialList.SelectedIndex != -1)
            {
                ClearMaterialsDetailsTab();
                selectedItem = lboxEventMaterialList.SelectedItem as Item;
                if(selectedItem != null)
                {
                    FillMaterialsDetailsTab();
                }
            }
        }

        private void btnEventMaterialAddMaterial_Click(object sender, EventArgs e)
        {
            using (var form = new AddItem())
            {
                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    for(int i = 0; i < form.amount; i++)
                    {
                        int id = eventManager.databaseHandler.GetnewItemID();

                        try
                        {
                            Item newItem = new Item(id, form.name, form.rentPrice, form.price);
                            selectedEvent.itemManager.AddItem(newItem);
                            eventManager.databaseHandler.AddItem(selectedEvent.ID, id, form.name, form.rentPrice, form.price);
                            FillMaterialsTab();
                            ClearMaterialsDetailsTab();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                    }
                }
            }
        }

        private void btnEventMaterialDeleteMaterial_Click(object sender, EventArgs e)
        {
            List<Item> selectedItemsList = new List<Item>();
            bool failed = false;

            foreach(Item item in selectedEvent.itemManager.itemList)
            {
                if(item.Name == selectedItem.Name)
                {
                    selectedItemsList.Add(item);
                }
            }

            foreach(Reservation reservation in selectedEvent.reservationManager.reservationList)
            {
                foreach(Item reservationItem in reservation.ItemList)
                {
                    foreach(Item item in selectedItemsList)
                    {
                        if(item.ID == reservationItem.ID)
                        {
                            failed = true;
                            break;
                        }
                    }
                }
            }

            if(!failed)
            {
                eventManager.databaseHandler.DeleteItem(selectedEvent.ID, selectedItem.Name);
                foreach(Item item in selectedItemsList)
                {
                    selectedEvent.itemManager.RemoveItem(item);
                }

                ClearMaterialsDetailsTab();
                FillMaterialsTab();

            }
            else
            {
                MessageBox.Show("Cannot delete item. Item has already been reserved. Remove reservations before removing item");
            }
        }

        private void btnEventMaterialDetailsAddRenter_Click(object sender, EventArgs e)
        {
            if(lboxEventMaterialList.SelectedIndex != -1)
            {
                int availible = eventManager.databaseHandler.GetItemAmount(selectedEvent.ID, selectedItem.Name);
                int used = eventManager.databaseHandler.GetAviableItemAmount(selectedEvent.ID, selectedItem.Name);

                using (var form = new AddItemToReservation((availible - used), selectedEvent.reservationManager.reservationList))
                {

                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        for(int i = 0; i < form.amount; i++)
                        {
                            if(form.selectedReservation.ReservedItemID == -1)
                            {
                                form.selectedReservation.ReservedItemID = eventManager.databaseHandler.GetNewItemReservationID(selectedEvent.ID);
                                eventManager.databaseHandler.AddItemReservationID(selectedEvent.ID, form.selectedReservation.ID, form.selectedReservation.ReservedItemID);
                            }

                            int itemID = eventManager.databaseHandler.AddItemToReservation(selectedEvent.ID, form.selectedReservation.ReservedItemID, selectedItem.Name);
                            Item item = selectedEvent.itemManager.GetItem(itemID);
                            form.selectedReservation.ItemList.Add(item);
                            item.itemReservation = form.selectedReservation;

                        }

                        FillMaterialsDetailsTab();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecteer een item eerst");
            }
        }

        private void btnEventMaterialDetailsDeleteRenter_Click(object sender, EventArgs e)
        {
            if (lboxEventMaterialDetailsRentersList.SelectedIndex != -1)
            {
                Reservation reservation = lboxEventMaterialDetailsRentersList.SelectedItem as Reservation;
                if (reservation != null)
                {
                    foreach (Item item in reservation.ItemList)
                    {
                        if (item.Name == selectedItem.Name)
                        {
                            item.ReservationID = null;
                            item.itemReservation = null;
                            reservation.ItemList.Remove(item);

                            eventManager.databaseHandler.DeleteItemReservation(item.ID);
                            ClearMaterialsDetailsTab();
                            FillMaterialsTab();
                            break;
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        //CampSites TAB
        //----------------------------------------------------------------------------------------------------

        private void FillCampSitesTab()
        {
            lboxEventBedsList.Items.Clear();
            foreach(CampSite campSite in selectedEvent.campsiteManager.campSiteList)
            {
                lboxEventBedsList.Items.Add(campSite);
            }
        }

        private void lboxEventBedsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lboxEventBedsList.SelectedIndex != -1)
            {
                selectedCampSite = lboxEventBedsList.SelectedItem as CampSite;
                if(selectedCampSite != null)
                {
                    tbEventBedsDetailsName.Text = selectedCampSite.Name;
                    tbEventBedsDetailsPrice.Text = selectedCampSite.Price.ToString("N2");
                    if(selectedCampSite.CampSiteReservation != null)
                    {
                        cboxEventBedsDetailsOcuppied.Checked = true;
                        tbEventBedsDetailsRenter.Text = selectedCampSite.CampSiteReservation.Booker.Surname + " " + selectedCampSite.CampSiteReservation.Booker.Lastname;
                    }
                    else
                    {
                        cboxEventBedsDetailsOcuppied.Checked = false;
                    }

                    tbEventBedsDetailsMaxRenters.Text = selectedCampSite.MaxOccupation.ToString();

                }
            }
        }

        private void btnEventBedsAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddCampSite())
            {

                var result = form.ShowDialog();
                if(result == DialogResult.OK)
                {
                    for(int i = 0; i < form.amount; i++)
                    {
                        int id = eventManager.databaseHandler.GetNewCampSiteID();
                        CampSite newCampsite = new CampSite(id, id.ToString(), form.price, 1, form.surfaceArea, form.maxRenters);

                        System.Threading.Thread.Sleep(10);

                        selectedEvent.campsiteManager.campSiteList.Add(newCampsite);
                        eventManager.databaseHandler.AddCampSite(selectedEvent.ID, newCampsite.Price, newCampsite.MaxOccupation, newCampsite.CampSize, newCampsite.Type);
                        
                    }
                }

                FillCampSitesTab();
            }
        }

        private void btnEventBedsDelete_Click(object sender, EventArgs e)
        {
            if(selectedCampSite != null)
            {
                if(selectedCampSite.CampSiteReservation == null)
                {
                    eventManager.databaseHandler.DeleteCampSite(selectedEvent.ID, selectedCampSite.ID);
                    selectedEvent.campsiteManager.campSiteList.Remove(selectedCampSite);
                    FillCampSitesTab();
                }
            }
        }




    }
}
