using Godot;
using System;

public partial class PlayerSpawner : Spawner
{
	[Export] public PackedScene[] player;



	public override void _Ready()
	{
		Events.levelStarted += SpawnPlayer;

		generateLevelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
		SpawnPlayer();
	}

	public void SpawnPlayer()
	{
		for (int i = 0; i < 1; i++)
		{
			Spawn(player);
		}
	}
}
