using Godot;
using System;
using System.Collections.Generic;

public partial class AudioController : AudioStreamPlayer
{
	// Звуки получекния урона
	[Export] AudioStreamWav[] hurtSounds;
	// Звуки ходьбы
	[Export] AudioStreamWav[] moveSounds;
	// Звуки промаха
	[Export] AudioStreamWav[] missSound;
	// Звуки подбирания предмета
	[Export] AudioStreamWav[] pickSound;

	public bool PlaySound(string typeSound, float pitchScaleMin, float pitchScaleMax)
	{
		switch(typeSound)
		{
			case "Hurt":
				this.Stream = hurtSounds[new Random().Next(0, hurtSounds.Length)];
				break;
			case "Move":
				this.Stream = moveSounds[new Random().Next(0, moveSounds.Length)];
				break;
			case "Miss":
				this.Stream = missSound[new Random().Next(0, missSound.Length)];
				break;
			case "Pick":
				this.Stream = pickSound[new Random().Next(0, pickSound.Length)];
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
