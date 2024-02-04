using Godot;
using System;

public partial class TurnController : Node
{
	private int currentTurn = 1;
	private int currentWalker = 0;

	public override void _Ready()
	{
		Events.playerTurnFinished += AddCurrentWalker;
		Events.endedHisTurn += AddCurrentWalker;
	}

	private void AddCurrentWalker()
	{
		GD.Print("a");

		currentWalker++;

		if (currentWalker <= TileStorage.characters.Count)
		{
			Turn();
		}
		else
		{
			AddTurn();
		}
	}

	private void AddTurn()
	{
		GD.Print("b");

		currentTurn++;
		currentWalker = 0;
		Turn();
	}

	private void Turn()
	{
		if (currentWalker < TileStorage.characters.Count)
		{
			Character charac = TileStorage.characters[currentWalker];

			GD.Print(currentWalker);

			if (charac is Enemy)
			{
				((Enemy)charac).Turn();
			}
		}
	}
}
