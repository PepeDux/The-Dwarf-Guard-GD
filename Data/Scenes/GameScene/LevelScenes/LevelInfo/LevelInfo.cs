using Godot;
using System;

public partial class LevelInfo : Node
{
	public override void _Ready()
	{
		Events.levelGenerated += AddLevel;
		Events.finishedAllTurn += AddTurn;
	}

	public override void _ExitTree()
	{
		Events.levelGenerated -= AddLevel;
		Events.finishedAllTurn -= AddTurn;
	}

	// Текущий уровень
	private int currentLevel = 0;
	public int CurrentLevel
	{
		get
		{
			return currentLevel;
		}
		set
		{
			currentLevel = Math.Clamp(value, 0, 1000);
		}
	}

	// Текущий ход
	private int currentTurn = 0;
	public int CurrentTurn
	{
		get
		{
			return currentTurn;
		}
		set
		{
			currentTurn = Math.Clamp(value, 1, 1000);
		}
	}



	private void AddLevel()
	{
		CurrentLevel++;
	}
	private void AddTurn()
	{
		CurrentTurn++;
	}
}
