using Godot;
using System;

public partial class Player : Character
{
	private bool isFacingRight = true;

	public bool canPerformAction = true;


	public override void _Ready()
	{
		base._Ready();

		//Подписываемся на события	
		Events.playerTurnFinished += UpdatePoints;
		Events.playerTurnFinished += ActionComplete;
		Events.finishedAllTurn += StartTimer;
		Events.finishedPlayerAction += StartTimer;
		Events.playerDied += PlayerDied;

		Events.playerSpawned?.Invoke();
	}

	public override void _ExitTree()
	{
		base._ExitTree();

		Events.playerTurnFinished -= UpdatePoints;
		Events.playerTurnFinished -= ActionComplete;
		Events.finishedAllTurn -= StartTimer;
		Events.finishedPlayerAction -= StartTimer;
        Events.playerDied -= PlayerDied;
    }

	

	public override void _Process(double delta)
	{
		base._Process(delta);

		MoveOrientation();
	}

	// Метод который разворачивает персонажа в соответсвии с положением курсора
	private void MoveOrientation()
	{
		if (canPerformAction == true) 
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
	}

	// Метод который зеркалит персонажа
	public void Flip()
	{
		isFacingRight = !isFacingRight;
		//получаем размеры персонажа
		Vector2 theScale = GetNode<Sprite2D>("Sprite2D").Scale;
		//зеркально отражаем персонажа по оси Х
		theScale.X *= -1;
		//задаем новый размер персонажа, равный старому, но зеркально отраженный
		GetNode<Sprite2D>("Sprite2D").Scale = theScale;
	}


	// Метод который запускает таймер
	private void StartTimer()
	{
		GetNode<Timer>("Timer").Start();
	}
	
	// Сигнао на окончание таймера. После окончания разрешает игроку дальше интерактировать с окружением
	private void _on_timer_timeout()
	{
		canPerformAction = true;
	}

	private void ActionComplete()
	{
		canPerformAction = false;
	}

	private void PlayerDied()
	{
		ActionComplete();
	}
}
