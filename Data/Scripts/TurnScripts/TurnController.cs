using Godot;
using System;
using System.Collections.Generic;
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

        Events.finishedHisTurn += AddCurrentWalker;
    }

    private void AddTurn()
    {
        GD.Print("b");

        currentTurn++;
        currentWalker = 0;
    }

    private void AddCurrentWalker()
    {
        GD.Print("a");

        currentWalker++;

        Turn();
    }

    private void Turn()
    {

        Character charac = TileStorage.characters[currentWalker];

        if (charac is Enemy)
        {
            GD.Print(currentWalker);

            ((Enemy)charac).Turn();
        }

        if (TileStorage.characters.Count() == currentWalker) 
        {
            AddTurn();
        }
    }
}
