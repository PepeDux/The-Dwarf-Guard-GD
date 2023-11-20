using Godot;
using System;
using System.Diagnostics;

public partial class PlayerTurn : Node
{
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("SpaceClick"))
		{
			Events.playerTurnFinished?.Invoke();

			//GD.Print("End Turn: " + TurnManager.turnCount);

			//TurnManager.turnCount += 1;
		}
	}
}
