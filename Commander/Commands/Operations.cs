using Commander.AutoIt;
using System.Drawing;
using System.Windows.Forms;

namespace Commander.Commands
{
    public static class Operations
    {
        public static void KeyDown(string keys)
        {
            SendKeys.SendWait(keys);
        }
        public static void MouseClick(MouseButtons buttons, int clicks, Point location)
        {
            AutoIt.AutoItX.MouseClick(buttons.ToString().ToUpper(), location.X, location.Y, clicks, 0);
        }
        public static void MouseDoubleClick(MouseButtons buttons, int clicks, Point location)
        {
            AutoIt.AutoItX.MouseClick(buttons.ToString().ToUpper(), location.X, location.Y, clicks, 0);
        }
        public static void MouseMove(Point location)
        {
            AutoIt.AutoItX.MouseMove(location.X, location.Y, 0);
        }
        public static void MouseDown(MouseButtons buttons, Point location)
        {
            AutoItX.MouseMove(location.X, location.Y, 0);
            AutoItX.MouseDown(buttons.ToString().ToUpper());
        }
        public static void MouseUp(MouseButtons buttons, Point location)
        {
            AutoItX.MouseMove(location.X, location.Y, 0);
            AutoItX.MouseUp(buttons.ToString().ToUpper());
        }
    }
}
