using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class test : Node2D
{
	[Export]Label label;
	public override void _Ready()
	{
		label.LabelSettings.FontColor = new Color(0, 0, 0, 1);
	}
}
