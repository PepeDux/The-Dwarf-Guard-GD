using Godot;
using System;

public partial class FunctionalObject : BaseObject
{
	[Export] Resource modifier;
	public override void _Ready()
	{
		Starter();
	}

	public virtual void Starter()
	{
		// Подписываемся на событие
		Events.characterMoved += CheckWalkerCell;

		FindTileMap();
		UpdateCoordinate();
	}

	public void CheckWalkerCell()
	{
		foreach (var character in CharacterStorage.characters)
		{
			if (this.coordinate == character.coordinate)
			{
				// Добавляем модификатор к персонажу наступившему на этот объект
				character.GetNode<СharacteristicModifierCalculation>("СharacteristicModifierCalculation").AddModifier(modifier as CharacteristicModifierData);
				// Удаляем объект со сцены
				this.Free();
			}
		}
	}
}

