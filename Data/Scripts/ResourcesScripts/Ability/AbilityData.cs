using Godot;
using System;
using System.Threading.Tasks;

public partial class AbilityData : Resource
{
	[ExportGroup("Изображение абилки")]
	[Export] public Texture2D abilityImage { get; set; }

	[ExportGroup("Стоимсоть применения абилки")]
	[Export] public int actionPointsCost { get; set; }
	[Export] public int movePointsCost { get; set; }
	[Export] public int beerPointsCost { get; set; }

	[ExportGroup("Требования к характеристикам")]
	[Export] public int strengthRequirement { get; set; }
	[Export] public int constitutionRequirement { get; set; }
	[Export] public int dexterityRequirement { get; set; }
	[Export] public int inteligenceRequirement { get; set; }
	[Export] public int wisdomRequirement { get; set; }
	[Export] public int charismaRequirement { get; set; }



	protected void PayForUse(Player player, int modifier = 1)
	{
		player.BeerPoints -= beerPointsCost * modifier;
		player.ActionPoints -= actionPointsCost * modifier;
		player.MovePoints -= movePointsCost * modifier;
	}

	public virtual void Use(Player player)
	{
		PayForUse(player);
	}

	protected bool CanUse(Player player)
	{
		if (player.Strength >= strengthRequirement &&
			player.Constitution >= constitutionRequirement &&
			player.Dexterity >= dexterityRequirement &&
			player.Inteligence >= inteligenceRequirement &&
			player.Wisdom >= wisdomRequirement &&
			player.Charisma >= charismaRequirement)
		{
			if (player.BeerPoints >= beerPointsCost && player.ActionPoints >= actionPointsCost && player.MovePoints >= movePointsCost)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		else
		{
			return false;
		}
	}



	protected virtual async void WaitClick(Player player, bool checkFreeCell = false, bool checkEnemyCell = false)
	{
		// Запрещаем игроку что-либо делать, пока он не закончит применение абилки
		player.canPerformAction = false;

		while (true)
		{
			TileMarker.SelectCell();

			if (Input.IsActionJustPressed("LeftMouseClick"))
			{
				bool canAction = true;

				if (checkFreeCell)
				{
					if (CheckFreeCell())
					{
						canAction = true;
					}
					else
					{
						canAction = false;
					}
				}
				if (checkEnemyCell)
				{
					if (CheckEnemyCell())
					{
						canAction = true;
					}
					else
					{
						canAction = false;
					}
				}

				if (canAction)
				{
					// Вызываем действие на ЛКМ
					ActionClick(player, MouseSelectTile.MouseCellPosition);

					break;
				}
			}
			else if (Input.IsActionJustPressed("RightMouseClick"))
			{
				// Возвращаем очки при отмене абилки
				PayForUse(player, -1);

				break;
			}
		}

		// Небольшая задержка, чтобы игрок случайно не пошел на клетку
		await Task.Delay(10);

		// Разрешаем игроку делать что-угодно
		player.canPerformAction = true;
	}

	protected virtual void ActionClick(Player player, Vector2I mouseCellPosition)
	{
		GD.PrintT("Action Complete");
	}

	protected bool CheckEnemyCell()
	{
		foreach (var target in CharacterStorage.characters)
		{
			if (MouseSelectTile.MouseCellPosition == target.Coordinate && target is Enemy)
			{
				return true;
			}
		}

		return false;
	}

	protected bool CheckFreeCell()
	{
		foreach (var cell in TileStorage.impassableCells)
		{
			if (MouseSelectTile.MouseCellPosition == cell)
			{
				return false;
			}
		}

		return true;
	}
}
