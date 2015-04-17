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
        public string rfid;

        public AddMember()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            surname = tbSurname.Text;
            lastname = tbLastname.Text;
            email = tbEmail.Text;
            rfid = tbRFID.Text;
        }
    }
}
