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

        levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}

    public override void _ExitTree()
    {
        Events.levelGenerated -= SpawnEnemy;
    }

    public void SpawnEnemy()
	{
        for (int i = 0; i < levelInfo.CaptainCount; i++)
        {
            Spawn(captain, Vector2I.Zero);
        }

        for (int i = 0; i < levelInfo.InfantryCount; i++)
		{
			Spawn(infantry, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.RiflemanCount; i++)
		{
			Spawn(rifleman, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.SpellcasterCount; i++)
		{
			Spawn(spellcaster, Vector2I.Zero);
		}
	}
}
