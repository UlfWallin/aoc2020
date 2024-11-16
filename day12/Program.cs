var moves = File.ReadAllLines("input.txt");
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
            heading = (heading - steps) % 360;
            if (heading < 0) {
                heading += 360;
            }
            break;
        case 'R':
            // rotate right
            Console.Write(move + ": "+ heading.ToString());
            heading = (heading + steps) % 360;
            Console.WriteLine(" new heading " + heading);
            break;
        case 'F':
            SetPosition(ToOrientation(heading), steps);
            break;
    }
}
Console.WriteLine("{0} + {1} = {2}", x, y, x + y);

void SetPosition(char orientation, int steps) {
    switch(orientation) {
        case 'N':
            y -= steps;
            break;
        case 'S':
            y += steps;
            break;
        case 'E':
            x += steps;
            break;
        case 'W':
            x -= steps;
            break;
    }
}

static char ToOrientation(int degrees) => degrees switch
{
    0 => 'E',
    90 => 'S',
    180 => 'W',
    270 => 'N',
    _ => throw new NotImplementedException()
};