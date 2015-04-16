using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MateriaalBeheerSysteem
{
    public partial class AddItem : Form
    {

        public string name;
        public decimal price;
        public decimal rentPrice;
        public int amount;

        public AddItem()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            name = tbName.Text;
            price = numPrice.Value;
            rentPrice = numRentPrice.Value;
            amount = Convert.ToInt32(numAmount.Value);
        }
    }
}
