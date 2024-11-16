const string fileName = "input.txt";
var part2 = Part2.Solve(fileName);
Console.WriteLine($"Part 2: {part2}");

var moves = File.ReadAllLines(fileName);
var x = 0;
var y = 0;
var heading = 0;
foreach(var move in moves) {
    var steps = int.Parse(move[1..]);

    switch(move[0]) {
        case 'N':
        case 'S':
        case 'E':
        case 'W':
            SetPosition(move[0], steps);
            break;
        case 'L':
            // rotate left
            heading = (heading - steps + 360) % 360;
            break;
        case 'R':
            // rotate right
            heading = (heading + steps) % 360;
            break;
        case 'F':
            SetPosition(ToOrientation(heading), steps);
            break;
    }
}
Console.WriteLine("{0} + {1} = {2}", x, y, Math.Abs(x + y));

void SetPosition(char orientation, int steps) {
    (x, y) = orientation switch {
        'N' => (x, y - steps),
        'S' => (x, y + steps),
        'E' => (x + steps, y),
        'W' => (x - steps, y),
        _ => (x, y) // Handle invalid orientations
    };
}

static char ToOrientation(int degrees) => degrees switch
{
    0 => 'E',
    90 => 'S',
    180 => 'W',
    270 => 'N',
    _ => throw new ArgumentException()
};