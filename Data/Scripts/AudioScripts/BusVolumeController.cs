using Godot;
using System;

public partial class BusVolumeController : Node
{
	// Метод для измения громкости
	public static void VolumeChange(double volume)
	{
		if ((float)volume == 0)
		{
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), true);
		}
		else if ((float)volume > 0)
		{
			AudioServer.SetBusMute(AudioServer.GetBusIndex("Master"), false);

			float decibels = ConvertPercentToDecibels((float)volume);
			AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), decibels);
		}
	}

	// Конвертируем проценты в децибелы
	private static float ConvertPercentToDecibels(float percent)
	{
		float scale = 20.0f;
		float divisior = 50.0f;
		return scale * (float)Math.Log10(percent / divisior);
	}
}
