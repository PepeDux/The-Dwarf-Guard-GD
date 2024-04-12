using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class CardHolder : Node
{
	private List<TextureButton> cards = new List<TextureButton>();


	public override void _Ready()
	{
		Events.levelEnded += ShowCard;

		// Добавляем все карты в лист
		cards.AddRange(GetChildren().OfType<TextureButton>());
	}

	public override void _ExitTree()
	{
		Events.levelEnded -= ShowCard;
	}


	private void ShowCard()
	{
		// Делаем карты видимыми
		if (cards.Count() > 0)
		{
			foreach (var card in cards)
			{
				card.Visible = true;
			}
		}
	}
}
