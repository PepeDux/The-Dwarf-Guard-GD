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
		GetParent<LevelInfo>().CaptainCount += mod * spawn.captainCount;
		GetParent<LevelInfo>().InfantryCount += mod * spawn.meleeCount;
		GetParent<LevelInfo>().RiflemanCount += mod * spawn.rangeCount;
		GetParent<LevelInfo>().SpellcasterCount += mod * spawn.wizardCount;

		GetParent<LevelInfo>().WallCount += mod * spawn.wallCount;
		GetParent<LevelInfo>().PitCount += mod * spawn.pitCount;

		GetParent<LevelInfo>().TrapCount += mod * spawn.trapCount;
		GetParent<LevelInfo>().FoodCount += mod * spawn.foodCount;
		GetParent<LevelInfo>().MoneyCount += mod * spawn.moneyCount;
		GetParent<LevelInfo>().CrystalCount += mod * spawn.crystalCount;
		GetParent<LevelInfo>().RuneCount += mod * spawn.runeCount;
	}
}
