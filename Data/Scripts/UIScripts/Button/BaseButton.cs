using Godot;
using System;

public partial class BaseButton : TextureButton
{
	public virtual void ButtonPressed()
	{
		if (Disabled == false) 
		{
			GetNode<ButtonAudioController>("AudioStreamPlayer").PlaySound("Click", 1, 1);
		}
	}
	private void Entered()
	{
		if (Disabled == false)
		{
			// Задаем курсору вид "лапки"
			CursorStyleController.SetBeam();

			Position = new Vector2(Position.X, Position.Y - 2);

			GetNode<ButtonAudioController>("AudioStreamPlayer").PlaySound("Hover", 1, 1);
		}
	}

	private void Exited()
	{
		if (Disabled == false)
		{
			Exit();
		}
	}

	public void Exit()
	{
		// Задаем курсору вид "стрелки"
		CursorStyleController.SetArrow();

		Position = new Vector2(Position.X, Position.Y + 2);
	}

	public void ButtonEventSubscribing()
	{
		// Событие на нажатие
		Pressed += ButtonPressed;
		// Событие на вход курсора на карту
		MouseEntered += Entered;
		// Событие на выход курсора на карту
		MouseExited += Exited;
	}

	public void Enable()
	{
		Disabled = false;
	}

	public void Disable()
	{
		Disabled = true;

		Exit();
	}
}
