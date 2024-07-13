using Godot;
using System;
using System.Threading.Tasks;

public partial class PickableObject : FunctionalObject
{
	[Export] Resource modifier;
	public override void _Ready()
	{
		base._Ready();
	}
	public override void _ExitTree()
	{
		base._ExitTree();
	}

	public override async void CheckWalkerCellAsync(Character character)
	{
		if (this.Coordinate == character.Coordinate) 
		{
			try
			{
				// Проигрываем звук
				GetNode<AudioController>("AudioStreamPlayer").PlaySound("Pick", 0.9f, 1.3f);
				// Немного ждем, для того чтобы звук точно проигрался
				await Task.Delay(10);
			}
			catch
			{

			}
			

			CharacteristicModifierData mod = modifier as CharacteristicModifierData;



			if (mod.permanent == true)
			{
				if (character is Player)
				{
					// Добавляем модификатор к общему пулу модификаторов игрока, модификатор становится постоянным
					GetTree().Root.GetNode("GameScene").GetNode<LevelModifier>("LevelModifier").playerModifiers.Add(modifier as CharacteristicModifierData);

					// Добавляем модификатор к персонажу, наступившему на этот объект
					character.GetNode<СharacteristicModifierCalculation>("СharacteristicModifierCalculation").AddModifier(modifier as CharacteristicModifierData, false);
				}
			}
			else if (mod.permanent == false)
			{
				// Добавляем модификатор к персонажу, наступившему на этот объект
				character.GetNode<СharacteristicModifierCalculation>("СharacteristicModifierCalculation").AddModifier(modifier as CharacteristicModifierData, false);
			}



			// Удаляем объект со сцены
			this.QueueFree();
		}	
	}
}
