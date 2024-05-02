using Godot;
using System;
using System.Diagnostics;

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


	Player player;
	Character target;

	public override void _Ready()
	{
		Events.playerSpawned += AddPlayer;
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
			HPLabel.Text = $"HP: {target.HP}/{target.MaxHP}";
			MovePointsLabel.Text = $"Move: {target.MovePoints}/{target.MaxMovePoints}";
			ActionPointsLabel.Text = $"Action: {target.ActionPoints}/{target.MaxActionPoints}";
			ACLabel.Text = $"AC: {target.AC}";

			strengthLabel.Text = $"STR: {target.Strength} ({target.strengthModifier})";
			dexterityLabel.Text = $"DEX: {target.Dexterity} ({target.dexterityModifier})";
			constitutionLabel.Text = $"CON: {target.Constitution} ({target.constitutionModifier})";
			intelligenceLabel.Text = $"INT: {target.Inteligence} ({target.inteligenceModifier})";
			wisdomLabel.Text = $"WIS: {target.Wisdom} ({target.wisdomModifier})";
		}
	}

	private void AddPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChild<Player>(0);
	}
}

