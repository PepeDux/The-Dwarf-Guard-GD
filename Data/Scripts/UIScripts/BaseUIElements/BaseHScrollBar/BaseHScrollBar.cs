using Godot;
using System;

public partial class BaseHScrollBar : HScrollBar, IToolTip
{
    [Export] public bool ToolTipIsActive { get; set; }
    [Export] public string ToolTipTittle { get; set; }
    [Export] public string ToolTipText { get; set; }

    public override void _Ready()
	{
		GetNode<Label>("ValueLabel").Text = Value.ToString();
	}
	public virtual void Scrolling()
	{
		GetNode<Label>("ValueLabel").Text = Value.ToString();
	}

	private void MouseEntered()
	{
        ((IToolTip)this).ShowToolTip(this);

        // Задаем курсору вид "лапки"
        CursorStyleController.SetBeam();

		GetNode<ButtonAudioController>("AudioStreamPlayer").PlaySound("Hover", 1, 1);
	}

	private void MouseExited()
	{
        ((IToolTip)this).HideToolTip();

        // Задаем курсору вид "стрелки"
        CursorStyleController.SetArrow();
	}
}
