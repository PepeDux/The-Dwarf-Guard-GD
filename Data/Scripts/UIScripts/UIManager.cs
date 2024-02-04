using Godot;
using System;
using System.Diagnostics;

public partial class UIManager : Node
{
	[Export] Label HPLabel;
	[Export] Label MovePointsLabel;
	[Export] Label ActionPointsLabel;

	Player player;
	Character target;

	public override void _Ready()
	{
		Events.playerSpawned += AddPlayer;
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

		HPLabel.Text = "HP: " + target.HP.ToString() + "/" + target.maxHP;
		MovePointsLabel.Text = "Move: " + target.MovePoints.ToString() + "/" + target.maxMovePoints;
		ActionPointsLabel.Text = "Action: " + target.ActionPoints.ToString() + "/" + target.maxActionPoints;
	}

	private void AddPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChild<Player>(0);
	}
}

