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


	[Export] Sprite2D WeaponFrame;
	[Export] Label damageLabel;
	[Export] Label attackLabel;
	[Export] Label attackCostLabel;

	[Export] Sprite2D AttackFrame;
	[Export] Sprite2D MoveFrame;

	[Export] Label currentLevelLabel;
	[Export] Label currentTurnLabel;


	Player player;
	Character target;

	LevelInfo levelInfo;

	public override void _Ready()
	{
		Events.playerSpawned += AddPlayer;

		AddLevelInfo();
	}

	public override void _ExitTree()
	{
		Events.playerSpawned -= AddPlayer;
	}

	public override void _Process(double delta)
	{
		if (DataBank.currentMouseTarget == null)
		{
			target = player;
		}
		else
		{
			target = DataBank.currentMouseTarget;
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
				ActionPointsProgressBar.ChangeValue(target.MovePoints, target.MaxActionPoints);
			}
			else
			{
				ActionPointsProgressBar.UnknownValue();
			}

			// Очки действия
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				MovePointsProgressBar.ChangeValue(target.ActionPoints, target.MaxActionPoints);
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
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				ACLabel.Text = target.AC.ToString();
			}
			else
			{
				ACLabel.Text = "???";
			}

			// Монетки
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				CoinsLabel.Text = target.Coins.ToString();
			}
			else
			{
				CoinsLabel.Text = "???";
			}

			#endregion

			#region Оружие

			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				// Картинка оружия
				if (target.weapon.weaponImage != null)
				{
					WeaponFrame.Texture = target.weapon.weaponImage;
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
				WeaponFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/QuestionMarkFrame.png");

				// Статы оружия
				damageLabel.Text = $"УРОН: ???";
				attackLabel.Text = $"ПОП: ???";
				attackCostLabel.Text = $"ОД: ???";
			}

			#endregion

			#region Первичные характеристики

			// Сила
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				strengthLabel.Text = $"{target.Strength}({target.strengthModifier})";
			}
			else
			{
				strengthLabel.Text = $"?(?)";
			}

			// Телосложение
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				constitutionLabel.Text = $"{target.Constitution}({target.constitutionModifier})";
			}
			else
			{
				constitutionLabel.Text = $"?(?)";
			}

			// Ловкость
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				dexterityLabel.Text = $"{target.Dexterity}({target.dexterityModifier})";
			}
			else
			{
				dexterityLabel.Text = $"?(?)";
			}

			// Интелект
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				intelligenceLabel.Text = $"{target.Inteligence}({target.inteligenceModifier})";
			}
			else
			{
				intelligenceLabel.Text = $"?(?)";
			}

			// Мудрость
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				wisdomLabel.Text = $"{target.Wisdom}({target.wisdomModifier})";
			}
			else
			{
				wisdomLabel.Text = $"?(?)";
			}

			// Харизма
			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				charismaLabel.Text = $"0 (-5)";
			}
			else
			{
				charismaLabel.Text = $"?(?)";
			}

			#endregion

			#region Картинка направления движения

			if (target == player || (target != player && player.wisdomModifier >= 2))
			{
				// Картинка направления движения и направления атаки
				if (target.directMove == true && target.diagonalMove == false)
				{
					MoveFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/MovementsFrames/DirectMovementFrame.png");
				}
				else if (target.directMove == false && target.diagonalMove == true)
				{
					MoveFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/MovementsFrames/DiagonalMovementFrame.png");
				}
				else if (target.directMove == true && target.diagonalMove == true)
				{
					MoveFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/MovementsFrames/AlloutMovementsFrame.png");
				}

				// Картинка направления атаки
				if (target.weapon.directAttack == true && target.weapon.diagonalAttack == false)
				{
					AttackFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/AttackFrames/DirectAttackFrame.png");
				}
				else if (target.weapon.directAttack == false && target.weapon.diagonalAttack == true)
				{
					AttackFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/AttackFrames/DiagonalAttackFrame.png");
				}
				else if (target.weapon.directAttack == true && target.weapon.diagonalAttack == true)
				{
					AttackFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/AttackFrames/AlloutAttackFrame.png");
				}
			}
			else
			{
				MoveFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/QuestionMarkFrame.png");
				AttackFrame.Texture = (Texture2D)GD.Load("res://Data/Sprites/UI/GameScene/SideMenu/Frames/QuestionMarkFrame.png");
			}

			#endregion


			// Счетчики уровня и ходов
			//currentLevelLabel.Text = $"УР: {levelInfo.CurrentLevel}";
			//currentTurnLabel.Text = $"Ход: {levelInfo.CurrentTurn}";
		}
	}

	private void AddPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChildren().OfType<Player>().FirstOrDefault();
	}

	private void AddLevelInfo()
	{
		levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}
}
