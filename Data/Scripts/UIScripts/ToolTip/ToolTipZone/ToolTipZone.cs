using Godot;
using System;

public partial class ToolTipZone : Node, IToolTip
{
	[Export] public bool ToolTipIsActive { get; set; }
	[Export] public string ToolTipTittle { get; set; }
	[Export(PropertyHint.MultilineText)] public string ToolTipText { get; set; }

	private void MouseEntered()
	{
		GD.Print("Enter");
		((IToolTip)this).ShowToolTip(this);
	}
	private void MouseExited()
	{
		GD.Print("Exit");
		((IToolTip)this).HideToolTip();
	}
}
