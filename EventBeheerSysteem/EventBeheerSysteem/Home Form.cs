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
        EventManager eventManager = new EventManager();
        Event selectedEvent;

        public EbsHomeForm()
        {
            InitializeComponent();
            RefreshList();
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
                    RefreshList();
                }
            }
        }

        private void btnEbsRemove_Click(object sender, EventArgs e)
        {
            if (dgvEbsEvents.CurrentCell != null)
            {
                selectedEvent = eventManager.GetEvent(Convert.ToInt32(dgvEbsEvents.CurrentRow.Cells[0].Value.ToString()));
                eventManager.databaseHandler.DeleteEvent(selectedEvent.ID);
                eventManager.GetAllEvents();
                RefreshList();
            }
        }

        private void btnEventTerug_Click(object sender, EventArgs e)
        {
            pnlEbsEvent.Visible = false;
            pnlEbsMain.Visible = true;
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

                selectedEvent.LoadData();

                FillEventDetailsTab();
                FillVisitorsTab();
                FillMaterialsTab();
                FillCampSitesTab();
            }
            
        }

        private void RefreshList()
        {
            dgvEbsEvents.Rows.Clear();

            foreach (Event currentEvent in eventManager.eventList)
            {
                dgvEbsEvents.Rows.Add(currentEvent.ID, currentEvent.Name, currentEvent.Location, currentEvent.BeginDate.ToString("dd/mm/yyyy"), currentEvent.EndDate.ToString("dd/mm/yyyy"));
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
                eventManager.databaseHandler.UpdateEventName(selectedEvent.ID, tbEventDetailsName.Text);
            }
            if(selectedEvent.Location != tbEventDetailsLocation.Text)
            {
                eventManager.databaseHandler.UpdateEventLocation(selectedEvent.ID, tbEventDetailsLocation.Text);
            }
            if(selectedEvent.BeginDate != dtpEventDetailsBeginDate.Value)
            {
                eventManager.databaseHandler.UpdateEventBeginDate(selectedEvent.ID, dtpEventDetailsBeginDate.Value);
            }
            if(selectedEvent.EndDate != dtpEventDetailsEndDate.Value)
            {
                eventManager.databaseHandler.UpdateEventEndDate(selectedEvent.ID, dtpEventDetailsEndDate.Value);
            }
            if(selectedEvent.ReservationsOpen != cboxEventDetailsOpen.Checked)
            {
                eventManager.databaseHandler.UpdateEventReservationState(selectedEvent.ID, cboxEventDetailsOpen.Checked);
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

        /// <summary>
        /// Fills the details menu with the informatie of the selected object
        /// </summary>
        private void lboxEventVisitorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lboxEventVisitorsList.SelectedIndex != -1)
            {
                Visitor selectedVisitor = lboxEventVisitorsList.SelectedItem as Visitor;
                if(selectedVisitor != null)
                {
                    tbEventVisitorsDetailsSurname.Text = selectedVisitor.VisitorBooker.Surname;
                    tbEventVisitorsDetailsLastname.Text = selectedVisitor.VisitorBooker.Lastname;
                    tbEventVisitorsDetailsStreet.Text = selectedVisitor.VisitorBooker.Address;
                    tbEventVisitorsDetailsZipcode.Text = selectedVisitor.VisitorBooker.Zipcode;

                    string campSites = "";

                    foreach (CampSite campSite in selectedVisitor.VisitorReservation.CampSiteList)
                    {
                        campSites += campSite.Name + ", ";
                    }

                    tbEventVisitorsDetailsCampNr.Text = campSites;

                    dtpEventVisitorsDetailsBookingDate.Value = selectedVisitor.VisitorReservation.ReservationDate;

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
            }
        }

        //TODO: Insert search function

        //----------------------------------------------------------------------------------------------------
        //VISITORS TAB
        //----------------------------------------------------------------------------------------------------

        private void FillMaterialsTab()
        {
            lboxEventMaterialList.Items.Clear();
            foreach(Item item in selectedEvent.itemManager.itemList)
            {
                lboxEventMaterialList.Items.Add(item);
            }
        }

        private void lboxEventMaterialList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lboxEventMaterialList.SelectedIndex != -1)
            {
                Item item = lboxEventMaterialList.SelectedItem as Item;
                if(item != null)
                {
                    tbEventMaterialDetailsName.Text = item.Name;
                    tbEventMaterialDetailsDailyRent.Text = item.Price.ToString("N2");
                    tbEventMaterialDetailsPrice.Text = item.NewPrice.ToString("N2");

                    int availible = eventManager.databaseHandler.GetItemAmount(selectedEvent.ID, item.Name);
                    int used = eventManager.databaseHandler.GetAviableItemAmount(selectedEvent.ID, item.Name);

                    tbEventMaterialDetailsAvailable.Text = Convert.ToString(availible - used) + " / " + availible.ToString();
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
                CampSite campSite = lboxEventBedsList.SelectedItem as CampSite;
                if(campSite != null)
                {
                    tbEventBedsDetailsName.Text = campSite.Name;
                    tbEventBedsDetailsPrice.Text = campSite.Price.ToString("N2");
                    if(campSite.CampSiteReservation != null)
                    {
                        cboxEventBedsDetailsOcuppied.Checked = true;
                        tbEventBedsDetailsRenter.Text = campSite.CampSiteReservation.Booker.Surname + " " + campSite.CampSiteReservation.Booker.Lastname;
                    }
                    else
                    {
                        cboxEventBedsDetailsOcuppied.Checked = false;
                    }
                    tbEventBedsDetailsMaxRenters.Text = campSite.Occupation.ToString() + " / " + campSite.MaxOccupation.ToString();
                }
            }
        }

    }
}
