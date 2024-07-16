using Godot;
using System;

public partial class BaseHScrollBar : HScrollBar
{
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
