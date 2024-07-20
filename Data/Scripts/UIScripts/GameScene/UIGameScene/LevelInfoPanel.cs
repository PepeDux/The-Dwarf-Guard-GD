using Godot;
using System;

public partial class LevelInfoPanel : Node
{
	[Export] Label currentLevelLabel;
	[Export] Label currentTurnLabel;

	LevelInfo levelInfo;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Счетчики уровня и ходов
		currentLevelLabel.Text = $"УР: {levelInfo.CurrentLevel}";
		currentTurnLabel.Text = $"Ход: {levelInfo.CurrentTurn}";
	}
}
