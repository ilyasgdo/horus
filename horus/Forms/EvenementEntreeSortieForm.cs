﻿using horus.@class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace horus.Forms
{
    public partial class EvenementEntreeSortieForm : Form
    {
        public EvenementEntreeSortieForm()
        {
            InitializeComponent();
        }

        private void btnValiderEvenement_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
