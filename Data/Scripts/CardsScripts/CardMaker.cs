using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class CardMaker : TextureButton
{
	Random random = new Random();

	// Позитивная и негативная карта
	public CardData cardPositive;
	public CardData cardNegative;

	// Массив карт
	public List<CardData> cards = new List<CardData>();

	// Нода/класс содержащая все статусы
	public LevelModifier levelModifier;



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
		cards = LoadResourceFromDirectory.Load<CardData>("res://Data/Resources/Cards/");

		levelModifier = GetTree().Root.GetNode("GameScene").GetNode<LevelModifier>("LevelModifier");

		Events.endSelectCard += EndSelectCard;

		Pressed += ButtonPressed;

		// Событие на вход курсора на карту
		MouseEntered += Entered;
		// Событие на выход курсора на карту
		MouseExited += Exited;

		// Позитивная карта
		cardNamePositive = GetNode<Label>("CardNamePositive");
		cardDescriptionPositive = GetNode<Label>("CardDescriptionPositive");
		cardImagePositive = GetNode<TextureRect>("CardImagePositive");

		// Негативная карта
		cardNameNegative = GetNode<Label>("CardNameNegative");
		cardDescriptionNegative = GetNode<Label>("CardDescriptionNegative");
		cardImageNegative = GetNode<TextureRect>("CardImageNegative");

		MakeCard();
	}




	private void MakeCard()
	{
		// Выбор позитивной карты
		cardPositive = cards.Where(c => c.type == CardData.Type.positive).OrderBy(с => Guid.NewGuid()).FirstOrDefault();
		// Выбор негативной карты
		cardNegative = cards.Where(c => c.type == CardData.Type.negative).OrderBy(с => Guid.NewGuid()).FirstOrDefault();



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

	private void ButtonPressed()
	{
		// Враги
		if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.enemy)
		{
			levelModifier.enemyStatuses.Add(cardPositive.modifier as StatusData);
		}
		if (cardNegative.modifier is StatusData && cardNegative.accessory == CardData.Accessory.enemy)
		{
			levelModifier.enemyStatuses.Add(cardNegative.modifier as StatusData);
		}
		
		// Игрок
		if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.player)
		{
			levelModifier.playerStatuses.Add(cardPositive.modifier as StatusData);
		}
		if (cardNegative.modifier is StatusData && cardNegative.accessory == CardData.Accessory.player)
		{
			levelModifier.playerStatuses.Add(cardNegative.modifier as StatusData);
		}

		// Спавн
		if (cardPositive.modifier is SpawnData && cardPositive.accessory == CardData.Accessory.spawn)
		{
			GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo").GetNode<SpawnCalculation>("SpawnCalculation").AddSpawn(cardPositive.modifier as SpawnData);

		}
		if (cardNegative.modifier is SpawnData && cardNegative.accessory == CardData.Accessory.spawn)
		{
			GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo").GetNode<SpawnCalculation>("SpawnCalculation").AddSpawn(cardNegative.modifier as SpawnData);
			GD.Print("Модификатор карты: " + cardNegative.modifier.GetType() + " Для кого: " + cardNegative.accessory);
		}



		// Вызов события при окончании выбора карты
		Events.endSelectCard?.Invoke();
	}

	private void Entered()
	{
		// Задаем курсору вид "лапки"
		CursorStyleController.SetBeam();

		Position = new Vector2(Position.X, Position.Y - 2);	
	}

	private void Exited()
	{
		// Задаем курсору вид "стрелки"
		CursorStyleController.SetArrow();

		Position = new Vector2(Position.X, Position.Y + 2);
	}


	private void EndSelectCard()
	{
		// После выбора карты создается следующие карты на следующий уровень
		MakeCard();
		Visible = false;
	}
}
