using Godot;
using System;

public partial class EnemySpawner : Spawner
{
	[Export] public PackedScene[] captain;
	[Export] public PackedScene[] infantry;
	[Export] public PackedScene[] rifleman;
	[Export] public PackedScene[] spellcaster;



	public override void _Ready()
	{
		Events.levelGenerated += SpawnEnemy;

        levelSpawnInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelSpawnInfo>("LevelSpawnInfo");
	}

    public override void _ExitTree()
    {
        Events.levelGenerated -= SpawnEnemy;
    }

    public void SpawnEnemy()
	{
        for (int i = 0; i < levelSpawnInfo.CaptainCount; i++)
        {
            Spawn(captain, Vector2I.Zero);
        }

        for (int i = 0; i < levelSpawnInfo.InfantryCount; i++)
		{
			Spawn(infantry, Vector2I.Zero);
		}

		for (int i = 0; i < levelSpawnInfo.RiflemanCount; i++)
		{
			Spawn(rifleman, Vector2I.Zero);
		}

		for (int i = 0; i < levelSpawnInfo.SpellcasterCount; i++)
		{
			Spawn(spellcaster, Vector2I.Zero);
		}
	}
}
