using Godot;
using System;

public partial class ToSettings : BaseButton
{
    public override void _Ready()
    {
        ButtonEventSubscribing();
    }

    public override void ButtonPressed()
    {
        base.ButtonPressed();

        GetTree().Paused = false;
    }
}
