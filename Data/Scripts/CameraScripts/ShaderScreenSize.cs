using Godot;
using System;

public partial class ShaderScreenSize : ColorRect
{
	public override void _Process(double delta)
	{
		this.Size = GetViewportRect().Size;		
	}
}
