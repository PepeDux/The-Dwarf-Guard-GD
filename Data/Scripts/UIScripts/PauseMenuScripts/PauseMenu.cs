using Godot;
using System;

public partial class PauseMenu : Node2D
{
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("EscClick"))
		{
			if (Visible == true) 
			{
				Visible = false;
				GetTree().Paused = false;
			}
			else if (Visible == false)
			{
				Visible = true;
				GetTree().Paused = true;
			}		
		}
	}
}
