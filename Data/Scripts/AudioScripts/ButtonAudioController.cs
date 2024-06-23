using Godot;
using System;

public partial class ButtonAudioController : AudioStreamPlayer
{
	// Звуки получекния урона
	[Export] AudioStreamWav[] hoverSounds;
	// Звуки ходьбы
	[Export] AudioStreamWav[] clickSounds;

	public bool PlaySound(string typeSound, float pitchScaleMin, float pitchScaleMax)
	{
		switch (typeSound)
		{
			case "Hover":
				this.Stream = hoverSounds[new Random().Next(0, hoverSounds.Length)];
				break;
			case "Click":
				this.Stream = clickSounds[new Random().Next(0, clickSounds.Length)];
				break;
			default:
				break;
		}

		// Питчим звук в диапазоне, чтобы звук звучал более по разному
		this.PitchScale = (float)(pitchScaleMin + (new Random().NextDouble() * (pitchScaleMax - pitchScaleMin)));
		// Проигрываем звук
		this.Play();

		return true;
	}
}
