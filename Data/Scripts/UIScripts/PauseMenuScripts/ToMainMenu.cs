using Godot;
using System;

public partial class ToMainMenu : BaseButton
{
	public override void _Ready()
	{
		
	}

	public override void Pressed()
	{
		base.Pressed();

		Events.levelEnded?.Invoke();

		GetTree().Paused = false;

		GetTree().ChangeSceneToFile("res://Data/Scenes/UI/MainMenu/MainMenu.tscn");
	}
}
