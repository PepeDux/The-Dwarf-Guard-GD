using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public partial class Enemy : Character
{
	//[Header("Тип противника")]
	public TypeEnemy typeEnemy;
	public enum TypeEnemy { captain, melee, range, wizard };

	private bool isFacingRight = true;

	//[Header("Игрок")]
	public Player player;



	public override void _Process(double delta)
	{
		Updater();
		Orientation();
	}

	public override void _Ready()
	{
		Starter();

		//Подписываемся на события
		Events.levelEnded += Destroy;
		Events.playerTurnFinished += Turn;
		Events.playerTurnFinished += Show;

		player = GetTree().Root.GetNode("GameScene").GetNode<PlayerSpawner>("PlayerHolder").GetNode<Player>("Player");
	}



	void Orientation()
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
				MovePoints -= moveCost;

				TileStorage.AddCharacter(this);
			}
		}
	}

	public async void Turn()
	{
		while (MovePoints >= moveCost)
		{
			await Task.Delay(1000);
			//tileManager.TileGameObjectUpdatePosition();

			int startPoints = MovePoints;

			EnemyMove();

			if (startPoints == MovePoints)
			{
				break;
			}
		}

		while (ActionPoints >= meleeAttackCost || ActionPoints >= rangeAttackCost && player != null)
		{
			int startPoints = ActionPoints;

			//GetComponent<AttackScript>().CalculationAttack(player.GetComponent<MainObject>());

			if (startPoints == ActionPoints)
			{
				break;
			}
		}
	}
}
