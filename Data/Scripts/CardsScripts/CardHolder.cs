using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class CardHolder : Node
{
	private List<Button> cards = new List<Button>();


	public override void _Ready()
	{
		Events.levelEnded += ShowCard;

		cards.Add(GetNode<Button>("Card1"));
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
