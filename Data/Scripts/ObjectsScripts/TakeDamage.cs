using Godot;
using System;

public partial class TakeDamage : Node
{
	public static Action playerDead;

	private Character target;

	//public GameObject corpse; //Труп или объект после смерти(не путать с лутом)
	//public GameObject[] lootAfterDeath; //Вещи выпадающие из обхекта после смерти



	//Скрипт TakeDamage обрабатывает типы урона поступаемые объектам
	//Он учитывает сопроивления к урону в объекте и выдает  итоге дамаг после вычислений
	//
	//
	//
	//К скрипту можно обратиться так - TakeDamage(Damage:15, Damage:43); минуя не нужные типы урона


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

		//Дрожание экрана при получении урона
		GetTree().Root.GetNode("GameScene").GetNode<CameraShake>("CameraShake").ShakeAsync(1, 1, 15, 10);
		//
		GetParent().GetNode<CpuParticles2D>("BloodParticles").Emitting = true;


		if (target.HP <= 0)
		{
			Die();
		}
		else
		{
			//Вызов анимации получения урона
			//GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("Hurt");
		}
	}


	public void Die()
	{
		GD.Print($"Я {GetParent().Name} умер");

		//Спавнит случайны лут из списка с вероятностью 50%
		//if (Random.Range(0, 100) > 50 && lootAfterDeath != null)
		//{
		//	try
		//	{
		//		GameObject loot = Instantiate(lootAfterDeath[Random.Range(0, lootAfterDeath.Length)]);
		//		loot.GetComponent<BaseObject>().coordinate = GetComponent<BaseObject>().tileMap.WorldToCell(transform.position);
		//	}
		//	catch
		//	{

		//	}
		//}



		//Instantiate(corpse, transform.position, transform.rotation);

		//GetParent().GetNode<AnimationController>("AnimationController").SetAnimation("Die");

		if (GetParent() is Player)
		{
			Events.playerDied?.Invoke();
		}

		if (GetParent() is Enemy)
		{
			if (GetParent<Enemy>().typeEnemy == Enemy.TypeEnemy.captain)
			{
				Events.levelEnded?.Invoke();
			}
		}

		//Очищаем координаты персонажа из хранилища координат 
		TileStorage.RemoveCharacter(GetParent<Character>());
		GetParent().QueueFree();
	}
}
