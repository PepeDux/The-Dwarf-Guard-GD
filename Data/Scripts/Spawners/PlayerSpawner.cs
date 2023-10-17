using Godot;
using System;

public partial class PlayerSpawner : Spawner
{
    [Export] public PackedScene[] player;

    public override void _Ready()
    {
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
