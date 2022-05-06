using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using PluginInterface;

namespace Plugins
{
    public class Trapeze: IPlugin
    {
        public void Draw(int x1, int y1, int lengthDown, int lengthUp, Pen pen, Brush brush, Graphics graphics)
        {
            int height = Math.Abs((lengthDown - lengthUp) / 2);
            if (lengthDown - lengthUp > 0)
            {
                Point[] points = { new Point(x1, y1), new Point(x1 + height, y1 - height), new Point(x1 + lengthDown - height, y1 - height), new Point(x1 + lengthDown, y1) };
                graphics.DrawPolygon(pen, points);
                if (pen.Width % 2 != 0)
                {
                    Point[] points2 = { new Point(x1, y1), new Point(x1 + height, y1 - height + 1), new Point(x1 + lengthDown - height, y1 - height), new Point(x1 + lengthDown, y1) };
                    graphics.FillPolygon(brush, points2);
                }
                else
                {
                    graphics.FillPolygon(brush, points);
                }
            }
            else
            {
                Point[] points = { new Point(x1, y1), new Point(x1 + height, y1 + height), new Point(x1 + lengthUp - height, y1 + height), new Point(x1 + lengthUp, y1) };
                graphics.DrawPolygon(pen, points);
                if (pen.Width % 2 != 0)
                {
                    Point[] points2 = { new Point(x1 + 2, y1 + 1), new Point(x1 + height, y1 + height), new Point(x1 + lengthUp - height, y1 + height), new Point(x1 + lengthUp, y1) };
                    graphics.FillPolygon(brush, points2);
                }
                else
                {
                    graphics.FillPolygon(brush, points);
                }
            }
        }
    }
}
