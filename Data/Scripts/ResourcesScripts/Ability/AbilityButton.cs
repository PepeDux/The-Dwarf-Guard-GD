using Godot;
using System;
using System.Linq;

public partial class AbilityButton : BaseButton
{
    [Export] public AbilityData ability;

    public override void Pressed()
    {
        base.Pressed();

        if (ability != null) 
        {
            // Передаем на кнопку игрока в качестве юсера
            // Надо обдумать этот моментик позднее :3
            ability.Use(GetTree().Root.GetNode("GameScene").GetNode("Holders").GetNode<PlayerSpawner>("PlayerHolder").GetChildren().OfType<Player>().FirstOrDefault());
        }
    }
}