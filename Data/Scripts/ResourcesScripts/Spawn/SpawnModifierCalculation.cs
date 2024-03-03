using Godot;
using System;
using System.Collections.Generic;

public partial class SpawnModifierCalculation : Node
{
	// Все статусы спавна 
	public List<SpawnModifierData> activeSpawnerModifier = new List<SpawnModifierData>();



	public override void _Ready()
	{
		// Перебираем все параметры спавнера и добавляем их в генерацию
		foreach (SpawnModifierData spawn in activeSpawnerModifier)
		{
			Сalculation(spawn, 1);
		}
	}


	// Добавляет статус спавна, добавляет параметры которые он превносит
	public void AddSpawn(SpawnModifierData spawn)
	{
		if (spawn != null)
		{
			Сalculation(spawn, 1);
			activeSpawnerModifier.Add(spawn);
		}
	}

	// Удаляет статус спавна, удаляет параметры которые он превносил
	public void RemoveSpawn(SpawnModifierData spawn)
	{
		if (spawn != null)
		{
			if (activeSpawnerModifier.Contains(spawn))
			{
				Сalculation(spawn, -1);
				activeSpawnerModifier.Remove(spawn);
			}
		}
	}



	public void Сalculation(SpawnModifierData spawn, int mod)
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
