using Godot;
using System;
using System.Diagnostics;

public partial class UIManager : Node
{
	[Export] Label HPLabel;
	[Export] Label MovePointsLabel;
	[Export] Label ActionPointsLabel;

	Player player;

	public override void _Ready()
	{
		Events.playerSpawned += AddPlayer;
	}
	public override void _Process(double delta)
	{
		HPLabel.Text = "HP: " + player.HP.ToString();
		MovePointsLabel.Text = "Move: " + player.MovePoints.ToString();
		ActionPointsLabel.Text = "Action: " + player.ActionPoints.ToString();
		//GD.Print(player.HP.ToString());
	}

	private void AddPlayer()
	{
		player = GetTree().Root.GetNode("GameScene").GetNode<PlayerSpawner>("PlayerHolder").GetNode<Player>("Player");
	}
}
