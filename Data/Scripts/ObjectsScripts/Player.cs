using Godot;
using System;

public partial class Player : Character
{
	public static Action<Player> playerSpawned;

	private bool isFacingRight = true;



	public override void _Ready()
	{
		//playerSpawned?.Invoke(this);
		Starter();
	}

	public override void _Process(double delta)
	{
		Updater();
		MoveOrientation(); //Отвечает за передвижение персонажа и его направление
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
