using Godot;
using System;

public partial class MasterVolumeHScrollBar : BaseHScrollBar
{
	ConfigFile config = new ConfigFile();

	public override void _Ready()
	{
		config.Load("user://Settings.cfg");

		this.Value = (int)config.GetValue("GameVolume", "MasterVolume");
		VolumeChange();

		base._Ready();
	}
	public override void Scrolling()
	{
		base.Scrolling();

		config.Load("user://Settings.cfg");
		// Store some values.
		config.SetValue("GameVolume", "MasterVolume", this.Value);
		// Задаем громкость общего звука в игре
		VolumeChange();
		// Save it to a file (overwrite if already exists).
		config.Save("user://Settings.cfg");
	}

	// Метод для измения громкости
	private void VolumeChange()
	{
		if ((float)this.Value == 0) 
		{
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), true);
		}
		else if ((float)this.Value > 0)
		{
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), false);

			float decibels = ConvertPercentToDecibels((float)this.Value);
			AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), decibels);
		}         
	}

	// Конвертируем проценты в децибелы
	private float ConvertPercentToDecibels(float percent)
	{
		float scale = 20.0f;
		float divisior = 50.0f;
		return scale * (float)Math.Log10(percent / divisior);
	}
}
