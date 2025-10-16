using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenSaver {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        public List<Shape> shapes = new List<Shape> {
            new Shape(new Point[] {
                new Point(50, 50),
                new Point(100, 50),
                new Point(250, 150),
                new Point(50, 150),
                new Point(50, 50)
            }, Color.Blue),
        };

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            foreach(var shape in shapes) {
                shape.Draw(shape.Points, e.Graphics);
            }
        }
    }
    public class Shape {
        public Point[] Points;
        public Color Color { get; set; }
        public Shape(Point[] points, Color color) {
            Points = points;
            Color = color;
        }

        public void Draw(Point[] points, Graphics g) {
            using(Pen pen = new Pen(Color, 3)) {
                g.DrawPolygon(pen, Array.ConvertAll(points, point => point));
            }
        }
    }
}
