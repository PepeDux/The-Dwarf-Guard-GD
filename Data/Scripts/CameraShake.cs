using Godot;
using System;
using System.Threading.Tasks;

public partial class CameraShake : Node
{
	[Export] Camera2D camera;
	Random random = new Random();

	public async Task ShakeAsync(int shakeIntensity = 1, float shakeModifier = 1, int shakeIteration = 10, int shakeSpeed = 10)
	{
		for (int i = 0; i < shakeIteration; i++)
		{
			await Task.Delay(shakeSpeed);
			camera.Offset = new Vector2(
				random.Next(-shakeIntensity, shakeIntensity) * shakeModifier,
				random.Next(-shakeIntensity, shakeIntensity) * shakeModifier);
		}

		// Возвращаем камеру на исходную позицию
		camera.Offset = new Vector2(0, 0);
	}
}
