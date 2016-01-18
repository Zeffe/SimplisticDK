using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace SimplisticDK
{
    public partial class formStart : Form
    {

        public formStart()
        {
            InitializeComponent();
        }

        public static void pbHighlight(PictureBox pct)
        {
            pct.MouseEnter += new EventHandler(pbEnter);
            pct.MouseLeave += new EventHandler(pbLeave);
        }

        public static void pbEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.BackColor = Color.FromArgb(pb.BackColor.R + 30, pb.BackColor.G + 30, pb.BackColor.B + 30);
        }

        public static void pbLeave(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            pb.BackColor = Color.FromArgb(pb.BackColor.R - 30, pb.BackColor.G - 30, pb.BackColor.B - 30);
        }

        private void formStart_Load(object sender, EventArgs e)
        {
            pbHighlight(btnExit);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void pnlTop_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
    }
}
