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

		levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}

	public override void _ExitTree()
	{
		Events.levelGenerated -= SpawnFunctionalObject;
	}

	public void SpawnFunctionalObject()
	{
		for (int i = 0; i < levelInfo.trapCount; i++)
		{
			Spawn(traps, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.foodCount; i++)
		{
			Spawn(foods, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.moneyCount; i++)
		{
			Spawn(moneys, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.crystalCount; i++)
		{
			Spawn(crystals, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.runeCount; i++)
		{
			Spawn(runes, Vector2I.Zero);
		}
	}
}
