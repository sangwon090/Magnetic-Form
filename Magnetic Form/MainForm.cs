using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magnetic_Form
{
    public partial class MainForm : Form
    {
        public bool[] location = { true, true, true, true};
        //북, 동, 남, 서
        //기본 값 : true, true, true, true

        MagneticForm mForm = new MagneticForm();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mForm.Show();
            button1.Enabled = false;
            mForm.passData(location, this.Location.X, this.Location.Y, this.Height, this.Width);
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            mForm.passData(location, this.Location.X, this.Location.Y, this.Height, this.Width);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            mForm.passData(location, this.Location.X, this.Location.Y, this.Height, this.Width);
        }
    }
}
