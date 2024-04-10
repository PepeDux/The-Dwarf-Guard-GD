using Godot;
using System;

public partial class ExitGame : BaseButton
{
	public override void _Ready()
	{
		ButtonEventSubscribing();
	}

	public override void ButtonPressed()
	{
		GetTree().Quit();
	}
}
