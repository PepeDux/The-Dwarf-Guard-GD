using Godot;
using System;

public partial class BaseProgressBar : TextureProgressBar, IToolTip
{
    [Export] public bool ToolTipIsActive { get; set; }
    [Export] public string ToolTipTittle { get; set; }
    [Export] public string ToolTipText { get; set; }

    public bool canChanged = true;

	public override void _Ready()
	{
		UpdateLabel();
	}

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
