using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painting
{
    public abstract class FigureFactory
    {
        public abstract Figure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor);
    }

    class LineFactory: FigureFactory
    {
        public override Figure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            return new Line(x1, y1, x2, y2, PenColor, PenWidth, BrushColor);
        }
    }

    class RectangleFactory : FigureFactory
    {
        public override Figure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            return new Rectangle(x1, y1, x2, y2, PenColor, PenWidth, BrushColor);
        }
    }

    class EllipseFactory : FigureFactory
    {
        public override Figure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            return new Ellipse(x1, y1, x2, y2, PenColor, PenWidth, BrushColor);
        }
    }
    class TrapezeFactory : FigureFactory
    {
        public override Figure CreateFigure(int x1, int y1, int x2, int y2, Color PenColor, float PenWidth, Color BrushColor)
        {
            return new Trapeze(x1, y1, x2, y2, PenColor, PenWidth, BrushColor);
        }
    }
}
