using Godot;
using System;
using System.Diagnostics;
using System.Linq;

public partial class UIManager : Node
{
	[Export] Label HPLabel;
	[Export] Label MovePointsLabel;
	[Export] Label ActionPointsLabel;
	[Export] Label ACLabel;

	[Export] Label strengthLabel;
	[Export] Label dexterityLabel;
	[Export] Label constitutionLabel;
	[Export] Label intelligenceLabel;
	[Export] Label wisdomLabel;

	[Export] Label currentLevelLabel;
	[Export] Label currentTurnLabel;


	Player player;
	Character target;

	LevelInfo levelInfo;

	public override void _Ready()
	{
		Events.playerSpawned += AddPlayer;

		AddLevelInfo();
	}

	public override void _ExitTree()
	{
		Events.playerSpawned -= AddPlayer;
	}

	public override void _Process(double delta)
	{
		if (DataBank.currentMouseTarget == null)
		{
			target = player;
		}
		else
		{
			target = DataBank.currentMouseTarget;
		}

		if (target != null) 
		{
			HPLabel.Text = $"ОЗ: {target.HP}/{target.MaxHP}";
			MovePointsLabel.Text = $"ОП: {target.MovePoints}/{target.MaxMovePoints}";
			ActionPointsLabel.Text = $"ОД: {target.ActionPoints}/{target.MaxActionPoints}";
			ACLabel.Text = $"КД: {target.AC}";

			strengthLabel.Text = $"СИЛ: {target.Strength} ({target.strengthModifier})";
			dexterityLabel.Text = $"ЛОВ: {target.Dexterity} ({target.dexterityModifier})";
			constitutionLabel.Text = $"ТЕЛ: {target.Constitution} ({target.constitutionModifier})";
			intelligenceLabel.Text = $"ИНТ: {target.Inteligence} ({target.inteligenceModifier})";
			wisdomLabel.Text = $"МУД: {target.Wisdom} ({target.wisdomModifier})";

			currentLevelLabel.Text = $"УР: {levelInfo.CurrentLevel}";
			currentTurnLabel.Text = $"Ход: {levelInfo.CurrentTurn}";
		}
	}

	private void AddPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChildren().OfType<Player>().FirstOrDefault();
	}

	private void AddLevelInfo()
	{
		levelInfo = GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo");
	}
}

