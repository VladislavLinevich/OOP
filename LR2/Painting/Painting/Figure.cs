using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painting
{
    public abstract class Figure
    {
        public string Name { get; set; }
        public abstract void Draw(Graphics graphics);
    }

    public class Line : Figure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public Line(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            Name = "Line";
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(new Pen(PenColor, PenWidth), new Point(x1, y1), new Point(x2, y2));
        }
    }

    public class Rectangle: Figure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public Rectangle(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            Name = "Rectangle";
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(PenColor, PenWidth), x1, y1, x2, y2);
            if (PenWidth % 2 != 0)
            {
                graphics.FillRectangle(new SolidBrush(BrushColor), x1 + 1, y1 + 1, x2 - 1, y2 - 1);
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(BrushColor), x1, y1, x2, y2);
            }
        }
    }

    public class Ellipse : Figure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public Ellipse(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            Name = "Ellipse";
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
        }
        public override void Draw(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(PenColor, PenWidth), x1, y1, x2, y2);
            graphics.FillEllipse(new SolidBrush(BrushColor), x1, y1, x2, y2);
        }
    }

    public class BrokenLine : Figure
    {
        public List<Line> lines { get; set; }
        public BrokenLine(List<Line> lines)
        {
            Name = "BrokenLine";
            this.lines = lines;
        }
        public override void Draw(Graphics graphics)
        {
            foreach (Line line in lines)
            {
                line.Draw(graphics);
            }
        }
    }

    public class Trapeze : Figure
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int lengthDown { get; set; }
        public int lengthUp { get; set; }
        public Color PenColor { get; set; }
        public float PenWidth { get; set; }
        public Color BrushColor { get; set; }
        public Trapeze(int x1, int y1, int lengthDown, int lengthUp, Color PenColor, float PenWidth, Color BrushColor)
        {
            Name = "Trapeze";
            this.x1 = x1;
            this.y1 = y1;
            this.lengthDown = lengthDown;
            this.lengthUp = lengthUp;
            this.PenColor = PenColor;
            this.PenWidth = PenWidth;
            this.BrushColor = BrushColor;
        }
        public override void Draw(Graphics graphics)
        {
            foreach (var plugin in Model.plugins)
            {
                if (plugin.GetType().Name == "Trapeze")
                {
                    plugin.Draw(x1, y1, lengthDown, lengthUp, new Pen(PenColor, PenWidth), new SolidBrush(BrushColor), graphics);
                }
            }
        }
    }
}
