using Godot;
using System;
using System.Collections.Generic;

public partial class LevelModifier : Node
{
	// Модификаторы противников
	public List<CharacteristicModifierData> enemyModifiers = new List<CharacteristicModifierData>();
	// Модификаторы игрока
	public List<CharacteristicModifierData> playerModifiers = new List<CharacteristicModifierData>();
	// Модификаторы спавна
	public List<SpawnModifierData> spawnModifiers = new List<SpawnModifierData>();
}