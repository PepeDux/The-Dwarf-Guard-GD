using Godot;
using System;

public partial class FunctionalObjectSpawner : Spawner
{
	[Export] public PackedScene[] traps; //Ловушки
	[Export] public PackedScene[] foods; //Еда
	[Export] public PackedScene[] moneys; //Монеты
	[Export] public PackedScene[] crystals; //Кристаллы
	[Export] public PackedScene[] runes; //Руны



	public override void _Ready()
	{
		Events.levelGenerated += SpawnFunctionalObject;

		levelSpawnInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelSpawnInfo>("LevelSpawnInfo");
	}

	public override void _ExitTree()
	{
		Events.levelGenerated -= SpawnFunctionalObject;
	}

	public void SpawnFunctionalObject()
	{
		for (int i = 0; i < levelSpawnInfo.TrapCount; i++)
		{
			Spawn(traps, Vector2I.Zero);
		}

		for (int i = 0; i < levelSpawnInfo.FoodCount; i++)
		{
			Spawn(foods, Vector2I.Zero);
		}

		for (int i = 0; i < levelSpawnInfo.MoneyCount; i++)
		{
			Spawn(moneys, Vector2I.Zero);
		}

		for (int i = 0; i < levelSpawnInfo.CrystalCount; i++)
		{
			Spawn(crystals, Vector2I.Zero);
		}

		for (int i = 0; i < levelSpawnInfo.RuneCount; i++)
		{
			Spawn(runes, Vector2I.Zero);
		}
	}
}
