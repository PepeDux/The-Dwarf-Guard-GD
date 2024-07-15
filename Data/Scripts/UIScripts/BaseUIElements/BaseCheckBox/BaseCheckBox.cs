using Godot;
using System;

public partial class BaseCheckBox : CheckBox, IToolTip
{
    [Export] public bool ToolTipIsActive { get; set; }
    [Export] public string ToolTipTittle { get; set; }
    [Export] public string ToolTipText { get; set; }

    public virtual void Pressed()
	{
		GetNode<ButtonAudioController>("AudioStreamPlayer").PlaySound("Click", 1, 1);
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
