using Godot;
using System;
using System.Collections.Generic;

public partial class CharacterAudioController : AudioStreamPlayer
{
	Random random = new Random();

	// Звуки получекния урона
	[Export] AudioStreamWav[] hurtSounds;
	// Звуки ходьбы
	[Export] AudioStreamWav[] moveSounds;
	// Звуки промаха
	[Export] AudioStreamWav[] missSound;
	
	public void PlaySound(string typeSound, float pitchScaleMin, float pitchScaleMax)
	{
		switch(typeSound)
		{
			case "Hurt":
				this.Stream = hurtSounds[random.Next(0, hurtSounds.Length)];
				break;
			case "Move":
				this.Stream = moveSounds[random.Next(0, moveSounds.Length)];
				break;
			case "Miss":
				this.Stream = missSound[random.Next(0, missSound.Length)];
				break;
			default:
				break;
		}

		// Питчим звук в диапазоне, чтобы звук звучал более по разному
		this.PitchScale = (float)(pitchScaleMin + (random.NextDouble() * (pitchScaleMax - pitchScaleMin)));
		// Проигрываем анимацию
		this.Play();
	}
}
