using Godot;
using System;

public partial class StaticObjectSpawner : Spawner
{
	[Export] public PackedScene[] wall; //Стена
	[Export] public PackedScene[] pit; //Яма



	public override void _Ready()
	{
        //Events.levelStarted += SpawnStaticTileObject;

        levelSpawnInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelSpawnInfo>("LevelSpawnInfo");
		//SpawnStaticTileObject();
	}

    public override void _ExitTree()
    {
        Events.levelGenerated -= SpawnStaticTileObject;
    }

    public void SpawnStaticTileObject()
	{
		for (int i = 0; i < levelSpawnInfo.WallCount; i++)
		{
			Spawn(wall, Vector2I.Zero);
		}

		for (int i = 0; i < levelSpawnInfo.PitCount; i++)
		{
			Spawn(pit, Vector2I.Zero);
		}
	}
}
