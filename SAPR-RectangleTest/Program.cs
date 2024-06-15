using SAPR_RectangleTest;
using SAPR_RectangleTest.Strategies.Logging;

string logMessage = "";

Console.WriteLine("Выберете вариант записи");
Console.WriteLine("1 - Консоль, 2 - Файл");

int userLogChoice = 0;
userLogChoice = int.Parse(Console.ReadLine());

Console.WriteLine("Введите количество второстепенных прямоугольников:");

int secondaryRectcount = 0;
secondaryRectcount = int.Parse(Console.ReadLine());

Console.WriteLine("Учитывать координаты точек второстепенных прямоугольников, которые изначально выходили за границу главного прямоугольника?");
Console.WriteLine("Y/N?");

string userIgnoreChoice = "";
userIgnoreChoice = Console.ReadLine();

Console.WriteLine("Нужно ли добавить возможность игнорирования цветов?");
Console.WriteLine("Y/N?");

string userIgnoreColorsChoice = "";
userIgnoreColorsChoice = Console.ReadLine();

int userIgnoreColorOption = 0;
string colorName = "";

if (userIgnoreColorsChoice == "Y" || userIgnoreColorsChoice == "y")
{
    Console.WriteLine("Введите цвет (прим. green, black, white...):");

    colorName = Console.ReadLine();

    Console.WriteLine($"Игнорировать {colorName}, или все цвета кроме {colorName}?:");
    Console.WriteLine($"1 - Все цвета кроме {colorName}, 2 - Игнорировать {colorName}");

    userIgnoreColorOption = int.Parse(Console.ReadLine());
}

LogStrategy logStrategy = null;
string filePath;

switch (userLogChoice)
{
	case 1:
		logStrategy = new ConsoleLogStrategy();
		break;
	case 2:
        Console.WriteLine("Введите путь к файлу");
        filePath = Console.ReadLine();
		
		if (filePath != string.Empty)
		{
			logStrategy = new TextLogStrategy(filePath);
        }
		else
		{
            Console.WriteLine("Вы не ввели путь к файлу");
            Console.ReadKey();
            Environment.Exit(0);
        }
        break;
	default:
        Console.WriteLine("Выбран некоректный вариант записи. Нажмите любую клавишу для продолжения");
        Console.ReadKey();
        Environment.Exit(0);
        break;
}

Console.WriteLine($"Введите координаты главного прямоугольника:");

Rectangle mainRectangle;
mainRectangle = RectanglesInputManager.CreateRectangle();

logMessage += "Главный прямоугольник:\n";
logMessage += $"Левая верхняя точка = [{mainRectangle.TopLeft.X}, {mainRectangle.TopLeft.Y}]\n, Правая верхняя точка = [{mainRectangle.TopRight.X}, {mainRectangle.TopRight.Y}]\n" +
        $", Левая нижняя точка = [{mainRectangle.BotLeft.X}, {mainRectangle.BotLeft.Y}]\n, Правая нижняя точка = [{mainRectangle.BotRight.X}, {mainRectangle.BotRight.Y}]\n" +
        $", Цвет =  {mainRectangle.FillColor}\n";

logMessage += "\n";
logMessage += "Второстепенные прямоугольники:\n";

List<Rectangle> rectangles = new List<Rectangle>();
rectangles = RectanglesInputManager.GetSecondaryRectangles(secondaryRectcount);

for (int i = 0; i < rectangles.Count; i++)
{
	logMessage += $"Второстепенный прямоугольник{i}:\n";
	logMessage += $"- Левая верхняя точка = [{rectangles[i].TopLeft.X}, {rectangles[i].TopLeft.Y}],\n - Правая верхняя точка = [{rectangles[i].TopRight.X}, {rectangles[i].TopRight.Y}],\n" +
		$", - Левая нижняя точка = [{rectangles[i].BotLeft.X}, {rectangles[i].BotLeft.Y}],\n - Правая нижняя точка = [{rectangles[i].BotRight.X}, {rectangles[i].BotRight.Y}],\n" +
		$", - Цвет =  {rectangles[i].FillColor}\n";
}
logMessage += "\n";

logMessage += "Перерисовываю главный прямоугольник...\n";

mainRectangle = mainRectangle.ReDrawMainRectangle(rectangles);

if (userIgnoreChoice == "Y" || userIgnoreChoice == "y")
{
    logMessage += "\n";

    logMessage += "Перерисовываю главный прямоугольник c учётом проигнорированных точек...\n";

    mainRectangle = Rectangle.RedrawWithIgnoredPoints(mainRectangle, rectangles);
}

//Последовательность операций соблюдена с условием ТЗ
if (userIgnoreColorsChoice == "Y" || userIgnoreColorsChoice == "y")
{
    List<string> colors = new List<string>();

    if (userIgnoreColorOption == 1)
    {
        logMessage += "\n";

        logMessage += $"Перерисовываю главный прямоугольник c учётом проигнорированных второстепенных прямоугольников {colorName} цвета...\n";

        colors.Add(colorName);
    }
    else
    {
        logMessage += "\n";

        logMessage += $"Перерисовываю главный прямоугольник c учётом проигнорированных второстепенных прямоугольников всех кроме {colorName} цвета...\n";

        foreach (var rect in rectangles)
        {
            if (rect.FillColor != colorName)
            {
                colors.Add(rect.FillColor);
            }
        }
    }

    mainRectangle = Rectangle.RedrawWithIgnoredColors(mainRectangle, rectangles, colors);
}

logMessage += "Главный прямоугольник очертивший крайние точки второстепенных прямоугольников:\n";
logMessage += $"Левая верхняя точка = [{mainRectangle.TopLeft.X}, {mainRectangle.TopLeft.Y}]\n, Правая верхняя точка = [{mainRectangle.TopRight.X}, {mainRectangle.TopRight.Y}]\n" +
        $", Левая нижняя точка = [{mainRectangle.BotLeft.X}, {mainRectangle.BotLeft.Y}]\n, Правая нижняя точка = [{mainRectangle.BotRight.X}, {mainRectangle.BotRight.Y}]\n" +
        $", Цвет =  {mainRectangle.FillColor}\n";

logStrategy.LogMessage = logMessage;

logStrategy.Log();


