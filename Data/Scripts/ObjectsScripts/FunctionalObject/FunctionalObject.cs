using Godot;
using System;
using System.Threading.Tasks;

public partial class FunctionalObject : BaseObject
{
	[Export] Resource modifier;
	public override void _Ready()
	{
		// Подписываемся на событие
		Events.characterMoved += CheckWalkerCell;

		FindTileMap();
		UpdateCoordinate();
	}

	public override void _ExitTree()
	{
		Events.characterMoved -= CheckWalkerCell;
	}

	public virtual async void CheckWalkerCell()
	{
		foreach (var character in CharacterStorage.characters)
		{
			if (this.coordinate == character.coordinate)
			{
				// Проигрываем звук
				GetNode<AudioController>("AudioStreamPlayer").PlaySound("Pick", 0.9f, 1.3f);
				// Немного ждем, для того чтобы звук точно проигрался
				await Task.Delay(10);

				// Добавляем модификатор к персонажу, наступившему на этот объект
				character.GetNode<СharacteristicModifierCalculation>("СharacteristicModifierCalculation").AddModifier(modifier as CharacteristicModifierData, false);

				// Отписываемся от события
				Events.characterMoved -= CheckWalkerCell;

				// Удаляем объект со сцены
				this.QueueFree();

			}
		}
	}
}

