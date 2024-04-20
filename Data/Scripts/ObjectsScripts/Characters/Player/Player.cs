using Godot;
using System;

public partial class Player : Character
{
	private bool isFacingRight = true;



	public override void _Ready()
	{
		//Подписываемся на события	
		Events.playerTurnFinished += UpdatePoints;

		base._Ready();

		Events.playerSpawned?.Invoke();
	}

	public override void _ExitTree()
	{
		base._ExitTree();
		Events.playerTurnFinished -= UpdatePoints;
	}

	

	public override void _Process(double delta)
	{
		base._Process(delta);

		MoveOrientation(); //Отвечает за направление
	}

	void MoveOrientation()
	{
		if (GetGlobalMousePosition().X < Position.X && isFacingRight == true)
		{
			Flip();
		}
		else if (GetGlobalMousePosition().X > Position.X && isFacingRight == false)
		{
			Flip();
		}
	}

	private void Flip()
	{
		isFacingRight = !isFacingRight;
		//получаем размеры персонажа
		Vector2 theScale = GetNode<Sprite2D>("Sprite2D").Scale;
		//зеркально отражаем персонажа по оси Х
		theScale.X *= -1;
		//задаем новый размер персонажа, равный старому, но зеркально отраженный
		GetNode<Sprite2D>("Sprite2D").Scale = theScale;
	}
}
