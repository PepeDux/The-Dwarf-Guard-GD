using Godot;
using System;
using System.Linq;

public partial class AbilityPanel : Node
{
	Player player;

	public override void _Ready()
	{
		Events.playerSpawned += GetPlayer;
		Events.playerSpawned += SetButtonAbility;
	}

	public override void _ExitTree()
	{
		Events.playerSpawned -= GetPlayer;
		Events.playerSpawned -= SetButtonAbility;
	}

	private void SetButtonAbility()
	{
		if (player != null)
		{
			// Нода хранящая абилки персонажа
			CharacterAbilitiesStorage characterAbilitiesStorage = player.GetNode<CharacterAbilitiesStorage>("CharacterAbilitiesStorage");

			// Перебираем все кнопки и добавляем к каждой кнопке абилку от персонажа
			for (int i = 1; i <= GetChildCount(); i++)
			{
				// Текущая кнопка в цикле
				AbilityButton abilityButton = GetNode<AbilityButton>($"AbilityButton{i}");

				if (i - 1 < characterAbilitiesStorage.abilities.Length && characterAbilitiesStorage.abilities[i - 1] != null)
				{
					// 
					abilityButton.ability = characterAbilitiesStorage.abilities[i - 1];
					// Задаем кнопке картинку абилки
					abilityButton.GetNode<TextureRect>("TextureRect").Texture = characterAbilitiesStorage.abilities[i - 1].abilityImage;
				}
				else
				{
					// Делаем кнопку невидимой если у игрока нет абилки под текущую кнопку в цикле
					abilityButton.Visible = false;
				}
			}
		}
	}

	private void GetPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChildren().OfType<Player>().FirstOrDefault();
	}
}
