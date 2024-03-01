using Godot;
using System;
using System.Collections.Generic;

public partial class LevelModifier : Node
{
	//[Export] private Enemy[] enemies;
	//[Export] private Player player;
	//[Export] private Spawner spawner;

	public List<StatusModifierData> enemyStatuses = new List<StatusModifierData>();
	public List<StatusModifierData> playerStatuses = new List<StatusModifierData>();
	public List<SpawnModifierData> spawnStatuses = new List<SpawnModifierData>();



	//private void Start()
	//{
	//	UpdateStatuses();
	//}

	//private void UpdateStatuses()
	//{
	//	//Добавляем статусы врагу
	//	foreach (Enemy enemy in enemies)
	//	{
	//		enemy.GetParent().GetNode<StatusCalculation>("StatusCalculation").activeStatuses = enemyStatuses;
	//	}

	//	spawner.GetParent().GetNode<SpawnCalculation>("SpawnCalculation").activeSpawners = spawnStatuses;

	//	//Добавляем статусы игроку
	//	player.GetParent().GetNode<StatusCalculation>("StatusCalculation").activeStatuses = playerStatuses;
	//}
}
