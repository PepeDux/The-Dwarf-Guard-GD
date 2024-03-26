using Godot;
using System;
using System.Collections.Generic;

public partial class CharacterAudioController : AudioStreamPlayer
{
	Random random = new Random();

	[Export] AudioStreamWav[] hurtSounds;
	[Export] AudioStreamWav[] moveSounds;
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
			//case "Move":
			//case "MeleeAttack":
			//case "RangeAttack":


		}

		this.PitchScale = (float)(pitchScaleMin + (random.NextDouble() * (pitchScaleMax - pitchScaleMin)));
		this.Play();
	}
}
