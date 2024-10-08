﻿using Godot;
using System;
using System.Threading.Tasks;

public partial class CameraShake : Node
{
	static Camera2D camera;

    public override void _Ready()
    {
        base._Ready();

		camera = GetParent<Camera2D>();
    }
    public static async Task ShakeAsync(int shakeIntensity = 1, float shakeModifier = 1, int shakeIteration = 10, int shakeSpeed = 10)
	{
		for (int i = 0; i < shakeIteration; i++)
		{
			await Task.Delay(shakeSpeed);
			camera.Offset = new Vector2(
                new Random().Next(-shakeIntensity, shakeIntensity) * shakeModifier,
                new Random().Next(-shakeIntensity, shakeIntensity) * shakeModifier);
		}

		// Возвращаем камеру на исходную позицию
		camera.Offset = new Vector2(0, 0);
	}
}