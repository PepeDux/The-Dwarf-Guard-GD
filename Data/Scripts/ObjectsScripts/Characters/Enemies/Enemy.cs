using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public partial class Enemy : Character
{
	public Player player;

	public bool isFacingRight = true;

	ConfigFile config = new ConfigFile();

	public override void _Ready()
	{
		base._Ready();

		//Подписываемся на события
		Events.playerSpawned += GetPlayer;
	}
	public override void _ExitTree()
	{
		base._ExitTree();

		Events.playerSpawned -= GetPlayer;
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

	public void EnemyMove()
	{
		List<Vector2I> pathToTarget = GetNode<Pathfinding>("Pathfinding").pathToTarget;

		if (((MovePoints >= MoveCost) || (ActionPoints >= MoveCost)) && player != null)
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

				// Отнимаем у противника очки движения или очки действия если нет очков движения
				if (MovePoints >= MoveCost)
				{
					MovePoints -= MoveCost;
				}
				else if (MovePoints <= MoveCost)
				{
					ActionPoints -= MoveCost;
				}

				Events.characterMoved?.Invoke(this);

				TileStorage.AddCell(this);
			}
		}
	}

	public async void Turn()
	{
		config.Load("user://Settings.cfg");
		int turnSpeed = (int)config.GetValue("TurnSpeed", "TurnSpeed");

		while ((MovePoints >= MoveCost) || (ActionPoints >= MoveCost))
		{
			await Task.Delay(turnSpeed);

			int startPoints = MovePoints;

			EnemyMove();

			if (startPoints == MovePoints)
			{
				break;
			}
		}

		while (ActionPoints >= weapon.attackCost && player != null)
		{
			await Task.Delay(turnSpeed);

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
