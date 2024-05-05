using Godot;
using System;

public partial class TurnButton : BaseButton
{
	public override void _Ready()
	{
		base._Ready();

		ButtonEventSubscribing();

		Events.finishedAllTurn += Enable;
		Events.playerTurnFinished += Disable;
	}

	public override void _ExitTree()
	{
		base._ExitTree();

		Events.finishedAllTurn -= Enable;
		Events.playerTurnFinished -= Disable;
	}

	public override void ButtonPressed()
	{
		base.ButtonPressed();

		Events.playerTurnFinished?.Invoke();
	}
}
