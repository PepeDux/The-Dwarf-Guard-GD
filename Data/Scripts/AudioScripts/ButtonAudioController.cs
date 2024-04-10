using Godot;
using System;

public partial class ButtonAudioController : AudioStreamPlayer
{
	Random random = new Random();

	// Звуки получекния урона
	[Export] AudioStreamWav[] hoverSounds;
	// Звуки ходьбы
	[Export] AudioStreamWav[] clickSounds;

	public bool PlaySound(string typeSound, float pitchScaleMin, float pitchScaleMax)
	{
		switch (typeSound)
		{
			case "Hover":
				this.Stream = hoverSounds[random.Next(0, hoverSounds.Length)];
				break;
			case "Click":
				this.Stream = clickSounds[random.Next(0, clickSounds.Length)];
				break;
			default:
				break;
		}

		// Питчим звук в диапазоне, чтобы звук звучал более по разному
		this.PitchScale = (float)(pitchScaleMin + (random.NextDouble() * (pitchScaleMax - pitchScaleMin)));
		// Проигрываем звук
		this.Play();

		return true;
	}
}
