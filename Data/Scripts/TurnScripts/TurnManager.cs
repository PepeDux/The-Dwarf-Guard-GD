using Godot;
using System;

public partial class TurnManager : Node
{
    public static int turnCount = 1; //Счеткич ходов

    public Player player;
    //public GameObject tileManager;



    //private void OnEnable()
    //{
    //    //Подписываемся на событие конца хода игрока 
    //    PlayerTurnManager.playerTurnFinished += EndPlayerTurn;
    //    Player.playerSpawned += AddPlayer;
    //}

    //private void OnDisable()
    //{
    //    //Отписываемся на событие конца хода игрока 
    //    PlayerTurnManager.playerTurnFinished -= EndPlayerTurn;
    //    Player.playerSpawned -= AddPlayer;
    //}



    //public void UpdatePoints()
    //{
    //    foreach (var obj in TileManager.enemyList)
    //    {
    //        obj.GetComponent<Enemy>().movePoints = obj.GetComponent<Enemy>().maxMovePoint;
    //        obj.GetComponent<Enemy>().actionPoints = obj.GetComponent<Enemy>().maxActionPoint;
    //        obj.GetComponent<Enemy>().beerPoint = obj.GetComponent<Enemy>().maxBeerPoint;
    //    }

    //    if (player != null)
    //    {
    //        player.movePoints = player.maxMovePoint;
    //        player.actionPoints = player.maxActionPoint;
    //        player.beerPoint = player.maxBeerPoint;
    //    }
    //}

    //private void EndPlayerTurn()
    //{
    //    UpdatePoints();
    //}

    private void AddPlayer(Player player)
    {
        this.player = player;
    }
}
