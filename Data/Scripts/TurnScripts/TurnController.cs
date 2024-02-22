using Godot;
using System;
using System.Threading.Tasks;

public partial class TurnController : Node
{
	private int currentTurn = 1;
	private int currentWalker = 0;

	public override void _Ready()
	{
		Events.playerTurnFinished += OtherTurn;
	}



	private async void OtherTurn()
	{
		GD.Print("a");

		currentWalker++;

		foreach (var charac in TileStorage.characters)
		{
			if (charac is Player)
			{
				continue;
			}
			else if (charac is Enemy)
			{
				((Enemy)charac).Turn();

				//Task.Delay(1000).Wait();
			}
		}
	}
}
