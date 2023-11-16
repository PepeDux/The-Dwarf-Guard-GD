using Godot;
using System;
using System.Linq;

public partial class test : Node
{
	Random random = new Random();
	public override void _Process(double delta)
	{

		if (Input.IsActionJustPressed("t"))
		{
			GD.Print(TileStorage.impassableCells.ElementAt(random.Next(0, TileStorage.impassableCells.Count)));
			

			//GD.Print("End Turn: " + TurnManager.turnCount);

			//TurnManager.turnCount += 1;
		}
	}
}
