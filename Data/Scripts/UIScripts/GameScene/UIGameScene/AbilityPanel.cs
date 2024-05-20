using Godot;
using System;
using System.Linq;

public partial class AbilityPanel : Node
{
	Player player;
	Character target;

	CharacterAbilitiesStorage characterAbilitiesStorage;

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
		if (DataBank.currentMouseTarget == null)
		{
			target = player;
		}
		else
		{
			//target = DataBank.currentMouseTarget;
		}

		if (target != null)
		{
			characterAbilitiesStorage = target.GetNode<CharacterAbilitiesStorage>("CharacterAbilitiesStorage");

			for (int i = 1; i <= GetChildCount(); i++)
			{
				AbilityButton abilityButton = GetNode<AbilityButton>($"AbilityButton{i}");

				if (characterAbilitiesStorage.abilities[i - 1] != null) 
				{
					abilityButton.ability = characterAbilitiesStorage.abilities[i - 1];

					abilityButton.GetNode<TextureRect>("TextureRect").Texture = characterAbilitiesStorage.abilities[i - 1].abilityImage;
				}

				break;
			}
		}
	}

	private void GetPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChildren().OfType<Player>().FirstOrDefault();
	}
}
