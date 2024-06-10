using Godot;
using System;

public partial class MainMenu : Node
{
	ConfigFile config = new ConfigFile();
	public override void _Ready()
	{
		config.Load("user://Settings.cfg");

		int value = (int)config.GetValue("GameVolume", "MasterVolume");
		BusVolumeController.VolumeChange(value);
	}

}
