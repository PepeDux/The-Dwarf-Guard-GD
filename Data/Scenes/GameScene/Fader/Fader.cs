using Godot;
using System;
using System.Xml.Schema;

public partial class Fader : Control
{
	public override void _Ready()
	{
		Events.levelEnded += Fade;
		Events.endSelectCard += UnFaid;
	}

	public override void _ExitTree()
	{
		Events.levelEnded -= Fade;
		Events.endSelectCard -= UnFaid;
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
