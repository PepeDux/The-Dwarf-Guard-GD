using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public partial class Enemy : Character
{
	private bool isFacingRight = true;

	public Player player;



	public override void _Ready()
	{
		//Подписываемся на события
		Events.playerSpawned += GetPlayer;
		Events.playerTurnFinished += UpdatePoints;

		base._Ready();
	}
	public override void _ExitTree()
	{
		base._ExitTree();
		Events.playerSpawned -= GetPlayer;
		Events.playerTurnFinished -= UpdatePoints;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		Orientation();

		GetPlayer();
	}

	

	private void GetPlayer()
	{
		if (player == null) 
		{
			player = GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChildren().OfType<Player>().FirstOrDefault();
		}
	}

	private void Orientation()
	{
		if (player != null)
		{
			if (player.Position.X < Position.X && isFacingRight == true)
			{
				Flip();
			}
			else if (player.Position.X > Position.X && isFacingRight == false)
			{
				Flip();
			}
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

	public void EnemyMove()
	{
		List<Vector2I> pathToTarget = GetNode<Pathfinding>("Pathfinding").pathToTarget;

		if (MovePoints >= moveCost && player != null)
		{
			pathToTarget.Clear();
			pathToTarget = GetNode<Pathfinding>("Pathfinding").GetPath(player.coordinate);

			if (pathToTarget.Count > 1)
			{
				TileStorage.RemoveCell(this);

				pathToTarget.RemoveAt(0);
				coordinate = pathToTarget[pathToTarget.Count - 1];
				// Обновляем Position исходя из координат объекта
				UpdateCoordinate();
				// Проигрываем звук ходьбы
				GetNode<AudioController>("AudioStreamPlayer").PlaySound("Move", 0.8f, 1f);
				// Отнимаем стоимость шага
				MovePoints -= moveCost;
				//
				Events.characterMoved?.Invoke();


				TileStorage.AddCell(this);
			}
		}
	}

	public async void Turn()
	{
		while (MovePoints >= moveCost)
		{
			await Task.Delay(250);

			int startPoints = MovePoints;

			EnemyMove();

			if (startPoints == MovePoints)
			{
				break;
			}
		}

		while (ActionPoints >= meleeAttackCost || ActionPoints >= rangeAttackCost && player != null)
		{
			await Task.Delay(250);

			int startPoints = ActionPoints;

			GetNode<AttackScript>("AttackScript").CalculationAttack(player);

			if (startPoints == ActionPoints)
			{
				break;
			}
		}

		Events.finishedEnemyTurn?.Invoke();
	}
}
