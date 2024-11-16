using System.Numerics;

internal static class Part2 {
    private static Vector2 waypoint; 
    private static Vector2 shipPos;

    public static int Solve(string file) {
        waypoint = new (10, -1);
        shipPos = new (0, 0);
        var moves = File.ReadAllLines(file);
        foreach (var move in moves) {
            var action = move[0];
            var steps = int.Parse(move[1..]);

            if ("NESW".Contains(action)) {
                UpdateWaypoint(action, steps);
            }

            if (action == 'R' || action == 'L') {
                RotateWaypoint(action, steps);
            }

            if (action == 'F') {
                shipPos += waypoint * steps;
            }

        }
        return Math.Abs((int)shipPos.X + (int)shipPos.Y);
    }

    private static void RotateWaypoint(char direction, int steps)
    {
        if (direction == 'L') {
            steps *= -1;
        }
        var rotation = Matrix3x2.CreateRotation((float)DegreesToRadians(steps));
        waypoint = Vector2.Transform(waypoint, rotation);;
    }

    private static void UpdateWaypoint(char direction, int length) {
        var v = direction switch {
            'N' => new Vector2(0, -length),
            'E' => new Vector2(length, 0),
            'W' => new Vector2(-length, 0),
            'S' => new Vector2(0, length),
            _ => new Vector2()
        };
        waypoint += v;
    }

    static double DegreesToRadians(int degrees) => degrees * Math.PI / 180.0; 
}