using Godot;
using System;

public partial class BaseButton : TextureButton
{
	private Vector2 basePosition;

	public override void _Ready()
	{
		base._Ready();

		basePosition = new Vector2(Position.X, Position.Y);
	}

	public virtual void Pressed()
	{
		if (Disabled == false) 
		{
			GetNode<ButtonAudioController>("AudioStreamPlayer").PlaySound("Click", 1, 1);
		}
	}

	private void MouseEntered()
	{
		if (Disabled == false)
		{
			// Задаем курсору вид "лапки"
			CursorStyleController.SetBeam();

			basePosition = new Vector2(Position.X, Position.Y);

			Position = new Vector2(Position.X, Position.Y - 2);

			GetNode<ButtonAudioController>("AudioStreamPlayer").PlaySound("Hover", 1, 1);
		}
	}

	private void MouseExited()
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

		Position = basePosition;
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
