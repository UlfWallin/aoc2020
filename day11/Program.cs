
var currentState = File
    .ReadAllLines("input.txt")
    .Select(l => '.' + l + '.')
    .ToArray();
var nextState = new string[currentState.Length];
currentState.CopyTo(nextState, 0);

var hasChanged = false;
do
{
    hasChanged = false;
    for (var row = 0; row < currentState.Length; row++)
    {
        for (var col = 1; col < currentState[row].Length - 1; col++)
        {
            char seat = currentState[row][col];
            // L = Empty
            // # = Occupied
            // . = Floor
            var occupied = 0;

            if (row > 0)
            {
                var nw = currentState[row - 1][col - 1];
                var n  = currentState[row - 1][col];
                var ne = currentState[row - 1][col + 1];
                occupied += nw == '#' ? 1 : 0;
                occupied += n == '#' ? 1 : 0;
                occupied += ne == '#' ? 1 : 0;
            }
            var w = currentState[row][col - 1];
            var e = currentState[row][col + 1];
            occupied += w == '#' ? 1 : 0;
            occupied += e == '#' ? 1 : 0;

            if (row < currentState.Length - 1)
            {
                var sw = currentState[row + 1][col - 1];
                var s = currentState[row + 1][col];
                var se = currentState[row + 1][col + 1];
                occupied += sw == '#' ? 1 : 0;
                occupied += s == '#' ? 1 : 0;
                occupied += se == '#' ? 1 : 0;
            }

            if (seat == '#' && occupied >= 4)
            {
                var temp = nextState[row].ToCharArray();
                temp[col] = 'L';
                nextState[row] = new string(temp);
                hasChanged = true;
            }
            else if (seat == 'L' && occupied == 0)
            {
                var temp = nextState[row].ToCharArray();
                temp[col] = '#';
                nextState[row] = new string(temp);
                hasChanged = true;
            }
            else
            {
                var temp = nextState[row].ToCharArray();
                temp[col] = nextState[row][col];
                nextState[row] = new string(temp);
            }
        }
    }
    nextState.CopyTo(currentState, 0);
    
} while(hasChanged);

var sumOccupied = 0;
foreach(var line in currentState) {
    sumOccupied += line.Count(c => c == '#');
}
Console.WriteLine(sumOccupied);