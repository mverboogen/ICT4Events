using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Beheer_Systeem
{
    public partial class EbsHomeForm : Form
    {
        public EbsHomeForm()
        {
            InitializeComponent();
            dgvEbsEvents.Rows.Add(99241,"Social Media Event", "Camping Blu", "22/12/2015", "26/12/2015");
            dgvEbsEvents.Rows.Add(99243,"Test Event 312", "Stadspark", "02/04/2016", "08/04/2016");
            dgvEbsEvents.Rows.Add(99244,"Nog een Test Event", "Aquabest", "12/06/2016", "20/06/2016");
            dgvEbsEvents.CurrentCell = null;
            
        }

        private void btnEbsAdd_Click(object sender, EventArgs e)
        {
            EbsAddEventForm addevent = new EbsAddEventForm();
            addevent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlEbsEvent.Visible = false;
            pnlEbsMain.Visible = true;
        }

        private void dgvEbsEvents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pnlEbsMain.Visible = false;
            pnlEbsEvent.Visible = true;
        }

        private void EbsHomeForm_Load(object sender, EventArgs e)
        {
            dgvEbsEvents.ClearSelection();
        }
    }
}
