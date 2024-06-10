using Godot;
using System;

public partial class MasterVolumeHScrollBar : BaseHScrollBar
{
	ConfigFile config = new ConfigFile();

	public override void _Ready()
	{
		config.Load("user://Settings.cfg");

		this.Value = (int)config.GetValue("GameVolume", "MasterVolume");
		BusVolumeController.VolumeChange(this.Value);

		base._Ready();
	}
	public override void Scrolling()
	{
		base.Scrolling();

		config.Load("user://Settings.cfg");
		// Store some values.
		config.SetValue("GameVolume", "MasterVolume", this.Value);
		// Задаем громкость общего звука в игре
		BusVolumeController.VolumeChange(this.Value);
		// Save it to a file (overwrite if already exists).
		config.Save("user://Settings.cfg");
	}
}
