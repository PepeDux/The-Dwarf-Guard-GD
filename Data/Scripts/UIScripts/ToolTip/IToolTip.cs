using Godot;
using System;

public interface IToolTip 
{
	// Активен ли тултип
	public bool ToolTipIsActive { get; set; }

	// Заголовок тултипа
	public string ToolTipTittle {  get; set; }

	// Текст тулптипа
	public string ToolTipText { get; set; }


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
