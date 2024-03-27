using Godot;
using System;

public partial class PlayerTileManager : Node2D
{
	[Export] private TileMap tileMap; //Тайлмап

	private Player player;

	private Vector2I cellPosition; //Тайловая координата курсора
	private Vector2I playerPosition; //Тайловая координата игрока



	public override void _Ready()
	{
		player = GetParent<Player>();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("LeftMouseClick") && GetParent<Player>().MovePoints > 0)
		{
			TileStorage.RemoveCell(player);

			cellPosition = GetParent().GetNode<PlayerSelectTile>("PlayerSelectTile").cellPosition;
			playerPosition = player.coordinate;

			CheckCells();

			if (GetParent<Player>().lineMove == true)
			{
				Move(new Vector2I(0, -1));  //Вверх
				Move(new Vector2I(0, 1)); //Вниз
				Move(new Vector2I(-1, 0)); //Влево
				Move(new Vector2I(1, 0));  //Вправо
			}

			if (GetParent<Player>().diagonalMove == true)
			{
				Move(new Vector2I(1, -1));   //Вправо вверх
				Move(new Vector2I(1, 1));  //Вправо вниз
				Move(new Vector2I(-1, 1)); //Влево вниз
				Move(new Vector2I(-1, -1));  //Влево вверх
			}

            TileStorage.AddCell(player);
        }
	}

	private void Move(Vector2I move)
	{
		if (cellPosition == playerPosition + move && CheckCells() == true)
		{
			GetParent<Player>().coordinate = cellPosition; //Перемещаем игрока на место кликнутого тайла           

			GetParent<Player>().MovePoints -= 1; //Отнимаем у игрока очки движения

            GetParent().GetNode<CharacterAudioController>("CharacterAudioController").PlaySound("Move", 0.8f, 1f);
        }
	}

	private bool CheckCells()
	{
		foreach (var cell in TileStorage.impassableCells)
		{
			if (cellPosition == cell)
			{
				//Если желаемая клетка занята, то ходить на нее запрещается
				return false;
			}
		}

		//Возвращает true если при проверке клеток желаемая клетка была свободной
		return true;
	}
}
