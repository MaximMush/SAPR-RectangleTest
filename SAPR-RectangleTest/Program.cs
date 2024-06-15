using SAPR_RectangleTest;


Console.WriteLine("Выберете вариант записи");
Console.WriteLine("1 - Консоль, 2 - Файл");

int userChoice = 0;

LogStrategy logStrategy = null;

userChoice = int.Parse(Console.ReadLine());

string logMessage = string.Empty;
string filePath;

switch (userChoice)
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
List<Rectangle> rectangles = new List<Rectangle>();
rectangles = SecondaryRectanglesInputManager.GetRectangles();

for (int i = 0; i < rectangles.Count; i++)
{
	logMessage += $"Второстепенный прямоугольник{i}:\n";
	logMessage += $"Левая верхняя точка = [{rectangles[i].TopLeft.X}, {rectangles[i].TopLeft.Y}]\n, Правая верхняя точка = [{rectangles[i].TopRight.X}, {rectangles[i].TopRight.X}]\n" +
		$", Левая нижняя точка = [{rectangles[i].BotLeft.X}, {rectangles[i].BotLeft.Y}]\n, Правая нижняя точка = [{rectangles[i].BotRight.X}, {rectangles[i].BotRight.Y}]\n" +
		$", Цвет =  {rectangles[i].FillColor}\n";
}

logMessage += "\n";

Rectangle mainRectangle;
mainRectangle = CreatorRectangle.GetMainRectangle(rectangles);

logMessage += "Главный прямоугольник очертивший крайние точки второстепенных прямоугольников:\n";
logMessage += $"Левая верхняя точка = [{mainRectangle.TopLeft.X}, {mainRectangle.TopLeft.Y}]\n, Правая верхняя точка = [{mainRectangle.TopRight.X}, {mainRectangle.TopRight.X}]\n" +
        $", Левая нижняя точка = [{mainRectangle.BotLeft.X}, {mainRectangle.BotLeft.Y}]\n, Правая нижняя точка = [{mainRectangle.BotRight.X}, {mainRectangle.BotRight.Y}]\n" +
        $", Цвет =  {mainRectangle.FillColor}\n";

logStrategy.LogMessage = logMessage;

logStrategy.Log();


