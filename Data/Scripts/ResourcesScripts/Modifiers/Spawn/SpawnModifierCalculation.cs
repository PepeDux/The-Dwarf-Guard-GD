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
		GetParent<LevelSpawnInfo>().CaptainCount += mod * spawn.captainCount;
		GetParent<LevelSpawnInfo>().InfantryCount += mod * spawn.meleeCount;
		GetParent<LevelSpawnInfo>().RiflemanCount += mod * spawn.rangeCount;
		GetParent<LevelSpawnInfo>().SpellcasterCount += mod * spawn.wizardCount;

		GetParent<LevelSpawnInfo>().WallCount += mod * spawn.wallCount;
		GetParent<LevelSpawnInfo>().PitCount += mod * spawn.pitCount;

		GetParent<LevelSpawnInfo>().TrapCount += mod * spawn.trapCount;
		GetParent<LevelSpawnInfo>().FoodCount += mod * spawn.foodCount;
		GetParent<LevelSpawnInfo>().MoneyCount += mod * spawn.moneyCount;
		GetParent<LevelSpawnInfo>().CrystalCount += mod * spawn.crystalCount;
		GetParent<LevelSpawnInfo>().RuneCount += mod * spawn.runeCount;
	}
}
