using Godot;
using System;

public partial class StaticObjectSpawner : Spawner
{
    [Export] public PackedScene[] wall; //Стена
    [Export] public PackedScene[] pit; //Яма




    public void SpawnStaticTileObject()
    {
        for (int i = 0; i < generateLevelInfo.wall; i++)
        {
            Spawn(wall);
        }

        for (int i = 0; i < generateLevelInfo.pit; i++)
        {
            Spawn(pit);
        }
    }
}
