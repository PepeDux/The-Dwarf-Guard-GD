using Godot;
using System;

public partial class VHS : Node2D
{
	ConfigFile config = new ConfigFile();

	public override void _Process(double delta)
	{
		config.Load("user://Settings.cfg");
		this.Visible = (bool)config.GetValue("VHS", "VHS");
	}
}
