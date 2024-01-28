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
		MouseEntered += Entered;
		MouseExited += Exited;

		cardNamePositive = GetNode<Label>("CardNamePositive");
		cardDescriptionPositive = GetNode<Label>("CardDescriptionPositive");

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



		cardNamePositive.Text = cardPositive.name;
		cardDescriptionPositive.Text = cardPositive.cardDescription;

		cardNameNegative.Text = cardNegative.name;
		cardDescriptionNegative.Text = cardNegative.cardDescription;
	}

	private void ButtonPressed()
	{
		//Враги
		if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.enemy)
		{
			levelModifier.GetParent().GetNode<LevelModifier>("LevelModifier").enemyStatuses.Add(cardPositive.modifier as StatusData);
		}
		if (cardNegative.modifier is StatusData && cardNegative.accessory == CardData.Accessory.enemy)
		{
			levelModifier.GetParent().GetNode<LevelModifier>("LevelModifier").enemyStatuses.Add(cardNegative.modifier as StatusData);
		}

		//Игрок
		if (cardPositive.modifier is StatusData && cardPositive.accessory == CardData.Accessory.player)
		{
			levelModifier.GetParent().GetNode<LevelModifier>("LevelModifier").playerStatuses.Add(cardPositive.modifier as StatusData);
		}
		if (cardNegative.modifier is StatusData && cardNegative.accessory == CardData.Accessory.player)
		{
			levelModifier.GetParent().GetNode<LevelModifier>("LevelModifier").playerStatuses.Add(cardNegative.modifier as StatusData);
		}

		//Спавн
		if (cardPositive.modifier is SpawnData && cardPositive.accessory == CardData.Accessory.spawn)
		{
			spawner.GetParent().GetNode<SpawnCalculation>("SpawnCalculation").AddSpawn(cardPositive.modifier as SpawnData);
		}
		if (cardNegative.modifier is SpawnData && cardNegative.accessory == CardData.Accessory.spawn)
		{
			spawner.GetParent().GetNode<SpawnCalculation>("SpawnCalculation").AddSpawn(cardNegative.modifier as SpawnData);
		}



		Events.endSelectCard?.Invoke();
	}

	private void Entered()
	{
		var beam = ResourceLoader.Load("res://Data/UI/Cursors/Sprite-0002.png");
		Input.SetCustomMouseCursor(beam);

		Position = new Vector2(Position.X, Position.Y - 2);
		
	}

	private void Exited()
	{
		var arrow = ResourceLoader.Load("res://Data/UI/Cursors/Sprite-0001.png");
		Input.SetCustomMouseCursor(arrow);

		Position = new Vector2(Position.X, Position.Y + 2);
	}


	private void EndSelectCard()
	{
		MakeCard();
		Visible = false;
	}
}
