using Godot;
using System;
using System.Threading.Tasks;

public partial class FunctionalObject : BaseObject
{
	public Character character;

	public override void _Ready()
	{
		base._Ready();

		// Подписываемся на событие
		Events.characterMoved += CheckWalkerCellAsync;

		TileStorage.occupiedCells.Add(this.Coordinate);

		UpdateCoordinate();
	}

	public override void _ExitTree()
	{
		base._ExitTree();

		Events.characterMoved -= CheckWalkerCellAsync;
	}

	public virtual async void CheckWalkerCellAsync(Character character)
	{
		if (this.Coordinate == character.Coordinate)
		{
			this.character = character;
		}
	}
}
