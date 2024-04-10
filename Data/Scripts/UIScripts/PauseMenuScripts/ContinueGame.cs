using Godot;
using System;

public partial class ContinueGame : BaseButton
{
    public override void _Ready()
    {
        ButtonEventSubscribing();
    }

    public override void ButtonPressed()
    {
        GetParent<Node2D>().Visible = false;
        GetTree().Paused = false;
    }
}
