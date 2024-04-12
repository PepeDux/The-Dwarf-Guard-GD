using Godot;
using System;

public partial class StaticObjectSpawner : Spawner
{
	[Export] public PackedScene[] wall; //Стена
	[Export] public PackedScene[] pit; //Яма



	public override void _Ready()
	{
        //Events.levelStarted += SpawnStaticTileObject;

        levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
		//SpawnStaticTileObject();
	}

    public override void _ExitTree()
    {
        Events.levelGenerated -= SpawnStaticTileObject;
    }

    public void SpawnStaticTileObject()
	{
		for (int i = 0; i < levelInfo.wall; i++)
		{
			Spawn(wall, Vector2I.Zero);
		}

		for (int i = 0; i < levelInfo.pit; i++)
		{
			Spawn(pit, Vector2I.Zero);
		}
	}
}
