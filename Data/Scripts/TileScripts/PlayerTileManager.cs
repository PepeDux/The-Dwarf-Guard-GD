using Godot;
using System;

public partial class PlayerTileManager : Node2D
{
	[Export] private TileMap tileMap; // Тайлмап

	private Player player;

	private Vector2I cellPosition; // Тайловая координата курсора
	private Vector2I playerPosition; // Тайловая координата игрока



	public override void _Ready()
	{
		player = GetParent<Player>();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("LeftMouseClick") &&
			(GetParent<Player>().MovePoints >= GetParent<Player>().MoveCost || GetParent<Player>().ActionPoints >= GetParent<Player>().MoveCost) &&
			GetParent<Player>().canPerformAction == true)
		{
			cellPosition = MouseSelectTile.MouseCellPosition;
			playerPosition = player.Coordinate;

			CheckCells();

			if (GetParent<Player>().directMove == true)
			{
				Move(new Vector2I(0, -1));  // Вверх
				Move(new Vector2I(0, 1)); // Вниз
				Move(new Vector2I(-1, 0)); // Влево
				Move(new Vector2I(1, 0));  // Вправо
			}

			if (GetParent<Player>().diagonalMove == true)
			{
				Move(new Vector2I(1, -1));   // Вправо вверх
				Move(new Vector2I(1, 1));  // Вправо вниз
				Move(new Vector2I(-1, 1)); // Влево вниз
				Move(new Vector2I(-1, -1));  // Влево вверх
			}
		}
	}

	private void Move(Vector2I move)
	{
		if (cellPosition == playerPosition + move && CheckCells() == true)
		{
			// Перемещаем игрока на место кликнутого тайла   
			GetParent<Player>().Coordinate = cellPosition;         			

			// Отнимаем у игрока очки движения или очки действия если нет очков движения
			if (GetParent<Player>().MovePoints >= GetParent<Player>().MoveCost) 
			{
				GetParent<Player>().MovePoints -= GetParent<Player>().MoveCost;
			}
			else if(GetParent<Player>().MovePoints <= GetParent<Player>().MoveCost)
			{
				GetParent<Player>().ActionPoints -= GetParent<Player>().MoveCost;
			}
        }
    }

	private bool CheckCells()
	{
		foreach (var cell in TileStorage.impassableCells)
		{
			if (cellPosition == cell)
			{
				// Если желаемая клетка занята, то ходить на нее запрещается
				return false;
			}
		}

		// Возвращает true если при проверке клеток желаемая клетка была свободной
		return true;
	}
}
