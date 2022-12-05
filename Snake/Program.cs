using System.Threading.Tasks.Sources;
List<(int, int)> serpent = new();
string[,] affichage = new string[20, 20];
//On met le debut du serpent au milieu du code
serpent.Add((affichage.GetLength(0) / 2, affichage.GetLength(1) / 2));
(int x, int y) = serpent[0];
Random random = new Random();
(int, int) pomme = (random.Next(20), random.Next(20));
ConsoleKeyInfo touche = Console.ReadKey();
ConsoleKeyInfo toucheTemporaire;
int nombreDeFoisLaTete = 0;
int score =0;
bool perdu = true;
Console.BackgroundColor = ConsoleColor.DarkGray;
while (perdu)
{
	for (int i = 0; i < (affichage.GetLength(1) + 2)*2; i++)
	{
		Console.Write("_");
	}
	Console.WriteLine();
	for (int i = 0; i < affichage.GetLength(0); i++)
	{
		Console.Write("|");
		for (int j = 0; j < affichage.GetLength(1); j++)
		{
			if (serpent.Contains((j, i)))
			{
				Console.BackgroundColor = ConsoleColor.Yellow;
				Console.Write("  ");
				Console.ResetColor();
			}
			else if (pomme == (j, i))
			{
				Console.BackgroundColor = ConsoleColor.Green;
				Console.Write("  ");
				Console.ResetColor();
			}
			else
			{
				Console.Write("  ");
			}
		}
		Console.Write("|");
		Console.WriteLine();
	}
	for (int i = 0; i <( affichage.GetLength(1) + 2)*2; i++)
	{
		Console.Write("-");
	}
	Console.WriteLine();
	Thread.Sleep(100);
	(x, y) = serpent[0];
	toucheTemporaire = touche;
	if (Console.KeyAvailable)
	{
		touche = Console.ReadKey();
	}
	switch (touche.Key)
	{
		case ConsoleKey.LeftArrow:
			if (toucheTemporaire.Key == ConsoleKey.RightArrow)
			{
				touche = toucheTemporaire;
				goto case ConsoleKey.RightArrow;
			}
			serpent.Insert(0, (x - 1, y));
			break;
		case ConsoleKey.RightArrow:
			if (toucheTemporaire.Key == ConsoleKey.LeftArrow)
			{
				touche = toucheTemporaire;
				goto case ConsoleKey.LeftArrow;
			}
			serpent.Insert(0, (x + 1, y));
			break;
		case ConsoleKey.UpArrow:
			if (toucheTemporaire.Key == ConsoleKey.DownArrow)
			{
				touche = toucheTemporaire;
				goto case ConsoleKey.DownArrow;
			}
			serpent.Insert(0, (x, y - 1));
			break;
		case ConsoleKey.DownArrow:
			if (toucheTemporaire.Key == ConsoleKey.UpArrow)
			{
				touche = toucheTemporaire;
				goto case ConsoleKey.UpArrow;
			}
			serpent.Insert(0, (x, y + 1));
			break;
	}
	if (pomme != serpent[0])
	{
		serpent.RemoveAt(serpent.Count - 1);
	}
	if (pomme == serpent[0])
	{
		score++;
		for (int i = 0; i < serpent.Count; i++)
		{
			pomme = (random.Next(20), random.Next(20));
			if (!serpent.Contains(pomme))
			{
				break;
			}
		}
	}
	for (int i = 0; i < serpent.Count; i++)
	{
		if (serpent[i] == serpent[0])
		{
			nombreDeFoisLaTete++;
		}
	}
	if (nombreDeFoisLaTete > 1)
	{
		perdu = false;
	}
	if (x > affichage.GetLength(1) -1 || x < 0)
	{
		perdu = false;
	}
	if (y > affichage.GetLength(0) - 1 || y < 0)
	{
		perdu = false;
	}
	nombreDeFoisLaTete = 0;
	Console.Clear();
	if (perdu==false)
	{
		Console.WriteLine("Votre score est de " + score);
		Console.WriteLine("Voulez-vous recommencer (y/n)?");
		string entrée =Console.ReadLine();
		if (entrée=="y")
		{
			perdu=true;
			serpent.Clear();
			serpent.Add((affichage.GetLength(0) / 2, affichage.GetLength(1) / 2));
			score = 0;
		}
	}
}
Console.Clear();