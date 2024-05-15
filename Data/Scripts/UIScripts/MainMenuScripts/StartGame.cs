using Godot;
using System;

public partial class StartGame : BaseButton
{
	public override void _Ready()
	{
		
	}

	public override void Pressed()
	{
		base.Pressed();

		GetTree().ChangeSceneToFile("res://Data/Scenes/UI/GameScene/GameScene.tscn");
	}
}
