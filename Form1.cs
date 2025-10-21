using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ScreenSaver {
    public partial class Form1: Form {

        static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Form1() {
            InitializeComponent();
            pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Controls.Add(pictureBox1);
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 16;
            timer.Start();
        }

        private void Form1_Load(object sender, System.EventArgs e) {
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
            foreach (var shape in shapes) {
                for (int i = 0; i < shape.Points.Length; i++) {
                    shape.Points[i] = new Point(
                        (int)(shape.Points[i].X + shape.xVel * 10),
                        (int)(shape.Points[i].Y + shape.yVel * 10)
                    );
                    if (shape.Points[i].X < 0 || shape.Points[i].X > pictureBox1.Width) {
                        shape.xVel = -shape.xVel;
                    }
                    if (shape.Points[i].Y < 0 || shape.Points[i].Y > pictureBox1.Height) {
                        shape.yVel = -shape.yVel;
                    }
                }
            }
            pictureBox1.Invalidate();
               
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var shape in shapes) {
                if (shape?.Points == null || shape.Points.Length < 3)
                    continue;

                using (var brush = new SolidBrush(shape.Color)) {
                    g.FillPolygon(brush, shape.Points);
                }
            }
        }

        public List<Shape> shapes = new List<Shape> {
            new Shape(new Point[] {
                new Point(50, 50),
                new Point(100, 50),
                new Point(250, 150),
                new Point(50, 150),
                new Point(50, 50)
            }, Color.Blue, new Random().NextDouble(), new Random().NextDouble()),
        };

        private void pictureBox1_Click(object sender, EventArgs e) {
            Random rnd = new Random();
            int numOfPoints = rnd.Next(3, 10);
            Point mousePos = pictureBox1.PointToClient(Cursor.Position);
            Point[] points = new Point[numOfPoints];
            for (int i = 0; i < numOfPoints; i++) {
                points[i] = new Point(
                    rnd.Next(mousePos.X - 80, mousePos.X + 80),
                    rnd.Next(mousePos.Y - 80, mousePos.Y + 80)
                );
                if(points[i].X < 0) points[i].X = 0;
                if(points[i].Y < 0) points[i].Y = 0;
                if(points[i].X > pictureBox1.Width) points[i].X = pictureBox1.Width;
                if(points[i].Y > pictureBox1.Height) points[i].Y = pictureBox1.Height;
            }
            shapes.Add(new Shape(points, Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255)), rnd.NextDouble() * 2 - 1, rnd.NextDouble() * 2 - 1));

        }
    }

    public class Shape {
        public Point[] Points;
        public Color Color { get; set; }
        public double xVel { get; set; }
        public double yVel { get; set; }
        public Shape(Point[] points, Color color, double xVel, double yVel) {
            Points = points;
            Color = color;
            this.xVel = xVel;
            this.yVel = yVel;
        }
    }
}
