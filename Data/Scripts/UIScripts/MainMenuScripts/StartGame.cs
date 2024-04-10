using Godot;
using System;

public partial class StartGame : BaseButton
{
	public override void _Ready()
	{
		ButtonEventSubscribing();
	}

	public override void ButtonPressed()
	{
		GetTree().ChangeSceneToFile("res://Data/Scenes/CoreScene/CoreScene.tscn");
	}
}
