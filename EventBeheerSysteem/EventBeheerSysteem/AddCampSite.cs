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
    public partial class AddCampSite : Form
    {

        public decimal price;
        public int maxRenters;
        public int type;
        public int surfaceArea;


        public AddCampSite()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(numPrice.Value != 0 && numMaxRenters.Value != 0 && numSurfaceArea.Value != 0 && cbType.SelectedValue != "")
            {
                price = numPrice.Value;
                maxRenters = Convert.ToInt32(numMaxRenters.Value);
                surfaceArea = Convert.ToInt32(numSurfaceArea.Value);
                type = Convert.ToInt32(cbType.SelectedValue);


                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
