using Godot;
using System;

public partial class PickableObject : FunctionalObject
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();

		TileStorage.occupiedCells.Add(this.coordinate);
	}
}
