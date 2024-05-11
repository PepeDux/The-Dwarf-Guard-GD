using Godot;
using System;

public partial class DropCardsButton : BaseButton
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

        Events.dropedCards?.Invoke();

        Disable();
    }
}
