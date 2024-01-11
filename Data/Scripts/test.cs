using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class test : Node
{
	public override void _Ready()
	{
		Events.levelEnded?.Invoke();
	}

}
