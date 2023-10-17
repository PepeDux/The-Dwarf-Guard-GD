using Godot;
using System;

public partial class EnemySpawner : Spawner
{
	[Export] public PackedScene[] melee;
	[Export] public PackedScene[] range;
	[Export] public PackedScene[] captain;
	[Export] public PackedScene[] wizard;

	public override void _Ready()
	{
		generateLevelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
		SpawnEnemy();

	}

	public void SpawnEnemy()
	{
		for (int i = 0; i < generateLevelInfo.melee; i++)
		{
			Spawn(melee);
		}

		for (int i = 0; i < generateLevelInfo.range; i++)
		{
			Spawn(range);
		}

		for (int i = 0; i < generateLevelInfo.captain; i++)
		{
			Spawn(captain);
		}

		for (int i = 0; i < generateLevelInfo.wizard; i++)
		{
			Spawn(wizard);
		}
	}
}
