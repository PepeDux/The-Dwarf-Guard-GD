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
	public ModifierData cardPositive;
	public ModifierData cardNegative;

	// Массив модификаторов
	public List<ModifierData> modifiers = new List<ModifierData>();

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
		// Событие на окончанеи выбора карты
		Events.endSelectCard += EndSelectCard;

		// Событие на нажатие
		Pressed += ButtonPressed;

		// Событие на вход курсора на карту
		MouseEntered += Entered;
		// Событие на выход курсора на карту
		MouseExited += Exited;

	   

		// Загружаем все карточки
		modifiers.AddRange(LoadResourceFromDirectory.Load("res://Data/Resources/CharacteristicStatuses/"));
		//modifiers.AddRange(LoadResourceFromDirectory.Load("res://Data/Resources/SpawnStatuses/"));
		//modifiers.AddRange(LoadResourceFromDirectory.Load("res://Data/Resources/OperationStatuses/"));

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



	private void MakeCard()
	{
		// Выбор позитивной карты
		cardPositive = modifiers.Where(c => c.type == ModifierData.Type.positive).OrderBy(с => Guid.NewGuid()).FirstOrDefault();
		// Выбор негативной карты исхояд из силы позитимвной карты в диапазоне -1 - +1
		cardNegative =
			modifiers.Where(c => c.type == ModifierData.Type.negative &&
			(c.cardStrength == cardPositive.cardStrength ||
			c.cardStrength == cardPositive.cardStrength - 1 ||
			c.cardStrength == cardPositive.cardStrength + 1))
			.OrderBy(с => Guid.NewGuid()).FirstOrDefault();



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
		if (cardPositive is StatusModifierData && cardPositive.accessory == ModifierData.Accessory.enemy)
		{
			levelModifier.enemyStatuses.Add(cardPositive as StatusModifierData);
		}
		if (cardNegative is StatusModifierData && cardNegative.accessory == ModifierData.Accessory.enemy)
		{
			levelModifier.enemyStatuses.Add(cardNegative as StatusModifierData);
		}
		
		// Игрок
		if (cardPositive is StatusModifierData && cardPositive.accessory == ModifierData.Accessory.player)
		{
			levelModifier.playerStatuses.Add(cardPositive as StatusModifierData);
		}
		if (cardNegative is StatusModifierData && cardNegative.accessory == ModifierData.Accessory.player)
		{
			levelModifier.playerStatuses.Add(cardNegative as StatusModifierData);
		}

		// Спавн
		if (cardPositive is SpawnModifierData && cardPositive.accessory == ModifierData.Accessory.spawn)
		{
			GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo").GetNode<SpawnCalculation>("SpawnCalculation").AddSpawn(cardPositive as SpawnModifierData);

		}
		if (cardNegative is SpawnModifierData && cardNegative.accessory == ModifierData.Accessory.spawn)
		{
			GetTree().Root.GetNode("GameScene").GetNode<LevelInfo>("LevelInfo").GetNode<SpawnCalculation>("SpawnCalculation").AddSpawn(cardNegative as SpawnModifierData);
			GD.Print("Модификатор карты: " + cardNegative.GetType() + " Для кого: " + cardNegative.accessory);
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
