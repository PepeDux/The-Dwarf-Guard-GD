using Godot;
using System;

public partial class SecondBreath : AbilityData
{
    public override void Use(Character user)
    {
        if (CanUse(user))
        {
            user.BeerPoints -= beerPointsCost;
            user.ActionPoints -= actionPointsCost;
            user.MovePoints -= movePointsCost;

            user.HP += DiceRoll.Roll(8, 1);
        }
    }
}
