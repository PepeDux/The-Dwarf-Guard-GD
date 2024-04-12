using Godot;
using System;
using System.Diagnostics;

public partial class UIManager : Node
{
	[Export] Label HPLabel;
	[Export] Label MovePointsLabel;
	[Export] Label ActionPointsLabel;
	[Export] Label ACLabel;

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

		if(target != null)
		{
			HPLabel.Text = "HP: " + target.HP.ToString() + "/" + target.maxHP;
			MovePointsLabel.Text = "Move: " + target.MovePoints.ToString() + "/" + target.maxMovePoints;
			ActionPointsLabel.Text = "Action: " + target.ActionPoints.ToString() + "/" + target.maxActionPoints;
			ACLabel.Text = "AC: " + target.AC;
		}
	}

	private void AddPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChild<Player>(0);
	}
}

