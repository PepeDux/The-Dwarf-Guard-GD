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
		Events.levelGenerated += SpawnFunctionalObject;

		levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");


		GD.Print(Events.levelGenerated.GetInvocationList().Length);
	}

	public override void _ExitTree()
	{
		Events.levelGenerated -= SpawnFunctionalObject;
	}

	public void SpawnFunctionalObject()
	{
		for (int i = 0; i < levelInfo.trap; i++)
		{
			Spawn(trap, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.food; i++)
		{
			Spawn(food, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.money; i++)
		{
			Spawn(money, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.crystal; i++)
		{
			Spawn(crystal, Vector2I.Zero);
		}
	}
}
