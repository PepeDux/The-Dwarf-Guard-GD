using Godot;
using System;

public partial class GameOver : Node
{
	public override void _Ready()
	{
		GetTree().Paused = false;
	}
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("EscClick"))
		{
			GetTree().ChangeSceneToFile("res://Data/Scenes/UI/MainMenu/MainMenu.tscn");
		}
	}
}
