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
        public int surfaceArea;
        public int amount;


        public AddCampSite()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(numPrice.Value != 0 && numMaxRenters.Value != 0 && numSurfaceArea.Value != 0)
            {

                bool failed = false;

                price = numPrice.Value;
                if(price == 0)
                {
                    failed = true;
                    MessageBox.Show("Prijs moet groter dan 0 zijn");
                }
                maxRenters = Convert.ToInt32(numMaxRenters.Value);
                if(maxRenters == 0)
                {
                    failed = true;
                    MessageBox.Show("Maximale bezetting moet groter dan 0 zijn");
                }
                surfaceArea = Convert.ToInt32(numSurfaceArea.Value);
                if(surfaceArea == 0)
                {
                    failed = true;
                    MessageBox.Show("Oppervlakte moet groter dan 0 zijn");
                }
                amount = Convert.ToInt32(numAmount.Value);
                if(amount == 0)
                {
                    failed = true;
                    MessageBox.Show("Hoeveelheid moet groter dan 0 zijn");
                }

                if(!failed)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
