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
    public partial class AddMember : Form
    {

        public string surname;
        public string lastname;
        public string email;

        public AddMember()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool failed = false;

            surname = tbSurname.Text;
            if(surname.Length > 40)
            {
                failed = true;
                MessageBox.Show("Voornaam kan niet langer dan 40 characters zijn");
            }
            lastname = tbLastname.Text;
            if (lastname.Length > 40)
            {
                failed = true;
                MessageBox.Show("Achternaam kan niet langer dan 40 characters zijn");
            }
            email = tbEmail.Text;

            if(!failed)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
