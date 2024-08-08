using Godot;
using System;

public partial class RerollCardsButton : BaseButton
{
    public override void _Ready()
    {
        base._Ready();

        Events.endSelectCard += Enable;
    }
    public override void _ExitTree()
    {
        base._ExitTree();

        Events.endSelectCard -= Enable;
    }
    public override void Pressed()
    {
        base.Pressed();

		Events.rerolledCards?.Invoke();

		Disable();
    }
}