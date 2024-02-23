using Godot;
using System;
using System.Xml.Schema;

public partial class Fader : ColorRect
{
	public override void _Ready()
	{
		Events.playerDied += Fade;
		Fade();
	}

	private void Fade()
	{
		Color color = new Color(27f, 27f, 27f, 255f);
		this.Color = color;
	}
}
