using Godot;
using System;
using System.Linq;

public partial class TileMarker : Node2D
{
	private static TileMap markerTileMap; //Тайлмап с маркерами

	private static Vector2I mouseCellPosition; //Тайловая координата курсора
	private Vector2I playerPosition; //Тайловая координата игрока

	private Player player;



	public override void _Ready()
	{
		Events.playerSpawned += GetPlayer;
		Events.levelEnded += () => player = null;

		markerTileMap = GetTree().Root.GetNode("GameScene").GetNode<TileMap>("MarkerTileMap");
	}

	public override void _ExitTree()
	{
		Events.playerSpawned -= GetPlayer;
		Events.levelEnded -= () => player = null;

		markerTileMap.Clear();
	}


	public override void _Process(double delta)
	{
		if (player != null) 
		{
			mouseCellPosition = MouseSelectTile.MouseCellPosition;
			playerPosition = player.coordinate;

			markerTileMap.Clear(); //Очищаем тайлмап от предыдущих тайлов-маркеров

			if (player.canPerformAction == true)
			{
				if (player.directMove == true)
				{
					SelectMoveCell(new Vector2I(0, -1));    //Вверх
					SelectMoveCell(new Vector2I(0, 1));     //Вниз
					SelectMoveCell(new Vector2I(-1, 0));    //Влево
					SelectMoveCell(new Vector2I(1, 0));     //Вправо
				}

				if (player.diagonalMove == true)
				{
					SelectMoveCell(new Vector2I(1, -1));    //Вправо вверх
					SelectMoveCell(new Vector2I(1, 1));     //Вправо вниз
					SelectMoveCell(new Vector2I(-1, 1));    //Влево вниз
					SelectMoveCell(new Vector2I(-1, -1));   //Влево вверх
				}

				if (player.weapon.directAttack == true)
				{
					SelectEnemyCell(new Vector2I(0, -1));   //Вверх
					SelectEnemyCell(new Vector2I(0, 1));    //Вниз
					SelectEnemyCell(new Vector2I(-1, 0));   //Влево
					SelectEnemyCell(new Vector2I(1, 0));    //Вправо
				}

				if (player.weapon.diagonalAttack == true)
				{
					SelectEnemyCell(new Vector2I(1, -1));   //Вправо вверх
					SelectEnemyCell(new Vector2I(1, 1));    //Вправо вниз
					SelectEnemyCell(new Vector2I(-1, 1));   //Влево вниз
					SelectEnemyCell(new Vector2I(-1, -1));  //Влево вверх
				}
			}
		}	
		else if (player == null)
		{
			markerTileMap.Clear();
		}
	}



	public void SelectMoveCell(Vector2I select)
	{
		if (mouseCellPosition == playerPosition + select && CheckMoveCell())
		{
			if (player.MovePoints >= player.MoveCost)
			{
				markerTileMap.SetCell(0, mouseCellPosition, 0, new Vector2I(1, 1));
			}
			else if (player.ActionPoints >= player.MoveCost)
			{
				markerTileMap.SetCell(0, mouseCellPosition, 0, new Vector2I(3, 1));
			}
		}
	}

	public void SelectEnemyCell(Vector2I select)
	{
		if (mouseCellPosition == playerPosition + select && CheckEnemyCell())
		{
			markerTileMap.SetCell(0, mouseCellPosition, 0, new Vector2I(2, 1));
		}
	}

	public static void SelectCell()
	{
		if (CheckMoveCell()) 
		{
			markerTileMap.SetCell(0, mouseCellPosition, 0, new Vector2I(1, 1));
		}
		else if(CheckEnemyCell())
		{
			markerTileMap.SetCell(0, mouseCellPosition, 0, new Vector2I(2, 1));
		}
	}



	private static bool CheckMoveCell()
	{
		foreach (var cell in TileStorage.impassableCells)
		{
			if (mouseCellPosition == cell)
			{
				return false;
			}
		}

		return true;
	}

	private static bool CheckEnemyCell()
	{
		foreach (Character character in CharacterStorage.characters)
		{
			if (mouseCellPosition == character.coordinate && character is Enemy)
			{
				return true;
			}
		}

		return false;
	}



	private void GetPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChildren().OfType<Player>().FirstOrDefault();
	}
}
