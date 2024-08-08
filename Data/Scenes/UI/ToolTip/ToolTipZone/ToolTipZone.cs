using Godot;
using System;

public partial class ToolTipZone : Node, IToolTip
{
	[Export] public bool ToolTipIsActive { get; set; }
	[Export] public string ToolTipTittle { get; set; }
	[Export(PropertyHint.MultilineText)] public string ToolTipText { get; set; }

	private void MouseEntered()
	{
		((IToolTip)this).ShowToolTip(this);
	}
	private void MouseExited()
	{
		((IToolTip)this).HideToolTip();
	}
}
