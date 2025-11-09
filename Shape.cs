using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver {
    public class Shape {
        public Point[] Points;
        public Color Color { get; set; }
        public int ID { get; set; }
        public int xVel { get; set; }
        public int yVel { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public List<int> CollidingWith = new List<int>();

        public Shape(Point mousePos, int maxWidth, int maxHeight, List<Shape> ExistingShapes) {
            this.ID = ExistingShapes.Count > 0 ? ExistingShapes.Max(s => s.ID) + 1 : 1;
            Random rnd = new Random();
            int numOfPoints = rnd.Next(3, 10);
            this.Points = new Point[numOfPoints];
            for(int i = 0; i < numOfPoints; i++) {
                this.Points[i] = new Point(
                    rnd.Next(mousePos.X - 80, mousePos.X + 80),
                    rnd.Next(mousePos.Y - 80, mousePos.Y + 80)
                );
                if(this.Points[i].X < 0) this.Points[i].X = 0;
                if(this.Points[i].Y < 0) this.Points[i].Y = 0;
                if(this.Points[i].X > maxWidth) this.Points[i].X = maxWidth;
                if(this.Points[i].Y > maxHeight) this.Points[i].Y = maxHeight;
            }
            this.Color = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            this.xVel = rnd.Next(-10, 10);
            this.yVel = rnd.Next(-10, 10);
            this.Top = this.Points.Min(p => p.Y);
            this.Bottom = this.Points.Max(p => p.Y);
            this.Left = this.Points.Min(p => p.X);
            this.Right = this.Points.Max(p => p.X);
        }

        public void collisionCheck(List<Shape> shapes, Graphics g) {
            foreach(var otherShape in shapes) {
                if(this != otherShape && this.IsCollidingWith(otherShape, g)) {
                    if(!this.CollidingWith.Contains(otherShape.ID)) {
                        this.CollidingWith.Add(otherShape.ID);
                        otherShape.CollidingWith.Add(this.ID);
                        if(Math.Abs(this.xVel) == this.xVel && Math.Abs(otherShape.xVel) == otherShape.xVel) {
                            if(this.xVel > otherShape.xVel) {
                                this.xVel = -this.xVel;
                            } else {
                                otherShape.xVel = -otherShape.xVel;
                            }
                        } else if(Math.Abs(this.xVel) != this.xVel && Math.Abs(otherShape.xVel) != otherShape.xVel) {
                            if(this.xVel < otherShape.xVel) {
                                this.xVel = -this.xVel;
                            } else {
                                otherShape.xVel = -otherShape.xVel;
                            }
                        } else {
                            this.xVel = -this.xVel;
                            otherShape.xVel = -otherShape.xVel;
                        }
                        if(Math.Abs(this.yVel) == this.yVel && Math.Abs(otherShape.yVel) == otherShape.yVel) {
                            if(this.yVel > otherShape.yVel) {
                                this.yVel = -this.yVel;
                            } else {
                                otherShape.yVel = -otherShape.yVel;
                            }
                        } else if(Math.Abs(this.yVel) != this.yVel && Math.Abs(otherShape.yVel) != otherShape.yVel) {
                            if(this.yVel < otherShape.yVel) {
                                this.yVel = -this.yVel;
                            } else {
                                otherShape.yVel = -otherShape.yVel;
                            }
                        } else {
                            this.yVel = -this.yVel;
                            otherShape.yVel = -otherShape.yVel;
                        }
                    }
                } else {
                    if(this.CollidingWith.Contains(otherShape.ID)) {
                        this.CollidingWith.Remove(otherShape.ID);
                        otherShape.CollidingWith.Remove(this.ID);
                    }
                }
            }
        }

        public void Move(int xDir, int yDir, int screenWidth, int screenHeight) {
            for(int i = 0; i < Points.Length; i++) {
                Points[i].X += xDir;
                Points[i].Y += yDir;
            }
            Top = (int) (Top + yDir);
            Bottom = (int) (Bottom + yDir);
            Left = (int) (Left + xDir);
            Right = (int) (Right + xDir);
            if(Top <= 0) {
                this.yVel = Math.Abs(this.yVel);
            }
            if(Bottom > screenHeight) {
                this.yVel = -Math.Abs(this.yVel);
            }
            if(Left <= 0) {
                this.xVel = Math.Abs(this.xVel);
            }
            if(Right > screenWidth) {
                this.xVel = -Math.Abs(this.xVel);
            }
        }

        public bool IsCollidingWith(Shape other, Graphics g) {
            GraphicsPath path1 = new GraphicsPath();
            path1.AddPolygon(this.Points);
            Region region1 = new Region(path1);
            GraphicsPath path2 = new GraphicsPath();
            path2.AddPolygon(other.Points);
            Region region2 = new Region(path2);
            region1.Intersect(region2);
            bool isColliding = !region1.IsEmpty(g);
            region1.Dispose();
            region2.Dispose();
            return isColliding;
        }

        public void Draw(Graphics g) {
            using(var brush = new SolidBrush(this.Color)) {
                g.FillPolygon(brush, this.Points, FillMode.Winding);
            }
        }
    }
}
