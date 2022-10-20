using ThreeInRow.models;

var gameTile = new GameTile(9, 9);
var field = gameTile.GetField();

Console.WriteLine("Game tile before:");
PrintMatrix(field);

var changeCount = 0;
while (gameTile.CheckCoincide()) { changeCount++; }

Console.WriteLine("Game tile after:");
PrintMatrix(field);
Console.WriteLine($"Changed {changeCount} times");

void PrintMatrix(List<List<int>> matrix) {
    foreach (var row in matrix) {
        foreach (var element in row) { Console.Write(element + " "); }
        Console.WriteLine();
    }
}