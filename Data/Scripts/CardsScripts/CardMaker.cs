using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public partial class CardMaker : TextureButton
{
	Random random = new Random();

	//Позитивная и негативная карта
	public CardData cardPositive;
	public CardData cardNegative;

	//Массив карт
	public List<CardData> cards = new List<CardData>();

	public LevelModifier levelModifier;

	[Export] private Node2D spawner;



	//Имя карты
	private Label cardNamePositive;
	private Label cardDescriptionPositive;

	//Описаник карты
	private Label cardNameNegative;
	private Label cardDescriptionNegative;



	public override void _Ready()
	{
		cards = LoadResourceFromDirectory.Load<CardData>("res://Data/Scripts/Resources/Cards/");

		Events.endSelectCard += EndSelectCard;

		Pressed += ButtonPressed;

		// Событие на вход курсора на карту
		MouseEntered += Entered;
        // Событие на выход курсора на карту
        MouseExited += Exited;

		// Позитивная карта
		cardNamePositive = GetNode<Label>("CardNamePositive");
		cardDescriptionPositive = GetNode<Label>("CardDescriptionPositive");

		// Негативная карта
		cardNameNegative = GetNode<Label>("CardNameNegative");
		cardDescriptionNegative = GetNode<Label>("CardDescriptionNegative");

		MakeCard();
	}




	private void MakeCard()
	{
		//Выбор позитивной карты
		cardPositive = cards.Where(c => c.type == CardData.Type.positive).OrderBy(с => Guid.NewGuid()).FirstOrDefault();
		//Выбор негативной карты
		cardNegative = cards.Where(c => c.type == CardData.Type.negative).OrderBy(с => Guid.NewGuid()).FirstOrDefault();



		// Задаем название и поисание позитивной карты
		cardNamePositive.Text = cardPositive.name;
		cardDescriptionPositive.Text = cardPositive.cardDescription;

        // Задаем название и поисание негативной карты
        cardNameNegative.Text = cardNegative.name;
		cardDescriptionNegative.Text = cardNegative.cardDescription;
	}

	private void ButtonPressed()
	{
		// Враги
		if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.enemy)
		{
			levelModifier.GetParent().GetNode<LevelModifier>("LevelModifier").enemyStatuses.Add(cardPositive.modifier as StatusData);
		}
		if (cardNegative.modifier is StatusData && cardNegative.accessory == CardData.Accessory.enemy)
		{
			levelModifier.GetParent().GetNode<LevelModifier>("LevelModifier").enemyStatuses.Add(cardNegative.modifier as StatusData);
		}

		// Игрок
		if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.player)
		{
			levelModifier.GetParent().GetNode<LevelModifier>("LevelModifier").playerStatuses.Add(cardPositive.modifier as StatusData);
		}
		if (cardNegative.modifier is StatusData && cardNegative.accessory == CardData.Accessory.player)
		{
			levelModifier.GetParent().GetNode<LevelModifier>("LevelModifier").playerStatuses.Add(cardNegative.modifier as StatusData);
		}

		// Спавн
		if (cardPositive.modifier is SpawnData && cardPositive.accessory == CardData.Accessory.spawn)
		{
			spawner.GetParent().GetNode<SpawnCalculation>("SpawnCalculation").AddSpawn(cardPositive.modifier as SpawnData);
		}
		if (cardNegative.modifier is SpawnData && cardNegative.accessory == CardData.Accessory.spawn)
		{
			spawner.GetParent().GetNode<SpawnCalculation>("SpawnCalculation").AddSpawn(cardNegative.modifier as SpawnData);
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
