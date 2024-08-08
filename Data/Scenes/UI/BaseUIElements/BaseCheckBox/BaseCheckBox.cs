using Godot;
using System;

public partial class BaseCheckBox : CheckBox
{
    public virtual void Pressed()
	{
		GetNode<ButtonAudioController>("AudioStreamPlayer").PlaySound("Click", 1, 1);
	}

	private void MouseEntered()
	{
        // Задаем курсору вид "лапки"
        CursorStyleController.SetBeam();

		GetNode<ButtonAudioController>("AudioStreamPlayer").PlaySound("Hover", 1, 1);
	}

	private void MouseExited()
	{
        // Задаем курсору вид "стрелки"
        CursorStyleController.SetArrow();
	}
}
