using Godot;
using System;
using System.Xml.Schema;

public partial class Fader : ColorRect
{
	public override void _Ready()
	{
		//Events.playerDied += Fade;
		Events.levelEnded += Fade;
		Events.endSelectCard += UnFaid;
	}

	private void Fade()
	{
		this.ZIndex = 1;
	}

	private void UnFaid()
	{
		this.ZIndex = -1;
	}
}
