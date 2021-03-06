﻿using System;
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

            bool failed = false;

            name = tbName.Text;
            if(name.Length > 40)
            {
                failed = true;
                MessageBox.Show("Naam kan niet groter dan 40 characters zijn");
            }
            price = numPrice.Value;
            rentPrice = numRentPrice.Value;
            amount = Convert.ToInt32(numAmount.Value);

            if(!failed)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
