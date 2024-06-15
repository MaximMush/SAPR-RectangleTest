using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_RectangleTest
{
    public static class RectanglesInputManager
    {
        public static Rectangle CreateRectangle(int i = 0)
        {
            Rectangle newRectangle;

            Console.Write("Top Left X: ");
            double topLeftX = double.Parse(Console.ReadLine());

            Console.Write("Top Left Y: ");
            double topLeftY = double.Parse(Console.ReadLine());

            Console.Write("Top Right X: ");
            double topRightX = double.Parse(Console.ReadLine());

            Console.Write("Top Right Y: ");
            double topRightY = double.Parse(Console.ReadLine());

            Console.Write("Bottom Left X: ");
            double botLeftX = double.Parse(Console.ReadLine());

            Console.Write("Bottom Left Y: ");
            double botLeftY = double.Parse(Console.ReadLine());

            Console.Write("Bottom Right X: ");
            double botRightX = double.Parse(Console.ReadLine());

            Console.Write("Bottom Right Y: ");
            double botRightY = double.Parse(Console.ReadLine());

            Console.Write("Color: ");
            string color = Console.ReadLine();

            Point topLeft = new Point(topLeftX, topLeftY);

            Point topRight = new Point(topRightX, topRightY);

            Point botLeft = new Point(botLeftX, botLeftY);

            Point botRight = new Point(botRightX, botRightY);

            newRectangle = new Rectangle(botLeft, topLeft, botRight, topRight, color);

            if (!IsValidRectangle(newRectangle.TopLeft, newRectangle.BotLeft, newRectangle.BotRight, newRectangle.TopRight))
            {
                Console.WriteLine("Вы ввели несущестующий прямоугольник. ");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return newRectangle;
        }

        public static List<Rectangle> GetSecondaryRectangles(int secondaryRectCount)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < secondaryRectCount; i++)
            {
                Console.WriteLine($"Введите координаты второстепенного прямоугольника {i + 1}:");

                Rectangle newRectangle = CreateRectangle(i);

                if (IsValidRectangle(newRectangle.TopLeft, newRectangle.BotLeft, newRectangle.BotRight, newRectangle.TopRight))
                { 
                    rectangles.Add(newRectangle);
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильный прямоугольник. Введите корректные вершины");
                    i--;
                }

            }
            return rectangles;
        }

        public static bool IsValidRectangle(Point p1, Point p2, Point p3, Point p4)
        {
            if (p1 == p2 || p1 == p3 || p1 == p4 || p2 == p3 || p2 == p4 || p3 == p4)
            {
                return false;
            }

            if (!IsParallelAndEqual(p1, p2, p3, p4) && !IsParallelAndEqual(p1, p3, p2, p4))
            {
                return false;
            }

            return true;
        }

        private static bool IsParallelAndEqual(Point p1, Point p2, Point p3, Point p4)
        {
            if (!IsParallel(p1, p2, p3, p4))
            {
                return false;
            }

            double d1 = Distance(p1, p2);
            double d2 = Distance(p3, p4);
            return Math.Abs(d1 - d2) < 1e-6;
        }

        private static bool IsParallel(Point p1, Point p2, Point p3, Point p4)
        {
            double dx1 = p2.X - p1.X;
            double dy1 = p2.Y - p1.Y;
            double dx2 = p4.X - p3.X;
            double dy2 = p4.Y - p3.Y;
            return Math.Abs(dx1 * dy2 - dy1 * dx2) < 1e-6;
        }

        private static double Distance(Point p1, Point p2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
    }
}


