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
            foreach(Event e in eventManager.eventList)
            {
                dgvEbsEvents.Rows.Add(e.ID, e.Name, e.Location, e.BeginDate.ToString("dd/mm/yyyy"), e.EndDate.ToString("dd/mm/yyyy"));
            }
            dgvEbsEvents.CurrentCell = null;
        }

        private void btnEbsAdd_Click(object sender, EventArgs e)
        {
            EbsAddEventForm addEvent = new EbsAddEventForm();
            addEvent.Show();
        }

        private void btnEventTerug_Click(object sender, EventArgs e)
        {
            pnlEbsEvent.Visible = false;
            pnlEbsMain.Visible = true;
        }

        private void dgvEbsEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(dgvEbsEvents.CurrentCell != null)
            {
                pnlEbsMain.Visible = false;
                pnlEbsEvent.Visible = true;

                selectedEvent = eventManager.GetEvent(Convert.ToInt32(dgvEbsEvents.CurrentRow.Cells[0].Value.ToString()));
                selectedEvent.ReservationsOpen = eventManager.databaseHandler.GetReservationState(selectedEvent.ID);

                FillEventTab();
            }
            
        }

        private void FillEventTab()
        {
            lblEbsTabEvent.Text = selectedEvent.Name;

            tbEventDetailsName.Text = selectedEvent.Name;
            tbEventDetailsLocation.Text = selectedEvent.Location;

            dtpEventDetailsBeginDate.Value = selectedEvent.BeginDate;
            dtpEventDetailsEndDate.Value = selectedEvent.EndDate;

            cboxEventDetailsOpen.Checked = selectedEvent.ReservationsOpen;

            tbEventDetailsCounter.Text = Convert.ToString(eventManager.databaseHandler.GetVistiorAmount(selectedEvent.ID));
        }

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

        private void EbsHomeForm_Load(object sender, EventArgs e)
        {
            dgvEbsEvents.ClearSelection();
        }


    }
}
