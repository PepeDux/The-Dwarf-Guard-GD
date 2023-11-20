using Godot;
using System;
using System.Collections.Generic;

public partial class SpawnCalculation : Node
{
    public List<SpawnData> activeSpawners = new List<SpawnData>();



    private void Start()
    {
        foreach (SpawnData spawn in activeSpawners)
        {
            Сalculation(spawn, 1);
        }
    }


    public void AddSpawn(SpawnData spawn)
    {
        if (spawn != null)
        {
            Сalculation(spawn, 1);
            activeSpawners.Add(spawn);
        }

    }

    public void RemoveSpawn(SpawnData spawn)
    {
        if (spawn != null)
        {
            if (activeSpawners.Contains(spawn))
            {
                Сalculation(spawn, -1);
                activeSpawners.Remove(spawn);
            }
        }
    }



    public void Сalculation(SpawnData spawn, int mod)
    {
        GetParent<LevelInfo>().melee += mod * spawn.melee;
        GetParent<LevelInfo>().range += mod * spawn.range;
        GetParent<LevelInfo>().captain += mod * spawn.captain;
        GetParent<LevelInfo>().wizard += mod * spawn.wizard;

        GetParent<LevelInfo>().wall += mod * spawn.wall;
        GetParent<LevelInfo>().pit += mod * spawn.pit;

        GetParent<LevelInfo>().trap += mod * spawn.trap;
        GetParent<LevelInfo>().food += mod * spawn.food;
        GetParent<LevelInfo>().money += mod * spawn.money;
        GetParent<LevelInfo>().crystal += mod * spawn.crystal;
    }
}
