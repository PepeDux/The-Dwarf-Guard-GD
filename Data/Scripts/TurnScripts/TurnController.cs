using Godot;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public partial class TurnController : Node
{
	private int currentWalker = 0;

	public override void _Ready()
	{
		Events.playerTurnFinished += AddTurn;
		Events.playerTurnFinished += AddCurrentWalker;
		Events.finishedEnemyTurn += AddCurrentWalker;
	}

	public override void _ExitTree()
	{
		Events.playerTurnFinished -= AddTurn;
		Events.playerTurnFinished -= AddCurrentWalker;
		Events.finishedEnemyTurn -= AddCurrentWalker;
	}

	private void AddTurn()
	{
		currentWalker = 0;
	}

	private void AddCurrentWalker()
	{
		currentWalker++;
		Turn();
	}

	private void Turn()
	{
		if (currentWalker < CharacterStorage.characters.Count)
		{
			Character charac = CharacterStorage.characters[currentWalker];

			if (charac is Enemy)
			{
				((Enemy)charac).Turn();
			}
		}

		if (currentWalker == CharacterStorage.characters.Count) 
		{
			Events.finishedAllTurn?.Invoke();
		}
	}
}
