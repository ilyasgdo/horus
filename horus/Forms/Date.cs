using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using horus.@class;

namespace horus.Forms
{
    public partial class Date : Form
    {
        public Date()
        {
            InitializeComponent();
            monthCalendar.MaxDate = DateTime.Now;
            monthCalendar.MaxDate = DateTime.Now;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            DateTime date = monthCalendar.SelectionStart;
            Parametres param = new Parametres();
            param.SetDate(date);
            this.Close();
        }
    }
}
