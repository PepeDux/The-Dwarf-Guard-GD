using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public partial class Enemy : Character
{
	private bool isFacingRight = true;

	public Player player;



	public override void _Process(double delta)
	{
		Updater();
		Orientation();

		GetPlayer();
	}

	public override void _Ready()
	{
		//Подписываемся на события
		Events.playerSpawned += GetPlayer;
		Events.playerTurnFinished += UpdatePoints;

		Starter();

		GD.Print(coordinate);
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
		List<Vector2I> pathToTarget = GetNode<EnemyTileManager>("EnemyTileManager").pathToTarget;

		if (MovePoints >= moveCost && player != null)
		{
			pathToTarget.Clear();
			pathToTarget = GetNode<EnemyTileManager>("EnemyTileManager").GetPath(player.coordinate);

			if (pathToTarget.Count > 1)
			{
				TileStorage.RemoveCharacter(this);

				pathToTarget.RemoveAt(0);
				coordinate = pathToTarget[pathToTarget.Count - 1];
				UpdateCoordinate();
				GetNode<CharacterAudioController>("CharacterAudioController").PlaySound("Move", 0.8f, 1f);
				MovePoints -= moveCost;

				TileStorage.AddCharacter(this);
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
