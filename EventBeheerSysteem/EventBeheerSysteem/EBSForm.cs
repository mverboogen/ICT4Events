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
    public partial class EBSForm : Form
    {
        private EventManager eventManager = new EventManager();
        private DatabaseManager dbHandler = new DatabaseManager();

        public EBSForm()
        {
            InitializeComponent();
        }
    }
}
