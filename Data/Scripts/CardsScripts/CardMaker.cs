using Godot;
using System;
using linq;
using System.Collections.Generic;
using System.Linq;

public partial class CardMaker : Button
{
	Random random = new Random();

	//Позитивная и негативная карта
	public CardData cardPositive;
	public CardData cardNegative;

	//Массив карт
	private List<CardData> cards = new list<CardData>();

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
		Events.endSelectCard += EndSelectCard;
		Pressed += ButtonPressed();

		cardNamePositive = GetNode<Label>("CardNamePositive");
		cardDescriptionPositive = GetNode<Label>("CardDescriptionPositive");

		cardNameNegative = GetNode<Label>("CardNameNegative");
		cardDescriptionNegative = GetNode<Label>("CardDescriptionNegative");


		//cards = Resources.LoadAll<CardData>("Cards");
		MakeCard();
	}


	private void MakeCard()
	{
		//Выбор позитивной карты
		cardPositive = cards.Where(c => c.type == CardData.Type.positive).OrderBy(с => Guid.NewGuid()).FirstOrDefault();
		//Выбор негативной карты
		cardNegative = cards.Where(c => c.type == CardData.Type.negative).OrderBy(с => Guid.NewGuid()).FirstOrDefault();



		cardNamePositive.text = cardPositive.name;
		cardDescriptionPositive.text = cardPositive.CardDescription;

		cardNameNegative.text = cardNegative.name;
		cardDescriptionNegative.text = cardNegative.CardDescription;
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

	private void EndSelectCard()
	{
		MakeCard();
		Visible = false;
	}
}
