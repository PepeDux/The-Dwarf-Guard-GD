using Godot;
using System;

public partial class ToMainMenu : BaseButton
{
    public override void _Ready()
    {
        ButtonEventSubscribing();
    }

    public override void ButtonPressed()
    {
        base.ButtonPressed();

        GetTree().Paused = false;
        GetTree().ChangeSceneToFile("res://Data/Scenes/UI/MainMenu/MainMenu.tscn");
    }
}