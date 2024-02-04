using Godot;
using System;

public partial class CursorStyleController
{
    private static Resource arrow = ResourceLoader.Load("res://Data/UI/Cursors/Arrow.png");
    private static Resource beam = ResourceLoader.Load("res://Data/UI/Cursors/Beam.png");

    public static void SetArrow()
    {
        Input.SetCustomMouseCursor(arrow);
    }

    public static void SetBeam()
    {
        Input.SetCustomMouseCursor(beam);
    }
}
