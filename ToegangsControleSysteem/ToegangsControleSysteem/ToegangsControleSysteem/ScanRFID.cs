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

namespace ToegangsControleSysteem
{
    public partial class ScanRFID : Form
    {

        public string rfidString;
        private RFID rfid;

        public ScanRFID()
        {
            InitializeComponent();

            rfid = new RFID();
            rfid.open();

            rfid.Attach += new AttachEventHandler(RFID_Attach);
            rfid.Detach += new DetachEventHandler(RFID_Detach);

            rfid.Tag += new TagEventHandler(RFID_Tag);

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
            if(e.Tag.Length == 10)
            {
                rfidString = e.Tag;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void ScanRFID_FormClosing(object sender, FormClosingEventArgs e)
        {
            rfid.Attach -= new AttachEventHandler(RFID_Attach);
            rfid.Detach -= new DetachEventHandler(RFID_Detach);
            rfid.Tag -= new TagEventHandler(RFID_Tag);

            rfid.close();
            rfid = null;
        }
    }
}
