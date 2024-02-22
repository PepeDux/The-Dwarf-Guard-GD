using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class DiceRoll : Node
{
    static Random random = new Random();

    public static int RollD100()
    {
        return random.Next(1, 101);
    }
    public static int RollD20()
    {
        return random.Next(1, 21);
    }
    public static int RollD12()
    {
        return random.Next(1, 13);
    }
    public static int RollD10()
    {
        return random.Next(1, 11);
    }
    public static int RollD8()
    {
        return random.Next(1, 9);
    }
    public static int RollD6()
    {
        return random.Next(1, 7);
    }
    public static int RollD4()
    {
        return random.Next(1, 5);
    }
}
