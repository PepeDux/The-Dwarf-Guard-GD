using Godot;
using System;

public partial class TileMarker : Node2D
{
	private TileMap markerTileMap; //Тайлмап с маркерами

	private Vector2I cellPosition; //Тайловая координата курсора
	private Vector2I playerPosition; //Тайловая координата игрока

	[Export] private TileData movePointer; //Указатель возможного хода
	[Export] private TileData enemyPointer; //Указатель возможной атаки

	private Player player;



	public override void _Ready()
	{
		player = GetParent<Player>();
		markerTileMap = GetTree().Root.GetNode("GameScene").GetNode<TileMap>("MarkerTileMap");
	}

	public override void _ExitTree()
	{
		markerTileMap.Clear();
	}


	public override void _Process(double delta)
	{
		cellPosition = GetParent().GetNode<PlayerSelectTile>("PlayerSelectTile").cellPosition;
		playerPosition = player.coordinate;
	  
		markerTileMap.Clear(); //Очищаем тайлмап от предыдущих тайлов-маркеров

		if (GetParent<Player>().canPerformAction == true) 
		{
			if (player.horizontalMove == true)
			{
				SelectMoveCell(new Vector2I(0, -1));	//Вверх
				SelectMoveCell(new Vector2I(0, 1));		//Вниз
				SelectMoveCell(new Vector2I(-1, 0));	//Влево
				SelectMoveCell(new Vector2I(1, 0));		//Вправо
			}

			if (player.diagonalMove == true)
			{
				SelectMoveCell(new Vector2I(1, -1));	//Вправо вверх
				SelectMoveCell(new Vector2I(1, 1));		//Вправо вниз
				SelectMoveCell(new Vector2I(-1, 1));	//Влево вниз
				SelectMoveCell(new Vector2I(-1, -1));	//Влево вверх
			}

			if (player.horizontalAttack == true)
			{
				SelectEnemyCell(new Vector2I(0, -1));	//Вверх
				SelectEnemyCell(new Vector2I(0, 1));	//Вниз
				SelectEnemyCell(new Vector2I(-1, 0));	//Влево
				SelectEnemyCell(new Vector2I(1, 0));	//Вправо
			}

			if (player.diagonalAttack == true)
			{
				SelectEnemyCell(new Vector2I(1, -1));   //Вправо вверх
				SelectEnemyCell(new Vector2I(1, 1));	//Вправо вниз
				SelectEnemyCell(new Vector2I(-1, 1));	//Влево вниз
				SelectEnemyCell(new Vector2I(-1, -1));  //Влево вверх
			}
		}
	}



	private void SelectMoveCell(Vector2I select)
	{
		if (cellPosition == playerPosition + select && CheckMoveCell())
		{
			markerTileMap.SetCell(0, cellPosition, 0, new Vector2I(1, 1));
		}
	}



	private void SelectEnemyCell(Vector2I select)
	{
		if (cellPosition == playerPosition + select && CheckEnemyCell())
		{
			markerTileMap.SetCell(0, cellPosition, 0, new Vector2I(2, 1));
		}
	}



	private bool CheckMoveCell()
	{
		foreach (var cell in TileStorage.impassableCells)
		{
			if (cellPosition == cell)
			{
				return false;
			}
		}

		return true;
	}

	private bool CheckEnemyCell()
	{
		foreach (Character character in CharacterStorage.characters)
		{
			if (cellPosition == character.coordinate && character is Enemy)
			{
				return true;
			}
		}

		return false;
	}
}
