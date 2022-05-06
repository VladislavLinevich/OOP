using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painting
{
    public class Presenter
    {
        private Model model;
        public Presenter(Model model)
        {
            this.model = model;
        }

        public Model MoveForLine(int eX, int eY)
        {
            model.MoveForLine(eX, eY);
            return model;
        }
        public Model MoveForOtherFigures(int eX, int eY)
        {
            model.MoveForOtherFigures(eX, eY);
            return model;
        }
        public Model Paint(string ComboText, Graphics graphics)
        {
            model.Paint(ComboText, graphics);
            return model;
        }
        public Model Click(string ComboText, int eX, int eY)
        {
            model.Click(ComboText, eX, eY);
            return model;
        }
        public Model DbClick(string ComboText)
        {
            model.DbClick(ComboText);
            return model;
        }
        public Model Undo()
        {
            model.Undo();
            return model;
        }
        public Model Redo()
        {
            model.Redo();
            return model;
        }
        public Model RedoAll()
        {
            model.RedoAll();
            return model;
        }
        public Model Serialize()
        {
            model.Serialize();
            return model;
        }
        public Model Deserialize()
        {
            model.Deserialize();
            return model;
        }
        public Model TrapezeClick(string ComboText, int eX, int eY, int length, int height)
        {
            model.TrapezeClick(ComboText, eX, eY, length, height);
            return model;
        }
    }
}
