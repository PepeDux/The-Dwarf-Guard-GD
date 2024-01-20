using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class test : Button
{
	public override void _Ready()
	{
		Pressed += ButtonPressed;
	}

	private void ButtonPressed()
	{
		GD.Print("fsafafsafas");
	}

}
