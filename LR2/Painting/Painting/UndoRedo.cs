using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting
{
    public class UndoRedo
    {
        public List<Figure> figures { get; set; }
        public Stack<Figure> UndoFigures { get; set; }
        public UndoRedo()
        {
            figures = new List<Figure>();
            UndoFigures = new Stack<Figure>();
        }

        public void Undo()
        {
            if (figures.Count > 0)
            {
                Figure figure = figures[figures.Count - 1];
                figures.RemoveAt(figures.Count - 1);
                UndoFigures.Push(figure);
            }
        }
        public void Redo()
        {
            if (UndoFigures.Count > 0)
            {
                Figure figure = UndoFigures.Pop();
                figures.Add(figure);
            }
        }

        public void RedoAll()
        {
            int count = UndoFigures.Count;
            for (int i = 0; i < count; i++)
            {
                Figure figure = UndoFigures.Pop();
                figures.Add(figure);
            }
        }
    }
}
