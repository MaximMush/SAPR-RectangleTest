using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_RectangleTest
{
    public class CreatorRectangle
    {
        public static Rectangle GetMainRectangle(List<Rectangle> secondaryRectangles)
        {
            double minX = secondaryRectangles.Min(r => r.TopLeft.X);
            double minY = secondaryRectangles.Min(r => r.TopLeft.Y);
            double maxX = secondaryRectangles.Max(r => r.BotRight.X);
            double maxY = secondaryRectangles.Max(r => r.BotRight.Y);

            Point TopLeft = new Point(minX, minY); 
            Point TopRight = new Point(maxX, minY);
            Point BotLeft = new Point(minX, maxY);
            Point BotRight = new Point(maxX, maxY);

            Rectangle mainRectangle = new Rectangle(BotLeft, TopLeft, BotRight, TopRight);

            return mainRectangle;
        }

    }
}
