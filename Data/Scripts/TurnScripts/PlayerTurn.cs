using Godot;
using System;
using System.Diagnostics;

public partial class PlayerTurn : Node
{
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("SpaceClick") && GetParent<Player>().canPerformAction == true)
		{
            GetParent<Player>().canPerformAction = false;

            Events.playerTurnFinished?.Invoke();

            //GD.Print("End Turn");

            //TurnManager.turnCount += 1;            
        }
	}
}
