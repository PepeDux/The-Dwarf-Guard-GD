using Godot;
using System;
using System.Diagnostics;
using System.Linq;

public partial class SideMenu : Node
{
	[Export] BaseProgressBar HPProgressBar;
	[Export] BaseProgressBar MovePointsProgressBar;
	[Export] BaseProgressBar ActionPointsProgressBar;
	[Export] BaseProgressBar BeerPointsProgressBar;

	[Export] Label ACLabel;
	[Export] Label CoinsLabel;

	[Export] Label strengthLabel;
	[Export] Label constitutionLabel;
	[Export] Label dexterityLabel;
	[Export] Label intelligenceLabel;
	[Export] Label wisdomLabel;
	[Export] Label charismaLabel;

	[Export] Sprite2D WeaponImage;
	[Export] Label damageLabel;
	[Export] Label attackLabel;
	[Export] Label attackCostLabel;

	[Export] Sprite2D AttackFrame;
	[Export] Sprite2D MoveFrame;

	[Export] Label currentLevelLabel;
	[Export] Label currentTurnLabel;

	Player player;
	Character target;

	public override void _Ready()
	{
		Events.playerSpawned += GetPlayer;
	}

	public override void _ExitTree()
	{
		Events.playerSpawned -= GetPlayer;
	}

	public override void _Process(double delta)
	{
		target = CharacterStorage.characters.Where(c => c.Coordinate == MouseSelectTile.MouseCellPosition).FirstOrDefault();

		if (target == null)
		{
			target = player;
		}

		if (target != null) 
		{
			#region Очки

			// Очки здоровья
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				HPProgressBar.ChangeValue(target.HP, target.MaxHP);
			}
			else
			{
				HPProgressBar.UnknownValue();
			}

			// Очки передвижения
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				ActionPointsProgressBar.ChangeValue(target.ActionPoints, target.MaxActionPoints);
			}
			else
			{
				ActionPointsProgressBar.UnknownValue();
			}

			// Очки действия
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				MovePointsProgressBar.ChangeValue(target.MovePoints, target.MaxMovePoints);
			}
			else
			{
				MovePointsProgressBar.UnknownValue();
			}

			// Очки пива
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				BeerPointsProgressBar.ChangeValue(target.BeerPoints, target.MaxBeerPoints);
			}
			else
			{
				BeerPointsProgressBar.UnknownValue();
			}

			#endregion

			#region Суб характристики

			// КД
			if (target == player || (target != player && player.wisdomModifier >= 1))
			{
				ACLabel.Text = target.AC.ToString();
			}
			else
			{
				ACLabel.Text = "???";
			}

			// Монетки
			if (target == player)
			{
				CoinsLabel.Text = GetTree().Root.GetNode("GameScene").GetNode<PlayerCoinCollection>("PlayerCoinCollection").coins.ToString();

			}
			else
			{
				CoinsLabel.Text = "???";
			}

			#endregion

			#region Оружие

			if (target == player || (target != player && player.wisdomModifier >= 0))
			{
				// Картинка оружия
				if (target.weapon.weaponImage != null)
				{
					WeaponImage.Texture = target.weapon.weaponImage;
				}
				else
				{

				}

				// Статы оружия
				damageLabel.Text = $"УРОН: {target.weapon.diceRolls}К{target.weapon.diceEdges} + {target.weapon.damageModifier + target.attackCharacteristicModifier}";
				attackLabel.Text = $"ПОП: 1К20 + {target.weapon.attackModifier + target.attackCharacteristicModifier}";
				attackCostLabel.Text = $"ОД: {target.weapon.attackCost}";
			}
			else
			{
				WeaponImage.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/QuestionMarkFrame.png");

				// Статы оружия
				damageLabel.Text = $"УРОН: ???";
				attackLabel.Text = $"ПОП: ???";
				attackCostLabel.Text = $"ОД: ???";
			}

			#endregion

			#region Первичные характеристики

			// Сила
			if (target == player || (target != player && player.wisdomModifier >= 3))
			{
				strengthLabel.Text = $"{target.Strength}({target.strengthModifier})";
			}
			else
			{
				strengthLabel.Text = $"?(?)";
			}

			// Телосложение
			if (target == player || (target != player && player.wisdomModifier >= 3))
			{
				constitutionLabel.Text = $"{target.Constitution}({target.constitutionModifier})";
			}
			else
			{
				constitutionLabel.Text = $"?(?)";
			}

			// Ловкость
			if (target == player || (target != player && player.wisdomModifier >= 3))
			{
				dexterityLabel.Text = $"{target.Dexterity}({target.dexterityModifier})";
			}
			else
			{
				dexterityLabel.Text = $"?(?)";
			}

			// Интелект
			if (target == player || (target != player && player.wisdomModifier >= 3))
			{
				intelligenceLabel.Text = $"{target.Inteligence}({target.inteligenceModifier})";
			}
			else
			{
				intelligenceLabel.Text = $"?(?)";
			}

			// Мудрость
			if (target == player || (target != player && player.wisdomModifier >= 3))
			{
				wisdomLabel.Text = $"{target.Wisdom}({target.wisdomModifier})";
			}
			else
			{
				wisdomLabel.Text = $"?(?)";
			}

			// Харизма
			if (target == player || (target != player && player.wisdomModifier >= 3))
			{
				charismaLabel.Text = $"{target.Charisma}({target.charismaModifier})";
			}
			else
			{
				charismaLabel.Text = $"?(?)";
			}

			#endregion

			#region Картинка направления движения

			if (target == player || (target != player && player.wisdomModifier >= -1))
			{
				// Картинка направления движения и направления атаки
				if (target.directMove == true && target.diagonalMove == false)
				{
					MoveFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/MovementsFrames/DirectMovementFrame.png");
				}
				else if (target.directMove == false && target.diagonalMove == true)
				{
					MoveFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/MovementsFrames/DiagonalMovementFrame.png");
				}
				else if (target.directMove == true && target.diagonalMove == true)
				{
					MoveFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/MovementsFrames/AlloutMovementsFrame.png");
				}

				// Картинка направления атаки
				if (target.weapon.directAttack == true && target.weapon.diagonalAttack == false)
				{
					AttackFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/AttackFrames/DirectAttackFrame.png");
				}
				else if (target.weapon.directAttack == false && target.weapon.diagonalAttack == true)
				{
					AttackFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/AttackFrames/DiagonalAttackFrame.png");
				}
				else if (target.weapon.directAttack == true && target.weapon.diagonalAttack == true)
				{
					AttackFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/AttackFrames/AlloutAttackFrame.png");
				}
			}
			else
			{
				MoveFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/QuestionMarkFrame.png");
				AttackFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/UIGameScene/SideMenu/Frames/QuestionMarkFrame.png");
			}

			#endregion


			// Счетчики уровня и ходов
			//currentLevelLabel.Text = $"УР: {levelInfo.CurrentLevel}";
			//currentTurnLabel.Text = $"Ход: {levelInfo.CurrentTurn}";
		}
	}

	private void GetPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChildren().OfType<Player>().FirstOrDefault();
	}
}
