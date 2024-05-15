using Godot;
using System;

public partial class BaseProgressBar : TextureProgressBar
{
	public bool canChanged = true;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		UpdateLabel();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateLabel();
	}

	public void ChangeValue(int value, int maxValue)
	{
		canChanged = true;

		Value = value;
		MaxValue = maxValue;

		UpdateLabel();
	}

	private void UpdateLabel()
	{
		if (GetNodeOrNull("ValueLabel") != null && canChanged == true)
		{
			GetNode<Label>("ValueLabel").Text = $"{this.Value}/{this.MaxValue}";
		}
	}

	public void UnknownValue()
	{
		canChanged = false;

		Value = MaxValue;

		if (GetNodeOrNull("ValueLabel") != null)
		{
			GetNode<Label>("ValueLabel").Text = "??/??";
		}
	}
}
