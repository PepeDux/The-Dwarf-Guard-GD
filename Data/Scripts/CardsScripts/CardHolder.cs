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

		cards.Add(GetNode<TextureButton>("Card1"));
		cards.Add(GetNode<TextureButton>("Card2"));
		cards.Add(GetNode<TextureButton>("Card3"));
	}


	private void ShowCard()
	{
		if (cards.Count() > 0)
		{
			foreach (var card in cards)
			{
				card.Visible = true;
			}
		}
	}
}
