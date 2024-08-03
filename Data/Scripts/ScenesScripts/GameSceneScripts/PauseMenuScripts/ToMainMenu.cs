using Godot;
using System;

public partial class ToMainMenu : BaseButton
{
	public override void Pressed()
	{
		base.Pressed();

		Events.levelEnded?.Invoke();

		GetTree().Paused = false;

		GetTree().ChangeSceneToFile("res://Data/Scenes/MainMenu/MainMenu.tscn");
	}
}
