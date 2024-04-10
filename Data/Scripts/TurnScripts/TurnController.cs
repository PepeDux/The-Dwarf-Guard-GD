using Godot;
using System;
using System.Linq;
using System.Threading.Tasks;

public partial class TurnController : Node
{
	private int currentTurn = 1;
	private int currentWalker = 0;

	public override void _Ready()
	{
		Events.playerTurnFinished += AddTurn;
		Events.playerTurnFinished += AddCurrentWalker;
		Events.finishedEnemyTurn += AddCurrentWalker;
	}

	private void AddTurn()
	{
		currentTurn++;
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
	}
}
