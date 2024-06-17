
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_RectangleTest
{
    public class Rectangle
    {
        public Rectangle() { }
        public Rectangle(
            Point botLeft, 
            Point topLeft, 
            Point botRight, 
            Point topRight,
            string color = "black")
        {
            BotLeft = botLeft;
            TopLeft = topLeft;
            BotRight = botRight;
            TopRight = topRight;
            FillColor = color;
        }
        public Point BotLeft { get; set; }

        public Point TopLeft { get; set; }

        public Point BotRight { get; set; }

        public Point TopRight { get; set; }
        public string FillColor { get; set; }

        public Rectangle ReDrawMainRectangle(List<Rectangle> secondaryRectangles)
        {
            var minX = secondaryRectangles.Min(r => r.BotLeft.X);
            var minY = secondaryRectangles.Min(r => r.BotLeft.Y);
            var maxX = secondaryRectangles.Max(r => r.TopRight.X);
            var maxY = secondaryRectangles.Max(r => r.TopRight.Y);

            var mainRectangle = new Rectangle(
                new Point(minX, minY),
                new Point(minX, maxY),
                new Point(maxX, minY),
                new Point(maxX, maxY)
            );

            return mainRectangle;
        }

        public static Rectangle Ignore(Rectangle userMainRectangle, List<Rectangle> secondaryRectangles)
        {
            double minX = userMainRectangle.TopRight.X;
            double minY = userMainRectangle.TopRight.Y;
            double maxX = userMainRectangle.BotLeft.X;
            double maxY = userMainRectangle.BotRight.Y;

            foreach (var rect in secondaryRectangles)
            {
                if (IsPointInsideMainRectangle(userMainRectangle, rect.BotLeft))
                {
                    minX = Math.Min(minX, rect.BotLeft.X);
                }

                if (IsPointInsideMainRectangle(userMainRectangle, rect.TopLeft))
                {
                    minX = Math.Min(minX, rect.TopLeft.X);
                    minY = Math.Min(minY, rect.BotLeft.Y);
                }

                if (IsPointInsideMainRectangle(userMainRectangle, rect.BotRight))
                {
                    maxX = Math.Max(maxX, rect.BotRight.X);
                    maxY = Math.Max(maxY, rect.BotRight.Y);
                }

                if (IsPointInsideMainRectangle(userMainRectangle, rect.TopRight))
                {
                    minY = Math.Min(minY, rect.BotLeft.Y);
                    maxX = Math.Max(maxX, rect.TopRight.X);
                }
            }

            Rectangle newRectangle = new Rectangle(
                new Point(minX, minY),
                new Point(minX, maxY),
                new Point(maxX, minY),
                new Point(maxX, maxY));

            return newRectangle;
        }

        public static Rectangle Ignore(Rectangle userMainRectangle, List<Rectangle> secondaryRectangles, List<string> colors)
        {
            double minX = userMainRectangle.TopRight.X;
            double minY = userMainRectangle.TopRight.Y;
            double maxX = userMainRectangle.BotLeft.X;
            double maxY = userMainRectangle.BotLeft.Y;

            foreach (var rect in secondaryRectangles)
            {
                if (colors.Contains(rect.FillColor))
                {
                    if (IsPointInsideMainRectangle(userMainRectangle, rect.BotLeft))
                    {
                        minX = Math.Min(minX, rect.BotLeft.X);
                    }

                    if (IsPointInsideMainRectangle(userMainRectangle, rect.TopLeft))
                    {
                        minX = Math.Min(minX, rect.TopLeft.X);
                        minY = Math.Min(minY, rect.BotLeft.Y); 
                    }

                    if (IsPointInsideMainRectangle(userMainRectangle, rect.BotRight))
                    {
                        maxX = Math.Max(maxX, rect.BotRight.X);
                        maxY = Math.Max(maxY, rect.TopRight.Y);
                    }

                    if (IsPointInsideMainRectangle(userMainRectangle, rect.TopRight))
                    {
                        minY = Math.Min(minY, rect.BotLeft.Y); 
                        maxX = Math.Max(maxX, rect.TopRight.X);
                    }
                }
            }

            Rectangle newRectangle = new Rectangle(
                new Point(minX, minY),
                new Point(minX, maxY),
                new Point(maxX, minY),
                new Point(maxX, maxY));

            return newRectangle;    
        }


        public static bool IsPointInsideMainRectangle(Rectangle mainRectangle, Point point)
        {
            return point.X >= mainRectangle.TopLeft.X && 
                   point.X <= mainRectangle.BotRight.X && 
                   point.Y <= mainRectangle.TopLeft.Y &&  
                   point.Y >= mainRectangle.BotRight.Y;  
        }


    }
}
