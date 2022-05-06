using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using PluginInterface;

namespace Painting
{
    public class Model
    {
        private int x1;
        private int x2;
        private int y1;
        private int y2;
        private int n;
        private int temp_x1;
        private int temp_y1;
        public static List<IPlugin> plugins;
        public UndoRedo undoRedo;
        private List<Line> lines;
        private Dictionary<string, FigureFactory> dict;
        public Pen pen { get; set; }
        public Graphics g { get; set; }
        public SolidBrush brush { get; set; }
        public bool IsClicked { get; set; }
        public Model()
        {
            IsClicked = false;
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
            n = 0;
            temp_x1 = 0;
            temp_y1 = 0;
            undoRedo = new UndoRedo();
            lines = new List<Line>();
            dict = new Dictionary<string, FigureFactory>();
            dict.Add("Line", new LineFactory());
            dict.Add("Ellipse", new EllipseFactory());
            dict.Add("Rectangle", new RectangleFactory());
            dict.Add("Trapeze", new TrapezeFactory());
            pen = new Pen(Color.Black);
            brush = new SolidBrush(Color.Transparent);
            plugins = new List<IPlugin>();
        }

        public void MoveForLine(int eX, int eY)
        {
            x2 = eX;
            y2 = eY;
        }

        public void MoveForOtherFigures(int eX, int eY)
        {
            if (eX - temp_x1 > 0 && eY - temp_y1 > 0)
            {
                x1 = temp_x1;
                y1 = temp_y1;
                x2 = eX - temp_x1;
                y2 = eY - temp_y1;
            }
            if (eX - temp_x1 < 0 && eY - temp_y1 > 0)
            {
                x1 = eX;
                y1 = temp_y1;
                x2 = temp_x1 - eX;
                y2 = eY - temp_y1;
            }
            if (eX - temp_x1 > 0 && eY - temp_y1 < 0)
            {
                x1 = temp_x1;
                y1 = eY;
                x2 = eX - temp_x1;
                y2 = temp_y1 - eY;
            }
            if (eX - temp_x1 < 0 && eY - temp_y1 < 0)
            {
                x1 = eX;
                y1 = eY;
                x2 = temp_x1 - eX;
                y2 = temp_y1 - eY;
            }
        }

        public void Paint(string ComboText, Graphics graphics)
        {
            
            foreach (Figure f in undoRedo.figures)
            {
                f.Draw(graphics);
            }
            if (ComboText == "BrokenLine")
            {
                foreach (Line f in lines)
                {
                    f.Draw(graphics);
                }
                Figure figure = dict["Line"].CreateFigure(x1, y1, x2, y2, pen.Color, pen.Width, brush.Color);
                figure.Draw(graphics);
            }
            else
            { 
                Figure figure = dict[ComboText].CreateFigure(x1, y1, x2, y2, pen.Color, pen.Width, brush.Color);
                figure.Draw(graphics);
            }
            
            

        }
        public void Click(string ComboText, int eX, int eY)
        {
            undoRedo.UndoFigures.Clear();
            n += 1;
            if (n != 2)
            {
                IsClicked = true;
                x1 = eX;
                y1 = eY;
                temp_x1 = x1;
                temp_y1 = y1;
            }
            else
            {
                if (ComboText == "BrokenLine")
                {
                    lines.Add((Line)dict["Line"].CreateFigure(x1, y1, x2, y2, pen.Color, pen.Width, brush.Color));
                    n = 1;
                    IsClicked = true;
                    x1 = eX;
                    y1 = eY;
                }
                else
                {
                    IsClicked = false;
                    n = 0;
                    undoRedo.figures.Add(dict[ComboText].CreateFigure(x1, y1, x2, y2, pen.Color, pen.Width, brush.Color));
                    x1 = 0;
                    y1 = 0;
                    x2 = 0;
                    y2 = 0;
                }
            }
        }

        public void DbClick(string ComboText)
        {
            if (ComboText == "BrokenLine")
            {
                IsClicked = false;
                n = 0;
                BrokenLine figure = new BrokenLine(lines);
                lines = new List<Line>();
                undoRedo.figures.Add(figure);
                x1 = 0;
                y1 = 0;
                x2 = 0;
                y2 = 0;
            }
        }

        public void Undo()
        {
            undoRedo.Undo();
        }

        public void Redo()
        {
            undoRedo.Redo();
        }
        public void RedoAll()
        {
            undoRedo.RedoAll();
        }
        public void Serialize()
        {
            string js;
            
            using (StreamWriter writer = new StreamWriter(@"C:\Users\uladl\OOP\LR2\Painting\Painting\Serialize.json", false))
            {
                foreach (Figure figure in undoRedo.figures)
                {
                    js = JsonConvert.SerializeObject(figure);
                    if (js == "")
                    {
                        return;
                    }
                    writer.WriteLine(js);
                }
            }
        }

        public void Deserialize()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\uladl\OOP\LR2\Painting\Painting\Serialize.json"))
            {
                string js;
                string t = "";
                while ((js = reader.ReadLine()) != null)
                {
                    for (int i = js.Length - 3; i > 0; i--)
                    {
                        if (js[i] != '"')
                        {
                            continue;
                        }
                        for (int j = i + 1; j < js.Length - 2; j++)
                        {
                            t += js[j];
                        }
                        break;
                    }
                    if (t == "Line")
                    { 
                        Figure fig = JsonConvert.DeserializeObject<Line>(js);
                        undoRedo.figures.Add(fig);
                        t = "";
                    }
                    if (t == "Rectangle")
                    {
                        Figure fig = JsonConvert.DeserializeObject<Rectangle>(js);
                        undoRedo.figures.Add(fig);
                        t = "";
                    }
                    if (t == "Ellipse")
                    {
                        Figure fig = JsonConvert.DeserializeObject<Ellipse>(js);
                        undoRedo.figures.Add(fig);
                        t = "";
                    }
                    if (t == "BrokenLine")
                    {
                        Figure fig = JsonConvert.DeserializeObject<BrokenLine>(js);
                        undoRedo.figures.Add(fig);
                        t = "";
                    }
                    if (t == "Trapeze")
                    {
                        Figure fig = JsonConvert.DeserializeObject<Trapeze>(js);
                        undoRedo.figures.Add(fig);
                        t = "";
                    }

                }
            }
        }
        public void TrapezeClick(string ComboText, int eX, int eY, int length, int height)
        {
            undoRedo.UndoFigures.Clear();
            undoRedo.figures.Add(dict[ComboText].CreateFigure(eX, eY, length, height, pen.Color, pen.Width, brush.Color));
        }

    }
}
