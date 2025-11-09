using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Linq;

namespace ScreenSaver {
    public partial class Form1: Form {
        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1() {
            InitializeComponent();
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Controls.Add(pictureBox1);
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 8;
            timer.Start();
        }

        private void Form1_Load(object sender, System.EventArgs e) {}

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            Graphics g;
            g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (var shape in shapes) {
                shape.Move(shape.xVel, shape.yVel, pictureBox1.Width, pictureBox1.Height);
                shape.collisionCheck(shapes, g);
                shape.Draw(g);
            }
        }

        public List<Shape> shapes = new List<Shape> {};

        private void pictureBox1_Click(object sender, EventArgs e) {
            shapes.Add(new Shape(pictureBox1.PointToClient(Cursor.Position), pictureBox1.Width, pictureBox1.Height, shapes));
        }
    }
}
