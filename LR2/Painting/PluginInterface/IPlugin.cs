using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PluginInterface
{
    public interface IPlugin
    {
        void Draw(int x1, int y1, int lengthDown, int lengthUp, Pen pen, Brush brush, Graphics graphics);
    }
}
