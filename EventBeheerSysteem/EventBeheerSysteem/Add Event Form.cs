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
        public EbsAddEventForm()
        {
            InitializeComponent();
        }

        private void btnAddEventCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
