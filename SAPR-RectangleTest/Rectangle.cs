using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_RectangleTest
{
    public class Rectangle
    {
        public Rectangle(Point botLeft, Point topLeft, Point botRight, Point topRight, string color = "black")
        {
            BotLeft = botLeft;
            TopLeft = topLeft;
            BotRight = botRight;
            TopRight = topRight;
        }
        public Point BotLeft { get; set; }

        public Point TopLeft { get; set; }

        public Point BotRight { get; set; }

        public Point TopRight { get; set; }
        public string FillColor { get; set; }
    }
}
