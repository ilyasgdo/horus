﻿using System;
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
    public partial class TelechargementForm : Form
    {
        public TelechargementForm()
        {
            InitializeComponent();
            monthCalendarDebut.MaxDate = DateTime.Now;
            monthCalendarFin.MaxDate = DateTime.Now;
        }
    }
}
