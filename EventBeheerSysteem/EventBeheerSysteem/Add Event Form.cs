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
    public partial class EbsAddEventForm : Form
    {

        public string eventName;
        public string eventLocation;
        public DateTime beginDate;
        public DateTime endDate;

        public EbsAddEventForm()
        {
            InitializeComponent();
        }

        private void btnAddEventOk_Click(object sender, EventArgs e)
        {

            bool failed = false;

            eventName = tbAddEventName.Text;
            if(eventName == "")
            {
                failed = true;
                MessageBox.Show("Vul een naam in voor het event");
            }

            eventLocation = tbAddEventLocation.Text;
            if(eventLocation == "")
            {
                failed = true;
                MessageBox.Show("Vul een lokatie in");
            }

            beginDate = dtpAddEventBeginDate.Value;
            endDate = dtpAddEventEndDate.Value;

            if(!failed)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
