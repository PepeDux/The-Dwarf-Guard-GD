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
		GetParent<LevelInfo>().meleeCount += mod * spawn.meleeCount;
		GetParent<LevelInfo>().rangeCount += mod * spawn.rangeCount;
		GetParent<LevelInfo>().captainCount += mod * spawn.captainCount;
		GetParent<LevelInfo>().wizardCount += mod * spawn.wizardCount;

		GetParent<LevelInfo>().wallCount += mod * spawn.wallCount;
		GetParent<LevelInfo>().pitCount += mod * spawn.pitCount;

		GetParent<LevelInfo>().trapCount += mod * spawn.trapCount;
		GetParent<LevelInfo>().foodCount += mod * spawn.foodCount;
		GetParent<LevelInfo>().moneyCount += mod * spawn.moneyCount;
		GetParent<LevelInfo>().crystalCount += mod * spawn.crystalCount;
		GetParent<LevelInfo>().runeCount += mod * spawn.runeCount;
	}
}
