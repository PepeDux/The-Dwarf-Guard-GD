using Godot;
using System;
using System.Collections.Generic;

public partial class LevelModifier : Node
{
	[Export] private Enemy[] enemies;
	[Export] private Player player;
	[Export] private Spawner spawner;

	public List<StatusData> enemyStatuses = new List<StatusData>();
	public List<StatusData> playerStatuses = new List<StatusData>();
	public List<SpawnData> spawnStatuses = new List<SpawnData>();



	private void Start()
	{
		UpdateStatuses();
	}

	private void UpdateStatuses()
	{
		//Добавляем статусы врагу
		foreach (Enemy enemy in enemies)
		{
			enemy.GetParent().GetNode<StatusCalculation>("StatusCalculation").activeStatuses = enemyStatuses;
		}

		spawner.GetParent().GetNode<SpawnCalculation>("SpawnCalculation").activeSpawners = spawnStatuses;

		//Добавляем статусы игроку
		player.GetParent().GetNode<StatusCalculation>("StatusCalculation").activeStatuses = playerStatuses;
	}
}
