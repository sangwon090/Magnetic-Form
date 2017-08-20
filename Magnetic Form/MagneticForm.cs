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
    public partial class MagneticForm : Form
    {
        public int sensitivity = 30;
        //10 에서 25 사이 값을 추천합니다. 기본 값 : 15

        private bool[] location;
        private int x;
        private int y;
        private int width;
        private int height;

        public MagneticForm()
        {
            InitializeComponent();
        }

        public void passData(bool[] remoteLocate, int remoteX, int remoteY, int remoteWidth, int remoteHeight)
        {
            location = remoteLocate;
            x = remoteX;
            y = remoteY;
            width = remoteWidth;
            height = remoteHeight;

            label2.Text = String.Format("데이터 : {0}, {1}, {2}, {3}", x, y, width ,height);
        }

        private void MagneticForm_Move(object sender, EventArgs e)
        {
            if (location[0])
            {
                if(this.Location.Y + this.height >= y - sensitivity && this.Location.Y + this.height <= y + sensitivity && this.Location.X + this.width >= x && this.Location.X <= x + width)
                {
                    this.Location = new Point(this.Location.X, y - this.height);
                }
            }

            if (location[1])
            {
                if (this.Location.X <= x + width + sensitivity && this.Location.X >= x + width - sensitivity && this.Location.Y + this.height >= y && this.Location.Y <= y + height)
                {
                    this.Location = new Point(x + width, this.Location.Y );
                }
            }

            if (location[2])
            {
                if(this.Location.Y <= y + height + sensitivity && this.Location.Y >= y + height - sensitivity && this.Location.X + this.width >= x && this.Location.X <= x + width)
                {
                    this.Location = new Point(this.Location.X, y + height);
                }
            }

            if (location[3])
            {
                if (this.Location.X + this.width >= x - sensitivity && this.Location.X + this.width <= x + sensitivity && this.Location.Y + this.height >= y && this.Location.Y <= y + height)
                {
                    this.Location = new Point(x - this.width, this.Location.Y);
                }
            }
        }

        private void MagneticForm_Load(object sender, EventArgs e)
        {
            label1.Text = String.Format("감도 : {0}", sensitivity);
        }
    }
}
