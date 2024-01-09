using Godot;
using System;
using System.Linq;

public partial class test : Node
{
	public override void _Process(double delta)
	{
		foreach(var i in TileStorage.characters)
		{
			GD.Print(i.Name);
		}
	}
}
