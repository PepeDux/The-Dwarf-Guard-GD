using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class CardHolder : Node2D
{
	private List<TextureButton> cardFaces = new List<TextureButton>();

	public override void _Ready()
	{
		Events.levelEnded += ShowCard;
		Events.endSelectCard += HideCard;
		Events.dropedCards += HideCard;

		// Добавляем все карты в лист
		cardFaces.AddRange(GetChildren().OfType<TextureButton>());
	}

	public override void _ExitTree()
	{
		Events.levelEnded -= ShowCard;
		Events.endSelectCard -= HideCard;
		Events.dropedCards -= HideCard;
	}


	private void ShowCard()
	{
		this.Visible = true;
	}

	private void HideCard()
	{
		this.Visible = false;
	}
}
