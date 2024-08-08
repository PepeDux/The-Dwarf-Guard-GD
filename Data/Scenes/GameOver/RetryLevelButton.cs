using Godot;
using System;

public partial class RetryLevelButton : BaseButton
{
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _ExitTree()
	{
		base._ExitTree();
	}

	public override void _Pressed()
	{
		base._Pressed();

		GetTree().ChangeSceneToFile("res://Data/Scenes/GameScene/GameScene.tscn");
	}
}
