using Godot;
using System;

public interface IToolTip 
{
	[ExportGroup("ToolTip")]
	// Активен ли тултип
	[Export] public bool ToolTipIsActive { get; set; }

	// Заголовок тултипа
	[Export] public string ToolTipTittle {  get; set; }

	// Текст тулптипа
	[Export(PropertyHint.MultilineText)] public string ToolTipText { get; set; }


	public void ShowToolTip(Node node)
	{
		if (ToolTipIsActive == true)
		{
			ToolTip.ShowToolTip(node, ToolTipTittle, ToolTipText);
		}
	}

	public void HideToolTip()
	{
		ToolTip.HideToolTip();
	}
}
