using Godot;
using System;

public partial class AbilityData : Resource
{
    [Export] public Texture2D abilityImage { get; set; }

    [Export] public int actionPointsCost { get; set; }
    [Export] public int movePointsCost { get; set; }
    [Export] public int beerPointsCost { get; set; }

    public virtual void Use(Character user)
    {
        GD.Print("IIIIIII");
    }

    
}
