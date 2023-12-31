﻿using Godot;
using System;

public partial class StaticObjectSpawner : Spawner
{
    [Export] public PackedScene[] wall; //Стена
    [Export] public PackedScene[] pit; //Яма



    public override void _Ready()
    {
        //Events.levelStarted += SpawnStaticTileObject;

        generateLevelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
        //SpawnStaticTileObject();
    }

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
