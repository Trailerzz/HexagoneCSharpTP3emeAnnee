// lien du tp : www.codingame.com/ide/puzzle/mars-lander-episode-1
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

// enum pr la puissance
enum ThrustPower
{
    Zero = 0,
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4
}

// classe fusee
class Lander
{
    public int X { get; set; }
    public int Y { get; set; }
    public int HSpeed { get; set; }
    public int VSpeed { get; set; }
    public int Fuel { get; set; }
    public int Rotate { get; set; }
    public ThrustPower Power { get; set; }

    public Lander(int x, int y, int hSpeed, int vSpeed, int fuel, int rotate, int power)
    {
        X = x;
        Y = y;
        HSpeed = hSpeed;
        VSpeed = vSpeed;
        Fuel = fuel;
        Rotate = rotate;
        Power = (ThrustPower)power;
    }

    public void AdjustThrust()
    {
        if (Y <= 1000)
            Power = ThrustPower.Four;
        else
            Power = ThrustPower.Three;
    }
}

class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        int surfaceN = int.Parse(Console.ReadLine()); // the number of points used to draw the surface of Mars.
        List<(int, int)> surfacePoints = new List<(int, int)>();
        
        for (int i = 0; i < surfaceN; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int landX = int.Parse(inputs[0]); // X coordinate of a surface point. (0 to 6999)
            int landY = int.Parse(inputs[1]); // Y coordinate of a surface point. By linking all the points together in a sequential fashion, you form the surface of Mars.
            surfacePoints.Add((landX, landY));
        }

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int X = int.Parse(inputs[0]);
            int Y = int.Parse(inputs[1]);
            int hSpeed = int.Parse(inputs[2]); // the horizontal speed (in m/s), can be negative.
            int vSpeed = int.Parse(inputs[3]); // the vertical speed (in m/s), can be negative.
            int fuel = int.Parse(inputs[4]); // the quantity of remaining fuel in liters.
            int rotate = int.Parse(inputs[5]); // the rotation angle in degrees (-90 to 90).
            int power = int.Parse(inputs[6]); // the thrust power (0 to 4).

            Lander lander = new Lander(X, Y, hSpeed, vSpeed, fuel, rotate, power);
            lander.AdjustThrust();

            // 2 integers: rotate power. rotate is the desired rotation angle (should be 0 for level 1), power is the desired thrust power (0 to 4).
            Console.WriteLine($"0 {(int)lander.Power}");
        }
    }
}
