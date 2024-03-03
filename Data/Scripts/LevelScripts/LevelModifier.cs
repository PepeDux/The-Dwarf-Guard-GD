using Godot;
using System;
using System.Collections.Generic;

public partial class LevelModifier : Node
{
	public List<CharacteristicModifierData> enemyModifiers = new List<CharacteristicModifierData>();
	public List<CharacteristicModifierData> playerModifiers = new List<CharacteristicModifierData>();
	public List<SpawnModifierData> spawnModifiers = new List<SpawnModifierData>();
}