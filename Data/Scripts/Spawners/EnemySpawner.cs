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
		Events.levelGenerated += SpawnEnemy;

        levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}

    public override void _ExitTree()
    {
        Events.levelGenerated -= SpawnEnemy;
    }

    public void SpawnEnemy()
	{
		for (int i = 0; i < levelInfo.melee; i++)
		{
			Spawn(melee, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.range; i++)
		{
			Spawn(range, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.captain; i++)
		{
			Spawn(captain, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.wizard; i++)
		{
			Spawn(wizard, Vector2I.Zero);
		}
	}
}
