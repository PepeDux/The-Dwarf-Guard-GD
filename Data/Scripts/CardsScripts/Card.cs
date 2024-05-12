using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class Card : BaseButton
{
	Random random = new Random();

	// Позитивная и негативная карта
	public CardData cardPositive;
	public CardData cardNegative;

	
	// Нода/класс содержащая все модификаторы
	public LevelModifier levelModifier;

	// Массив модификаторов
	[Export] public CardData[] cards;

	// Имя карты
	private Label cardNamePositive;
	private Label cardDescriptionPositive;

	// Описаник карты
	private Label cardNameNegative;
	private Label cardDescriptionNegative;

	// Изображение карты 
	private TextureRect cardImagePositive;
	private TextureRect cardImageNegative;


	public override void _Ready()
	{
		Events.endSelectCard += MakeCard;
		Events.rerolledCards += MakeCard;

		// Получаем LevelModifier
		levelModifier = GetTree().Root.GetNode("GameScene").GetNode<LevelModifier>("LevelModifier");
		
		// Ноды позитивной карты
		cardNamePositive = GetNode<Label>("CardNamePositive");
		cardDescriptionPositive = GetNode<Label>("CardDescriptionPositive");
		cardImagePositive = GetNode<TextureRect>("CardImagePositive");

		// Ноды негативной карта
		cardNameNegative = GetNode<Label>("CardNameNegative");
		cardDescriptionNegative = GetNode<Label>("CardDescriptionNegative");
		cardImageNegative = GetNode<TextureRect>("CardImageNegative");

		MakeCard();
	}

	public override void _ExitTree()
	{
		Events.endSelectCard -= MakeCard;
		Events.rerolledCards -= MakeCard;
	}



	private void MakeCard()
	{
		FindCards();

		// Задаем название позитивной карты
		cardNamePositive.Text = cardPositive.name;
		cardDescriptionPositive.Text = cardPositive.cardDescription;

		// Задаем поисание негативной карты
		cardNameNegative.Text = cardNegative.name;
		cardDescriptionNegative.Text = cardNegative.cardDescription;

		// Задаем изображение карты
		cardImagePositive.Texture = cardPositive.texture;
		cardImageNegative.Texture = cardNegative.texture;
	}

	private void FindCards()
	{
		// Выбор позитивной карты
		cardPositive = cards.Where(c => c.type == CardData.Type.positive).OrderBy(с => Guid.NewGuid()).FirstOrDefault();
		// Выбор негативной карты исхояд из силы позитимвной карты в диапазоне -1 - +1
		cardNegative =
			cards.Where(c => c.type == CardData.Type.negative &&
			(c.cardStrength == cardPositive.cardStrength ||
			c.cardStrength == cardPositive.cardStrength - 1 ||
			c.cardStrength == cardPositive.cardStrength + 1))
			.OrderBy(с => Guid.NewGuid()).FirstOrDefault();
			
		if (cardNegative == null)
		{
			cardNegative = cards.Where(c => c.type == CardData.Type.negative).OrderBy(с => Guid.NewGuid()).FirstOrDefault();
		}
	}

	public override void Pressed()
	{
		base.Pressed();

		AddModifier();

		// Вызов события при окончании выбора карты
		Events.endSelectCard?.Invoke();
	}

	// Добавляет модификаторы к LevelModifier
	private void AddModifier()
	{

		// Враги
		if (cardPositive.modifier is CharacteristicModifierData && cardPositive.accessory == CardData.Accessory.enemy)
		{
			levelModifier.enemyModifiers.Add(cardPositive.modifier as CharacteristicModifierData);
		}
		if (cardNegative.modifier is CharacteristicModifierData && cardNegative.accessory == CardData.Accessory.enemy)
		{
			levelModifier.enemyModifiers.Add(cardNegative.modifier as CharacteristicModifierData);
		}

		// Игрок
		if (cardPositive.modifier is CharacteristicModifierData && cardPositive.accessory == CardData.Accessory.player)
		{
			levelModifier.playerModifiers.Add(cardPositive.modifier as CharacteristicModifierData);
		}
		if (cardNegative.modifier is CharacteristicModifierData && cardNegative.accessory == CardData.Accessory.player)
		{
			levelModifier.playerModifiers.Add(cardNegative.modifier as CharacteristicModifierData);
		}

		// Спавн
		if (cardPositive.modifier is SpawnModifierData && cardPositive.accessory == CardData.Accessory.spawn)
		{
			GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo").GetNode<SpawnModifierCalculation>("SpawnModifierCalculation").AddSpawn(cardPositive.modifier as SpawnModifierData);
		}
		if (cardNegative.modifier is SpawnModifierData && cardNegative.accessory == CardData.Accessory.spawn)
		{
			GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo").GetNode<SpawnModifierCalculation>("SpawnModifierCalculation").AddSpawn(cardNegative.modifier as SpawnModifierData);
		}
	}
}
