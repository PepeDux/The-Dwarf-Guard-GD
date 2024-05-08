using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class CardHolder : Node
{
	private List<TextureButton> cardFaces = new List<TextureButton>();

	// Массив модификаторов
	[Export] public CardData[] cards;

	public override void _Ready()
	{
		Events.levelEnded += ShowCard;

		// Добавляем все карты в лист
		cardFaces.AddRange(GetChildren().OfType<TextureButton>());
	}

	public override void _ExitTree()
	{
		Events.levelEnded -= ShowCard;
	}


	private void ShowCard()
	{
		// Делаем карты видимыми
		if (cardFaces.Count() > 0)
		{
			foreach (var cardFace in cardFaces)
			{
				cardFace.Visible = true;
			}
		}
	}
}
