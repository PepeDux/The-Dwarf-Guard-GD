using Godot;
using System;
using System.Xml.Schema;

public partial class Fader : Node
{
	public override void _Ready()
	{
		Events.playerDied += Fade;
	}

	private void Fade()
	{
		//Color color = new Color(0f, 0f, 0f, 255f);
		//GetParent<>().Color = color;
	}
}
