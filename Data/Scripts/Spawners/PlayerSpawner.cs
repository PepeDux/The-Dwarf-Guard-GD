using Godot;
using System;

public partial class PlayerSpawner : Spawner
{
	[Export] public PackedScene[] player;



	public override void _Ready()
	{
		Events.levelGenerated += SpawnPlayer;

		levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}

    public override void _ExitTree()
    {
        Events.levelGenerated -= SpawnPlayer;
    }

    public void SpawnPlayer()
	{
		for (int i = 0; i < 1; i++)
		{
			Spawn(player, Vector2I.Zero);
		}
	}
}
