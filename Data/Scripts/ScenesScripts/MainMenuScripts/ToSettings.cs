using Godot;
using System;

public partial class ToSettings : BaseButton
{
	public override void _Ready()
	{
		
	}

	public override void Pressed()
	{
		base.Pressed();

		GetTree().Paused = false;

		GetTree().ChangeSceneToFile("res://Data/Scenes/Settings/Settings.tscn");
	}
}
