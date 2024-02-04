using Godot;
using System;

public partial class FunctionalObjectSpawner : Spawner
{
	[Export] public PackedScene[] trap; //Ловушки
	[Export] public PackedScene[] food; //Еда
	[Export] public PackedScene[] money; //Монеты
	[Export] public PackedScene[] crystal; //Кристаллы



	public override void _Ready()
	{
		//Events.levelStarted += SpawnFunctionalObject;

		generateLevelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
		//SpawnFunctionalObject();
	}

	public void SpawnFunctionalObject()
	{
		for (int i = 0; i < generateLevelInfo.trap; i++)
		{
			Spawn(trap);
		}

		for (int i = 0; i < generateLevelInfo.food; i++)
		{
			Spawn(food);
		}

		for (int i = 0; i < generateLevelInfo.money; i++)
		{
			Spawn(money);
		}

		for (int i = 0; i < generateLevelInfo.crystal; i++)
		{
			Spawn(crystal);
		}
	}
}
