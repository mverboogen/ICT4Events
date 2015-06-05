using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace ToegangsControleSysteem
{
    public partial class IncheckSystemForm : Form
    {

        private int eventID = 1;

        private RFID rfid = new RFID();

        private ItemManager itemManager = new ItemManager();
        private VisitorManager visitorManager = new VisitorManager();
        private ReservationManager reservationManager = new ReservationManager();
        private CampSiteManager campsiteManager = new CampSiteManager();

        private DatabaseManager databaseHandler = new DatabaseManager();

        private Visitor selectedVisitor;

        public IncheckSystemForm()
        {
            InitializeComponent();

            RetrieveData();
            FillData();
        }

        private void RefreshUI()
        {
            ClearDetails();

            tbVisitorSurname.Text = selectedVisitor.Surname;
            tbVisitorLastname.Text = selectedVisitor.Lastname;
            tbVisitorAddress.Text = selectedVisitor.VisitorBooker.Address;
            tbVisitorZipcode.Text = selectedVisitor.VisitorBooker.Zipcode;

            string campSites = "";

            foreach (CampSite campSite in selectedVisitor.VisitorReservation.CampSiteList)
            {
                campSites += campSite.Name + ", ";
            }
            if (campSites != "")
            {
                campSites = campSites.Substring(0, campSites.Length - 2);
            }

            tbVisitorCampSite.Text = campSites;

            dtpVisitorReservationDate.Value = selectedVisitor.VisitorReservation.ReservationDate;

            cboxVisitorPayed.Checked = selectedVisitor.VisitorReservation.Payed;

            if (selectedVisitor.VisitorReservation.CheckinDate.HasValue)
            {
                cboxVisitorPresent.Checked = true;
            }
            else
            {
                cboxVisitorPresent.Checked = false;
            }

            lboxVisitorsDetailsMembers.Items.Clear();
            lboxVisitorsDetailsMaterials.Items.Clear();

            foreach (Visitor visitor in selectedVisitor.VisitorReservation.VisitorList)
            {
                lboxVisitorsDetailsMembers.Items.Add(visitor);
            }

            foreach (Item item in selectedVisitor.VisitorReservation.ItemList)
            {
                lboxVisitorsDetailsMaterials.Items.Add(item);
            }
        }

        private void ClearDetails()
        {
            tbVisitorSurname.Clear();
            tbVisitorLastname.Clear();
            tbVisitorZipcode.Clear();
            tbVisitorCampSite.Clear();
            tbVisitorAddress.Clear();

            lboxVisitorsDetailsMaterials.Items.Clear();
            lboxVisitorsDetailsMembers.Items.Clear();

            cboxVisitorPayed.Checked = false;
            cboxVisitorPresent.Checked = false;
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
            foreach (Visitor visitor in visitorManager.visitorList)
            {
                lboxAllVisitors.Items.Add(visitor);

                if(visitor.VisitorReservation.CheckinDate != null)
                {
                    lboxCheckedInVisitors.Items.Add(visitor);
                }
            }
        }

        private void RefreshDetailMembers()
        {
            lboxVisitorsDetailsMembers.Items.Clear();

            foreach (Visitor visitor in selectedVisitor.VisitorReservation.VisitorList)
            {
                lboxVisitorsDetailsMembers.Items.Add(visitor);
            }
        }


        private void lboxAllVisitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lboxAllVisitors.SelectedIndex != -1)
            {
                selectedVisitor = lboxAllVisitors.SelectedItem as Visitor;
                if (selectedVisitor != null)
                {
                    RefreshUI();
                }
            }
        }

        private void lboxCheckedInVisitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxCheckedInVisitors.SelectedIndex != -1)
            {
                selectedVisitor = lboxCheckedInVisitors.SelectedItem as Visitor;
                if (selectedVisitor != null)
                {
                    tbVisitorSurname.Text = selectedVisitor.Surname;
                    tbVisitorLastname.Text = selectedVisitor.Lastname;
                    tbVisitorAddress.Text = selectedVisitor.VisitorBooker.Address;
                    tbVisitorZipcode.Text = selectedVisitor.VisitorBooker.Zipcode;

                    string campSites = "";

                    foreach (CampSite campSite in selectedVisitor.VisitorReservation.CampSiteList)
                    {
                        campSites += campSite.Name + ", ";
                    }
                    if (campSites != "")
                    {
                        campSites = campSites.Substring(0, campSites.Length - 2);
                    }

                    tbVisitorCampSite.Text = campSites;

                    dtpVisitorReservationDate.Value = selectedVisitor.VisitorReservation.ReservationDate;

                    cboxVisitorPayed.Checked = selectedVisitor.VisitorReservation.Payed;

                    if (selectedVisitor.VisitorReservation.CheckinDate != null)
                    {
                        cboxVisitorPresent.Checked = true;
                    }
                    else
                    {
                        cboxVisitorPresent.Checked = false;
                    }

                    lboxVisitorsDetailsMembers.Items.Clear();
                    lboxVisitorsDetailsMaterials.Items.Clear();

                    foreach (Visitor visitor in selectedVisitor.VisitorReservation.VisitorList)
                    {
                        lboxVisitorsDetailsMembers.Items.Add(visitor);
                    }

                    foreach (Item item in selectedVisitor.VisitorReservation.ItemList)
                    {
                        lboxVisitorsDetailsMaterials.Items.Add(item);
                    }
                }
            }
        }

        private void tbcVisitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            lboxCheckedInVisitors.SelectedIndex = -1;
            lboxAllVisitors.SelectedIndex = -1;

            ClearDetails();
        }

        private void btnVisitorSave_Click(object sender, EventArgs e)
        {

            if(cboxVisitorPayed.Checked && !selectedVisitor.VisitorReservation.Payed)
            {
                selectedVisitor.VisitorReservation.Payed = cboxVisitorPayed.Checked;
                databaseHandler.SetReservationPayement(eventID, selectedVisitor.VisitorReservation.ID, cboxVisitorPayed.Checked);
            }
            else if(!cboxVisitorPayed.Checked && selectedVisitor.VisitorReservation.Payed)
            {
                selectedVisitor.VisitorReservation.Payed = cboxVisitorPayed.Checked;
                databaseHandler.SetReservationPayement(eventID, selectedVisitor.VisitorReservation.ID, cboxVisitorPayed.Checked);
            }

            if(cboxVisitorPresent.Checked && !selectedVisitor.VisitorReservation.Payed)
            {
                MessageBox.Show("Reservering heeft nog niet betaalt!");
            }
            else
            {
                if(cboxVisitorPresent.Checked && (!selectedVisitor.VisitorReservation.CheckinDate.HasValue || selectedVisitor.VisitorReservation == null))
                {
                    selectedVisitor.VisitorReservation.CheckinDate = DateTime.Now;
                    databaseHandler.SetReservationCheckInDate(eventID, selectedVisitor.VisitorReservation.ID);
                }
                else if (!cboxVisitorPresent.Checked && selectedVisitor.VisitorReservation.CheckinDate.HasValue)
                {
                    selectedVisitor.VisitorReservation.CheckinDate = null;
                    databaseHandler.RemoveReservationCheckInDate(eventID, selectedVisitor.ReservationID);
                }
            }

            lboxAllVisitors.Items.Clear();
            lboxCheckedInVisitors.Items.Clear();
            FillData();
            RefreshDetailMembers();
        }

        private void btnVisitorDelete_Click(object sender, EventArgs e)
        {
            if (lboxVisitorsDetailsMembers.SelectedIndex != -1)
            {
                Visitor lbVisitor = lboxVisitorsDetailsMembers.SelectedItem as Visitor;
                if (lbVisitor != null)
                {
                    if (lbVisitor.ID != lbVisitor.BookerID)
                    {
                        databaseHandler.DeleteVisitor(lbVisitor.VisitorReservation.ID, lbVisitor.ID);
                        visitorManager.RemoveVisitor(lbVisitor);
                        lbVisitor.VisitorReservation.VisitorList.Remove(lbVisitor);
                        lboxAllVisitors.Items.Clear();
                        lboxCheckedInVisitors.Items.Clear();
                        FillData();
                        RefreshDetailMembers();
                    }
                    else
                    {
                        if (lbVisitor.VisitorReservation.VisitorList.Count == 1)
                        {
                            databaseHandler.DeleteVisitor(lbVisitor.VisitorReservation.ID, lbVisitor.ID);
                            visitorManager.RemoveVisitor(lbVisitor);
                            lbVisitor.VisitorReservation.VisitorList.Remove(lbVisitor);
                            lboxAllVisitors.Items.Clear();
                            lboxCheckedInVisitors.Items.Clear();
                            FillData();
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

        private void btnVisitorAdd_Click(object sender, EventArgs e)
        {
            if (selectedVisitor != null)
            {
                using (var form = new AddMember())
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        int id = databaseHandler.GetNewVisitorID(eventID);
                        Visitor newVisitor = new Visitor(id, form.surname, form.lastname, form.email, selectedVisitor.BookerID, selectedVisitor.ReservationID, "");
                        newVisitor.VisitorReservation = selectedVisitor.VisitorReservation;
                        newVisitor.VisitorBooker = selectedVisitor.VisitorBooker;
                        databaseHandler.AddVisitor(id, selectedVisitor.ReservationID, eventID, form.surname, form.lastname, form.email, selectedVisitor.BookerID);
                        selectedVisitor.VisitorReservation.AddVisitor(newVisitor);

                        visitorManager.AddVisitor(newVisitor);
                        RefreshDetailMembers();
                    }
                }
            }
        }

        private void btnAttend_Click(object sender, EventArgs e)
        {
            if (!selectedVisitor.VisitorReservation.Payed)
            {
                MessageBox.Show("Reservering heeft nog niet betaalt!");
            }
            else
            {
                if (!selectedVisitor.VisitorReservation.CheckinDate.HasValue || selectedVisitor.VisitorReservation == null)
                {
                    selectedVisitor.VisitorReservation.CheckinDate = DateTime.Now;
                    databaseHandler.SetReservationCheckInDate(eventID, selectedVisitor.VisitorReservation.ID);
                }
                else
                {
                    selectedVisitor.VisitorReservation.CheckinDate = null;
                    databaseHandler.RemoveReservationCheckInDate(eventID, selectedVisitor.ReservationID);
                }

                RefreshUI();
            }
        }

        private void btnPayed_Click(object sender, EventArgs e)
        {
            if (!selectedVisitor.VisitorReservation.Payed)
            {
                selectedVisitor.VisitorReservation.Payed = !cboxVisitorPayed.Checked;
                databaseHandler.SetReservationPayement(eventID, selectedVisitor.VisitorReservation.ID, !cboxVisitorPayed.Checked);
            }
            else
            {
                selectedVisitor.VisitorReservation.Payed = !cboxVisitorPayed.Checked;
                databaseHandler.SetReservationPayement(eventID, selectedVisitor.VisitorReservation.ID, !cboxVisitorPayed.Checked);
            }

            RefreshUI();
        }

        private void btnScanRFID_Click(object sender, EventArgs e)
        {
            if(cbAutoScan.Checked)
            {
                cbAutoScan.Checked = false;
            }

            using(var form = new ScanRFID())
            {
                var result = form.ShowDialog();
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    GetVisitorDetails(form.rfidString);
                }
            }
        }

        private void GetVisitorDetails(string rfidTag)
        {
            int index = 0;
            foreach (Visitor visitor in lboxAllVisitors.Items)
            {
                if (visitor.RFID == rfidTag)
                {
                    lboxAllVisitors.SelectedIndex = index;
                    break;
                }
                else
                {
                    index++;
                }
            }

            if (index < lboxAllVisitors.Items.Count)
            {
                lboxAllVisitors.SelectedIndex = index;
                Console.Beep(1000, 500);

            }
            else
            {
                int freq = 1250;
                int dur = 125;
                int del = 125;

                lboxAllVisitors.SelectedIndex = -1;
                ClearDetails();
                Console.Beep(freq, dur);
                Thread.Sleep(del);
                Console.Beep(freq, dur);
                Thread.Sleep(del);
                Console.Beep(freq, dur);

                MessageBox.Show("RFID tag niet bekend");
            }
        }

        private void cbAutoScan_CheckedChanged(object sender, EventArgs e)
        {
            if(cbAutoScan.Checked)
            {
                rfid.open();

                rfid.Attach += new AttachEventHandler(RFID_Attach);
                rfid.Detach += new DetachEventHandler(RFID_Detach);

                rfid.Tag += new TagEventHandler(RFID_Tag);
            }
            else
            {
                rfid.Attach -= new AttachEventHandler(RFID_Attach);
                rfid.Detach -= new DetachEventHandler(RFID_Detach);
                rfid.Tag -= new TagEventHandler(RFID_Tag);

                rfid.close();
            }
        }


        private void RFID_Attach(object sender, AttachEventArgs e)
        {
            RFID attached = (RFID)sender;


            if (rfid.outputs.Count > 0)
            {
                rfid.Antenna = true;
                rfid.LED = true;
            }
        }

        void RFID_Detach(object sender, DetachEventArgs e)
        {
            RFID detached = (RFID)sender;

            if (rfid.outputs.Count > 0)
            {
                rfid.Antenna = false;
                rfid.LED = false;
            }
        }

        private void RFID_Tag(object sender, TagEventArgs e)
        {
            if (e.Tag.Length == 10)
            {
                GetVisitorDetails(e.Tag);
            }
        }

    }
}
