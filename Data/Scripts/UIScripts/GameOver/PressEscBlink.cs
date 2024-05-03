using Godot;
using System;
using System.Threading.Tasks;

public partial class PressEscBlink : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Blink();
	}

	private async void Blink()
	{
		while(true)
		{
			await Task.Delay(500);

			Visible = !Visible;
		}
	}
}
