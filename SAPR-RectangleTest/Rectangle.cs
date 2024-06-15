using SAPR_RectangleTest.Strategies.Ignore;
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

        public static Rectangle RedrawWithIgnoredPoints(Rectangle userMainRectangle, List<Rectangle> secondaryRectangles)
        {
            double minX = userMainRectangle.TopLeft.X;

            double minY = userMainRectangle.TopLeft.Y;

            double maxX = userMainRectangle.BotRight.X;

            double maxY = userMainRectangle.BotRight.Y;

            foreach (var rect in secondaryRectangles)
            {
                if (IsPointInsideMainRectangle(userMainRectangle, rect.BotLeft))
                {
                    minX = Math.Min(minX, rect.BotLeft.X);
                    minY = Math.Min(minY, rect.BotLeft.Y);
                    maxX = Math.Max(maxX, rect.BotLeft.X);
                    maxY = Math.Max(maxY, rect.BotLeft.Y);
                }

                if (IsPointInsideMainRectangle(userMainRectangle, rect.TopLeft))
                {
                    minX = Math.Min(minX, rect.TopLeft.X);
                    minY = Math.Min(minY, rect.TopLeft.Y);
                    maxX = Math.Max(maxX, rect.TopLeft.X);
                    maxY = Math.Max(maxY, rect.TopLeft.Y);
                }

                if (IsPointInsideMainRectangle(userMainRectangle, rect.BotRight))
                {
                    minX = Math.Min(minX, rect.BotRight.X);
                    minY = Math.Min(minY, rect.BotRight.Y);
                    maxX = Math.Max(maxX, rect.BotRight.X);
                    maxY = Math.Max(maxY, rect.BotRight.Y);
                }

                if (IsPointInsideMainRectangle(userMainRectangle, rect.TopRight))
                {
                    minX = Math.Min(minX, rect.TopRight.X);
                    minY = Math.Min(minY, rect.TopRight.Y);
                    maxX = Math.Max(maxX, rect.TopRight.X);
                    maxY = Math.Max(maxY, rect.TopRight.Y);
                }
            }


            Rectangle newRectangle = new Rectangle(
                new Point(minX, minY),
                new Point(minX, maxY),
                new Point(maxX, minY),
                new Point(maxX, maxY));

            return newRectangle;
        }

        public static Rectangle RedrawWithIgnoredColors(Rectangle userMainRectangle, List<Rectangle> secondaryRectangles, List<string> colors)
        {
            double minX = userMainRectangle.TopLeft.X;

            double minY = userMainRectangle.TopLeft.Y;

            double maxX = userMainRectangle.BotRight.X;

            double maxY = userMainRectangle.BotRight.Y;

            foreach (var rect in secondaryRectangles)
            {
                if (colors.Contains(rect.FillColor))
                {
                    if (IsPointInsideMainRectangle(userMainRectangle, rect.BotLeft))
                    {
                        minX = Math.Min(minX, rect.BotLeft.X);
                        minY = Math.Min(minY, rect.BotLeft.Y);
                        maxX = Math.Max(maxX, rect.BotLeft.X);
                        maxY = Math.Max(maxY, rect.BotLeft.Y);
                    }

                    if (IsPointInsideMainRectangle(userMainRectangle, rect.TopLeft))
                    {
                        minX = Math.Min(minX, rect.TopLeft.X);
                        minY = Math.Min(minY, rect.TopLeft.Y);
                        maxX = Math.Max(maxX, rect.TopLeft.X);
                        maxY = Math.Max(maxY, rect.TopLeft.Y);
                    }

                    if (IsPointInsideMainRectangle(userMainRectangle, rect.BotRight))
                    {
                        minX = Math.Min(minX, rect.BotRight.X);
                        minY = Math.Min(minY, rect.BotRight.Y);
                        maxX = Math.Max(maxX, rect.BotRight.X);
                        maxY = Math.Max(maxY, rect.BotRight.Y);
                    }

                    if (IsPointInsideMainRectangle(userMainRectangle, rect.TopRight))
                    {
                        minX = Math.Min(minX, rect.TopRight.X);
                        minY = Math.Min(minY, rect.TopRight.Y);
                        maxX = Math.Max(maxX, rect.TopRight.X);
                        maxY = Math.Max(maxY, rect.TopRight.Y);
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
                   point.Y >= mainRectangle.TopLeft.Y &&
                   point.X <= mainRectangle.BotRight.X &&
                   point.Y <= mainRectangle.BotRight.Y;
        }
    }
}
