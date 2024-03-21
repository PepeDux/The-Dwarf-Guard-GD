using Godot;
using System;
using System.Threading.Tasks;

public partial class TakeDamage : Node
{
	public static Action playerDead;

	private Random random = new Random();

	private Character target;

	//public GameObject corpse; //Труп или объект после смерти(не путать с лутом)

	// Скрипт TakeDamage обрабатывает типы урона поступаемые объектам
	// Он учитывает сопроивления к урону в объекте и выдает  итоге дамаг после вычислений
	//
	//
	//
	// К скрипту можно обратиться так - TakeDamage(Damage:15, Damage:43); минуя не нужные типы урона


	public override void _Ready()
	{
		target = GetParent<Character>();
	}

	public void Take
		(
		int physicalDamage = 0,
		int poisonDamage = 0,
		int fireDamage = 0,
		int frostDamage = 0,
		int drunkennessDamage = 0
		)
	{
		Random random = new Random();

		int totalDamage = 0;

		//target.HP -= poisonDamage * (1 - target.poisonResist / 100);
		//target.HP -= fireDamage * (1 - target.fireResist / 100);
		//target.HP -= frostDamage * (1 - target.frostResist / 100);
		//target.HP -= drunkennessDamage * (1 - target.drunkennessResist / 100);

		totalDamage += physicalDamage - target.physicalResist;

		if (totalDamage > 0)
		{
			target.HP -= totalDamage;
		}

		// Дрожание экрана при получении урона
		GetTree().Root.GetNode("GameScene").GetNode<CameraShake>("CameraShake").ShakeAsync(1, 1, 15, 10);
		// Вызываем партиклы крови при получении урона
		GetParent().GetNode<CpuParticles2D>("BloodParticles").Emitting = true;


		if (target.HP <= 0)
		{
			Die();
		}
		else
		{
			// Вызов анимации получения урона
			GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("TakeDamage");
		}
	}


	public async void Die()
	{
		GD.Print($"Я {GetParent().Name} умер");

		PackedScene[] loot = GetParent<Character>().loot;

		//Спавнит случайны лут из списка с вероятностью 50 %
		if (random.Next(0, 100) > 50 && loot.Length > 0)
		{
			try
			{
				GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<FunctionalObjectSpawner>("FunctioanalObjectsHolder").Spawn(loot, GetParent<Character>().coordinate);
			}
			catch
			{

			}
		}



		GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("Die");

		// Очищаем координаты персонажа из хранилища координат 
		TileStorage.RemoveCharacter(GetParent<Character>());

		await Task.Delay(1500);

		if (GetParent() is Player)
		{
			Events.playerDied?.Invoke();
		}

		if (GetParent() is Captain)
		{
			Events.levelEnded?.Invoke();
		}

		GetParent().QueueFree();
	}
}