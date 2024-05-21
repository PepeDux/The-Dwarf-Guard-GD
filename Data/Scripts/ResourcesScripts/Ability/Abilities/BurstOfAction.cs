using Godot;
using System;

public partial class BurstOfAction : AbilityData
{
	public override void Use(Character user)
	{
		if (CanUse(user)) 
		{
			user.BeerPoints -= beerPointsCost;
			user.ActionPoints -= actionPointsCost;
			user.MovePoints -= movePointsCost;

			user.ActionPoints += 2;			
		}
	}
}
