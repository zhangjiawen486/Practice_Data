﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PracticeAdmin
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        public String str = "";

        private void frmLoading_Load(object sender, EventArgs e)
        {
            label1.Text = str;
        }
    }
}
