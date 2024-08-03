using Godot;
using System;

public partial class SaveSettingsButton : BaseButton
{
	public override void _Ready()
	{

	}

	public override void Pressed()
	{
		base.Pressed();

		GetTree().Paused = false;

		GetTree().ChangeSceneToFile("res://Data/Scenes/MainMenu/MainMenu.tscn");
	}
}
