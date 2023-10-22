using Godot;
using System;

public partial class TEST : Node
{
    int a;
	public int A
	{
		get 
		{
			return a;
		} 
		set 
		{
			a = Math.Clamp(value, 10, 20);		
		}
	}
	public override void _Ready()
	{
		A = 50;
		GD.Print(a);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
