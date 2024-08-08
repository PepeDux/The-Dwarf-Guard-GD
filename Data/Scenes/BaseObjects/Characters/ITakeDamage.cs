using Godot;
using System;
using System.Threading.Tasks;

public interface ITakeDamage
{
	// Обрабатывает типы урона поступаемые объектам
	// Он учитывает сопроивления к урону в объекте и выдает  итоге дамаг после вычислений
	public async void TakeDamage
		(
		Character character,
		bool isCriticalDamage = false,
		int physicalDamage = 0
		)
	{
		int totalDamage = 0;

		// Перекрашиваем label в белый цвет
		character.GetNode<SubViewport>("SubViewport").GetNode<Label>("Label").Modulate = new Color(0.96f, 0.96f, 0.98f);

		//target.HP -= poisonDamage * (1 - target.poisonResist / 100);
		//target.HP -= fireDamage * (1 - target.fireResist / 100);
		//target.HP -= frostDamage * (1 - target.frostResist / 100);
		//target.HP -= drunkennessDamage * (1 - target.drunkennessResist / 100);

		totalDamage += physicalDamage - character.PhysicalResist;

		if (totalDamage <= 0) 
		{
			totalDamage = 1;
		}

		if (isCriticalDamage == true)
		{
			totalDamage *= 2;

			// Перекрашиваем label в красный цвет
			character.GetNode<SubViewport>("SubViewport").GetNode<Label>("Label").Modulate = new Color(1, 0, 0);
			// Дрожание экрана при получении критического урона
			CameraShake.ShakeAsync(3, 1, 20, 10);
			// Проигрываем звук получения урона при крите
			character.GetNode<AudioController>("AudioStreamPlayer").PlaySound("Hurt", 0.4f, 0.6f);
		}
		else
		{
			// Дрожание экрана при получении обычного урона
			CameraShake.ShakeAsync(1, 1, 15, 10);
			// Проигрываем звук получения урона 
			character.GetNode<AudioController>("AudioStreamPlayer").PlaySound("Hurt", 0.9f, 1.3f);
		}

		// Вызываем партиклы крови при получении урона
		character.GetNode<CpuParticles2D>("BloodParticles").Emitting = true;
		// Урон в тексте лабела партикли
		character.GetNode<SubViewport>("SubViewport").GetNode<Label>("Label").Text = totalDamage.ToString();
		// Проигрываем партиклю лабела
		character.GetNode<CpuParticles2D>("MessageParticles").Emitting = true;

		if (totalDamage > 0)
		{
			character.HP -= totalDamage;
		}

		if (character.HP <= 0)
		{
			Die(character);
		}
		else
		{
			// Вызов анимации получения урона
			character.GetNode<AnimationController>("AnimationController").PlayAnimation("TakeDamage");
		}
	}

	async void Die(Character character)
	{
		// Массив лута
		PackedScene[] loot = character.loot;

		// Спавнит случайны лут из списка с вероятностью 50 %
		if (new Random().Next(0, 100) > 50 && loot.Length > 0)
		{
			try
			{
				character.GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<FunctionalObjectSpawner>("FunctioanalObjectsHolder").Spawn(loot, character.Coordinate);
			}
			catch
			{

			}
		}

		// Вызываем анимацию смерти
		character.GetNode<AnimationController>("AnimationController").PlayAnimation("Die");

		// Очищаем координаты персонажа из хранилища координат 
		TileStorage.RemoveCell(character.Coordinate);
		// Очищаем персонажа с хранилища персонажей
		CharacterStorage.characters.Remove(character);

		if (character is Player)
		{
			Events.playerDied?.Invoke();

			await Task.Delay(1500);
			// Вызывает экран GAME OVER
			character.GetTree().ChangeSceneToFile("res://Data/Scenes/GameOver/GameOver.tscn");
		}
		else if (character is Captain)
		{
			await Task.Delay(1500);
			// Заканчиваем левел при смерти капитана
			Events.levelEnded?.Invoke();
		}
		else
		{
			await Task.Delay(1500);
		}

		// Удаляем объект со сцены
		character.Free();
	}
}
