using Godot;
using System;

public partial class CardMaker : Node
{
    Random random = new Random();

    [ExportGroup("Карты")]
    //Позитивная и негативная карта
    public CardData cardPositive;
    public CardData cardNegative;

    //Массив карт
    private CardData[] cards;

    public LevelModifier levelModifier;

    [Export] private Node2D spawner;

    //[ExportGroup("Позитивная карта")]
    //Имя карты
    //[Export] private TMP_Text cardNamePositive;
    //[Export] private TMP_Text cardDescriptionPositive;

    //[ExportGroup("Негативная карта")]
    //Описаник карты
    //[Export] private TMP_Text cardNameNegative;
    //[Export] private TMP_Text cardDescriptionNegative;



    public override void _Ready()
    {
        Events.endSelectCard += EndSelectCard;

        //cards = Resources.LoadAll<CardData>("Cards");
        MakeCard();
    }


    private void MakeCard()
    {
        while (true)
        {
            cardPositive = cards[random.Next(0, cards.Length)];
            cardNegative = cards[random.Next(0, cards.Length)];

            if (cardPositive.type == CardData.Type.positive && cardNegative.type == CardData.Type.negative)
            {
                break;
            }
        }

        try
        {
            //cardNamePositive.text = cardPositive.name;
            //cardDescriptionPositive.text = cardPositive.CardDescription;

            //cardNameNegative.text = cardNegative.name;
            //cardDescriptionNegative.text = cardNegative.CardDescription;
        }
        catch
        {

        }
    }

    private void OnClick()
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
        //this.gameObject.SetActive(false);
    }
}
