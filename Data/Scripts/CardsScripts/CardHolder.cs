using Godot;
using System;
using System.Collections.Generic;

public partial class CardHolder : Node
{
	[Export] Node2D[] cards;


	public override void _Ready()
	{
		Events.levelEnded += ShowCard;
	}


	private void ShowCard()
	{
		if (cards.Length > 0)
		{
			foreach (var card in cards)
			{
				card.Visible = true;
			}
		}
	}
}
