using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;

namespace EventBeheerSysteem
{
    public partial class AddRFID : Form
    {
        private List<Visitor> visitorList = new List<Visitor>();

        public string rfidString;
        private RFID rfid;

        public AddRFID(List<Visitor> visitorList)
        {
            InitializeComponent();
            this.visitorList = visitorList;

            rfid = new RFID();
            rfid.open();

            //rfid.waitForAttachment();

            rfid.Attach += new AttachEventHandler(RFID_Attach);
            rfid.Detach += new DetachEventHandler(RFID_Detach);

            rfid.Tag += new TagEventHandler(RFID_Tag);

        }

        private void RFID_Attach(object sender, AttachEventArgs e)
        {
            RFID attached = (RFID)sender;

            rfid.Antenna = true;
            rfid.LED = true;
        }

        void RFID_Detach(object sender, DetachEventArgs e)
        {
            RFID detached = (RFID)sender;
        }

        private void RFID_Tag(object sender, TagEventArgs e)
        {
            tbRFID.Clear();
            tbRFID.Text = e.Tag;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            rfidString = tbRFID.Text;
            bool failed = false;

            if(rfidString == "")
            {
                failed = true;
            }

            foreach(Visitor visitor in visitorList)
            {
                if(visitor.RFID == rfidString)
                {
                    MessageBox.Show("RFID Tag al in gebruik");
                    failed = true;
                    break;
                }
            }

            if(!failed)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void AddRFID_FormClosing(object sender, FormClosingEventArgs e)
        {
            rfid.close();
            rfid = null;
        }
    }
}
