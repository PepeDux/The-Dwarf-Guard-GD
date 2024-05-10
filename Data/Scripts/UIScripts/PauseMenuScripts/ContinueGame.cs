using Godot;
using System;

public partial class ContinueGame : BaseButton
{
    public override void _Ready()
    {
        
    }

    public override void Pressed()
    {
        base.Pressed();

        GetParent<Node2D>().Visible = false;
        GetTree().Paused = false;
    }
}
