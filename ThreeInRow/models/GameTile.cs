namespace ThreeInRow.models;

public class GameTile {
    private readonly int _rowCount;
    private readonly int _columnCount;
    private List<List<int>> Field { get; set; }

    public GameTile(int rows, int columns) {
        _rowCount = rows;
        _columnCount = columns;
        Field = new List<List<int>>();
        for (var i = 0; i < columns; i++) {
            Field.Add(new List<int>());
            for (var j = 0; j < rows; j++) { Field[i].Add(0); }
        }
        CreateNewField();
    }

    public void CreateNewField() {
        foreach (var row in Field) {
            for (var j = 0; j < row.Count; j++) { row[j] = GetRandomNumber(); }
        }
    }

    public bool CheckCoincide() {
        var hasCoincide = false;

        // Check horizontal coincide
        for (var i = 0; i < _columnCount; i++) {
            for (var j = 0; j < _rowCount; j++) {
                var k = 1;
                var s = 1;
                while (j + s < _rowCount) {
                    if (Field[i][j] == Field[i][j + s]) {
                        s++;
                        k++;
                    }
                    else { break; }
                }
                if (k < 3) continue;
                ChangeRow(i, j, k);
                hasCoincide = true;
            }
        }

        // Check vertical coincide
        for (var i = 0; i < _rowCount; i++) {
            for (var j = 0; j < _columnCount; j++) {
                var k = 1;
                var s = 1;
                while (j + s < _columnCount) {
                    if (Field[j][i] == Field[j + s][i]) {
                        s++;
                        k++;
                    }
                    else { break; }
                }
                if (k < 3) continue;
                ChangeColumn(j, i, k);
                hasCoincide = true;
            }
        }
        return hasCoincide;
    }

    private void ChangeRow(int startPointRow, int startPointColumn, int count) {
        if (startPointRow == 0) {
            for (var i = 0; i < count; i++, startPointColumn++)
                Field[startPointRow][startPointColumn] = GetRandomNumber();
        }
        else {
            for (var i = 0; i < count; i++, startPointColumn++) {
                Field[startPointRow][startPointColumn] = Field[startPointRow - 1][startPointColumn];
                Field[startPointRow - 1][startPointColumn] = GetRandomNumber();
            }
        }
    }

    private void ChangeColumn(int startPointRow, int startPointColumn, int count) {
        var endPointRow = startPointRow + count - 1;
        while (endPointRow >= 0) {
            if (endPointRow - count < 0) { Field[endPointRow][startPointColumn] = GetRandomNumber(); }
            else { Field[endPointRow][startPointColumn] = Field[endPointRow - count][startPointColumn]; }
            endPointRow--;
        }
    }

    private int GetRandomNumber() => new Random().Next(0, 4);

    public List<List<int>> GetField() => Field;
}