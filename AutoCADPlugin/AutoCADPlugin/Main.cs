using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.Runtime;

namespace AutoCADPlugin
{

    public static class Main
    {
        [CommandMethod("DrawingSelection")]
        public static void DrawingSelection()
        {
            DrawingSelection form = new AutoCADPlugin.DrawingSelection();
            form.ShowDialog();
        }
    }
}
