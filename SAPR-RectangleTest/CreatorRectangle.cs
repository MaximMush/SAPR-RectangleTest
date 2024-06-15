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
            var minX = secondaryRectangles.Min(r => r.TopLeft.X);
            var minY = secondaryRectangles.Min(r => r.TopLeft.Y);
            var maxX = secondaryRectangles.Max(r => r.BotRight.X);
            var maxY = secondaryRectangles.Max(r => r.BotRight.Y);

            var mainRectangle = new Rectangle(
                new Point(minX, minY),   
                new Point(minX, maxY),   
                new Point(maxX, minY),   
                new Point(maxX, maxY)    
            );

            return mainRectangle;
        }
    }
}
