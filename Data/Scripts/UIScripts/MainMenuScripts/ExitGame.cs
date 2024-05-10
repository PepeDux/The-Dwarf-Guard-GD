using Godot;
using System;

public partial class ExitGame : BaseButton
{
	public override void _Ready()
	{
		
	}

	public override void Pressed()
	{
		base.Pressed();

		GetTree().Quit();
	}
}
